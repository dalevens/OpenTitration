from Titration_Simulator import *

a_acidic = bool(sys.argv[1])
t_acidic = bool(sys.argv[2])

a_pK = list(map(float, sys.argv[3].split(",")))
t_pK = list(map(float, sys.argv[4].split(",")))

a_vol = float(sys.argv[5])
a_conc = float(sys.argv[6])
t_conc = float(sys.argv[7])

resolution = float(sys.argv[8])

analyte = Compound("analyte", a_acidic, a_pK)
titrant = Compound("titrant", t_acidic, t_pK)



titr = Titration(analyte=analyte, 
                 titrant=titrant, 
                 volume_analyte=a_vol, 
                 concentration_analyte=a_conc, 
                 concentration_titrant=t_conc,
                 precision=resolution
       )

pH_values = titr.ph_t
vol_values = titr.volume_titrant_t

print(pH_values)
print(vol_values)
