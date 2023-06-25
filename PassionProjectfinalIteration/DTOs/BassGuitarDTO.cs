using System.ComponentModel.DataAnnotations;

namespace PassionProjectfinalIteration.Models
{
    public class BassGuitarDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [Range(4, 6, ErrorMessage = "Number of strings must be between 4 and 6.")]
        public int NumberOfStrings { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Manufacturer is required.")]
        public string Manufacturer { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }

        //data needed for keeping track of bassguitar images uploaded
        //images deposited into /Content/Images/BassGuitar/{id}.{extension}
        public bool BassGuitarHasPic { get; set; }
        public string PicExtension { get; set; }
    }
}