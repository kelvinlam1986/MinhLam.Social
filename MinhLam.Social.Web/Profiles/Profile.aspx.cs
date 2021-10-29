using MinhLam.Social.Application;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Memberships;
using MinhLam.Social.Presentors.Profiles;
using Ninject;
using System;
using System.Web.UI;

namespace MinhLam.Social.Web.Profiles
{
    public partial class Profile : System.Web.UI.Page, IProfileView
    {
        [Inject]
        public IAccountQuery AccountQuery { get; set; }

        [Inject]
        public IPrivacyFlagQuery PrivacyFlagQuery { get; set; }

        [Inject]
        public IProfileQuery ProfileQuery { get; set; }

        [Inject]
        public IPrivacyFlagTypeQuery PrivacyFlagTypeQuery { get; set; }

        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }
        
        private ProfilePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new ProfilePresenter(
                AccountQuery, 
                PrivacyFlagQuery, 
                ProfileQuery,
                PrivacyFlagTypeQuery,
                UserSession, 
                Redirector);
            string username = Page.RouteData.Values["username"] as string;
            presenter.Init(this, username);
        }
        public void DisplayInfo(GetCurrentAccountReadModel accountDisplay)
        {
            lblFirstName.Text = accountDisplay.FirstName;
            lblLastName.Text = accountDisplay.LastName;
            litLastUpdateDate.Text = accountDisplay.LastUpdated.ToString();
            litZip.Text = accountDisplay.Zip;
            litBirthDate.Text = accountDisplay.BirthDate.ToString();
            litEmail.Text = accountDisplay.Email;
           
            if (accountDisplay.Profile != null)
            {
                if (accountDisplay.Profile.ProfileId != Guid.Empty)
                {
                    litIMAOL.Text = accountDisplay.Profile.AolAccountName;
                    litIMGIM.Text = accountDisplay.Profile.GoogleAccountName;
                    litIMICQ.Text = accountDisplay.Profile.IcqAccountName;
                    litIMMSN.Text = accountDisplay.Profile.MsnAccountName;
                    litIMSkype.Text = accountDisplay.Profile.SkypeAccountName;
                    litIMYIM.Text = accountDisplay.Profile.YahooAccountName;
                    litNumberOfTanksOwned.Text = accountDisplay.Profile.NumberOfTanksOwned.ToString();
                    litNumberOfFishOwned.Text = accountDisplay.Profile.NumberOfFishOwned.ToString();
                    litYearOfFirstTank.Text = accountDisplay.Profile.YearOfFirstTank.ToString();
                    litLevelOfExperience.Text = "(" + accountDisplay.Profile.LevelOfExperience + ")";
                    if (accountDisplay.Profile.Attributes.Count > 0)
                    {
                        phAttributes.Controls.Add(new LiteralControl("<fieldset>"));
                        foreach (var attribute in accountDisplay.Profile.Attributes) 
                        {
                            if (presenter.IsAttributeVisible(attribute.PrivacyFlagTypeId))
                            {
                                if (!string.IsNullOrEmpty(attribute.Response))
                                {
                                    phAttributes.Controls.Add(new LiteralControl("<div class=\"divContainerTitle\">"));
                                    phAttributes.Controls.Add(new LiteralControl(attribute.AttributeTypeName));
                                    phAttributes.Controls.Add(new LiteralControl("</div>"));
                                    phAttributes.Controls.Add(new LiteralControl("<div class=\"divContainerRow\">"));
                                    phAttributes.Controls.Add(new LiteralControl(attribute.Response));
                                    phAttributes.Controls.Add(new LiteralControl("</div>"));
                                }
                            }
                           
                        }

                        phAttributes.Controls.Add(new LiteralControl("</fieldset>"));
                    }

                }
            }
        }

        public void pnlPrivacyAccountInfoVisible(bool value)
        {
            pnlPrivacyAccountInfo.Visible = value;
        }

        public void pnlPrivacyIMVisible(bool value)
        {
            pnlPrivacyIM.Visible = value;
        }

        public void pnlPrivacyTankInfoVisible(bool value)
        {
            pnlPrivacyTankInfo.Visible = value;
        }
    }
}