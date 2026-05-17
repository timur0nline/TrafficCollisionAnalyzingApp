using System.Collections.Generic;
using System;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

namespace Анализ_данных_о_ДТП
{
    public static class ImportManager
    {
        private static Dictionary<string, int> accidentTypes = new Dictionary<string, int>();
        private static Dictionary<string, int> districts = new Dictionary<string, int>();
        private static Dictionary<string, int> weatherConditions = new Dictionary<string, int>();
        private static Dictionary<string, int> roadStates = new Dictionary<string, int>();
        private static Dictionary<string, int> lightingConditions = new Dictionary<string, int>();

        private static Dictionary<string, int> vehicleTypes = new Dictionary<string, int>();
        private static Dictionary<string, int> vehicleModels = new Dictionary<string, int>();
        private static Dictionary<string, int> ownershipTypes = new Dictionary<string, int>();
        private static Dictionary<string, int> colors = new Dictionary<string, int>();
        private static Dictionary<string, int> driveTypes = new Dictionary<string, int>();
        private static Dictionary<string, int> hitAndRunStatuses = new Dictionary<string, int>();

        public static void ImportData(bool clear = true)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseManager.connectionString))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    if (clear) 
                    {
                        ClearDatabase(connection);
                    }
                    ImportDirectories(connection);
                    ImportAccidents(connection);
                    ImportVehicles(connection);
                    transaction.Commit();
                }
            }
        }

        private static void ClearDatabase(SQLiteConnection connection)
        {
            string sql = @"
            DELETE FROM Vehicles;
            DELETE FROM Accidents;

            DELETE FROM AccidentTypes;
            DELETE FROM Districts;
            DELETE FROM WeatherConditions;
            DELETE FROM RoadStates;
            DELETE FROM LightingConditions;

            DELETE FROM VehicleTypes;
            DELETE FROM VehicleModels;
            DELETE FROM OwnershipTypes;
            DELETE FROM Colors;
            DELETE FROM DriveTypes;
            DELETE FROM HitAndRunStatuses;
            ";

            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        private static void ImportDirectories(SQLiteConnection connection)
        {
            string[] accidentLines = File.ReadAllLines(Path.Combine(mainForm.pythonDirectory, "accidents.csv"));
            string[] vehicleLines = File.ReadAllLines(Path.Combine(mainForm.pythonDirectory, "vehicles.csv"));

            for (int i = 1; i < accidentLines.Length; i++)
            {
                string[] values = accidentLines[i].Split(';');

                InsertDirectoryValue(connection, "AccidentTypes", "AccidentTypeID", values[5], accidentTypes);
                InsertDirectoryValue(connection, "Districts", "DistrictID", values[6], districts);
                InsertDirectoryValue(connection, "WeatherConditions", "WeatherConditionID", values[7], weatherConditions);
                InsertDirectoryValue(connection, "RoadStates", "RoadStateID", values[8], roadStates);
                InsertDirectoryValue(connection, "LightingConditions", "LightingConditionID", values[9], lightingConditions);
            }

            for (int i = 1; i < vehicleLines.Length; i++)
            {
                string[] values = vehicleLines[i].Split(';');

                InsertDirectoryValue(connection, "VehicleTypes", "VehicleTypeID", values[2], vehicleTypes);
                InsertDirectoryValue(connection, "VehicleModels", "VehicleModelID", values[4], vehicleModels);
                InsertDirectoryValue(connection, "OwnershipTypes", "OwnershipTypeID", values[5], ownershipTypes);
                InsertDirectoryValue(connection, "Colors", "ColorID", values[6], colors);
                InsertDirectoryValue(connection, "DriveTypes", "DriveTypeID", values[7], driveTypes);
                InsertDirectoryValue(connection, "HitAndRunStatuses", "HitAndRunStatusID", values[8], hitAndRunStatuses);
            }
        }

        private static void InsertDirectoryValue(SQLiteConnection connection, string tableName, string idColumn, string value, Dictionary<string, int> cache)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            if (cache.ContainsKey(value))
            {
                return;
            }

            string insertSql = $"INSERT OR IGNORE INTO {tableName}(Name) VALUES(@value)";

            SQLiteCommand insertCommand = new SQLiteCommand(insertSql, connection);

            insertCommand.Parameters.AddWithValue("@value", value);

            insertCommand.ExecuteNonQuery();

            string selectSql = $"SELECT {idColumn} FROM {tableName} WHERE Name=@value";

            SQLiteCommand selectCommand = new SQLiteCommand(selectSql, connection);

            selectCommand.Parameters.AddWithValue("@value", value);

            int id = Convert.ToInt32(selectCommand.ExecuteScalar());

            cache[value] = id;
        }

        private static void ImportAccidents(SQLiteConnection connection)
        {
            string[] lines = File.ReadAllLines(Path.Combine(mainForm.pythonDirectory, "accidents.csv"));

            string sql = @"
            INSERT INTO Accidents
            (
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
            VALUES
            (
                @AccidentID,
                @Date,
                @Time,
                @Latitude,
                @Longitude,
                @AccidentTypeID,
                @DistrictID,
                @WeatherConditionID,
                @RoadStateID,
                @LightingConditionID,
                @VehicleCount,
                @ParticipantCount,
                @DeadCount,
                @InjuredCount
            )";

            SQLiteCommand command = new SQLiteCommand(sql, connection);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(';');

                command.Parameters.Clear();

                command.Parameters.AddWithValue("@AccidentID", ParseInt(values[0]));
                command.Parameters.AddWithValue("@Date", values[1]);
                command.Parameters.AddWithValue("@Time", values[2]);
                command.Parameters.AddWithValue("@Latitude", ParseDouble(values[3]));
                command.Parameters.AddWithValue("@Longitude", ParseDouble(values[4]));

                command.Parameters.AddWithValue("@AccidentTypeID", GetId(accidentTypes, values[5]));
                command.Parameters.AddWithValue("@DistrictID", GetId(districts, values[6]));
                command.Parameters.AddWithValue("@WeatherConditionID", GetId(weatherConditions, values[7]));
                command.Parameters.AddWithValue("@RoadStateID", GetId(roadStates, values[8]));
                command.Parameters.AddWithValue("@LightingConditionID", GetId(lightingConditions, values[9]));

                command.Parameters.AddWithValue("@VehicleCount", ParseInt(values[10]));
                command.Parameters.AddWithValue("@ParticipantCount", ParseInt(values[11]));
                command.Parameters.AddWithValue("@DeadCount", ParseInt(values[12]));
                command.Parameters.AddWithValue("@InjuredCount", ParseInt(values[13]));

                command.ExecuteNonQuery();
            }
        }

        private static void ImportVehicles(SQLiteConnection connection)
        {
            string[] lines = File.ReadAllLines(Path.Combine(mainForm.pythonDirectory, "vehicles.csv"));

            string sql = @"
            INSERT INTO Vehicles
            (
                AccidentID,
                VehicleNumber,
                VehicleTypeID,
                VehicleModelID,
                OwnershipTypeID,
                ColorID,
                DriveTypeID,
                HitAndRunStatusID,
                Year,
                TechnicalIssues
            )
            VALUES
            (
                @AccidentID,
                @VehicleNumber,
                @VehicleTypeID,
                @VehicleModelID,
                @OwnershipTypeID,
                @ColorID,
                @DriveTypeID,
                @HitAndRunStatusID,
                @Year,
                @TechnicalIssues
            )";

            SQLiteCommand command = new SQLiteCommand(sql, connection);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(';');

                command.Parameters.Clear();

                command.Parameters.AddWithValue("@AccidentID", ParseInt(values[0]));
                command.Parameters.AddWithValue("@VehicleNumber", ParseInt(values[1]));

                command.Parameters.AddWithValue("@VehicleTypeID", GetId(vehicleTypes, values[2]));
                command.Parameters.AddWithValue("@VehicleModelID", GetId(vehicleModels, values[4]));
                command.Parameters.AddWithValue("@OwnershipTypeID", GetId(ownershipTypes, values[5]));
                command.Parameters.AddWithValue("@ColorID", GetId(colors, values[6]));
                command.Parameters.AddWithValue("@DriveTypeID", GetId(driveTypes, values[7]));
                command.Parameters.AddWithValue("@HitAndRunStatusID", GetId(hitAndRunStatuses, values[8]));
                command.Parameters.AddWithValue("@TechnicalIssues", values[9]);
                command.Parameters.AddWithValue("@Year", ParseInt(values[3]));

                command.ExecuteNonQuery();
            }
        }

        private static object GetId(Dictionary<string, int> dictionary, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return DBNull.Value;
            }

            int id;

            if (dictionary.TryGetValue(value, out id))
            {
                return id;
            }

            return DBNull.Value;
        }

        private static object ParseInt(string value)
        {
            int result;

            if (int.TryParse(value, out result))
            {
                return result;
            }

            return DBNull.Value;
        }

        private static object ParseDouble(string value)
        {
            double result;

            if (double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }

            return DBNull.Value;
        }
    }
}