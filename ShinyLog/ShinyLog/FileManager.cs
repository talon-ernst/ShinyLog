namespace ShinyLog
{
    public static class FileManager
    {
        public static string EnsureDBPathExists(string fileName)
        {
            string _folderPath = Path.Combine(Environment.GetFolderPath
               (Environment.SpecialFolder.ApplicationData), fileName);

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            return _folderPath;
        }
    }
}