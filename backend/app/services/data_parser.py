"""Titration data parsing and assessment.

Port of adddata.cs data-import logic.  Parses CSV/TXT content
containing volume-pH data pairs and detects swapped columns.
"""

from __future__ import annotations

from dataclasses import dataclass

import numpy as np

from app.services.formula_parser import is_letters_only

_PH_SWAP_THRESHOLD = 15.0


@dataclass(frozen=True)
class ParsedData:
    """Immutable result of parsing raw titration data."""

    volumes: np.ndarray
    ph_values: np.ndarray
    is_swapped: bool
    warnings: list[str]


def _split_line(line: str) -> list[str] | None:
    """Split a single data line by comma, tab, or whitespace.

    Returns None when the line does not contain exactly two columns.
    """
    for sep in (",", "\t"):
        parts = line.split(sep)
        if len(parts) == 2:
            return [p.strip() for p in parts]

    parts = line.split()
    if len(parts) == 2:
        return parts

    return None


def parse_titration_data(content: str) -> ParsedData:
    """Parse raw CSV/TXT titration data into volume and pH arrays.

    Each line should contain one data point with two numeric values
    separated by a comma, tab, or whitespace.  Header lines composed
    entirely of letters are skipped automatically.

    If the first column appears to contain pH values (average above 15),
    the columns are swapped and *is_swapped* is set to True.

    Args:
        content: Raw file content with one data point per line.

    Returns:
        A ``ParsedData`` instance with separated volume and pH arrays.

    Raises:
        ValueError: If no valid data points are found or a value cannot
            be parsed as a float.
    """
    lines = content.strip().split("\n")
    first_values: list[float] = []
    second_values: list[float] = []
    warnings: list[str] = []

    for line in lines:
        line = line.strip()
        if not line:
            continue

        parts = _split_line(line)

        if parts is None:
            if any(is_letters_only(p) for p in line.split()):
                continue  # skip header lines
            raise ValueError(
                f"Line does not contain exactly two columns: '{line}'"
            )

        if is_letters_only(parts[0]) or is_letters_only(parts[1]):
            continue  # skip header lines with labels

        try:
            col_a = float(parts[0])
            col_b = float(parts[1])
        except (ValueError, TypeError) as exc:
            raise ValueError(
                f"Non-numeric value on line: '{line}'"
            ) from exc

        first_values.append(col_a)
        second_values.append(col_b)

    if not first_values:
        raise ValueError("No valid data points found in input.")

    is_swapped = False
    avg_first = sum(first_values) / len(first_values)
    if avg_first > _PH_SWAP_THRESHOLD:
        volumes = np.array(second_values, dtype=float)
        ph_values = np.array(first_values, dtype=float)
        is_swapped = True
        warnings.append(
            "Columns were swapped: first column values appeared to be pH."
        )
    else:
        volumes = np.array(first_values, dtype=float)
        ph_values = np.array(second_values, dtype=float)

    return ParsedData(
        volumes=volumes,
        ph_values=ph_values,
        is_swapped=is_swapped,
        warnings=warnings,
    )


def assess_data(volumes: np.ndarray, ph_values: np.ndarray) -> bool:
    """Determine whether titration data represents a base analyte.

    Compares the first and last pH readings.  A decreasing pH trend
    indicates the analyte is a base (being neutralised by an acidic
    titrant).

    Args:
        volumes: Array of volume values (unused but kept for API
            consistency with the original C# signature).
        ph_values: Array of pH values in measurement order.

    Returns:
        True if the data appears to be a base (pH decreasing), False
        for an acid (pH increasing).

    Raises:
        ValueError: If *ph_values* has fewer than two entries.
    """
    if len(ph_values) < 2:
        raise ValueError("Need at least two pH readings to assess data.")
    return bool(ph_values[0] > ph_values[-1])
