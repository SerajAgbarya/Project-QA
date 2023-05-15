using System;
using System.ComponentModel.DataAnnotations;
using WebApplication5.Models;
namespace WebApplication5.Models
{
    public class Bird
    {
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Serial Number must contain digits only.")]
        public int SerialNumber { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Species must contain letters only.")]
        public string Species { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Subspecies must contain letters only.")]
        public string Subspecies { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HatchDate { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Cage Number must contain letters and numbers only.")]
        public string CageNumber { get; set; }

        [Required]
        public int MasterSerialNumber { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "If Serial Number must contain digits only.")]
        public int IfSerialNumber { get; set; }
    }

}
