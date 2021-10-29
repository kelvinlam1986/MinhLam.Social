using MinhLam.Social.Application.Memberships;
using MinhLam.Social.Presentors.Memberships;
using Ninject;
using System;

namespace MinhLam.Social.Web.Account
{
    public partial class RecoverPassword : System.Web.UI.Page, IRecoverPasswordView
    {
        [Inject]
        public IAccountService AccountService { get; set; }
        private RecoverPasswordPresenter recoverPasswordPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            recoverPasswordPresenter = new RecoverPasswordPresenter(AccountService);
            recoverPasswordPresenter.Init(this);
        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            recoverPasswordPresenter.RecoverPassword(txtEmail.Text);
        }

        public void ShowMessage(string message)
        {
            this.pnlMessage.Visible = true;
            lblMessage.Text = message;
        }

        public void ShowRecoverPasswordPanel(bool isVisible)
        {
            this.pnlRecoverPassword.Visible = isVisible;
        }
    }
}