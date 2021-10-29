using MinhLam.Social.Application.Profiles;
using System.Collections.Generic;

namespace MinhLam.Social.Presentors.Profiles
{
    public interface IManageProfileView
    {
        void LoadLevelOfExperienceTypes(List<GetLevelOfExperienceTypeListReadModel> listOfLevelExperience);
        void LoadProfileAttributeTypes(List<GetProfileAttributeTypeReadModel> listOfProfileAttributeType);
        void ShowMessage(string message);
        void LoadProfile(GetCurrentProfileReadModel currentProfile);
    }
}
