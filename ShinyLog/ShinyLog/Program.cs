using ShinyLog.Database;

namespace ShinyLog
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            BuildDatabase.Instance.CreateDatabase();
            Application.Run(new ShinyLog());
        }
    }
}