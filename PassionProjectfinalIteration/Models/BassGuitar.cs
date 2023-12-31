﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassionProjectfinalIteration.Models
{
    public class BassGuitar
    {
        [Key] // Primary key
        public int ID { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [Range(4, 6, ErrorMessage = "Number of strings must be between 4 and 6.")]
        public int NumberOfStrings { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Manufacturer is required.")]
        public string Manufacturer { get; set; }
        //property for image path
       
        // BassGuitar and Category have a 1-M relationship (one category can have multiple bass guitars).
        [ForeignKey("Category")] // Foreign key 
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        // BassGuitar and Bassist have a 1-M relationship (one bassist can own multiple bass guitars).
        [ForeignKey("Owner")]
        public int OwnerID { get; set; }
        public virtual Bassist Owner { get; set; }

        //data needed for keeping track of bassguitar images uploaded
        //images deposited into /Content/Images/BassGuitar/{id}.{extension}
        public bool BassGuitarHasPic { get; set; }
        public string PicExtension { get; set; }
        
    }
}
