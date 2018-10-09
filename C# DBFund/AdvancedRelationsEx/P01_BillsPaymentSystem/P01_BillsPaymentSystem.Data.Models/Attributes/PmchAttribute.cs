using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PmchAttribute : ValidationAttribute
    {
        private string pmchTargetAttribute;

        public PmchAttribute(string pmchTargetAttribute)
        {
            this.pmchTargetAttribute = pmchTargetAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var targetAttribute = validationContext.ObjectType
                .GetProperty(pmchTargetAttribute)
                .GetValue(validationContext.ObjectInstance);

            if ((targetAttribute == null && value !=null) || (targetAttribute != null && value ==null))
            {
                return ValidationResult.Success;
            }

            string errorMsg = "Payment method must have only one fund source, either bank account OR credit card!";

            return new ValidationResult(errorMsg);
        }
    }
}
