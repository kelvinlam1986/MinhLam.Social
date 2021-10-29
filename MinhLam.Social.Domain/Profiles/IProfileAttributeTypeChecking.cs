using System;

namespace MinhLam.Social.Domain.Profiles
{
    public interface IProfileAttributeTypeChecking
    {
        bool ExistWithId(Guid id);
    }
}
