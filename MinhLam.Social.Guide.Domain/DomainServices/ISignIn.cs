using MinhLam.Social.Guide.Domain.Models;

namespace MinhLam.Social.Guide.Domain.DomainServices
{
    public interface ISignIn
    {
        User Execute(string username, string password);
    }
}
