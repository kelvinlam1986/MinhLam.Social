using MinhLam.Social.Domain.Common;

namespace MinhLam.Social.Infrastructure.Common
{
    public class UserSession : IUserSession
    {
        private IWebContext webContext;

        public UserSession(IWebContext webContext)
        {
            this.webContext = webContext;
        }

        public bool IsLoggedIn 
        {
            get { return this.webContext.IsLoggedIn; }
            set { this.webContext.IsLoggedIn = value; }
        }
        public string Username 
        { 
            get { return this.webContext.Username; }
            set { this.webContext.Username = value; }
        }
        public SharedAccountProfile CurrentUser 
        {
            get { return this.webContext.CurrentUser; }
            set { this.webContext.CurrentUser = value; }
        }
    }
}
