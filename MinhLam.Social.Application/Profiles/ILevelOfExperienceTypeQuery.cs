using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public interface ILevelOfExperienceTypeQuery
    {
        List<GetLevelOfExperienceTypeListReadModel> GetLevelOfExperienceTypeList();
    }
}
