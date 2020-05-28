using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Models
{
    public class Actors
    {
        public Actors()
        {
            Actor_Id = 0;
            ActorName = "";
            MovieName = "";
            Age = 0;
        }

        public int Actor_Id { get; set; }
        public string ActorName { get; set; }
        public string MovieName { get; set; }
        public int Age { get; set; }
    }
}
