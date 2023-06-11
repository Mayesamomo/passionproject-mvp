using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectfinalIteration.Models
{
    public class Bassist
    {
        [Key] //primary key
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")] //error message and validation
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Years of experience must be a non-negative value.")] //validation, must be 0 or more
        public int YearsOfExperience { get; set; }
        //guitar owns by guitarist
        public virtual ICollection<BassGuitar> OwnedGuitars { get; set; }
    }
}