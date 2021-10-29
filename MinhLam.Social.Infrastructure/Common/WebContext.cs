using MinhLam.Social.Domain.Common;
using System;
using System.Web;

namespace MinhLam.Social.Infrastructure.Common
{
    public class WebContext : IWebContext
    {
        public string RootUrl
        {
            get
            {
                string result;

                string Port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                if (Port == null || Port == "80" || Port == "443")
                    Port = "";
                else
                    Port = ":" + Port;

                string Protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                if (Protocol == null || Protocol == "0")
                    Protocol = "http://";
                else
                    Protocol = "https://";

                result = Protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] +
                    Port + HttpContext.Current.Request.ApplicationPath;

                return result;
            }
        }

        public Guid AccountId
        { 
            get
            {
                if (!string.IsNullOrEmpty(GetQueryStringValue("AccountId")))
                {
                    return Guid.Parse(GetQueryStringValue("AccountId"));
                }

                return Guid.Empty;
            } 
        }

        public bool ShowGravatar
        {
            get
            {
                if (!string.IsNullOrEmpty(GetQueryStringValue("ShowGravatar")) && 
                    GetQueryStringValue("ShowGravatar") == "1")
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsLoggedIn 
        {
            get
            {
                if (ContainsInSession("LoggedIn"))
                {
                    if ((bool)GetFromSession("LoggedIn"))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                SetInSession("LoggedIn", value);
            }
        }

        public string Username 
        { 
            get
            {
                if (ContainsInSession("Username"))
                {
                    return GetFromSession("Username").ToString();
                }

                return "";
            }
            set
            {
                SetInSession("Username", value);
            } 
        }
        public SharedAccountProfile CurrentUser 
        {
            get
            {
                if (ContainsInSession("CurrentUser"))
                {
                    return GetFromSession("CurrentUser") as SharedAccountProfile;
                }

                return null;
            }
            set
            {
                SetInSession("CurrentUser", value);
            }
        }

        public string UsernameToVerify
        {
            get 
            {
                return GetQueryStringValue("a");
            }
        }

        private void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        private bool ContainsInSession(string key)
        {
            return HttpContext.Current.Session[key] != null;
        }

        private void RemoveFromSession(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        private string GetQueryStringValue(string key)
        {
            return HttpContext.Current.Request.QueryString.Get(key);
        }

        private void SetInSession(string key, object value)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return;
            }
            HttpContext.Current.Session[key] = value;
        }

        private object GetFromSession(string key)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return null;
            }
            return HttpContext.Current.Session[key];
        }

        private void UpdateInSession(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }
    }
}
