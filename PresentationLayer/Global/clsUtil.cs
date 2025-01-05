using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Global
{
    public class clsUtil
    {
        public static string ConvertToShortDateString(DateTime longDate)
        {
            // Format as "MM/dd/yyyy" or modify as needed for your locale
            return longDate.ToString("MM/dd/yyyy");
        }








    }
}
