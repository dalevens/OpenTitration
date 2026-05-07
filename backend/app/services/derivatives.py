from dataclasses import dataclass
import numpy as np


@dataclass(frozen=True)
class DerivativeResult:
    first_derivative: np.ndarray
    second_derivative: np.ndarray
    avg_volumes_first: np.ndarray
    avg_volumes_second: np.ndarray


def first_derivative(volumes: np.ndarray, ph: np.ndarray) -> tuple[np.ndarray, np.ndarray]:
    dv = np.diff(volumes)
    dph = np.diff(ph)
    avg_volumes = (volumes[:-1] + volumes[1:]) / 2
    deriv = dph / dv
    return avg_volumes, deriv


def second_derivative(avg_volumes: np.ndarray, first_deriv: np.ndarray) -> tuple[np.ndarray, np.ndarray]:
    dv = np.diff(avg_volumes)
    dd = np.diff(first_deriv)
    avg_volumes_2 = (avg_volumes[:-1] + avg_volumes[1:]) / 2
    deriv2 = dd / dv
    return avg_volumes_2, deriv2


def normalize(values: np.ndarray, norm_factor: float) -> np.ndarray:
    vmin = np.min(values)
    vmax = np.max(values)
    if vmax == vmin:
        return np.zeros_like(values)
    return ((values - vmin) / (vmax - vmin)) * norm_factor


def normalize_with_offset(values: np.ndarray, norm_factor: float, offset: float) -> np.ndarray:
    return normalize(values, norm_factor) + offset


def compute_derivatives(volumes: np.ndarray, ph: np.ndarray) -> DerivativeResult:
    avg_v1, d1 = first_derivative(volumes, ph)
    avg_v2, d2 = second_derivative(avg_v1, d1)
    return DerivativeResult(
        first_derivative=d1,
        second_derivative=d2,
        avg_volumes_first=avg_v1,
        avg_volumes_second=avg_v2,
    )
