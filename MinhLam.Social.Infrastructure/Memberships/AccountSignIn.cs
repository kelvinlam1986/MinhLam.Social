using MinhLam.Framework;
using MinhLam.Social.Domain.Memberships;

namespace MinhLam.Social.Infrastructure.Memberships
{
    public class AccountSignIn : IAccountSignIn
    {
        private IAccountRepository accountRepository;
        private ISendEmail sendEmail;

        public AccountSignIn(
            IAccountRepository accountRepository,
            ISendEmail sendEmail)
        {
            this.accountRepository = accountRepository;
            this.sendEmail = sendEmail;
        }

        public void Execute(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException(MembershipExceptionCodes.UsernameIsBlank, "Username cannot empty");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException(MembershipExceptionCodes.PasswordIsBlank, "Password cannot empty");
            }

            var passwordObj = Password.NewFromOriginal(password);
            var hashedPassword = HashedPassword.NewFromOriginalPassword(passwordObj, username);
            var account = accountRepository.GetAccountByUsername(username);
            if (account == null)
            {
                throw new DomainException(MembershipExceptionCodes.UserNotFound, $"Check your username and try again");
            }

            if (account.Password != hashedPassword)
            {
                throw new DomainException(
                    MembershipExceptionCodes.PasswordNotMatch, "Password seems to be incorrect. Please try again");
            }

            if (account.EmailVerified == false)
            {
                this.sendEmail.SendVerificationEmail(account.UserName.Value, account.Email.Value);
                string message = "The login information you provided  was correct " +
                                 "but your email address has not yet " +
                                 "been verified. " +
                                 "We just sent another email" +
                                 "verification email to you.";
                throw new DomainException(
                    MembershipExceptionCodes.EmailNotVerified, message);
            }
        }
    }
}
