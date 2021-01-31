from Titration_Simulator import *

a_acidic = bool(sys.argv[1])
t_acidic = bool(sys.argv[2])
t_pK = list(map(float, sys.argv[4].split(",")))
a_pK = list(map(float, sys.argv[3].split(",")))

a_strong = bool(sys.argv[5])
t_strong = bool(sys.argv[6])

a_vol = float(sys.argv[7])
a_conc = float(sys.argv[8])
t_conc = float(sys.argv[9])

analyte = Compound("analyte", a_acidic, a_pK, strong=a_strong)
titrant = Compound("titrant", t_acidic, t_pK, strong=t_strong)

titr = Titration(analyte=analyte, titrant=titrant, volume_analyte=a_vol, concentration_analyte=a_conc, concentration_titrant=t_conc)

pH_values = list(titr.ph_t)
vol_values = list(titr.volume_titrant_t)

print(pH_values)
print(vol_values)
