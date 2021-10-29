using System;
using System.Configuration;

namespace MinhLam.Framework
{
    public static class Connection
    {
        public static string GetConnectionString(string name)
        {
            var connectionSettings = ConfigurationManager.ConnectionStrings[name];
            if (connectionSettings == null || string.IsNullOrEmpty(connectionSettings.ConnectionString))
            {
                throw new InvalidOperationException($"Cannot get connection string to database with connection name {name}");
            }

            return connectionSettings.ConnectionString;
        }
    }
}
