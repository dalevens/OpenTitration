import { useCallback } from 'react';
import { cardStyle, sectionLabelStyle, inputStyle, labelStyle, colors } from '../../styles/theme';

interface AnalysisConfigProps {
  protonationState: number;
  onProtonationChange: (value: number) => void;
  isBase: boolean;
  onIsBaseChange: (value: boolean) => void;
  isKnownAnalyte: boolean;
  onIsKnownChange: (value: boolean) => void;
  knownAnalyteName: string;
  onKnownNameChange: (value: string) => void;
  solveMethod: 'automatic' | 'manual_range';
  onSolveMethodChange: (value: 'automatic' | 'manual_range') => void;
  rangeType: 'volume' | 'ph';
  onRangeTypeChange: (value: 'volume' | 'ph') => void;
  rangeOne: string;
  onRangeOneChange: (value: string) => void;
  rangeTwo: string;
  onRangeTwoChange: (value: string) => void;
}

export default function AnalysisConfig({
  protonationState,
  onProtonationChange,
  isBase,
  onIsBaseChange,
  isKnownAnalyte,
  onIsKnownChange,
  knownAnalyteName,
  onKnownNameChange,
  solveMethod,
  onSolveMethodChange,
  rangeType,
  onRangeTypeChange,
  rangeOne,
  onRangeOneChange,
  rangeTwo,
  onRangeTwoChange,
}: AnalysisConfigProps) {
  const handleProtonation = useCallback(
    (e: React.ChangeEvent<HTMLSelectElement>) => {
      onProtonationChange(Number(e.target.value));
    },
    [onProtonationChange],
  );

  const handleSolveMethod = useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      onSolveMethodChange(e.target.value as 'automatic' | 'manual_range');
    },
    [onSolveMethodChange],
  );

  return (
    <div style={cardStyle}>
      <label style={sectionLabelStyle}>Analysis Configuration</label>

      <div style={styles.row}>
        <div style={styles.field}>
          <label style={labelStyle} htmlFor="protonation">Protonation State</label>
          <select id="protonation" value={protonationState} onChange={handleProtonation} style={styles.select}>
            <option value={1}>Monoprotic (1)</option>
            <option value={2}>Diprotic (2)</option>
            <option value={3}>Triprotic (3)</option>
          </select>
        </div>
      </div>

      <div style={styles.row}>
        <ToggleSwitch label="Analyte Type" leftLabel="Acid" rightLabel="Base" checked={isBase} onChange={onIsBaseChange} />
      </div>

      <div style={styles.row}>
        <ToggleSwitch label="Analyte" leftLabel="Known" rightLabel="Unknown" checked={!isKnownAnalyte} onChange={v => onIsKnownChange(!v)} />
      </div>

      {!isKnownAnalyte && (
        <div style={styles.field}>
          <label style={labelStyle} htmlFor="known-name">Analyte Name</label>
          <input id="known-name" type="text" value={knownAnalyteName} onChange={e => onKnownNameChange(e.target.value)} placeholder="e.g. HCl" style={inputStyle} />
        </div>
      )}

      <div style={styles.divider} />

      <label style={labelStyle}>Solve Method</label>
      <div style={styles.radioGroup}>
        <label style={styles.radioLabel}>
          <input type="radio" name="solve-method" value="automatic" checked={solveMethod === 'automatic'} onChange={handleSolveMethod} />
          Automatic
        </label>
        <label style={styles.radioLabel}>
          <input type="radio" name="solve-method" value="manual_range" checked={solveMethod === 'manual_range'} onChange={handleSolveMethod} />
          Manual Range
        </label>
      </div>

      {solveMethod === 'manual_range' && (
        <div style={styles.manualRange}>
          <div style={styles.row}>
            <label style={styles.radioLabel}>
              <input type="radio" name="range-type" value="volume" checked={rangeType === 'volume'} onChange={() => onRangeTypeChange('volume')} />
              Volume
            </label>
            <label style={styles.radioLabel}>
              <input type="radio" name="range-type" value="ph" checked={rangeType === 'ph'} onChange={() => onRangeTypeChange('ph')} />
              pH
            </label>
          </div>
          <div style={styles.rangeInputs}>
            <div style={styles.field}>
              <label style={labelStyle} htmlFor="range-one">From</label>
              <input id="range-one" type="number" value={rangeOne} onChange={e => onRangeOneChange(e.target.value)} style={inputStyle} step="any" />
            </div>
            <div style={styles.field}>
              <label style={labelStyle} htmlFor="range-two">To</label>
              <input id="range-two" type="number" value={rangeTwo} onChange={e => onRangeTwoChange(e.target.value)} style={inputStyle} step="any" />
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

interface ToggleSwitchProps {
  label: string;
  leftLabel: string;
  rightLabel: string;
  checked: boolean;
  onChange: (value: boolean) => void;
}

function ToggleSwitch({ label, leftLabel, rightLabel, checked, onChange }: ToggleSwitchProps) {
  return (
    <div style={styles.toggleContainer}>
      <span style={styles.toggleLabel}>{label}:</span>
      <button type="button" onClick={() => onChange(false)} style={{ ...styles.toggleBtn, ...(checked ? {} : styles.toggleBtnActive) }}>
        {leftLabel}
      </button>
      <button type="button" onClick={() => onChange(true)} style={{ ...styles.toggleBtn, ...(checked ? styles.toggleBtnActive : {}) }}>
        {rightLabel}
      </button>
    </div>
  );
}

const styles: Record<string, React.CSSProperties> = {
  row: { display: 'flex', alignItems: 'center', gap: 12, marginBottom: 12 },
  field: { flex: 1, marginBottom: 8 },
  select: {
    width: '100%',
    padding: '8px 12px',
    fontSize: 14,
    border: `1px solid ${colors.inputBorder}`,
    borderRadius: 6,
    backgroundColor: colors.inputBg,
    color: colors.text,
  },
  toggleContainer: { display: 'flex', alignItems: 'center', gap: 4 },
  toggleLabel: { fontSize: 12, fontWeight: 500, color: colors.textMuted, marginRight: 8 },
  toggleBtn: {
    padding: '4px 12px',
    fontSize: 13,
    border: `1px solid ${colors.inputBorder}`,
    backgroundColor: colors.inputBg,
    color: colors.textMuted,
    cursor: 'pointer',
    borderRadius: 4,
  },
  toggleBtnActive: {
    backgroundColor: colors.primary,
    color: '#fff',
    borderColor: colors.primary,
  },
  radioGroup: { display: 'flex', gap: 16, marginBottom: 8 },
  radioLabel: { display: 'flex', alignItems: 'center', gap: 4, fontSize: 13, color: colors.text, cursor: 'pointer' },
  divider: { height: 1, backgroundColor: colors.divider, margin: '12px 0' },
  manualRange: { marginTop: 8 },
  rangeInputs: { display: 'flex', gap: 12 },
};
