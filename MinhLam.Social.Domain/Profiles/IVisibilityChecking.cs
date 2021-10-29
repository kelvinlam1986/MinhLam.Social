using System;

namespace MinhLam.Social.Domain.Profiles
{
    public interface IVisibilityChecking
    {
        bool ExistWithId(Guid id);
    }
}
