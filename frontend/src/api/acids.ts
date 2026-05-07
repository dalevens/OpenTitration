import client from './client';

export async function listAcids(protonation: number, isBase: boolean): Promise<string[]> {
  const response = await client.get<{ acids: string[] }>('/acids/list', {
    params: { protonation, is_base: isBase },
  });
  return response.data.acids;
}
