import sqlite3
import pandas as pd


connection = sqlite3.connect("traffic.db")

cursor = connection.cursor()
cursor.executescript("""

DROP TABLE IF EXISTS Vehicles;
DROP TABLE IF EXISTS Accidents;

DROP TABLE IF EXISTS AccidentTypes;
DROP TABLE IF EXISTS Districts;
DROP TABLE IF EXISTS WeatherConditions;
DROP TABLE IF EXISTS RoadStates;
DROP TABLE IF EXISTS LightingConditions;

DROP TABLE IF EXISTS VehicleTypes;
DROP TABLE IF EXISTS VehicleModels;
DROP TABLE IF EXISTS OwnershipTypes;
DROP TABLE IF EXISTS Colors;
DROP TABLE IF EXISTS DriveTypes;
DROP TABLE IF EXISTS HitAndRunStatuses;


CREATE TABLE AccidentTypes (
    AccidentTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE Districts (
    DistrictID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE WeatherConditions (
    WeatherConditionID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE RoadStates (
    RoadStateID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE LightingConditions (
    LightingConditionID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE VehicleTypes (
    VehicleTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE VehicleModels (
    VehicleModelID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE OwnershipTypes (
    OwnershipTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE Colors (
    ColorID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE DriveTypes (
    DriveTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);

CREATE TABLE HitAndRunStatuses (
    HitAndRunStatusID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT UNIQUE
);


CREATE TABLE Accidents (
    AccidentID INTEGER PRIMARY KEY,

    Date TEXT,
    Time TEXT,

    Latitude REAL,
    Longitude REAL,

    AccidentTypeID INTEGER,
    DistrictID INTEGER,
    WeatherConditionID INTEGER,
    RoadStateID INTEGER,
    LightingConditionID INTEGER,

    VehicleCount INTEGER,
    ParticipantCount INTEGER,
    DeadCount INTEGER,
    InjuredCount INTEGER,

    FOREIGN KEY (AccidentTypeID)
        REFERENCES AccidentTypes(AccidentTypeID),

    FOREIGN KEY (DistrictID)
        REFERENCES Districts(DistrictID),

    FOREIGN KEY (WeatherConditionID)
        REFERENCES WeatherConditions(WeatherConditionID),

    FOREIGN KEY (RoadStateID)
        REFERENCES RoadStates(RoadStateID),

    FOREIGN KEY (LightingConditionID)
        REFERENCES LightingConditions(LightingConditionID)
);


CREATE TABLE Vehicles (
    VehicleID INTEGER PRIMARY KEY AUTOINCREMENT,

    AccidentID INTEGER,

    VehicleNumber INTEGER,

    VehicleTypeID INTEGER,
    VehicleModelID INTEGER,
    OwnershipTypeID INTEGER,
    ColorID INTEGER,
    DriveTypeID INTEGER,
    HitAndRunStatusID INTEGER,

    Year INTEGER,

    FOREIGN KEY (AccidentID)
        REFERENCES Accidents(AccidentID),

    FOREIGN KEY (VehicleTypeID)
        REFERENCES VehicleTypes(VehicleTypeID),

    FOREIGN KEY (VehicleModelID)
        REFERENCES VehicleModels(VehicleModelID),

    FOREIGN KEY (OwnershipTypeID)
        REFERENCES OwnershipTypes(OwnershipTypeID),

    FOREIGN KEY (ColorID)
        REFERENCES Colors(ColorID),

    FOREIGN KEY (DriveTypeID)
        REFERENCES DriveTypes(DriveTypeID),

    FOREIGN KEY (HitAndRunStatusID)
        REFERENCES HitAndRunStatuses(HitAndRunStatusID)
);

""")


accidents_df = pd.read_csv(
    "accidents.csv",
    sep=";",
    encoding="utf-8-sig"
)

vehicles_df = pd.read_csv(
    "vehicles.csv",
    sep=";",
    encoding="utf-8-sig"
)


def fill_directory_table(df, column_name, table_name):

    unique_values = (
        df[column_name]
        .dropna()
        .astype(str)
        .unique()
    )

    for value in unique_values:

        cursor.execute(
            f"""
            INSERT OR IGNORE INTO {table_name}(Name)
            VALUES(?)
            """,
            (value,)
        )


fill_directory_table(
    accidents_df,
    "Вид ДТП",
    "AccidentTypes"
)

fill_directory_table(
    accidents_df,
    "Район",
    "Districts"
)

fill_directory_table(
    accidents_df,
    "Состояние погоды",
    "WeatherConditions"
)

fill_directory_table(
    accidents_df,
    "Состояние проезжей части",
    "RoadStates"
)

fill_directory_table(
    accidents_df,
    "Освещение",
    "LightingConditions"
)

fill_directory_table(
    vehicles_df,
    "Тип ТС",
    "VehicleTypes"
)

fill_directory_table(
    vehicles_df,
    "Марка/модель ТС",
    "VehicleModels"
)

fill_directory_table(
    vehicles_df,
    "Форма собственности",
    "OwnershipTypes"
)

fill_directory_table(
    vehicles_df,
    "Цвет",
    "Colors"
)

fill_directory_table(
    vehicles_df,
    "Расположение руля, тип привода",
    "DriveTypes"
)

fill_directory_table(
    vehicles_df,
    "Оставление места ДТП",
    "HitAndRunStatuses"
)


def get_id(table_name, value):

    if pd.isna(value):
        return None

    cursor.execute(
        f"""
        SELECT rowid
        FROM {table_name}
        WHERE Name = ?
        """,
        (str(value),)
    )

    result = cursor.fetchone()

    if result:
        return result[0]

    return None


for _, row in accidents_df.iterrows():

    cursor.execute("""

    INSERT INTO Accidents (

        AccidentID,

        Date,
        Time,

        Latitude,
        Longitude,

        AccidentTypeID,
        DistrictID,
        WeatherConditionID,
        RoadStateID,
        LightingConditionID,

        VehicleCount,
        ParticipantCount,
        DeadCount,
        InjuredCount

    )

    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)

    """, (

        int(row["Номер ДТП"]),

        row["Дата"],
        row["Время"],

        row["Широта"],
        row["Долгота"],

        get_id(
            "AccidentTypes",
            row["Вид ДТП"]
        ),

        get_id(
            "Districts",
            row["Район"]
        ),

        get_id(
            "WeatherConditions",
            row["Состояние погоды"]
        ),

        get_id(
            "RoadStates",
            row["Состояние проезжей части"]
        ),

        get_id(
            "LightingConditions",
            row["Освещение"]
        ),

        pd.to_numeric(
            row["Количество ТС"],
            errors="coerce"
        ),

        pd.to_numeric(
            row["Число участников"],
            errors="coerce"
        ),

        pd.to_numeric(
            row["Число погибших"],
            errors="coerce"
        ),

        pd.to_numeric(
            row["Число раненых"],
            errors="coerce"
        )

    ))


for _, row in vehicles_df.iterrows():

    year = pd.to_numeric(
        row["Год выпуска"],
        errors="coerce"
    )

    if pd.isna(year):
        year = None
    else:
        year = int(year)

    cursor.execute("""

    INSERT INTO Vehicles (

        AccidentID,

        VehicleNumber,

        VehicleTypeID,
        VehicleModelID,
        OwnershipTypeID,
        ColorID,
        DriveTypeID,
        HitAndRunStatusID,

        Year

    )

    VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)

    """, (

        int(row["Номер ДТП"]),

        pd.to_numeric(
            row["Номер ТС"],
            errors="coerce"
        ),

        get_id(
            "VehicleTypes",
            row["Тип ТС"]
        ),

        get_id(
            "VehicleModels",
            row["Марка/модель ТС"]
        ),

        get_id(
            "OwnershipTypes",
            row["Форма собственности"]
        ),

        get_id(
            "Colors",
            row["Цвет"]
        ),

        get_id(
            "DriveTypes",
            row["Расположение руля, тип привода"]
        ),

        get_id(
            "HitAndRunStatuses",
            row["Оставление места ДТП"]
        ),

        year

    ))

connection.commit()
connection.close()

print("База данных успешно создана")