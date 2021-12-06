using PartTrader.API.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartTrader.API.Helpers.Validations
{
    public class PartsCodeCustomValidation : ValidationAttribute
    {
        /// <summary>
        /// validation of code of PartNumber
        /// partCode;
        //  partCode   = {4 * alphanumeric}, {alphanumeric};
        //  
        /// </summary>
        /// <param name="value"></param>
        /// <returns>ValidationResult Success if value it's OK, error message if not </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            try
            {
                string valueToCheck = (string)value;
         
                //check lenght of partCode >= 4
                if (valueToCheck.Length < 4)
                {
                    return new ValidationResult("Part Code lenght is not valid, should be at least 4 alphanumeric characters");
                }

                //partCode can't be only numbers
                int intPartCode;
                if (Int32.TryParse(valueToCheck, out intPartCode))
                {
                    return new ValidationResult("Part Code can't be only numbers");
                }

                return ValidationResult.Success;

            }
            catch (Exception ex)
            {

                return new ValidationResult(ex.Message);

            }


        }
    }
}



