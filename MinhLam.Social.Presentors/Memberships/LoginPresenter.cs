using MinhLam.Social.Application;
using MinhLam.Social.Application.Memberships;

namespace MinhLam.Social.Presentors.Memberships
{
    public class LoginPresenter
    {
        private IAccountService accountService;
        private ILoginView loginView;
        private IRedirector redirector;

        public LoginPresenter(
            IAccountService accountService,
            IRedirector redirector)
        {
            this.accountService = accountService;
            this.redirector = redirector;
        }

        public void Init(ILoginView loginView)
        {
            this.loginView = loginView;
        }

        public void Login(string username, string password)
        {
            try
            {
                var loginCommand = new LoginCommand(username, password);
                this.accountService.Handle(loginCommand);
            }
            catch (Framework.ApplicationServiceException e)
            {
                loginView.DisplayMessage(e.Message);
            }
        }

        public void GoToRegister()
        {
            this.redirector.GoToAccountRegisterPage();
        }

        public void GoToRecoverPassword()
        {
            this.redirector.GoToAccountRecoverPasswordPage();
        }
    }
}
