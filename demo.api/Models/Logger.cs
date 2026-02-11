namespace demo.api.Models
{
    public static class Logger
    {

        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");

        public static void Log(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
