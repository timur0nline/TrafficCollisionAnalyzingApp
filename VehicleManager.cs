using System.Data;
using System.Data.SQLite;

namespace Анализ_данных_о_ДТП
{
    public static class VehicleManager
    {
        public static SQLiteDataAdapter adapter;
        public static DataTable GetVehiclesTable()
        {
            SQLiteConnection connection = new SQLiteConnection(DatabaseManager.connectionString);
            connection.Open();
            string sql = @"
            SELECT
                VehicleID,
                AccidentID,
                VehicleNumber,
                VehicleTypeID,
                Year,
                VehicleModelID,
                OwnershipTypeID,
                ColorID,
                DriveTypeID,
                HitAndRunStatusID,
                TechnicalIssues
            FROM Vehicles";

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
