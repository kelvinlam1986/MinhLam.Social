using MinhLam.Social.Domain.Memberships;

namespace MinhLam.Social.Infrastructure.Memberships
{
    public class AccountCheckExisting : IAccountCheckExisting
    {
        private IAccountRepository accountRepository;

        public AccountCheckExisting(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public bool ExistWithEmail(string email)
        {
            var user = this.accountRepository.GetAccountByEmail(email);
            return user != null;
        }

        public bool ExistWithUserName(string username)
        {
            var user = this.accountRepository.GetAccountByUsername(username);
            return user != null;
        }
    }
}
