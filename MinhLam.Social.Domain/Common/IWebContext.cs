using System;

namespace MinhLam.Social.Domain.Common
{
    public interface IWebContext
    {
        bool IsLoggedIn { get; set; }
        string Username { get; set; }
        SharedAccountProfile CurrentUser { get; set; }
        string UsernameToVerify { get; }
        bool ShowGravatar { get; }
        Guid AccountId { get; }
        string RootUrl { get; }
    }
}
