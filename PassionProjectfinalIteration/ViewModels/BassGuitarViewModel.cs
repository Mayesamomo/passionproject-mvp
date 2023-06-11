using PassionProjectfinalIteration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectfinalIteration.ViewModels
{
    public class BassGuitarViewModel
    {
        public string Color { get; set; }

        [Range(4, 6, ErrorMessage = "Number of strings must be between 4 and 6.")]
        public int NumberOfStrings { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public IEnumerable<Category> AvailableCategories { get; set; }
    }
}
