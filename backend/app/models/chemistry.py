from pydantic import BaseModel


class MolarMassResponse(BaseModel):
    formula: str
    molar_mass: float


class AcidEntry(BaseModel):
    name: str
    formula: str
    pka: str


class AcidLookupResponse(BaseModel):
    matches: list[AcidEntry]
    single: bool
