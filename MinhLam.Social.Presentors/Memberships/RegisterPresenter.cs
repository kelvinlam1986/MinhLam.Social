using MinhLam.Framework;
using MinhLam.Social.Application.Memberships;
using System;

namespace MinhLam.Social.Presentors.Memberships
{
    public class RegisterPresenter
    {
        private IAccountService accountService;
        private ITermQuery termQuery;
        private IRegisterView view;

        public RegisterPresenter(
            IAccountService accountService,
            ITermQuery termQuery)
        {
            this.accountService = accountService;
            this.termQuery = termQuery;
        }

        public void Init(IRegisterView view)
        {
            this.view = view;
            var currentTerm = this.termQuery.GetCurentTerm();
            view.LoadTerms(currentTerm);
        }

        public void Register(
            string username, 
            string password,
            string firstName,
            string lastName,
            string email,
            string zip,
            string birthDate,
            bool isCapchaValid,
            bool agreesWithTerms,
            string termId)
        {
            if (agreesWithTerms)
            {
                if (isCapchaValid)
                {
                    try
                    {
                        var registerCommand = new RegisterCommand(
                               username,
                               password,
                               email,
                               firstName,
                               lastName,
                               birthDate,
                               zip,
                               termId);
                        this.accountService.Handle(registerCommand);
                        this.view.ShowAccountCreatedPanel();
                    }
                    catch (ApplicationServiceException e)
                    {
                        this.view.ShowErrorMessage(e.Message);
                        switch (e.Code)
                        {
                            case MembershipAppExceptionCodes.UserAlreadyExistWithEmail:
                            case MembershipAppExceptionCodes.UserAlreadyExistWithUserName:
                            case MembershipAppExceptionCodes.SystemException:
                                this.view.ToggleWizardIndex(0);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        this.view.ShowErrorMessage("System has some wrong operation. Please contact administrator");
                        this.view.ToggleWizardIndex(0);
                    }
                }
                else
                {
                    this.view.ShowErrorMessage("Your entry doesn't match the reCAPTCHA image.  Please try again.");
                }    
            }
            else
            {
                this.view.ToggleWizardIndex(2);
                this.view.ShowErrorMessage("You cannot create an account on this site if you don't agree with our terms");
            }

        }

    }
}