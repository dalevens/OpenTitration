export interface DataPoint {
  volume: number;
  ph: number;
}

export interface DerivativePoint {
  volume: number;
  value: number;
  normalized: number;
}

export interface EquivalencePoint {
  index: number;
  volume: number;
  ph: number;
}

export interface AcidIdentification {
  name: string;
  percent_error: number;
  database_pka: string;
}

export interface ConcentrationResult {
  titrant_concentration: number;
  analyte_concentrations: number[];
}

export interface AnalysisResponse {
  titration_data: DataPoint[];
  first_derivative: DerivativePoint[];
  second_derivative: DerivativePoint[];
  equivalence_points: EquivalencePoint[];
  pka_values: number[];
  pka_volumes: number[];
  acid_identification: AcidIdentification | null;
  concentration: ConcentrationResult | null;
  molar_mass: number;
  max_volume: number;
  max_ph: number;
  is_data_acid: boolean;
  warnings: string[];
}

export interface AnalysisFormState {
  titrant_formula: string;
  protonation_state: number;
  is_base: boolean;
  is_known_analyte: boolean;
  known_analyte_name: string;
  molar_ratio: string;
  analyte_volume: number;
  dilution_factor: number;
  titrant_concentration: string;
  titrant_mass: string;
  titrant_volume: string;
  solve_method: 'automatic' | 'manual_range';
  range_type: 'volume' | 'ph';
  range_one: string;
  range_two: string;
  norm_y1: number;
  norm_y2: number;
  offset_y2: number;
}
