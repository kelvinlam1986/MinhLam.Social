using MinhLam.Framework;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using Ninject;
using System;

namespace MinhLam.Social.Web.Images.ProfileAvatar
{
    public partial class ProfileImage : System.Web.UI.Page
    {
        [Inject]
        public IWebContext WebContext { get; set; }

        [Inject]
        public IAccountQuery AccountQuery { get; set; }

        [Inject]
        public IUserSession UserSession { get; set; }


        private Guid accountId;
        private GetCurrentAccountReadModel account;
        private CurrentAccountProfileReadModel profile;

        private

        protected void Page_Load(object sender, EventArgs e)
        {

            if (WebContext.AccountId != Guid.Empty)
            {
                accountId = WebContext.AccountId;
                account = AccountQuery.GetCurrentAccount(accountId);
            }
            else
            {
                if (UserSession.IsLoggedIn && UserSession.CurrentUser != null)
                {
                    var currentUser = UserSession.CurrentUser;
                    account = AccountQuery.GetCurrentAccount(currentUser.Id);
                }
            }

            //if account is not obtained, cannot proceed further
            if (account == null)
            {
                Response.Redirect("~/Images/ProfileAvatar/Male.jpg");
            }

            profile = account.Profile;

            if (WebContext.ShowGravatar || (profile != null && profile.UseGravatar))
            {
                Response.Redirect(GetGravatarURL());
            }
            else if (profile != null && profile.Avatar != null)
            {
                Response.Clear();
                Response.ContentType = profile.AvatarMimeType;
                Response.BinaryWrite(profile.Avatar);
            }
            else
            {
                Response.Redirect("~/Images/ProfileAvatar/Male.jpg");
            }
        }

        public string GetGravatarURL()
        {
            var defaultAvatar = Server.UrlPathEncode(WebContext.RootUrl + "Images/ProfileAvatar/Male.jpg");

            var  gravatarURL = "http://www.gravatar.com/avatar.php?";
            gravatarURL += "gravatar_id=" + account.Email.ToMD5Hash();
            gravatarURL += "&rating=r";
            gravatarURL += "&size=80";
            gravatarURL += "&default=" + defaultAvatar;
            return gravatarURL;
        }
    }
}