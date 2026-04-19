using System;
using System.Configuration;
namespace SawaStore_DataAccessLayer
{
    public static class clsDataAccessSettings
    {
        public static string ConnectionString
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings["SawaStoreConnectionString"]?.ConnectionString;

                if (string.IsNullOrWhiteSpace(cs))
                    throw new InvalidOperationException("Connection string 'SawaStoreConnectionString' is not configured in App.config.");

                return cs;
            }
        }
    }
}
