using System;

namespace MinhLam.Social.Application.Profiles
{
    public interface IAccountQuery
    {
        GetCurrentAccountReadModel GetCurrentAccount(string username);
        GetCurrentAccountReadModel GetCurrentAccount(Guid id);
    }
}
