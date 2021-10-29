using System;
using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public interface IPrivacyFlagQuery
    {
        List<GetPrivacyFlagListByProfileReadModel> GetPrivacyFlagsByProfile(Guid profileId); 
    }
}
