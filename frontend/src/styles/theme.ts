import type { CSSProperties } from 'react';

export const colors = {
  primary: '#0d7377',
  primaryDark: '#095456',
  accent: '#14a3a8',
  text: '#1a1a2e',
  textMuted: '#6b7280',
  bg: '#f8fafb',
  cardBg: '#ffffff',
  border: '#d1d5db',
  error: '#dc2626',
  errorBg: '#fef2f2',
  inputBg: '#f9fafb',
  inputBorder: '#d1d5db',
  divider: '#e5e7eb',
  headerBg: '#f1f5f9',
  warningBg: '#fffbeb',
  warningBorder: '#f59e0b',
  warningText: '#92400e',
};

export const cardStyle: CSSProperties = {
  backgroundColor: colors.cardBg,
  borderRadius: 8,
  border: `1px solid ${colors.border}`,
  padding: 16,
};

export const sectionLabelStyle: CSSProperties = {
  display: 'block',
  fontSize: 13,
  fontWeight: 600,
  marginBottom: 12,
  color: colors.text,
  textTransform: 'uppercase',
  letterSpacing: '0.5px',
};

export const inputStyle: CSSProperties = {
  width: '100%',
  boxSizing: 'border-box',
  padding: '8px 12px',
  fontSize: 14,
  border: `1px solid ${colors.inputBorder}`,
  borderRadius: 6,
  backgroundColor: colors.inputBg,
  color: colors.text,
  outline: 'none',
};

export const labelStyle: CSSProperties = {
  display: 'block',
  fontSize: 12,
  fontWeight: 500,
  marginBottom: 4,
  color: colors.textMuted,
};
