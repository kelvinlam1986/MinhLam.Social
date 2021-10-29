using MinhLam.Framework;
using MinhLam.Social.Application.Memberships;
using MinhLam.Social.Domain.Common;
using System;

namespace MinhLam.Social.Presentors.Memberships
{
    public class VerifyEmailPresenter
    {
        private IAccountService accountService;
        private IVerifyEmailView view;
        private IWebContext webContext;

        public VerifyEmailPresenter(
            IAccountService accountService,
            IWebContext webContext)
        {
            this.accountService = accountService;
            this.webContext = webContext;
        }

        public void Init(IVerifyEmailView view)
        {
            this.view = view;
            try
            {
                string username = Cryptography.Decrypt(this.webContext.UsernameToVerify, "verify");
                var verifyEmailCommand = new VerifyEmailCommand(username);
                this.accountService.Handle(verifyEmailCommand);
                this.view.ShowMessage("Your email address has been successfully verified!");
            }
            catch (ApplicationServiceException e)
            {
                this.view.ShowMessage(e.Message);
            }
            catch (Exception e)
            {
                this.view.ShowMessage("There appears to be something wrong " +
                    "with your verification link! Please try again.If " +
                    "you are having issues by clicking on the link, please " +
                    "try copying the URL from your email and pasting it " +
                    "into your browser window.");
            }
        }
    }
}
