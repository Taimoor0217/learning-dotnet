using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Genre { get; set; }

        public string ResleaseDate { get; set; }

        public string DateAdded { get; set; }

        public int NumberInStock { get; set; }
    }
}