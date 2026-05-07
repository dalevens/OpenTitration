interface ChartControlsProps {
  showTitration: boolean;
  showDeriv1: boolean;
  showDeriv2: boolean;
  showEquivalence: boolean;
  onShowTitrationChange: (value: boolean) => void;
  onShowDeriv1Change: (value: boolean) => void;
  onShowDeriv2Change: (value: boolean) => void;
  onShowEquivalenceChange: (value: boolean) => void;
}

interface ToggleOption {
  label: string;
  checked: boolean;
  onChange: (value: boolean) => void;
  color: string;
}

export default function ChartControls({
  showTitration,
  showDeriv1,
  showDeriv2,
  showEquivalence,
  onShowTitrationChange,
  onShowDeriv1Change,
  onShowDeriv2Change,
  onShowEquivalenceChange,
}: ChartControlsProps) {
  const toggles: ToggleOption[] = [
    { label: 'Titration Data', checked: showTitration, onChange: onShowTitrationChange, color: PH_COLOR },
    { label: '1st Derivative', checked: showDeriv1, onChange: onShowDeriv1Change, color: DERIV1_COLOR },
    { label: '2nd Derivative', checked: showDeriv2, onChange: onShowDeriv2Change, color: DERIV2_COLOR },
    { label: 'Equivalence Points', checked: showEquivalence, onChange: onShowEquivalenceChange, color: EQUIV_COLOR },
  ];

  return (
    <div style={styles.container}>
      {toggles.map(toggle => (
        <label key={toggle.label} style={styles.toggleItem}>
          <input
            type="checkbox"
            checked={toggle.checked}
            onChange={e => toggle.onChange(e.target.checked)}
            style={styles.checkbox}
          />
          <span style={{ ...styles.colorDot, backgroundColor: toggle.color }} />
          <span style={styles.toggleLabel}>{toggle.label}</span>
        </label>
      ))}
    </div>
  );
}

const PH_COLOR = '#0d7377';
const DERIV1_COLOR = '#e67e22';
const DERIV2_COLOR = '#8e44ad';
const EQUIV_COLOR = '#dc2626';

const styles: Record<string, React.CSSProperties> = {
  container: {
    display: 'flex',
    flexWrap: 'wrap' as const,
    gap: 16,
    backgroundColor: '#ffffff',
    borderRadius: 8,
    border: '1px solid #d1d5db',
    padding: '10px 16px',
    alignItems: 'center',
  },
  toggleItem: {
    display: 'flex',
    alignItems: 'center',
    gap: 6,
    cursor: 'pointer',
    fontSize: 13,
    color: '#1a1a2e',
  },
  checkbox: {
    cursor: 'pointer',
  },
  colorDot: {
    width: 10,
    height: 10,
    borderRadius: '50%',
    display: 'inline-block',
  },
  toggleLabel: {
    userSelect: 'none' as const,
  },
};
