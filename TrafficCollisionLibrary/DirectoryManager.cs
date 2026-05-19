using System.Data;
using System.Data.SQLite;
using Анализ_данных_о_ДТП;

namespace Анализ_данных_о_ДТП
{
    public static class DirectoryManager
    {
        public static DataTable GetDirectoryTable(string tableName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseManager.connectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM {tableName}";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
        public static void UpdateDirectory(DataTable table, string tableName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DatabaseManager.connectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM {tableName}";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, connection);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
                adapter.Update(table);
            }
        }
    }
}