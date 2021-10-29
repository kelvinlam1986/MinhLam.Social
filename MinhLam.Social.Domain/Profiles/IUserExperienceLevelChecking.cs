using System;

namespace MinhLam.Social.Domain.Profiles
{
    public interface IUserExperienceLevelChecking
    {
        bool ExistWithId(Guid id);
    }
}
