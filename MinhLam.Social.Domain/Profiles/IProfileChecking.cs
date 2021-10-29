using System;

namespace MinhLam.Social.Domain.Profiles
{
    public interface IProfileChecking
    {
        bool ExistWithId(Guid id);
    }
}
