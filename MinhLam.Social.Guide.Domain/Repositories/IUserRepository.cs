using MinhLam.Social.Guide.Domain.Models;

namespace MinhLam.Social.Guide.Domain.Repositories
{
    public interface IUserRepository
    {
        bool Has(string username);
        User ByUserName(string username);
    }
}
