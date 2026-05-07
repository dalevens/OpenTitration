import type { CSSProperties } from 'react';

const c = {
  primary: '#0d7377',
  text: '#1a1a2e',
  textMuted: '#6b7280',
  bg: '#f8fafb',
  cardBg: '#ffffff',
  border: '#d1d5db',
  error: '#dc2626',
  errorBg: '#fef2f2',
};

export const styles: Record<string, CSSProperties> = {
  container: {
    minHeight: '100vh',
    backgroundColor: c.bg,
    color: c.text,
    fontFamily:
      '-apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif',
  },
  header: {
    backgroundColor: c.primary,
    color: '#fff',
    padding: '16px 24px',
    textAlign: 'center',
  },
  title: {
    margin: 0,
    fontSize: 24,
    fontWeight: 700,
  },
  subtitle: {
    margin: '4px 0 0',
    fontSize: 14,
    opacity: 0.85,
  },
  layout: {
    display: 'flex',
    gap: 24,
    padding: 24,
    maxWidth: 1400,
    margin: '0 auto',
  },
  leftColumn: {
    flex: '0 0 380px',
    display: 'flex',
    flexDirection: 'column',
    gap: 16,
  },
  rightColumn: {
    flex: 1,
    minWidth: 0,
    display: 'flex',
    flexDirection: 'column',
    gap: 16,
  },
  analyzeButton: {
    backgroundColor: c.primary,
    color: '#fff',
    border: 'none',
    borderRadius: 6,
    padding: '12px 24px',
    fontSize: 16,
    fontWeight: 600,
    width: '100%',
    transition: 'background-color 0.2s',
  },
  error: {
    backgroundColor: c.errorBg,
    color: c.error,
    padding: 12,
    borderRadius: 6,
    fontSize: 14,
    border: `1px solid ${c.error}`,
  },
  placeholder: {
    backgroundColor: c.cardBg,
    borderRadius: 8,
    border: `1px solid ${c.border}`,
    padding: 48,
    textAlign: 'center',
    color: c.textMuted,
    fontSize: 16,
  },
};
