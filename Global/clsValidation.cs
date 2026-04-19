using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sawa_Store_Project
{
    public class clsValidation
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var pattern = @"^[a-zA-Z0-9.\+\-]+@gmail\.com$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);

        }
        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Text)
        {
            return (ValidateFloat(Text) || ValidateInteger(Text));
        }

        /// <summary>
        /// This method use a BitArray to track whether a password has an uppercase letter,
        /// a lowercase letter, a digit, and a special character.
        /// 
        /// </summary>
        /// <param name="Password"></param>
        /// <returns>
        /// Returns Tuple data type Item1 : if the password strong or not Item2: How much is it strong
        /// </returns>
        public static (bool Strength, string Message) PasswordStrengthChecker(string Password, short PasswordLength = 4)
        {
            bool IsStrength = false;
            string Message = "";

            BitArray passwordStrength = new BitArray(4, false);

            foreach (char c in Password)
            {
                if (char.IsUpper(c)) passwordStrength[0] = true;
                else if (char.IsLower(c)) passwordStrength[1] = true;
                else if (char.IsDigit(c)) passwordStrength[2] = true;
                else if (char.IsLetterOrDigit(c) || "!@#$%^&*()-_+=".Contains(c)) passwordStrength[3] = true;
            }

            int countFactors = 0;

            for (int i = 0; i < passwordStrength.Length; i++)
            {
                if (passwordStrength[i])
                    countFactors++;
            }


            if (countFactors <= 2)
            {
                IsStrength = false;
                Message = "weak";
            }
            else if (countFactors == 3)
            {
                IsStrength = true;
                Message = "good";
            }
            else if (countFactors > 3)
            {
                IsStrength = true;
                Message = "strong";
            }

            if (Password.Length < PasswordLength)
            {
                IsStrength = false;
                Message = "weak"; 
            }

            return (IsStrength, Message);
        }

    }
}
