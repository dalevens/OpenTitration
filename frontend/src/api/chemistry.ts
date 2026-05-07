import client from './client';
import type { MolarMassResponse, AcidLookupResponse } from '../types/chemistry';

export async function getMolarMass(formula: string): Promise<MolarMassResponse> {
  const response = await client.get<MolarMassResponse>('/chemistry/molar-mass', {
    params: { formula },
  });
  return response.data;
}

export async function lookupAcid(formula: string): Promise<AcidLookupResponse> {
  const response = await client.get<AcidLookupResponse>('/chemistry/acid-lookup', {
    params: { formula },
  });
  return response.data;
}
