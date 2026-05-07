from dataclasses import dataclass

from app.data.unknown_acid_database import UNKNOWN_ACID_DATABASE


@dataclass(frozen=True)
class AcidMatch:
    name: str
    percent_error: float
    database_pka: str


def identify_unknown(experimental_pka: list[float], protonation: int, is_base: bool) -> AcidMatch | None:
    if protonation not in UNKNOWN_ACID_DATABASE:
        return None
    base_map = UNKNOWN_ACID_DATABASE[protonation]
    if is_base not in base_map:
        return None

    database = base_map[is_base]
    if not database:
        return None

    sorted_experimental = sorted(experimental_pka)

    if protonation == 1:
        return _match_monoprotic(sorted_experimental, database)
    elif protonation == 2:
        return _match_diprotic(sorted_experimental, database)
    elif protonation == 3:
        return _match_triprotic(sorted_experimental, database)

    return None


def _match_monoprotic(experimental: list[float], database: dict[str, str]) -> AcidMatch:
    closest_name = ""
    closest_diff = 14.0
    closest_pka = ""
    exp_val = experimental[0]

    for name, pka_str in database.items():
        db_val = float(pka_str)
        diff = abs(db_val - exp_val)
        if diff < closest_diff:
            closest_diff = diff
            closest_name = name
            closest_pka = pka_str

    percent_error = round((closest_diff / exp_val) * 100, 1) if exp_val != 0 else 0.0
    return AcidMatch(name=closest_name, percent_error=percent_error, database_pka=closest_pka)


def _match_diprotic(experimental: list[float], database: dict[str, str]) -> AcidMatch:
    closest_name = ""
    closest_diff = float("inf")
    closest_pka = ""
    first_diff = 0.0
    second_diff = 0.0
    first_equiv = 0.0
    second_equiv = 0.0

    for name, pka_str in database.items():
        entries = sorted([float(v.strip()) for v in pka_str.split(",")])
        total = abs(entries[0] - experimental[0]) + abs(entries[1] - experimental[1])
        if total < closest_diff:
            closest_diff = total
            closest_name = name
            closest_pka = pka_str
            first_diff = abs(entries[0] - experimental[0])
            second_diff = abs(entries[1] - experimental[1])
            first_equiv = entries[0]
            second_equiv = entries[1]

    percent_error = round(((first_diff / first_equiv) + (second_diff / second_equiv)) / 2 * 100, 1) if first_equiv != 0 and second_equiv != 0 else 0.0
    return AcidMatch(name=closest_name, percent_error=percent_error, database_pka=closest_pka)


def _match_triprotic(experimental: list[float], database: dict[str, str]) -> AcidMatch:
    closest_name = ""
    closest_diff = float("inf")
    closest_pka = ""
    first_diff = 0.0
    second_diff = 0.0
    third_diff = 0.0
    first_equiv = 0.0
    second_equiv = 0.0
    third_equiv = 0.0

    for name, pka_str in database.items():
        entries = pka_str.split(",")
        first_db = float(entries[0])
        second_db = float(entries[1])

        third_options: list[float] = []
        if "/" in entries[2]:
            third_options = [float(v.strip()) for v in entries[2].split("/")]
        else:
            third_options = [float(entries[2])]

        for third_db in third_options:
            total = abs(first_db - experimental[0]) + abs(second_db - experimental[1]) + abs(third_db - experimental[2])
            if total < closest_diff:
                closest_diff = total
                closest_name = name
                closest_pka = pka_str
                first_diff = abs(first_db - experimental[0])
                second_diff = abs(second_db - experimental[1])
                third_diff = abs(third_db - experimental[2])
                first_equiv = first_db
                second_equiv = second_db
                third_equiv = third_db

    denom = 0
    count = 0
    if first_equiv != 0:
        denom += first_diff / first_equiv
        count += 1
    if second_equiv != 0:
        denom += second_diff / second_equiv
        count += 1
    if third_equiv != 0:
        denom += third_diff / third_equiv
        count += 1

    percent_error = round((denom / count) * 100, 1) if count > 0 else 0.0
    return AcidMatch(name=closest_name, percent_error=percent_error, database_pka=closest_pka)


def get_known_pka(name: str, protonation: int, is_base: bool) -> str | None:
    if protonation not in UNKNOWN_ACID_DATABASE:
        return None
    base_map = UNKNOWN_ACID_DATABASE[protonation]
    if is_base not in base_map:
        return None
    database = base_map[is_base]
    if name not in database:
        return None
    pka_str = database[name]
    if "/" in pka_str:
        entries = pka_str.split(",")
        last = entries[-1]
        if "/" in last:
            entries[-1] = last.split("/")[0]
        return ",".join(entries)
    return pka_str


def list_acids(protonation: int, is_base: bool) -> list[str]:
    if protonation not in UNKNOWN_ACID_DATABASE:
        return []
    base_map = UNKNOWN_ACID_DATABASE[protonation]
    if is_base not in base_map:
        return []
    return list(base_map[is_base].keys())


def pkb_to_pka(pkb: float) -> float:
    return 14.0 - pkb
