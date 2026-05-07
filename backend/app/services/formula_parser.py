"""Chemical formula string parsing utilities.

Port of SplitString.cs - splits chemical formulas into element symbols
and numeric multipliers using regex patterns.
"""

from __future__ import annotations

import re

_CAPITAL_LETTERS_PATTERN = re.compile(r"(?<!^)(?=[A-Z])")
_DIGIT_SPLIT_PATTERN = re.compile(r"(\d+)")
_LETTERS_ONLY_PATTERN = re.compile(r"^[a-zA-Z]+$")


def split_capital_letters(formula: str) -> list[str]:
    """Split a chemical formula at capital letter boundaries.

    Each capital letter starts a new element token. The regex uses a
    positive lookahead so the capital letter is retained at the start
    of the next token rather than consumed as a delimiter.

    Examples:
        "H2SO4" -> ["H2", "S", "O4"]
        "NaOH"  -> ["Na", "O", "H"]
        "Na"    -> ["Na"]
    """
    parts = _CAPITAL_LETTERS_PATTERN.split(formula)
    return [p for p in parts if p]


def split_numbers_from_letters(token: str) -> list[str]:
    """Split numeric digits from alphabetic characters in a token.

    Capturing parentheses in the regex ensure the digit groups are
    retained in the output.  Empty strings produced by the split are
    filtered out.

    Examples:
        "H2"  -> ["H", "2"]
        "O4"  -> ["O", "4"]
        "Fe"  -> ["Fe"]
    """
    parts = _DIGIT_SPLIT_PATTERN.split(token)
    return [p for p in parts if p]


def is_letters_only(source: str) -> bool:
    """Return True if *source* contains only alphabetic characters.

    Examples:
        "Fe"  -> True
        "H2"  -> False
        ""    -> False
    """
    if not source:
        return False
    return bool(_LETTERS_ONLY_PATTERN.match(source))
