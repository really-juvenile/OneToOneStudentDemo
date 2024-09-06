using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneToOneStudentDemo.Models
{
    public class GmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string email = value.ToString();
                if (email.Contains("gmail"))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Email should be of gmail domain only");
        }
    }
}