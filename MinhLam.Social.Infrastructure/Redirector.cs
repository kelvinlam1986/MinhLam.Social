using MinhLam.Social.Application;
using System.Web;

namespace MinhLam.Social.Infrastructure
{
    public class Redirector : IRedirector
    {
        public void GoToAccountLoginPage()
        {
            Redirect("~/Account/Login.aspx");
        }

        public void GoToAccountRecoverPasswordPage()
        {
            Redirect("~/Account/RecoverPassword.aspx");
        }

        public void GoToAccountRegisterPage()
        {
            Redirect("~/Account/Register.aspx");
        }

        public void GoToHomePage()
        {
            Redirect("~/Default.aspx");
        }

        public void GoToProfilesDefault()
        {
            Redirect("~/Profiles/Default.aspx");
        }

        public void GoToProfilesManageProfile()
        {
            Redirect("~/Profiles/ManageProfile.aspx");
        }

        public void GoToProfilesProfile()
        {
            Redirect("~/Profiles/Profile.aspx");
        }

        private void Redirect(string path)
        {
            HttpContext.Current.Response.Redirect(path);
        }
    }
}
