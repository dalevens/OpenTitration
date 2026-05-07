import { useState, useCallback } from 'react';
import type { AnalysisResponse, AnalysisFormState } from './types/titration';
import { analyzeTitration } from './api/titration';
import { getMolarMass, lookupAcid } from './api/chemistry';
import { styles } from './styles/appStyles';
import FileUpload from './components/data-input/FileUpload';
import TitrantForm from './components/data-input/TitrantForm';
import AnalysisConfig from './components/data-input/AnalysisConfig';
import ConcentrationForm from './components/data-input/ConcentrationForm';
import TitrationChart from './components/chart/TitrationChart';
import ChartControls from './components/chart/ChartControls';
import AnalysisResults from './components/results/AnalysisResults';

const INITIAL_FORM: AnalysisFormState = {
  titrant_formula: '',
  protonation_state: 1,
  is_base: false,
  is_known_analyte: true,
  known_analyte_name: '',
  molar_ratio: '1:1',
  analyte_volume: 25,
  dilution_factor: 1,
  titrant_concentration: '',
  titrant_mass: '',
  titrant_volume: '',
  solve_method: 'automatic',
  range_type: 'volume',
  range_one: '',
  range_two: '',
  norm_y1: 0,
  norm_y2: 14,
  offset_y2: 0,
};

export default function App() {
  const [file, setFile] = useState<File | null>(null);
  const [results, setResults] = useState<AnalysisResponse | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [form, setForm] = useState<AnalysisFormState>(INITIAL_FORM);
  const [molarMass, setMolarMass] = useState(0);
  const [acidName, setAcidName] = useState('');
  const [showTitration, setShowTitration] = useState(true);
  const [showDeriv1, setShowDeriv1] = useState(true);
  const [showDeriv2, setShowDeriv2] = useState(false);
  const [showEquivalence, setShowEquivalence] = useState(true);

  const handleFileSelect = useCallback((selectedFile: File) => {
    setFile(selectedFile);
    setError(null);
  }, []);

  const handleFormulaChange = useCallback(async (formula: string) => {
    setForm(prev => ({ ...prev, titrant_formula: formula }));
    if (formula.trim().length < 2) {
      setMolarMass(0);
      setAcidName('');
      return;
    }
    try {
      const [massRes, acidRes] = await Promise.all([
        getMolarMass(formula),
        lookupAcid(formula),
      ]);
      setMolarMass(massRes.molar_mass);
      if (acidRes.single && acidRes.matches.length === 1) {
        setAcidName(acidRes.matches[0].name);
      } else if (acidRes.matches.length > 1) {
        setAcidName(`${acidRes.matches.length} matches found`);
      } else {
        setAcidName('');
      }
    } catch {
      setMolarMass(0);
      setAcidName('');
    }
  }, []);

  const updateForm = useCallback(<K extends keyof AnalysisFormState>(
    key: K,
    value: AnalysisFormState[K],
  ) => {
    setForm(prev => ({ ...prev, [key]: value }));
  }, []);

  const handleAnalyze = useCallback(async () => {
    if (!file) {
      setError('Please select a CSV file first.');
      return;
    }
    setLoading(true);
    setError(null);
    setResults(null);

    const formData = new FormData();
    formData.append('file', file);
    formData.append('titrant_formula', form.titrant_formula);
    formData.append('protonation_state', String(form.protonation_state));
    formData.append('is_base', String(form.is_base));
    formData.append('is_known_analyte', String(form.is_known_analyte));
    formData.append('known_analyte_name', form.known_analyte_name);
    formData.append('molar_ratio', form.molar_ratio);
    formData.append('analyte_volume', String(form.analyte_volume));
    formData.append('dilution_factor', String(form.dilution_factor));
    formData.append('titrant_concentration', form.titrant_concentration);
    formData.append('titrant_mass', form.titrant_mass);
    formData.append('titrant_volume', form.titrant_volume);
    formData.append('solve_method', form.solve_method);
    formData.append('range_type', form.range_type);
    formData.append('range_one', form.range_one);
    formData.append('range_two', form.range_two);
    formData.append('norm_y1', String(form.norm_y1));
    formData.append('norm_y2', String(form.norm_y2));
    formData.append('offset_y2', String(form.offset_y2));

    try {
      const data = await analyzeTitration(formData);
      setResults(data);
    } catch (err: unknown) {
      const msg = err instanceof Error ? err.message : 'Analysis failed. Please check your inputs.';
      setError(msg);
    } finally {
      setLoading(false);
    }
  }, [file, form]);

  return (
    <div style={styles.container}>
      <header style={styles.header}>
        <h1 style={styles.title}>OpenTitration</h1>
        <p style={styles.subtitle}>Titration Data Analysis Tool</p>
      </header>

      <div style={styles.layout}>
        <div style={styles.leftColumn}>
          <FileUpload onFileSelect={handleFileSelect} />
          <TitrantForm
            formula={form.titrant_formula}
            onFormulaChange={handleFormulaChange}
            molarMass={molarMass}
            acidName={acidName}
          />
          <AnalysisConfig
            protonationState={form.protonation_state}
            onProtonationChange={v => updateForm('protonation_state', v)}
            isBase={form.is_base}
            onIsBaseChange={v => updateForm('is_base', v)}
            isKnownAnalyte={form.is_known_analyte}
            onIsKnownChange={v => updateForm('is_known_analyte', v)}
            knownAnalyteName={form.known_analyte_name}
            onKnownNameChange={v => updateForm('known_analyte_name', v)}
            solveMethod={form.solve_method}
            onSolveMethodChange={v => updateForm('solve_method', v)}
            rangeType={form.range_type}
            onRangeTypeChange={v => updateForm('range_type', v)}
            rangeOne={form.range_one}
            onRangeOneChange={v => updateForm('range_one', v)}
            rangeTwo={form.range_two}
            onRangeTwoChange={v => updateForm('range_two', v)}
          />
          <ConcentrationForm
            titrantConcentration={form.titrant_concentration}
            onConcentrationChange={v => updateForm('titrant_concentration', v)}
            titrantMass={form.titrant_mass}
            onMassChange={v => updateForm('titrant_mass', v)}
            titrantVolume={form.titrant_volume}
            onVolumeChange={v => updateForm('titrant_volume', v)}
            molarRatio={form.molar_ratio}
            onMolarRatioChange={v => updateForm('molar_ratio', v)}
            analyteVolume={form.analyte_volume}
            onAnalyteVolumeChange={v => updateForm('analyte_volume', v)}
            dilutionFactor={form.dilution_factor}
            onDilutionFactorChange={v => updateForm('dilution_factor', v)}
          />
          <button
            onClick={handleAnalyze}
            disabled={loading}
            style={{
              ...styles.analyzeButton,
              opacity: loading ? 0.6 : 1,
              cursor: loading ? 'not-allowed' : 'pointer',
            }}
          >
            {loading ? 'Analyzing...' : 'Analyze'}
          </button>
          {error && <div style={styles.error}>{error}</div>}
        </div>

        <div style={styles.rightColumn}>
          {results ? (
            <>
              <ChartControls
                showTitration={showTitration}
                showDeriv1={showDeriv1}
                showDeriv2={showDeriv2}
                showEquivalence={showEquivalence}
                onShowTitrationChange={setShowTitration}
                onShowDeriv1Change={setShowDeriv1}
                onShowDeriv2Change={setShowDeriv2}
                onShowEquivalenceChange={setShowEquivalence}
              />
              <TitrationChart
                results={results}
                showTitration={showTitration}
                showDeriv1={showDeriv1}
                showDeriv2={showDeriv2}
                showEquivalence={showEquivalence}
              />
              <AnalysisResults results={results} />
            </>
          ) : (
            <div style={styles.placeholder}>
              <p>Upload data and configure parameters, then click Analyze.</p>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}
