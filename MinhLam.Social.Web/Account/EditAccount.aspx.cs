using MinhLam.Social.Application;
using MinhLam.Social.Application.Memberships;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Presentors.Memberships;
using Ninject;
using System;

namespace MinhLam.Social.Web.Account
{
    public partial class EditAccount : System.Web.UI.Page, IEditAccountView
    {
        [Inject]
        public IAccountService AccountService { get; set; }
        [Inject]
        public IUserSession UserSession { get; set; }
        [Inject]
        public IRedirector Redirector { get; set; }

        private EditAccountPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new EditAccountPresenter(AccountService, UserSession, Redirector);
            presenter.Init(this, IsPostBack);
        }

        public void LoadCurrentInformation(SharedAccountProfile currentUserInfo)
        {
            txtBirthDate.Text = currentUserInfo.BirthDate;
            txtEmail.Text = currentUserInfo.Email;
            txtFirstName.Text = currentUserInfo.FirstName;
            txtLastName.Text = currentUserInfo.LastName;
            txtZipCode.Text = currentUserInfo.ZipCode;
            lblUsername.Text = currentUserInfo.UserName;
        }

        public void ShowMessage(bool success, string message, string userName)
        {
            lblMessage.Text = message;
            lblUsername.Text = userName;
            if (success)
            {
                btnSave.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.presenter.UpdateAccount(
                txtOldPassword.Text,
                txtNewPassword.Text,
                UserSession.Username,
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtZipCode.Text,
                txtBirthDate.Text);
        }
    }
}