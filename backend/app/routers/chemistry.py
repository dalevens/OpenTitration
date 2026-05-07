from fastapi import APIRouter, HTTPException

from app.models.chemistry import AcidEntry, AcidLookupResponse, MolarMassResponse
from app.services.molar_mass import calculate_molar_mass
from app.data.acid_database import ACID_DATABASE

router = APIRouter(prefix="/api/chemistry", tags=["chemistry"])


@router.get("/molar-mass")
def get_molar_mass(formula: str) -> MolarMassResponse:
    try:
        mass = calculate_molar_mass(formula)
    except ValueError as e:
        raise HTTPException(status_code=422, detail=str(e))
    return MolarMassResponse(formula=formula, molar_mass=round(mass, 4))


@router.get("/acid-lookup")
def lookup_acid(formula: str) -> AcidLookupResponse:
    matches = [
        AcidEntry(name=a["name"], formula=a["formula"], pka=a["pka"])
        for a in ACID_DATABASE
        if a["formula"] == formula
    ]
    return AcidLookupResponse(matches=matches, single=len(matches) == 1)
