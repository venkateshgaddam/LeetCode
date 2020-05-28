using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LeetCode.Models;

namespace ServerlessApp.Pages
{
    public class EditMovieModel : PageModel
    {
        public int Movie_Id { get; set; }
        public string MovieName { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string Producer { get; set; }
        public Actors actor { get; set; }
        public void OnGet()
        {

        }
    }
}