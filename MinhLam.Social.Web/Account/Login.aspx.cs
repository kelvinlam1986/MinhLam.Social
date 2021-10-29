using MinhLam.Framework;
using MinhLam.Social.Application;
using MinhLam.Social.Application.Memberships;
using MinhLam.Social.Presentors.Memberships;
using Ninject;
using System;

namespace MinhLam.Social.Web.Account
{
    public partial class Login : System.Web.UI.Page, ILoginView
    {
        private LoginPresenter presenter;
        
        [Inject]
        public IAccountService AccountService { get; set; }
        [Inject]
        public IRedirector Redirector { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.presenter = new LoginPresenter(AccountService, Redirector);
            string encryptName =  Cryptography.Encrypt("kelvinlam", "verify");
            this.presenter.Init(this);
        }

        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            this.presenter.Login(txtUsername.Text, txtPassword.Text);
        }

        protected void lbRegister_Click(object sender, EventArgs e)
        {
            this.presenter.GoToRegister();
        }

        protected void lbRecoverPassword_Click(object sender, EventArgs e)
        {
            this.presenter.GoToRecoverPassword();
        }
    }
}