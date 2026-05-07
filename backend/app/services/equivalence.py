from dataclasses import dataclass
import numpy as np


@dataclass(frozen=True)
class EquivalenceResult:
    equivalence_points: list[float]
    equivalence_ph: list[float]
    pka_volumes: list[float]
    pka_values: list[float]


def linear_interpolate(volumes: np.ndarray, ph: np.ndarray, target_volume: float) -> float:
    for i in range(1, len(volumes)):
        if volumes[i] == target_volume:
            return float(ph[i])
        if volumes[i] > target_volume:
            x1, y1 = volumes[i - 1], ph[i - 1]
            x2, y2 = volumes[i], ph[i]
            return float(y1 + (target_volume - x1) * ((y2 - y1) / (x2 - x1)))
    return float(ph[-1])


def _get_equivalence_from_second_deriv(second_deriv: np.ndarray, avg_volumes: np.ndarray) -> float:
    min_idx = int(np.argmin(second_deriv))
    max_idx = int(np.argmax(second_deriv))
    y2 = second_deriv[min_idx]
    y1 = second_deriv[max_idx]
    x2 = avg_volumes[min_idx]
    x1 = avg_volumes[max_idx]
    if x2 == x1:
        return float(x1)
    slope = (y2 - y1) / (x2 - x1)
    return float(((x1 * slope) - y1) / slope)


def find_equivalence_automatic(
    volumes: np.ndarray,
    ph: np.ndarray,
    first_deriv: np.ndarray,
    second_deriv: np.ndarray,
    avg_volumes_first: np.ndarray,
    avg_volumes_second: np.ndarray,
    num_protons: int,
    is_base: bool,
    iteration_setting: int = 2,
    parse_cutoff: float | None = None,
) -> EquivalenceResult:
    work_deriv = np.copy(first_deriv)
    work_second = np.copy(second_deriv)
    work_avg = np.copy(avg_volumes_first)

    if parse_cutoff is not None:
        skip = int(np.searchsorted(volumes, parse_cutoff))
        if skip > 0:
            work_deriv = work_deriv[skip:]
            work_second = np.copy(second_deriv)
            work_second_trimmed = work_second[skip:] if len(work_second) > skip else work_second
            work_avg = work_avg[skip:]
            work_second = work_second_trimmed

    equivalence_points: list[float] = []
    equivalence_ph: list[float] = []

    for _ in range(num_protons):
        if is_base:
            peak_val = np.min(work_deriv)
        else:
            peak_val = np.max(work_deriv)

        peak_idx = int(np.argmax(work_deriv == peak_val))

        equiv_vol = _get_equivalence_from_second_deriv(work_second, work_avg[: len(work_second)])
        if equiv_vol <= 0 or np.isnan(equiv_vol) or np.isinf(equiv_vol):
            equiv_vol = float(work_avg[peak_idx])

        equiv_ph = linear_interpolate(volumes, ph, equiv_vol)

        equivalence_points.append(equiv_vol)
        equivalence_ph.append(round(equiv_ph, 4))

        begin = max(0, peak_idx - iteration_setting)
        end = min(len(work_deriv), peak_idx + iteration_setting + 1)
        work_deriv[begin:end] = 0
        work_second[begin:end] = 0

    equivalence_points.sort()

    pka_volumes = _compute_pka_volumes(equivalence_points, num_protons)
    pka_values = [round(linear_interpolate(volumes, ph, pv), 4) for pv in pka_volumes]

    if is_base:
        equivalence_ph.sort(reverse=True)
        pka_values.sort(reverse=True)
    else:
        equivalence_ph.sort()
        pka_values.sort()

    return EquivalenceResult(
        equivalence_points=equivalence_points,
        equivalence_ph=equivalence_ph,
        pka_volumes=pka_volumes,
        pka_values=pka_values,
    )


def find_equivalence_manual(
    volumes: np.ndarray,
    ph: np.ndarray,
    second_deriv: np.ndarray,
    avg_volumes_second: np.ndarray,
    num_protons: int,
    is_base: bool,
    range_type: str,
    range_one: float,
    range_two: float | None = None,
) -> EquivalenceResult:
    if range_type.lower() == "volume":
        ref_values = volumes
    else:
        ref_values = ph

    slices: list[tuple[np.ndarray, np.ndarray]] = []

    if num_protons == 1:
        slices.append((second_deriv, avg_volumes_second))
    elif num_protons == 2:
        idx1 = int(np.searchsorted(ref_values[: len(second_deriv) + 1], range_one))
        s1_d = second_deriv[:idx1]
        s1_v = avg_volumes_second[:idx1]
        s2_d = second_deriv[idx1:]
        s2_v = avg_volumes_second[idx1:]
        slices.append((s1_d, s1_v))
        slices.append((s2_d, s2_v))
    elif num_protons == 3:
        idx1 = int(np.searchsorted(ref_values[: len(second_deriv) + 1], range_one))
        idx2 = int(np.searchsorted(ref_values[: len(second_deriv) + 1], range_two))
        slices.append((second_deriv[:idx1], avg_volumes_second[:idx1]))
        slices.append((second_deriv[idx1:idx2], avg_volumes_second[idx1:idx2]))
        slices.append((second_deriv[idx2:], avg_volumes_second[idx2:]))

    equivalence_points: list[float] = []
    equivalence_ph: list[float] = []

    for sd, av in slices:
        if len(sd) == 0:
            equivalence_points.append(0.0)
            equivalence_ph.append(0.0)
            continue
        if np.min(sd) == np.max(sd):
            equivalence_points.append(0.0)
            equivalence_ph.append(0.0)
            continue
        equiv = _get_equivalence_from_second_deriv(sd, av)
        equivalence_points.append(equiv)
        equivalence_ph.append(round(linear_interpolate(volumes, ph, equiv), 4))

    pka_volumes = _compute_pka_volumes(equivalence_points, num_protons)
    pka_values = [round(linear_interpolate(volumes, ph, pv), 4) for pv in pka_volumes]

    if is_base:
        equivalence_ph.sort(reverse=True)
        pka_values.sort(reverse=True)
    else:
        equivalence_ph.sort()
        pka_values.sort()

    return EquivalenceResult(
        equivalence_points=equivalence_points,
        equivalence_ph=equivalence_ph,
        pka_volumes=pka_volumes,
        pka_values=pka_values,
    )


def _compute_pka_volumes(equivalence_points: list[float], num_protons: int) -> list[float]:
    if num_protons == 0:
        return []
    pka_vols = [equivalence_points[0] / 2]
    if num_protons == 2:
        pka_vols.append(equivalence_points[0] + (equivalence_points[1] - equivalence_points[0]) / 2)
    elif num_protons == 3:
        pka_vols.append(equivalence_points[0] + (equivalence_points[1] - equivalence_points[0]) / 2)
        pka_vols.append(equivalence_points[1] + (equivalence_points[2] - equivalence_points[1]) / 2)
    return pka_vols
