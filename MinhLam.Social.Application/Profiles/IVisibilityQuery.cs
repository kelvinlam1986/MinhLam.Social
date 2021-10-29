using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public interface IVisibilityQuery
    {
        List<GetVisibilityListReadModel> GetVisibilities();
    }
}
