using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Models
{
    public class clsConfig
    {
        public clsConfig()
        {
            FilePath = "";
            LogLevel = "";
        }
        public string FilePath { get; set; }

        public string LogLevel { get; set; }
    }
}
