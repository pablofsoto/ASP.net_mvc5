using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfaMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId==MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthdayDate == null)
                return new ValidationResult("Birthday is required");

            DateTime zeroTime = new DateTime(1, 1, 1);
            var ageSpan = DateTime.Today - (DateTime)customer.BirthdayDate;
            int age = (zeroTime + ageSpan).Year - 1;

            return (age>=18)? ValidationResult.Success : new ValidationResult("Customer Should be at least 18 years old to go on a membership");
        }
    }
}