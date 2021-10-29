using MinhLam.Social.Domain.Memberships;
using System.Linq;

namespace MinhLam.Social.Infrastructure.Memberships
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(SocialContext dbContext) : base(dbContext)
        {
        }

        public Account GetAccountByUsername(string username)
        {
            return this.DbContext.Accounts.FirstOrDefault(x => x.UserName.Value == username);
        }

        public Account GetAccountByEmail(string email)
        {
            return this.DbContext.Accounts.FirstOrDefault(x => x.Email.Value == email);
        }
    }
}
