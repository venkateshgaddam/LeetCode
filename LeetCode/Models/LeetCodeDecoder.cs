using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Models
{
    public class LeetCodeDecoder
    {
        public LeetCodeDecoder()
        {
            No_of_ways = 0;
            Combinations.Add("");
        }
        public int No_of_ways { get; set; }

        public List<string> Combinations { get; set; } = new List<string>();
    }
}
