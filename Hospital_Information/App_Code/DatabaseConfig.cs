using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>
namespace Hospital_Information
{
    public class DatabaseConfig
    {
        #region Constructor

        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        public static String ConnectionString = ConfigurationManager.ConnectionStrings["HospitalInformation"].ConnectionString;

    }
}