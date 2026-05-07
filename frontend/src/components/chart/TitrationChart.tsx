import {
  ComposedChart,
  Scatter,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  Legend,
  ResponsiveContainer,
  ZAxis,
} from 'recharts';
import type { AnalysisResponse, DataPoint, DerivativePoint } from '../../types/titration';

interface TitrationChartProps {
  results: AnalysisResponse;
  showTitration: boolean;
  showDeriv1: boolean;
  showDeriv2: boolean;
  showEquivalence: boolean;
}

const PH_COLOR = '#0d7377';
const DERIV1_COLOR = '#e67e22';
const DERIV2_COLOR = '#8e44ad';
const EQUIV_COLOR = '#dc2626';

export default function TitrationChart({
  results,
  showTitration,
  showDeriv1,
  showDeriv2,
  showEquivalence,
}: TitrationChartProps) {
  const { titration_data, first_derivative, second_derivative, equivalence_points } = results;

  const chartData = buildChartData(
    titration_data,
    first_derivative,
    second_derivative,
  );

  const equivData = equivalence_points.map(ep => ({
    x: ep.volume,
    y: ep.ph,
  }));

  const hasDerivatives = first_derivative.length > 0 || second_derivative.length > 0;

  return (
    <div style={styles.card}>
      <ResponsiveContainer width="100%" height={450}>
        <ComposedChart data={chartData} margin={{ top: 10, right: 30, left: 10, bottom: 10 }}>
          <CartesianGrid strokeDasharray="3 3" stroke="#e5e7eb" />
          <XAxis
            dataKey="volume"
            type="number"
            domain={['auto', 'auto']}
            tick={{ fontSize: 12 }}
            label={{ value: 'Volume (mL)', position: 'insideBottom', offset: -5, fontSize: 12 }}
          />
          <YAxis
            yAxisId="ph"
            domain={['auto', 'auto']}
            tick={{ fontSize: 12 }}
            label={{ value: 'pH', angle: -90, position: 'insideLeft', fontSize: 12 }}
          />
          {hasDerivatives && (
            <YAxis
              yAxisId="deriv"
              orientation="right"
              domain={[0, 1]}
              tick={{ fontSize: 12 }}
              label={{
                value: 'Normalized Derivative',
                angle: 90,
                position: 'insideRight',
                fontSize: 12,
              }}
            />
          )}
          <Tooltip content={<CustomTooltip />} />
          <Legend />

          {showTitration && (
            <Scatter
              yAxisId="ph"
              name="Titration Data"
              data={chartData}
              dataKey="ph"
              fill={PH_COLOR}
              fillOpacity={0.8}
            >
              <ZAxis range={[20, 20]} />
            </Scatter>
          )}

          {showDeriv1 && first_derivative.length > 0 && (
            <Line
              yAxisId="deriv"
              name="1st Derivative"
              dataKey="deriv1Norm"
              stroke={DERIV1_COLOR}
              dot={false}
              strokeWidth={2}
              connectNulls
            />
          )}

          {showDeriv2 && second_derivative.length > 0 && (
            <Line
              yAxisId="deriv"
              name="2nd Derivative"
              dataKey="deriv2Norm"
              stroke={DERIV2_COLOR}
              dot={false}
              strokeWidth={2}
              connectNulls
            />
          )}

          {showEquivalence && equivData.length > 0 && (
            <Scatter
              yAxisId="ph"
              name="Equivalence Points"
              data={equivData}
              dataKey="y"
              fill={EQUIV_COLOR}
              shape="diamond"
              fillOpacity={1}
            >
              <ZAxis range={[60, 60]} />
            </Scatter>
          )}
        </ComposedChart>
      </ResponsiveContainer>
    </div>
  );
}

interface ChartRow {
  volume: number;
  ph: number | null;
  deriv1Norm: number | null;
  deriv2Norm: number | null;
}

function buildChartData(
  titration: DataPoint[],
  deriv1: DerivativePoint[],
  deriv2: DerivativePoint[],
): ChartRow[] {
  const volumeSet = new Set<number>();
  for (const d of titration) volumeSet.add(d.volume);
  for (const d of deriv1) volumeSet.add(d.volume);
  for (const d of deriv2) volumeSet.add(d.volume);

  const volumes = Array.from(volumeSet).sort((a, b) => a - b);

  const phMap = new Map(titration.map(d => [d.volume, d.ph]));
  const d1Map = new Map(deriv1.map(d => [d.volume, d.normalized]));
  const d2Map = new Map(deriv2.map(d => [d.volume, d.normalized]));

  return volumes.map(v => ({
    volume: v,
    ph: phMap.get(v) ?? null,
    deriv1Norm: d1Map.get(v) ?? null,
    deriv2Norm: d2Map.get(v) ?? null,
  }));
}

import type { TooltipProps } from 'recharts';

function CustomTooltip({ active, payload, label }: TooltipProps<number, string>) {
  if (!active || !payload || payload.length === 0) {
    return null;
  }

  return (
    <div style={tooltipStyles.container}>
      <p style={tooltipStyles.volume}>Volume: {Number(label).toFixed(2)} mL</p>
      {payload.map((entry, i) => (
        <p key={i} style={{ color: entry.color, margin: '2px 0', fontSize: 12 }}>
          {entry.name}: {entry.value != null ? Number(entry.value).toFixed(4) : 'N/A'}
        </p>
      ))}
    </div>
  );
}

const tooltipStyles: Record<string, React.CSSProperties> = {
  container: {
    backgroundColor: '#fff',
    border: '1px solid #d1d5db',
    borderRadius: 4,
    padding: '8px 12px',
    fontSize: 12,
  },
  volume: {
    margin: '0 0 4px',
    fontWeight: 600,
    color: '#1a1a2e',
  },
};

const styles: Record<string, React.CSSProperties> = {
  card: {
    backgroundColor: '#ffffff',
    borderRadius: 8,
    border: '1px solid #d1d5db',
    padding: 16,
  },
};
