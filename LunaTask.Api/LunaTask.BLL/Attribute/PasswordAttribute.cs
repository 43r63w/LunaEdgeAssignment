using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LunaTask.BLL.Attribute
{
    public class PasswordAttribute : ValidationAttribute
    {
        private readonly string _pattern;

        public PasswordAttribute(string pattern = @"[!@#$%^&*(),.?""':{}|<>]")
        {
            _pattern = pattern;
            ErrorMessage = "Password must contain at least one special character";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var stringValue = value as string;

            if (Regex.IsMatch(stringValue, _pattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
