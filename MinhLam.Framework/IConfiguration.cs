using System;

namespace MinhLam.Framework
{
    public interface IConfiguration
    {
        object GetConfigurationSetting(Type expectedType, string key);
    }
}
