from pydantic import BaseModel


class DataPoint(BaseModel):
    volume: float
    ph: float


class DerivativePoint(BaseModel):
    volume: float
    value: float
    normalized: float


class EquivalencePoint(BaseModel):
    index: int
    volume: float
    ph: float


class AcidIdentification(BaseModel):
    name: str
    percent_error: float
    database_pka: str


class ConcentrationResult(BaseModel):
    titrant_concentration: float
    analyte_concentrations: list[float]


class AnalysisResponse(BaseModel):
    titration_data: list[DataPoint]
    first_derivative: list[DerivativePoint]
    second_derivative: list[DerivativePoint]
    equivalence_points: list[EquivalencePoint]
    pka_values: list[float]
    pka_volumes: list[float]
    acid_identification: AcidIdentification | None = None
    concentration: ConcentrationResult | None = None
    molar_mass: float
    max_volume: float
    max_ph: float
    is_data_acid: bool
    warnings: list[str] = []


class AnalysisRequest(BaseModel):
    titrant_formula: str = ""
    protonation_state: int = 1
    is_base: bool = False
    is_known_analyte: bool = False
    known_analyte_name: str | None = None
    molar_ratio: str = "1:1"
    analyte_volume: float = 25.0
    dilution_factor: float = 1.0
    titrant_concentration: float | None = None
    titrant_mass: float | None = None
    titrant_volume: float | None = None
    solve_method: str = "automatic"
    range_type: str = "volume"
    range_one: float | None = None
    range_two: float | None = None
    norm_y1: int = 6
    norm_y2: int = 4
    offset_y2: int = 2


class ExportRequest(BaseModel):
    analysis: AnalysisResponse
    format: str = "csv"
    titrant_info: dict = {}
    analyte_info: dict = {}
