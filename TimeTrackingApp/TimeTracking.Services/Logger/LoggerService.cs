using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.Services.Logger
{
    public class LoggerService
    {
        private static string loggerDirPath = @"../../../../loggerDir/";
        public LoggerService()
        {
            if (!Directory.Exists(loggerDirPath))
            {
                Directory.CreateDirectory(loggerDirPath);
            }
        }

        public static void ErrorLog(string error, string source)
        {
            string errorLogPath = $@"{loggerDirPath}/errorLog.txt";
            if (!File.Exists(errorLogPath))
            {
                File.Create(errorLogPath).Close();
            }
            using StreamWriter sw = new StreamWriter(errorLogPath, true);
            sw.WriteLine($@"{DateTime.Now}. ERROR:""{error}"". SOURCE: ""{source}""");
        }

        public static void LoginLog(User user)
        {
            string loginLogPath = $@"{loggerDirPath}/loginLog.txt";
            if (!File.Exists(loginLogPath))
            {
                File.Create(loginLogPath).Close();
            }
            using StreamWriter sw = new StreamWriter(loginLogPath, true);
            sw.WriteLine($"{DateTime.Now}. USERNAME: {user.Username}.");
        }

        public static void RegisterLog()
        {
            string registerLogPath = $@"{loggerDirPath}/registerLog.txt";
            if (!File.Exists(registerLogPath))
            {
                File.Create(registerLogPath).Close();
            }
        }

    }
}
