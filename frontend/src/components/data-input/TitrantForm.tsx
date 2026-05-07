import { useCallback } from 'react';

interface TitrantFormProps {
  formula: string;
  onFormulaChange: (formula: string) => void;
  molarMass: number;
  acidName: string;
}

export default function TitrantForm({
  formula,
  onFormulaChange,
  molarMass,
  acidName,
}: TitrantFormProps) {
  const handleChange = useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      onFormulaChange(e.target.value);
    },
    [onFormulaChange],
  );

  return (
    <div style={styles.card}>
      <label style={styles.label} htmlFor="titrant-formula">
        Titrant Formula
      </label>
      <input
        id="titrant-formula"
        type="text"
        value={formula}
        onChange={handleChange}
        placeholder="e.g. NaOH"
        style={styles.input}
      />
      {molarMass > 0 && (
        <div style={styles.detail}>
          Molar mass: <strong>{molarMass.toFixed(2)} g/mol</strong>
        </div>
      )}
      {acidName && (
        <div style={styles.detail}>
          Matched: <strong>{acidName}</strong>
        </div>
      )}
    </div>
  );
}

const colors = {
  border: '#d1d5db',
  cardBg: '#ffffff',
  text: '#1a1a2e',
  textMuted: '#6b7280',
  accent: '#0d7377',
  inputBg: '#f9fafb',
  inputBorder: '#d1d5db',
  inputFocusBorder: '#0d7377',
};

const styles: Record<string, React.CSSProperties> = {
  card: {
    backgroundColor: colors.cardBg,
    borderRadius: 8,
    border: `1px solid ${colors.border}`,
    padding: 16,
  },
  label: {
    display: 'block',
    fontSize: 13,
    fontWeight: 600,
    marginBottom: 8,
    color: colors.text,
    textTransform: 'uppercase' as const,
    letterSpacing: '0.5px',
  },
  input: {
    width: '100%',
    boxSizing: 'border-box' as const,
    padding: '8px 12px',
    fontSize: 14,
    border: `1px solid ${colors.inputBorder}`,
    borderRadius: 6,
    backgroundColor: colors.inputBg,
    outline: 'none',
    color: colors.text,
  },
  detail: {
    marginTop: 8,
    fontSize: 13,
    color: colors.textMuted,
  },
};
