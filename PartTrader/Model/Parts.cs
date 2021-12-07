using PartTrader.API.Helpers.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Model
{
    public class Parts
    {
        [Required(ErrorMessage = "PartId is required")]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Please enter valid Part Id")]
        public string PartId { get; set; }

        [Required(ErrorMessage = "PartCode is required")]
        [PartsCodeCustomValidation]
        public string PartCode { get; set; }

        public string Description { get; set; }
        public Brand Brand { get; set; }
        public List<Parts> CompatibleParts { get; set; }

        //other attributes
        public double Price { get; set; }

    }
}
