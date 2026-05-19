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
def safe_str(value):

    if pd.isna(value):
        return "Неизвестно"

    value = str(value).strip()

    if value == "":
        return "Неизвестно"

    return value

for i, row in df.iterrows():

    if pd.notna(row["Номер"]):

        current_accident_id = row["Номер ДТП"]

        accidents.append({
        "Номер ДТП": safe_int(row["Номер ДТП"]),
        "Дата": safe_str(row["Дата"]),
        "Время": safe_str(row["Время"]),
        "Широта": safe_str(row["Широта"]),
        "Долгота": safe_str(row["Долгота"]),
        "Вид ДТП": safe_str(row["Вид ДТП"]),
        "Район": safe_str(row["Адрес"]),
        "Состояние погоды": safe_str(row["Состояние погоды"]),
        "Состояние проезжей части": safe_str(row["Состояние проезжей части"]),
        "Освещение": safe_str(row["Освещение"]),
        "Количество ТС": safe_int(row["Количество ТС"]),
        "Число участников": safe_int(row["Число участников"]),
        "Число погибших": safe_int(row["Число погибших"]),
        "Число раненых": safe_int(row["Число раненых"])
        })

    else:

        vehicles.append({
        "Номер ДТП": safe_int(current_accident_id),
        "Номер ТС": safe_int(row["Номер Тс"]),
        "Тип ТС": safe_str(row["Тип ТС"]),
        "Год выпуска": safe_int(row["Год выпуска"]),
        "Марка/модель ТС": safe_str(row["Марка/модель ТС"]),
        "Форма собственности": safe_str(row["Форма собственности"]),
        "Цвет": safe_str(row["Цвет"]),
        "Расположение руля, тип привода":safe_str(row["Расположение руля, тип привода"]),
        "Оставление места ДТП":safe_str(row["Сведения об оставлении места ДТП"]),
        "Технические неисправности":safe_str(row["Технические неисправности"])
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
