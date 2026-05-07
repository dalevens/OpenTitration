import sys
import os
import pytest
import numpy as np

sys.path.insert(0, os.path.join(os.path.dirname(__file__), ".."))

from app.services.data_parser import parse_titration_data
from app.services.derivatives import compute_derivatives
from app.services.equivalence import find_equivalence_automatic
from app.services.acid_identifier import identify_unknown
from app.services.concentration import return_concentration
from app.services.molar_mass import calculate_molar_mass

EXAMPLE_DIR = os.path.join(os.path.dirname(__file__), "..", "..", "Example Titration Data")


def test_parse_monoprotic():
    with open(os.path.join(EXAMPLE_DIR, "Monoprotic Acid.txt")) as f:
        content = f.read()
    result = parse_titration_data(content)
    assert len(result.volumes) > 0
    assert len(result.ph_values) > 0
    assert len(result.volumes) == len(result.ph_values)


def test_parse_diprotic():
    with open(os.path.join(EXAMPLE_DIR, "Diprotic Acid.csv")) as f:
        content = f.read()
    result = parse_titration_data(content)
    assert len(result.volumes) > 0


def test_derivatives():
    volumes = np.array([1.0, 2.0, 3.0, 4.0, 5.0])
    ph = np.array([3.0, 3.5, 7.0, 10.5, 11.0])
    result = compute_derivatives(volumes, ph)
    assert len(result.first_derivative) == 4
    assert len(result.second_derivative) == 3
    assert result.first_derivative[2] > result.first_derivative[0]


def test_equivalence_automatic():
    volumes = np.array([1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0])
    ph = np.array([3.0, 3.2, 3.5, 4.0, 5.5, 9.0, 10.0, 10.5, 10.8, 11.0])
    deriv = compute_derivatives(volumes, ph)
    result = find_equivalence_automatic(
        volumes, ph,
        deriv.first_derivative, deriv.second_derivative,
        deriv.avg_volumes_first, deriv.avg_volumes_second,
        num_protons=1, is_base=False,
    )
    assert len(result.equivalence_points) == 1
    assert 3.0 < result.equivalence_points[0] < 7.0


def test_acid_identifier():
    match = identify_unknown([4.76], protonation=1, is_base=False)
    assert match is not None
    assert match.name == "Acetic"
    assert match.percent_error < 5.0


def test_concentration():
    c = return_concentration(14.5, 0.1, "1:1", 25.0, 1.0)
    assert abs(c - 0.058) < 0.001


def test_molar_mass():
    assert abs(calculate_molar_mass("NaOH") - 39.997) < 0.01
    assert abs(calculate_molar_mass("HCl") - 36.461) < 0.01


def test_full_pipeline():
    with open(os.path.join(EXAMPLE_DIR, "Monoprotic Acid.txt")) as f:
        content = f.read()
    parsed = parse_titration_data(content)
    deriv = compute_derivatives(parsed.volumes, parsed.ph_values)
    result = find_equivalence_automatic(
        parsed.volumes, parsed.ph_values,
        deriv.first_derivative, deriv.second_derivative,
        deriv.avg_volumes_first, deriv.avg_volumes_second,
        num_protons=1, is_base=False,
    )
    assert len(result.equivalence_points) == 1
    assert len(result.pka_values) == 1
    assert result.pka_values[0] > 0
