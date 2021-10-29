using System;

namespace MinhLam.Social.Guide.Framework
{
    public interface IConfiguration
    {
        string GetConfigurationSetting(Type expectedType, string key);
    }
}
