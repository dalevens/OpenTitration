from fastapi import APIRouter

from app.models.chemistry import AcidEntry
from app.data.acid_database import ACID_DATABASE
from app.services.acid_identifier import list_acids

router = APIRouter(prefix="/api/acids", tags=["acids"])


@router.get("/list")
def list_known_acids(protonation: int = 1, is_base: bool = False) -> dict:
    names = list_acids(protonation, is_base)
    return {"acids": names}


@router.get("/search")
def search_acids(name: str = "", formula: str = "") -> dict:
    results = ACID_DATABASE
    if name:
        results = [a for a in results if name.lower() in a["name"].lower()]
    if formula:
        results = [a for a in results if formula.lower() == a["formula"].lower()]
    return {"acids": [AcidEntry(name=a["name"], formula=a["formula"], pka=a["pka"]) for a in results]}
