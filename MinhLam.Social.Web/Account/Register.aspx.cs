using MinhLam.Social.Application.Memberships;
using MinhLam.Social.Domain.Memberships;
using MinhLam.Social.Presentors.Memberships;
using Ninject;
using System;
using System.Web.UI.WebControls;

namespace MinhLam.Social.Web.Account
{
    public partial class Register : System.Web.UI.Page, IRegisterView
    {
        private RegisterPresenter registerPresenter;
        
        [Inject]
        public IAccountService AccountService { get; set; }

        [Inject]
        public ITermQuery TermQuery { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            registerPresenter = new RegisterPresenter(AccountService, TermQuery);
            registerPresenter.Init(this);
        }

        protected void wizRegister_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            lblErrorMessage.Text = "";
        }

        protected void wizRegister_ActiveStepChanged(object sender, EventArgs e)
        {
            if (wizRegister.ActiveStepIndex == 1)
            {
                ViewState.Add("password", txtPassword.Text);
            }
        }

        protected void wizRegister_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            this.registerPresenter.Register(
                txtUsername.Text,
                ViewState["password"].ToString(),
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtZipcode.Text,
                txtBirthday.Text,
                true,
                chkAgreeWithTerms.Checked,
                lblTermID.Text);
        }


        public void ShowErrorMessage(string message)
        {
            lblErrorMessage.Text = message;
        }

        public void ShowAccountCreatedPanel()
        {
            pnlAccountCreated.Visible = true;
            pnlCreateAccount.Visible = false;
        }

        public void ShowCreateAccountPanel()
        {
            pnlAccountCreated.Visible = false;
            pnlCreateAccount.Visible = true;
        }

        public void ToggleWizardIndex(int index)
        {
            wizRegister.ActiveStepIndex = index;
        }

        public void LoadTerms(GetCurrentTermReadModel term)
        {
            if (term != null)
            {
                lblTermID.Text = term.TermId.ToString();
                txtTerms.Text = term.Terms;
            }
        }

        public void LoadreCaptchaSetting(bool value)
        {
            throw new NotImplementedException();
        }

        public void LoadEmailAddressFromFriendInvitation(string email)
        {
            txtEmail.Text = email;
        }
    }
}