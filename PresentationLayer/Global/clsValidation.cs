using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PresentationLayer.Global
{
    public class clsValidation
    {
        public static bool IsValidEmail(string Email)
        {
           string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

             
            return Regex.IsMatch(Email, emailRegex, RegexOptions.IgnoreCase); ;
        }

        public static bool IsValidNumber(string Number)
        {
            for(int i=0;i<Number.Length;i++)
            {
                if (!char.IsDigit(Number[i]))
                {
                    return false;
                }
            }
            return true;
        }





    }
}
