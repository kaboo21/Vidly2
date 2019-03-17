using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class NumbeAvailableRange:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            return (movie.NumberAvailable > 0 && movie.NumberAvailable < movie.NumberInStock)
                ? ValidationResult.Success
                : new ValidationResult($"Availavle number should be in range [1, {movie.NumberInStock}]");


        }
    }
    
}