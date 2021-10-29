using MinhLam.Framework;
using System;

namespace MinhLam.Social.Domain.Profiles
{
    public interface IProfileRepository : IRepositoryBase<Profile>
    {
        Profile GetCurrentProfileIncludeAttributes(Guid id);
    }
}
