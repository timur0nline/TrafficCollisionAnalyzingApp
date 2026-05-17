using System;
using System.Data.SQLite;
using System.IO;


namespace Анализ_данных_о_ДТП
{
    public static class DatabaseManager
    {
        public static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "traffic.db");
        public static string connectionString = $"Data Source={databasePath};Version=3;";
        public static void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = @"

                PRAGMA foreign_keys = ON;

                CREATE TABLE IF NOT EXISTS AccidentTypes (
                    AccidentTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS Districts (
                    DistrictID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS WeatherConditions (
                    WeatherConditionID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS RoadStates (
                    RoadStateID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS LightingConditions (
                    LightingConditionID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS VehicleTypes (
                    VehicleTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS VehicleModels (
                    VehicleModelID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS OwnershipTypes (
                    OwnershipTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS Colors (
                    ColorID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS DriveTypes (
                    DriveTypeID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS HitAndRunStatuses (
                    HitAndRunStatusID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE
                );

                CREATE TABLE IF NOT EXISTS Accidents (
                    AccidentID INTEGER PRIMARY KEY AUTOINCREMENT,

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

                CREATE TABLE IF NOT EXISTS Vehicles (
                    VehicleID INTEGER PRIMARY KEY AUTOINCREMENT,

                    AccidentID INTEGER,

                    VehicleNumber INTEGER,

                    VehicleTypeID INTEGER,
                    VehicleModelID INTEGER,
                    OwnershipTypeID INTEGER,
                    ColorID INTEGER,
                    DriveTypeID INTEGER,
                    HitAndRunStatusID INTEGER,
                    TechnicalIssues TEXT,

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

                ";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
