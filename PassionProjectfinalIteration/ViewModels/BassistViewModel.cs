using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectfinalIteration.ViewModels
{
    public class BassistViewModel
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Years of experience must be a non-negative value.")]
        public int YearsOfExperience { get; set; }
    }
}