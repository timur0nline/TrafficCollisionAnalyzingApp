using System.Data;
using System.Data.SQLite;

namespace Анализ_данных_о_ДТП
{
    public static class AccidentManager
    {
        public static SQLiteDataAdapter adapter;
        public static DataTable GetAccidentsTable()
        {
            SQLiteConnection connection = new SQLiteConnection(DatabaseManager.connectionString);
            connection.Open();
            string sql = @"
            SELECT
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
            FROM Accidents";

            adapter = new SQLiteDataAdapter(sql, connection);
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public static void SaveChanges(DataTable table)
        {
            adapter.Update(table);
        }
    }
}
