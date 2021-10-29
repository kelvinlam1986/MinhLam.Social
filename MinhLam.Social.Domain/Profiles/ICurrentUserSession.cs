using System;

namespace MinhLam.Social.Domain.Profiles
{
    public interface ICurrentUserSession
    {
        Guid GetAccountIdByUsername(string username);
    }
}
