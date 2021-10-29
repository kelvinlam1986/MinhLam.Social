using MinhLam.Framework;
using MinhLam.Social.Application;
using MinhLam.Social.Application.Memberships;
using MinhLam.Social.Domain.Common;

namespace MinhLam.Social.Presentors.Memberships
{
    public class EditAccountPresenter
    {
        private IAccountService accountService;
        private IEditAccountView view;
        private IUserSession userSession;
        private IRedirector redirector;

        public EditAccountPresenter(
            IAccountService accountService,
            IUserSession userSession,
            IRedirector redirector)
        {
            this.accountService = accountService;
            this.userSession = userSession;
            this.redirector = redirector;
        }

        public void Init(IEditAccountView view, bool isPostBack)
        {
            this.view = view;
            if (userSession.CurrentUser == null)
            {
                this.redirector.GoToAccountLoginPage();
            }

            if (isPostBack == false)
            {
                LoadCurrentUser();
            }
        }

        private void LoadCurrentUser()
        {
            this.view.LoadCurrentInformation(this.userSession.CurrentUser);
        }

        public void UpdateAccount(
            string oldPassword,
            string newPassword,
            string username,
            string firstName,
            string lastName,
            string email,
            string zipCode,
            string birthDate)
        {
            try
            {
                var updateAccountCommand = new UpdateAccountCommand(
                    oldPassword, 
                    newPassword,
                    username,
                    firstName,
                    lastName,
                    email,
                    zipCode,
                    birthDate);
                this.accountService.Handle(updateAccountCommand);
                this.view.ShowMessage(true, "Your account has been updated!", username);
            }
            catch (ApplicationServiceException e)
            {
                this.view.ShowMessage(false, e.Message, username);
            }
        }

    }
}
