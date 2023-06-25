using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectfinalIteration.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; }
      
        public virtual ICollection<BassGuitar> BassGuitars { get; set; }
    }
}