using LeetCode.Models;
using System;
using System.IO;

namespace LeetCode.DAL
{
    public sealed class Logs
    {
        //private static readonly IOptions<clsConfig> appSettings;
        //public Logs(IOptions<clsConfig> options)
        //{
        //    appSettings = options;
        //}
        private static Logs instance;
        private static readonly object padlock = new object();
        static string filePath = AWSConstants._filePath;
        //string path = ConfigurationManager.AppSettings["Path"].ToString();
        int logLevel = AWSConstants._logLevel;

        /// <summary>
        /// Singleton class to create an instance of Logs and also creates the Directory for Storing the Log Files.
        /// </summary>
        public static Logs Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Logs();
                        if (!Directory.Exists(filePath))
                        {
                            DirectoryInfo d = new DirectoryInfo(filePath);
                            d.Create();
                        }
                    }
                }
                return instance;
            }

        }

        /// <summary>
        /// Method to Log all the Log Mesages 
        /// </summary>
        /// <param name="message">Message to be printed in the LOG</param>
        /// <param name="level">Level of Log</param>
        public void Log(string message, string level)
        {
            string levelName;
            using (StreamWriter writer = new StreamWriter(AWSConstants.path, true))
            {
                if ((logLevel <= int.Parse(level)) && (logLevel != 0))
                {
                    levelName = Enum.GetName(typeof(AWSConstants.LogLevels), Convert.ToInt32(level));
                    writer.WriteLine(levelName + "\t" + DateTime.Now + "\t" + message);
                }
            }
        }
    }
}
