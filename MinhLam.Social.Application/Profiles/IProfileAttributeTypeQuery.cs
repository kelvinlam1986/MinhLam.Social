using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public interface IProfileAttributeTypeQuery
    {
        List<GetProfileAttributeTypeReadModel> GetProfileAttributeTypeReadModelList();
    }
}
