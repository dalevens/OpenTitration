"""Molar mass calculation from chemical formula strings.

Port of molarcalc.cs FindMolarMass().  Uses the formula parser to
decompose a formula into element symbols and multipliers, then sums
atomic weights to produce the total molar mass.
"""

from __future__ import annotations

from app.data.atomic_weights import ATOMIC_WEIGHTS
from app.services.formula_parser import split_capital_letters
from app.services.formula_parser import split_numbers_from_letters


def calculate_molar_mass(formula: str) -> float:
    """Calculate the molar mass (g/mol) of a chemical *formula*.

    The formula is split at capital-letter boundaries into element
    tokens.  Each token is further separated into its element symbol
    and optional numeric multiplier (defaulting to 1).  The result is
    the sum of ``atomic_weight * multiplier`` for every element.

    Args:
        formula: A chemical formula string, e.g. ``"H2SO4"`` or ``"NaOH"``.

    Returns:
        The total molar mass in grams per mole.

    Raises:
        ValueError: If an element symbol in *formula* is not found in
            the atomic weights table.

    Examples:
        >>> calculate_molar_mass("H2O")
        18.0152
        >>> calculate_molar_mass("NaOH")
        39.9967
    """
    tokens = split_capital_letters(formula)
    total_mass = 0.0

    for token in tokens:
        parts = split_numbers_from_letters(token)
        element_symbol = parts[0]

        if element_symbol not in ATOMIC_WEIGHTS:
            raise ValueError(
                f"Unknown element symbol: '{element_symbol}' "
                f"(parsed from formula '{formula}')"
            )

        multiplier = float(parts[1]) if len(parts) > 1 else 1.0
        total_mass += ATOMIC_WEIGHTS[element_symbol] * multiplier

    return total_mass
