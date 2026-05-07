import type { AnalysisResponse } from '../../types/titration';

interface AnalysisResultsProps {
  results: AnalysisResponse;
}

export default function AnalysisResults({ results }: AnalysisResultsProps) {
  const {
    equivalence_points,
    pka_values,
    pka_volumes,
    acid_identification,
    concentration,
    warnings,
  } = results;

  return (
    <div style={styles.container}>
      {warnings.length > 0 && (
        <div style={styles.warnings}>
          {warnings.map((w, i) => (
            <div key={i} style={styles.warningText}>{w}</div>
          ))}
        </div>
      )}

      <div style={styles.grid}>
        <div style={styles.card}>
          <h3 style={styles.cardTitle}>Equivalence Points</h3>
          {equivalence_points.length === 0 ? (
            <p style={styles.empty}>No equivalence points found.</p>
          ) : (
            <table style={styles.table}>
              <thead>
                <tr>
                  <th style={styles.th}>#</th>
                  <th style={styles.th}>Volume (mL)</th>
                  <th style={styles.th}>pH</th>
                </tr>
              </thead>
              <tbody>
                {equivalence_points.map((ep, i) => (
                  <tr key={i}>
                    <td style={styles.td}>{i + 1}</td>
                    <td style={styles.td}>{ep.volume.toFixed(3)}</td>
                    <td style={styles.td}>{ep.ph.toFixed(3)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>

        <div style={styles.card}>
          <h3 style={styles.cardTitle}>pKa Values</h3>
          {pka_values.length === 0 ? (
            <p style={styles.empty}>No pKa values determined.</p>
          ) : (
            <table style={styles.table}>
              <thead>
                <tr>
                  <th style={styles.th}>#</th>
                  <th style={styles.th}>pKa</th>
                  <th style={styles.th}>Volume (mL)</th>
                </tr>
              </thead>
              <tbody>
                {pka_values.map((pka, i) => (
                  <tr key={i}>
                    <td style={styles.td}>{i + 1}</td>
                    <td style={styles.td}>{pka.toFixed(3)}</td>
                    <td style={styles.td}>{pka_volumes[i]?.toFixed(3) ?? '-'}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>

        {concentration && (
          <div style={styles.card}>
            <h3 style={styles.cardTitle}>Concentrations</h3>
            <div style={styles.concentrationRow}>
              <span style={styles.concLabel}>Titrant:</span>
              <span style={styles.concValue}>
                {concentration.titrant_concentration.toFixed(4)} mol/L
              </span>
            </div>
            {concentration.analyte_concentrations.map((conc, i) => (
              <div key={i} style={styles.concentrationRow}>
                <span style={styles.concLabel}>
                  Analyte {concentration.analyte_concentrations.length > 1 ? `(${i + 1})` : ''}:
                </span>
                <span style={styles.concValue}>{conc.toFixed(4)} mol/L</span>
              </div>
            ))}
          </div>
        )}

        {acid_identification && (
          <div style={styles.card}>
            <h3 style={styles.cardTitle}>Acid Identification</h3>
            <div style={styles.idRow}>
              <span style={styles.idLabel}>Name:</span>
              <span style={styles.idValue}>{acid_identification.name}</span>
            </div>
            <div style={styles.idRow}>
              <span style={styles.idLabel}>Database pKa:</span>
              <span style={styles.idValue}>{acid_identification.database_pka}</span>
            </div>
            <div style={styles.idRow}>
              <span style={styles.idLabel}>Percent Error:</span>
              <span style={{
                ...styles.idValue,
                color: acid_identification.percent_error < 5 ? '#16a34a' : '#dc2626',
              }}>
                {acid_identification.percent_error.toFixed(2)}%
              </span>
            </div>
          </div>
        )}
      </div>
    </div>
  );
}

const colors = {
  border: '#d1d5db',
  cardBg: '#ffffff',
  text: '#1a1a2e',
  textMuted: '#6b7280',
  headerBg: '#f1f5f9',
  warningBg: '#fffbeb',
  warningBorder: '#f59e0b',
  warningText: '#92400e',
};

const styles: Record<string, React.CSSProperties> = {
  container: {
    display: 'flex',
    flexDirection: 'column' as const,
    gap: 16,
  },
  grid: {
    display: 'grid',
    gridTemplateColumns: 'repeat(auto-fit, minmax(280px, 1fr))',
    gap: 16,
  },
  card: {
    backgroundColor: colors.cardBg,
    borderRadius: 8,
    border: `1px solid ${colors.border}`,
    padding: 16,
    overflow: 'hidden',
  },
  cardTitle: {
    margin: '0 0 12px',
    fontSize: 14,
    fontWeight: 600,
    color: colors.text,
    textTransform: 'uppercase' as const,
    letterSpacing: '0.5px',
    paddingBottom: 8,
    borderBottom: `2px solid ${colors.headerBg}`,
  },
  table: {
    width: '100%',
    borderCollapse: 'collapse' as const,
    fontSize: 13,
  },
  th: {
    textAlign: 'left' as const,
    padding: '6px 8px',
    fontSize: 11,
    fontWeight: 600,
    color: colors.textMuted,
    textTransform: 'uppercase' as const,
    borderBottom: `1px solid ${colors.border}`,
  },
  td: {
    padding: '6px 8px',
    color: colors.text,
    borderBottom: `1px solid ${colors.headerBg}`,
  },
  empty: {
    fontSize: 13,
    color: colors.textMuted,
    fontStyle: 'italic',
    margin: 0,
  },
  concentrationRow: {
    display: 'flex',
    justifyContent: 'space-between',
    padding: '6px 0',
    fontSize: 13,
    borderBottom: `1px solid ${colors.headerBg}`,
  },
  concLabel: {
    color: colors.textMuted,
  },
  concValue: {
    fontWeight: 600,
    color: colors.text,
  },
  idRow: {
    display: 'flex',
    justifyContent: 'space-between',
    padding: '6px 0',
    fontSize: 13,
    borderBottom: `1px solid ${colors.headerBg}`,
  },
  idLabel: {
    color: colors.textMuted,
  },
  idValue: {
    fontWeight: 600,
    color: colors.text,
  },
  warnings: {
    backgroundColor: colors.warningBg,
    border: `1px solid ${colors.warningBorder}`,
    borderRadius: 6,
    padding: 12,
    fontSize: 13,
  },
  warningText: {
    color: colors.warningText,
    margin: '2px 0',
  },
};
