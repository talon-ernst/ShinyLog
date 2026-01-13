using Microsoft.Data.Sqlite;

namespace ShinyLog.Database
{
    public class BuildDatabase
    {            
        private readonly string _folderPath = string.Empty;
        private readonly string _databasePath = string.Empty;

        private SqliteConnection? _dbConnection;

        private static readonly Lazy<BuildDatabase> _instance =
            new(() => new BuildDatabase());

        public static BuildDatabase Instance => _instance.Value;

        private BuildDatabase()
        {
            _folderPath = FileManager.EnsureDBPathExists(Constants.AppDataFolder);
            _databasePath = Path.Combine(_folderPath, Constants.DatabaseName);                          
        }

        public void CreateDatabase()
        {
            if (_dbConnection is null)
            {
                _dbConnection = new SqliteConnection($"Data Source={_databasePath}");
                _dbConnection.Open();
                _dbConnection.Close();
            }
        }
    }
}