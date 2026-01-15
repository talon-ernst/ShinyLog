using ShinyLog.Database.Tables;
using SQLite;

namespace ShinyLog.Database
{
    public class DatabaseManager
    {            
        private readonly string _folderPath = string.Empty;
        private readonly string _databasePath = string.Empty;

        private static readonly Lazy<DatabaseManager> _instance =
            new(() => new DatabaseManager());

        public static DatabaseManager Instance => _instance.Value;

        private DatabaseManager()
        {
            _folderPath = FileManager.EnsureDBPathExists(Constants.AppDataFolder);
            _databasePath = Path.Combine(_folderPath, Constants.DatabaseName);
        }

        public void CreateDatabase()
        {
            using var dbConnection = GetDatabaseConnection();
            dbConnection.EnableWriteAheadLogging();
            dbConnection.CreateTable<Hunt>();
        }

        private SQLiteConnection GetDatabaseConnection()
        {
            SQLiteConnection dbConnection;
            try
            {
                dbConnection = new SQLiteConnection(_databasePath);             
            }
            catch (Exception ex) 
            {
                throw new Exception($"Failed to open a connection to the database: {_databasePath}", ex);
            }
            return dbConnection;
        }  
    }
}