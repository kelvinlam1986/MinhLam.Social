using System;
using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public interface IProfileQuery
    {
        GetCurrentProfileReadModel GetCurrentProfile(string username);
        bool ShouldShowAttribute(Guid privacyFlagTypeId, 
            List<GetPrivacyFlagListByProfileReadModel> profileFlags);
    }
}
