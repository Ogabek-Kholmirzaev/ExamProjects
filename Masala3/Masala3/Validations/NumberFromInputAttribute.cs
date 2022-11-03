using System.ComponentModel.DataAnnotations;

namespace Masala3.Validations
{
    public class NumberFromInputAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var numberString = (string)value!;

            if (string.IsNullOrEmpty(numberString))
            {
                ErrorMessage = "Integer kiriting!";
                return false;
            }

            var isSuccess = int.TryParse(numberString, out var number);

            if (!isSuccess)
            {
                ErrorMessage = "Integer kiriting!";
                return false;
            }

            if (number < 0)
            {
                ErrorMessage = "Noldan katta son kiriting!";
                return false;
            }

            return true;
        }
    }
}
