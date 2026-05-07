import client from './client';
import type { AnalysisResponse } from '../types/titration';

export async function analyzeTitration(formData: FormData): Promise<AnalysisResponse> {
  const response = await client.post<AnalysisResponse>('/titration/analyze', formData, {
    headers: { 'Content-Type': 'multipart/form-data' },
  });
  return response.data;
}

export async function exportResults(analysis: AnalysisResponse, format: string): Promise<string> {
  const response = await client.post<{ data: string }>('/titration/export', {
    analysis,
    format,
  });
  return response.data.data;
}
