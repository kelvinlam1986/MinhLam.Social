using MinhLam.Framework;
using MinhLam.Social.Application.Memberships;

namespace MinhLam.Social.Presentors.Memberships
{
    public class RecoverPasswordPresenter
    {
        private IAccountService accountService;
        private IRecoverPasswordView view;

        public RecoverPasswordPresenter(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public void Init(IRecoverPasswordView view)
        {
            this.view = view;
        }

        public void RecoverPassword(string email)
        {
            try
            {
                var recoverPasswordCommand = new RecoverPasswordCommand(email);
                this.accountService.Handle(recoverPasswordCommand);
                this.view.ShowRecoverPasswordPanel(false);
                this.view.ShowMessage("An email was sent to your account!");
            }
            catch (ApplicationServiceException e)
            {
                this.view.ShowRecoverPasswordPanel(true);
                this.view.ShowMessage(e.Message);
            }
        }
    }
}
