using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode.Models
{
    public class Movie
    {
        public Movie()
        {
            Movie_Id = 0;
            MovieName = "";
            Producer = "";
            DateOfRelease = DateTime.Now.Date;
            actor = new Actors();

        }

        public int Movie_Id { get; set; }
        public string MovieName { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string Producer { get; set; }
        public Actors actor { get; set; }

    }
}
