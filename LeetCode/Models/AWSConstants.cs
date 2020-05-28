using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Models
{
    public static class AWSConstants
    {
        public const string _vSecretKey= "lVeDWYYJHSTRiXGE8SlmiLDfWGCEaT8qcRqhiwyk";
        public const string _vAccessKey= "AKIAVDDJYSUOTMADICOA";
        public const string _sSecretKey = "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";
        public const string _sAccessKey= "AKIA23XZGIB6J3545MHV";

        public enum server_types
        {
            RDS=1,
            EC2=2
        }

        public const string _filePath = "C:\\Venky";
        public const int _logLevel = 0;
        public const string linkcommonError = "CommonError.html";
        public static string logKeyOff = "0";
        public static string logKeyDebug = "1";
        public static string logKeyInfo = "2";
        public static string logKeyWarn = "3";
        public static string logKeyError = "4";
        public const string StartMessage = "Display Records class has Started";
        public const string regStartMessage = "buttonclick method has Started ";
        public const string btnclickEndMessage = "buttonclick method has Ended ";
        public const string error = "Error occured";
        public const string endMessage = "Display Registered Records Method Ended";
        public const string datatablesMessage = "binded Gridview data to DataTables";
        public const string exceptionType = "Exception occured & The type is {0}";
        public const string path = "C:\\Users\\gaddamv\\Documents\\Visual Studio 2013\\Projects\\ErrorLog.txt";
        public const string logLevel = "0";
        public const string connectionString = @"Data Source=MD-SATISH2\SQLEXPRESS;Initial Catalog=Form;Integrated Security=True";
        public enum LogLevels
        {
            OFF,
            DEBUG,
            INFO,
            WARN,
            ERROR
        }
    }
}
