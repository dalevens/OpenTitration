import { useState, useCallback } from 'react';

interface ConcentrationFormProps {
  titrantConcentration: string;
  onConcentrationChange: (value: string) => void;
  titrantMass: string;
  onMassChange: (value: string) => void;
  titrantVolume: string;
  onVolumeChange: (value: string) => void;
  molarRatio: string;
  onMolarRatioChange: (value: string) => void;
  analyteVolume: number;
  onAnalyteVolumeChange: (value: number) => void;
  dilutionFactor: number;
  onDilutionFactorChange: (value: number) => void;
}

export default function ConcentrationForm({
  titrantConcentration,
  onConcentrationChange,
  titrantMass,
  onMassChange,
  titrantVolume,
  onVolumeChange,
  molarRatio,
  onMolarRatioChange,
  analyteVolume,
  onAnalyteVolumeChange,
  dilutionFactor,
  onDilutionFactorChange,
}: ConcentrationFormProps) {
  const [knownConcentration, setKnownConcentration] = useState(true);

  const handleKnownToggle = useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      setKnownConcentration(e.target.checked);
    },
    [],
  );

  return (
    <div style={styles.card}>
      <label style={styles.sectionLabel}>Concentration</label>

      <label style={styles.checkboxRow}>
        <input
          type="checkbox"
          checked={knownConcentration}
          onChange={handleKnownToggle}
        />
        <span style={styles.checkboxLabel}>Known titrant concentration</span>
      </label>

      {knownConcentration ? (
        <div style={styles.field}>
          <label style={styles.label} htmlFor="titrant-conc">
            Concentration (mol/L)
          </label>
          <input
            id="titrant-conc"
            type="number"
            value={titrantConcentration}
            onChange={e => onConcentrationChange(e.target.value)}
            placeholder="0.1"
            step="any"
            style={styles.input}
          />
        </div>
      ) : (
        <>
          <div style={styles.field}>
            <label style={styles.label} htmlFor="titrant-mass">
              Mass (g)
            </label>
            <input
              id="titrant-mass"
              type="number"
              value={titrantMass}
              onChange={e => onMassChange(e.target.value)}
              placeholder="4.0"
              step="any"
              style={styles.input}
            />
          </div>
          <div style={styles.field}>
            <label style={styles.label} htmlFor="titrant-vol">
              Volume (L)
            </label>
            <input
              id="titrant-vol"
              type="number"
              value={titrantVolume}
              onChange={e => onVolumeChange(e.target.value)}
              placeholder="1.0"
              step="any"
              style={styles.input}
            />
          </div>
        </>
      )}

      <div style={styles.divider} />

      <div style={styles.field}>
        <label style={styles.label} htmlFor="molar-ratio">
          Molar Ratio
        </label>
        <input
          id="molar-ratio"
          type="text"
          value={molarRatio}
          onChange={e => onMolarRatioChange(e.target.value)}
          placeholder="1:1"
          style={styles.input}
        />
      </div>

      <div style={styles.field}>
        <label style={styles.label} htmlFor="analyte-vol">
          Analyte Volume (mL)
        </label>
        <input
          id="analyte-vol"
          type="number"
          value={analyteVolume}
          onChange={e => onAnalyteVolumeChange(Number(e.target.value))}
          placeholder="25"
          step="any"
          style={styles.input}
        />
      </div>

      <div style={styles.field}>
        <label style={styles.label} htmlFor="dilution-factor">
          Dilution Factor
        </label>
        <input
          id="dilution-factor"
          type="number"
          value={dilutionFactor}
          onChange={e => onDilutionFactorChange(Number(e.target.value))}
          placeholder="1"
          step="any"
          min={1}
          style={styles.input}
        />
      </div>
    </div>
  );
}

const colors = {
  border: '#d1d5db',
  cardBg: '#ffffff',
  text: '#1a1a2e',
  textMuted: '#6b7280',
  inputBg: '#f9fafb',
  inputBorder: '#d1d5db',
  divider: '#e5e7eb',
};

const styles: Record<string, React.CSSProperties> = {
  card: {
    backgroundColor: colors.cardBg,
    borderRadius: 8,
    border: `1px solid ${colors.border}`,
    padding: 16,
  },
  sectionLabel: {
    display: 'block',
    fontSize: 13,
    fontWeight: 600,
    marginBottom: 12,
    color: colors.text,
    textTransform: 'uppercase' as const,
    letterSpacing: '0.5px',
  },
  label: {
    display: 'block',
    fontSize: 12,
    fontWeight: 500,
    marginBottom: 4,
    color: colors.textMuted,
  },
  field: {
    marginBottom: 8,
  },
  input: {
    width: '100%',
    boxSizing: 'border-box' as const,
    padding: '8px 12px',
    fontSize: 14,
    border: `1px solid ${colors.inputBorder}`,
    borderRadius: 6,
    backgroundColor: colors.inputBg,
    color: colors.text,
  },
  checkboxRow: {
    display: 'flex',
    alignItems: 'center',
    gap: 8,
    marginBottom: 12,
    cursor: 'pointer',
  },
  checkboxLabel: {
    fontSize: 13,
    color: colors.text,
  },
  divider: {
    height: 1,
    backgroundColor: colors.divider,
    margin: '12px 0',
  },
};
