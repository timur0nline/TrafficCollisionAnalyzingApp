import pandas as pd
import json
import os

df = pd.read_csv(
    "data.csv",
    sep=";",
    encoding="utf-8"
)

accidents = []
vehicles = []

current_accident_id = None

def safe_int(value):

    if pd.isna(value):
        return None

    return int(value)

for _, row in df.iterrows():

    if pd.notna(row["Номер"]):

        current_accident_id = row["Номер ДТП"]

        accidents.append({
        "Номер ДТП": safe_int(row["Номер ДТП"]),
        "Дата": row["Дата"],
        "Время": row["Время"],
        "Широта": row["Широта"],
        "Долгота": row["Долгота"],
        "Вид ДТП": row["Вид ДТП"],
        "Район": row["Адрес"],
        "Состояние погоды": row["Состояние погоды"],
        "Состояние проезжей части": row["Состояние проезжей части"],
        "Освещение": row["Освещение"],
        "Количество ТС": safe_int(row["Количество ТС"]),
        "Число участников": safe_int(row["Число участников"]),
        "Число погибших": safe_int(row["Число погибших"]),
        "Число раненых": safe_int(row["Число раненых"])
        })

    else:

        vehicles.append({
        "Номер ДТП": safe_int(current_accident_id),
        "Номер ТС": safe_int(row["Номер Тс"]),
        "Тип ТС": row["Тип ТС"],
        "Год выпуска": safe_int(row["Год выпуска"]),
        "Марка/модель ТС": row["Марка/модель ТС"],
        "Форма собственности": row["Форма собственности"],
        "Цвет": row["Цвет"],
        "Расположение руля, тип привода":row["Расположение руля, тип привода"],
        "Оставление места ДТП":row["Сведения об оставлении места ДТП"],
        "Технические неисправности":row["Технические неисправности"]
        })

accidents_df = pd.DataFrame(accidents)
vehicles_df = pd.DataFrame(vehicles)
vehicles_df["Год выпуска"] = (
    pd.to_numeric(
        vehicles_df["Год выпуска"],
        errors="coerce"
    )
    .astype("Int64")
)

accidents_df.to_csv(
    "accidents.csv",
    sep=';',
    index=False,
    encoding="utf-8-sig"
)

vehicles_df.to_csv(
    "vehicles.csv",
    sep=';',
    index=False,
    encoding="utf-8-sig"
)
