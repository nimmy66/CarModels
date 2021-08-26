using System;
using System.ComponentModel.DataAnnotations;

namespace CarModels.Models
{
    public class Car
    {
        

        public int id { get; set; }
        [Required(ErrorMessage="Enter car Model")]
        [Display(Name ="Car Model")]
        public string CarModel { get; set; }

        [Required(ErrorMessage="Enter Brand")]
        [Display(Name ="Brand")]
        public string Brand { get; set; }

    }
}
