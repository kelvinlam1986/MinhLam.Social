using MinhLam.Social.Application.Memberships;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Presentors.Memberships;
using Ninject;
using System;

namespace MinhLam.Social.Web.Account
{
    public partial class VerifyEmail : System.Web.UI.Page, IVerifyEmailView
    {
        [Inject]
        public IAccountService AccountService { get; set; }

        [Inject]
        public IWebContext WebContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var verifyEmailPresenter = new VerifyEmailPresenter(AccountService, WebContext);
            verifyEmailPresenter.Init(this);
        }

        public void ShowMessage(string message)
        {
            lblMsg.Text = message;
        }
    }
}