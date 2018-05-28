using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class NumberInStockRange:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;

            return (movie.NumberInStock > 0 && movie.NumberInStock < 21)
                ? ValidationResult.Success
                : new ValidationResult("Number in stock should be in range [1,20]");


        }
    }
}