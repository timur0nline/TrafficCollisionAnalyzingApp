import sys
import sqlite3
import pandas as pd
import matplotlib.pyplot as plt

database_path = "traffic.db"

if len(sys.argv) < 5:
    print("Недостаточно аргументов")
    sys.exit(1)

dataset = sys.argv[1]
group_by = sys.argv[2]
metric = sys.argv[3]
chart_type = sys.argv[4]

accident_columns = {
    "Район": ("Districts", "Name", "DistrictID"),
    "Состояние погоды": ("WeatherConditions", "Name", "WeatherConditionID"),
    "Освещение": ("LightingConditions", "Name", "LightingConditionID"),
    "Вид ДТП": ("AccidentTypes", "Name", "AccidentTypeID"),
    "Состояние проезжей части": ("RoadStates", "Name", "RoadStateID")
}

vehicle_columns = {
    "Тип ТС": ("VehicleTypes", "Name", "VehicleTypeID"),
    "Марка/модель ТС": ("VehicleModels", "Name", "VehicleModelID"),
    "Год выпуска": ("Vehicles", "Year", "Year"),
    "Цвет": ("Colors", "Name", "ColorID"),
    "Расположение руля, тип привода": ("DriveTypes", "Name", "DriveTypeID"),
    "Технические неисправности": ("Vehicles", "TechnicalIssues", "TechnicalIssues")
}

metrics = {
    "Количество ДТП": "COUNT(*)",
    "Число погибших": "SUM(a.DeadCount)",
    "Число раненых": "SUM(a.InjuredCount)"
}

connection = sqlite3.connect(database_path)
try:

    if dataset == "ДТП":

        if group_by not in accident_columns:
            print("Неизвестный параметр группировки")
            sys.exit(1)

        table_name, name_column, id_column = accident_columns[group_by]

        metric_sql = metrics[metric]

        sql = f"""
        SELECT
            t.{name_column} AS Category,
            {metric_sql} AS Value
        FROM Accidents a
        LEFT JOIN {table_name} t
            ON a.{id_column} = t.{id_column}
        GROUP BY t.{name_column}
        ORDER BY Value DESC
        """
    else:

        if group_by not in vehicle_columns:
            print("Неизвестный параметр группировки")
            sys.exit(1)

        table_name, name_column, id_column = vehicle_columns[group_by]

        if table_name == "Vehicles":

            sql = f"""
            SELECT
                v.{name_column} AS Category,
                COUNT(*) AS Value
            FROM Vehicles v
            GROUP BY v.{name_column}
            ORDER BY Value DESC
            """

        else:

            sql = f"""
            SELECT
                t.{name_column} AS Category,
                COUNT(*) AS Value
            FROM Vehicles v
            LEFT JOIN {table_name} t
                ON v.{id_column} = t.{id_column}
            GROUP BY t.{name_column}
            ORDER BY Value DESC
            """

    df = pd.read_sql_query(sql, connection)
    df = df.head(15)
    if df.empty:
        print("Нет данных")
        sys.exit(1)


    plt.figure(figsize=(12, 6))
    if chart_type == "Столбчатая диаграмма":
        plt.bar(df["Category"], df["Value"])
    elif chart_type == "Круговая диаграмма":
        plt.pie(df["Value"], labels=df["Category"], autopct="%1.1f%%")
    else:
        print("Неизвестный тип графика")
        sys.exit(1)
    plt.title(f"{metric} по параметру '{group_by}'")

    if chart_type != "Круговая":
        plt.xticks(rotation=45)
    plt.tight_layout()
    plt.savefig("chart.png")
    plt.close()
except Exception as error:
    print(str(error))
finally:
    connection.close()