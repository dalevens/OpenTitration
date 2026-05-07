"""Titration concentration calculations.

Port of concentration.cs.  Provides pure functions for computing
analyte concentration, titrant concentration, and molar ratio parsing.
"""

from __future__ import annotations


def return_concentration(
    equivalence_vol: float,
    titrant_conc: float,
    molar_ratio_str: str,
    analyte_vol: float,
    dilution_factor: float,
) -> float:
    """Calculate analyte concentration from the equivalence point.

    Args:
        equivalence_vol: Volume at the equivalence point (mL).
        titrant_conc: Concentration of the titrant (mol/L).
        molar_ratio_str: Molar ratio as a string, e.g. ``"1:2"``.
        analyte_vol: Volume of the analyte (mL).
        dilution_factor: Multiplicative dilution factor.

    Returns:
        The analyte concentration in mol/L.

    Raises:
        ValueError: If *molar_ratio_str* is not in ``"a:b"`` format
            or *analyte_vol* is zero.

    Examples:
        >>> return_concentration(25.0, 0.1, "1:1", 50.0, 1.0)
        0.05
    """
    if analyte_vol == 0:
        raise ValueError("Analyte volume must be non-zero.")
    ratio = parse_molar_ratio(molar_ratio_str)
    return (equivalence_vol * titrant_conc * ratio / analyte_vol) * dilution_factor


def titrant_concentration(molar_mass: float, mass: float, volume_ml: float) -> float:
    """Calculate titrant concentration from solid mass and solution volume.

    Args:
        molar_mass: Molar mass of the titrant compound (g/mol).
        mass: Mass of titrant weighed out (g).
        volume_ml: Solution volume (mL).

    Returns:
        The titrant concentration in mol/L.

    Raises:
        ValueError: If *molar_mass* or *volume_ml* is zero.

    Examples:
        >>> round(titrant_concentration(58.44, 5.844, 1000.0), 4)
        0.1
    """
    if molar_mass == 0:
        raise ValueError("Molar mass must be non-zero.")
    if volume_ml == 0:
        raise ValueError("Volume must be non-zero.")
    return (mass / molar_mass) / (volume_ml / 1000.0)


def parse_molar_ratio(molar_ratio_str: str) -> float:
    """Parse a molar ratio string into a numeric multiplier.

    The ratio string is expected in ``"a:b"`` format where ``a`` is
    the titrant coefficient and ``b`` is the analyte coefficient.
    The returned value is ``b / a``.

    Args:
        molar_ratio_str: Ratio string, e.g. ``"1:2"``.

    Returns:
        The numeric ratio (analyte over titrant coefficient).

    Raises:
        ValueError: If the string cannot be parsed or the first
            coefficient is zero.

    Examples:
        >>> parse_molar_ratio("1:2")
        2.0
        >>> parse_molar_ratio("2:1")
        0.5
    """
    parts = molar_ratio_str.split(":")
    if len(parts) != 2:
        raise ValueError(
            f"Molar ratio must be in 'a:b' format, got '{molar_ratio_str}'"
        )
    denominator = float(parts[0])
    if denominator == 0:
        raise ValueError("First coefficient in molar ratio must be non-zero.")
    return float(parts[1]) / denominator
