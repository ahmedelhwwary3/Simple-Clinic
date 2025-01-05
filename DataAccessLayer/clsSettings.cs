using System;
using System.Configuration;
 

namespace DataAccessLayer
{
    public class clsSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;











    }
}
