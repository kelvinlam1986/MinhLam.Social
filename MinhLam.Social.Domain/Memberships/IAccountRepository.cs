using MinhLam.Framework;

namespace MinhLam.Social.Domain.Memberships
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Account GetAccountByUsername(string username);
        Account GetAccountByEmail(string email);
    }
}
