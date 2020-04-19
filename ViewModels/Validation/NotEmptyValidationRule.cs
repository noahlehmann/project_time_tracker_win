using System.Globalization;
using System.Windows.Controls;

namespace ProjectTimeTrackerWPF.ViewModels.Validation
{
    class NotEmptyValidationRule : ValidationRule
    {

        public NotEmptyValidationRule() { }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = (string)value;
            if(input == null || input.Length == 0 || input == string.Empty)
            {
                return new ValidationResult(false, null);
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
