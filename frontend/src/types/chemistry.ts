export interface MolarMassResponse {
  formula: string;
  molar_mass: number;
}

export interface AcidEntry {
  name: string;
  formula: string;
  pka: string;
}

export interface AcidLookupResponse {
  matches: AcidEntry[];
  single: boolean;
}
