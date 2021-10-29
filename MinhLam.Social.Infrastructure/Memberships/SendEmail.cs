using MinhLam.Framework;
using MinhLam.Social.Domain.Memberships;

namespace MinhLam.Social.Infrastructure.Memberships
{
    public class SendEmail : ISendEmail
    {
        private IConfiguration configuration;

        public SendEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendPasswordReminder(string email, string password, string username)
        {
            string websiteEmail = this.configuration.GetConfigurationSetting(typeof(string), "Email").ToString();
            string message = "Here is the password you requested:" +
                Cryptography.Decrypt(password, username);
            EmailHelper.SendEmail(websiteEmail, email, "", "", "Password Reminder", message);
        }

        public void SendVerificationEmail(string username, string emailAddress)
        {
            string rootUrl = this.configuration.GetConfigurationSetting(typeof(string), "RootUrl").ToString();
            string websiteEmail = this.configuration.GetConfigurationSetting(typeof(string), "Email").ToString();
            string encryptedName = Cryptography.Encrypt(username, "verify");
            string msg = "Please click on the link below or paste it into a " +
                "browser to verify your email account <br><br>" +
                "<a href=\"" + rootUrl + "Account/VerifyEmail.aspx?a=" +
                encryptedName + "\">" + rootUrl + "Account/VerifyEmail.aspx?a=" +
                encryptedName + "</a>";
            EmailHelper.SendEmail(
                websiteEmail, 
                emailAddress, 
                "", 
                "", 
                "Account created! Email verification required.", msg);
        }
    }
}
