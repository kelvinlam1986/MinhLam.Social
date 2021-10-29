using MinhLam.Framework;
using System;
using System.Collections.Generic;

namespace MinhLam.Social.Domain.Profiles
{
    public interface IPrivacyFlagRepository : IRepositoryBase<PrivacyFlag>
    {
        List<PrivacyFlag> GetByProfileId(Guid profileId);
    }
}
