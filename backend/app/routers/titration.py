import numpy as np
from fastapi import APIRouter, UploadFile, File, Form, HTTPException
from typing import Optional

from app.models.titration import (
    AnalysisResponse,
    DataPoint,
    DerivativePoint,
    EquivalencePoint,
    AcidIdentification,
    ConcentrationResult,
)
from app.services.data_parser import parse_titration_data
from app.services.derivatives import compute_derivatives, normalize, normalize_with_offset
from app.services.equivalence import find_equivalence_automatic, find_equivalence_manual
from app.services.acid_identifier import identify_unknown, get_known_pka
from app.services.concentration import return_concentration, titrant_concentration
from app.services.molar_mass import calculate_molar_mass

router = APIRouter(prefix="/api/titration", tags=["titration"])


@router.post("/analyze")
async def analyze(
    file: UploadFile = File(...),
    titrant_formula: str = Form(""),
    protonation_state: int = Form(1),
    is_base: bool = Form(False),
    is_known_analyte: bool = Form(False),
    known_analyte_name: Optional[str] = Form(None),
    molar_ratio: str = Form("1:1"),
    analyte_volume: float = Form(25.0),
    dilution_factor: float = Form(1.0),
    titrant_concentration_val: Optional[float] = Form(None, alias="titrant_concentration"),
    titrant_mass: Optional[float] = Form(None),
    titrant_volume: Optional[float] = Form(None),
    solve_method: str = Form("automatic"),
    range_type: str = Form("volume"),
    range_one: Optional[float] = Form(None),
    range_two: Optional[float] = Form(None),
    norm_y1: int = Form(6),
    norm_y2: int = Form(4),
    offset_y2: int = Form(2),
    iteration_setting: int = Form(2),
) -> AnalysisResponse:
    warnings: list[str] = []

    content = (await file.read()).decode("utf-8")
    parsed = parse_titration_data(content)
    volumes = parsed.volumes
    ph = parsed.ph_values
    warnings.extend(parsed.warnings)

    if parsed.is_swapped:
        warnings.append("PH and Volume columns were automatically swapped")

    is_data_acid = not (ph[0] > ph[-1])

    mol_mass = 0.0
    if titrant_formula:
        try:
            mol_mass = calculate_molar_mass(titrant_formula)
        except ValueError as e:
            warnings.append(f"Could not calculate molar mass: {e}")

    deriv_result = compute_derivatives(volumes, ph)

    norm_d1 = normalize(deriv_result.first_derivative, norm_y1)
    norm_d2 = normalize_with_offset(deriv_result.second_derivative, norm_y2, offset_y2)

    try:
        if solve_method == "automatic":
            equiv_result = find_equivalence_automatic(
                volumes=volumes,
                ph=ph,
                first_deriv=deriv_result.first_derivative,
                second_deriv=deriv_result.second_derivative,
                avg_volumes_first=deriv_result.avg_volumes_first,
                avg_volumes_second=deriv_result.avg_volumes_second,
                num_protons=protonation_state,
                is_base=is_base,
                iteration_setting=iteration_setting,
            )
        else:
            equiv_result = find_equivalence_manual(
                volumes=volumes,
                ph=ph,
                second_deriv=deriv_result.second_derivative,
                avg_volumes_second=deriv_result.avg_volumes_second,
                num_protons=protonation_state,
                is_base=is_base,
                range_type=range_type,
                range_one=range_one or 0,
                range_two=range_two,
            )
    except Exception as e:
        raise HTTPException(status_code=422, detail=f"Analysis failed: {str(e)}")

    acid_id = None
    if not is_known_analyte:
        match = identify_unknown(equiv_result.pka_values, protonation_state, is_base)
        if match:
            acid_id = AcidIdentification(
                name=match.name,
                percent_error=match.percent_error,
                database_pka=match.database_pka,
            )

    conc_result = None
    try:
        if titrant_concentration_val is not None:
            tit_conc = titrant_concentration_val
        elif titrant_mass is not None and titrant_volume is not None and mol_mass > 0:
            tit_conc = titrant_concentration(mol_mass, titrant_mass, titrant_volume)
        else:
            tit_conc = 0.0

        analyte_concs = []
        for ep in equiv_result.equivalence_points:
            c = return_concentration(ep, tit_conc, molar_ratio, analyte_volume, dilution_factor)
            analyte_concs.append(round(c, 6))

        conc_result = ConcentrationResult(
            titrant_concentration=round(tit_conc, 6),
            analyte_concentrations=analyte_concs,
        )
    except Exception:
        pass

    titration_data = [DataPoint(volume=float(v), ph=float(p)) for v, p in zip(volumes, ph)]
    first_deriv_pts = [
        DerivativePoint(volume=float(v), value=float(d), normalized=float(n))
        for v, d, n in zip(deriv_result.avg_volumes_first, deriv_result.first_derivative, norm_d1)
    ]
    second_deriv_pts = [
        DerivativePoint(volume=float(v), value=float(d), normalized=float(n))
        for v, d, n in zip(deriv_result.avg_volumes_second, deriv_result.second_derivative, norm_d2)
    ]
    equiv_pts = [
        EquivalencePoint(index=i + 1, volume=round(ep, 4), ph=round(equiv_result.equivalence_ph[i], 4))
        for i, ep in enumerate(equiv_result.equivalence_points)
    ]

    return AnalysisResponse(
        titration_data=titration_data,
        first_derivative=first_deriv_pts,
        second_derivative=second_deriv_pts,
        equivalence_points=equiv_pts,
        pka_values=equiv_result.pka_values,
        pka_volumes=equiv_result.pka_volumes,
        acid_identification=acid_id,
        concentration=conc_result,
        molar_mass=round(mol_mass, 4),
        max_volume=float(volumes[-1]),
        max_ph=float(ph[-1]),
        is_data_acid=is_data_acid,
        warnings=warnings,
    )


@router.post("/export")
async def export_results(request: dict) -> dict:
    fmt = request.get("format", "csv")
    analysis = request.get("analysis", {})
    if fmt == "csv":
        lines = ["Volume(mL),PH,Y',Y''"]
        for i, dp in enumerate(analysis.get("titration_data", [])):
            d1 = ""
            d2 = ""
            deriv1 = analysis.get("first_derivative", [])
            deriv2 = analysis.get("second_derivative", [])
            if i < len(deriv1):
                d1 = str(deriv1[i].get("value", ""))
            if i < len(deriv2):
                d2 = str(deriv2[i].get("value", ""))
            lines.append(f"{dp['volume']},{dp['ph']},{d1},{d2}")
        return {"format": "csv", "data": "\n".join(lines)}
    return {"format": fmt, "data": "export not yet implemented for this format"}
