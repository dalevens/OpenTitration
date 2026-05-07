import { useState, useRef, useCallback, type DragEvent } from 'react';

interface FileUploadProps {
  onFileSelect: (file: File) => void;
}

const ACCEPTED_EXTENSIONS = ['.csv', '.txt'];

export default function FileUpload({ onFileSelect }: FileUploadProps) {
  const [fileName, setFileName] = useState<string | null>(null);
  const [dragOver, setDragOver] = useState(false);
  const inputRef = useRef<HTMLInputElement>(null);

  const isValidFile = useCallback((file: File): boolean => {
    const lower = file.name.toLowerCase();
    return ACCEPTED_EXTENSIONS.some(ext => lower.endsWith(ext));
  }, []);

  const handleFile = useCallback(
    (file: File) => {
      if (!isValidFile(file)) {
        return;
      }
      setFileName(file.name);
      onFileSelect(file);
    },
    [isValidFile, onFileSelect],
  );

  const handleDrop = useCallback(
    (e: DragEvent<HTMLDivElement>) => {
      e.preventDefault();
      setDragOver(false);
      const droppedFile = e.dataTransfer.files[0];
      if (droppedFile) {
        handleFile(droppedFile);
      }
    },
    [handleFile],
  );

  const handleDragOver = useCallback((e: DragEvent<HTMLDivElement>) => {
    e.preventDefault();
    setDragOver(true);
  }, []);

  const handleDragLeave = useCallback(() => {
    setDragOver(false);
  }, []);

  const handleClick = useCallback(() => {
    inputRef.current?.click();
  }, []);

  const handleInputChange = useCallback(
    (e: React.ChangeEvent<HTMLInputElement>) => {
      const selected = e.target.files?.[0];
      if (selected) {
        handleFile(selected);
      }
    },
    [handleFile],
  );

  const borderColor = dragOver ? colors.accent : colors.border;
  const bgColor = dragOver ? '#e0f5f5' : '#fafafa';

  return (
    <div style={styles.card}>
      <label style={styles.label}>Data File</label>
      <div
        style={{ ...styles.dropZone, borderColor, backgroundColor: bgColor }}
        onDrop={handleDrop}
        onDragOver={handleDragOver}
        onDragLeave={handleDragLeave}
        onClick={handleClick}
      >
        {fileName ? (
          <div style={styles.fileInfo}>
            <span style={styles.fileIcon}>&#128196;</span>
            <span style={styles.fileName}>{fileName}</span>
          </div>
        ) : (
          <div style={styles.prompt}>
            <span style={styles.promptText}>Drag & drop a CSV file here</span>
            <span style={styles.promptSubtext}>or click to browse</span>
          </div>
        )}
      </div>
      <input
        ref={inputRef}
        type="file"
        accept=".csv,.txt"
        onChange={handleInputChange}
        style={styles.hiddenInput}
      />
    </div>
  );
}

const colors = {
  border: '#d1d5db',
  accent: '#0d7377',
  cardBg: '#ffffff',
  text: '#1a1a2e',
  textMuted: '#6b7280',
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
  dropZone: {
    border: '2px dashed',
    borderRadius: 6,
    padding: 24,
    textAlign: 'center' as const,
    cursor: 'pointer',
    transition: 'all 0.2s',
  },
  prompt: {
    display: 'flex',
    flexDirection: 'column' as const,
    gap: 4,
  },
  promptText: {
    fontSize: 14,
    color: colors.text,
  },
  promptSubtext: {
    fontSize: 12,
    color: colors.textMuted,
  },
  fileInfo: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    gap: 8,
  },
  fileIcon: {
    fontSize: 20,
  },
  fileName: {
    fontSize: 14,
    fontWeight: 500,
    color: colors.accent,
  },
  hiddenInput: {
    display: 'none',
  },
};
