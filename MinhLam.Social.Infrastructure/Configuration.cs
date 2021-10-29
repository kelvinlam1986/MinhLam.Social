using MinhLam.Framework;
using System;
using System.Configuration;

namespace MinhLam.Social.Infrastructure
{
    public class Configuration : IConfiguration
    {
        public object GetConfigurationSetting(Type expectedType, string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);
            if (value == null)
            {
                throw new Exception(string.Format("AppSetting: {0} is not configured.", key));
            }

            try
            {
                if (expectedType.Equals(typeof(int)))
                {
                    return int.Parse(value);
                }

                if (expectedType.Equals(typeof(string)))
                {
                    return value;
                }

                if (expectedType.Equals(typeof(bool)))
                {
                    return Convert.ToBoolean(value);
                }


                throw new Exception("Type not supported.");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Config key:{0} was expected to be of type {1} but was not.", key, expectedType),
                                    ex);
            }
        }
    }
}
