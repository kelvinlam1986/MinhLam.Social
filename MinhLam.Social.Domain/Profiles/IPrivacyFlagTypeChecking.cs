using System;

namespace MinhLam.Social.Domain.Profiles
{
    public interface IPrivacyFlagTypeChecking
    {
        bool ExistWithId(Guid id);
    }
}
