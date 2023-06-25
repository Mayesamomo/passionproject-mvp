using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectfinalIteration.Models
{
    public class BassistDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Years of experience must be a non-negative value.")]
        public int YearsOfExperience { get; set; }
    }
}