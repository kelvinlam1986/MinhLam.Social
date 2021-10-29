using MinhLam.Social.Application;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Social.Presentors.Profiles
{
    public class ProfilePresenter
    {
        private IProfileView view;
        private IUserSession userSession;
        private IAccountQuery accountQuery;
        private IRedirector redirector;
        private IPrivacyFlagQuery privacyFlagQuery;
        private IPrivacyFlagTypeQuery privacyFlagTypeQuery;
        private IProfileQuery profileQuery;
        private List<GetPrivacyFlagListByProfileReadModel> privacyFlags;

        public ProfilePresenter(
            IAccountQuery accountQuery,
            IPrivacyFlagQuery privacyFlagQuery,
            IProfileQuery profileQuery,
            IPrivacyFlagTypeQuery privacyFlagTypeQuery,
            IUserSession userSession,
            IRedirector redirector)
        {
            this.accountQuery = accountQuery;
            this.privacyFlagQuery = privacyFlagQuery;
            this.profileQuery = profileQuery;
            this.privacyFlagTypeQuery = privacyFlagTypeQuery;
            this.userSession = userSession;
            this.redirector = redirector;
            this.privacyFlags = new List<GetPrivacyFlagListByProfileReadModel>();
        }

        public void Init(IProfileView view, string username)
        {
            this.view = view;
            GetCurrentAccountReadModel account = null;
            if (string.IsNullOrEmpty(username))
            {
                if (userSession != null && string.IsNullOrEmpty(userSession.Username) == false)
                {
                    account = this.accountQuery.GetCurrentAccount(userSession.Username);
                }
            }
            else
            {
                account = this.accountQuery.GetCurrentAccount(username);
            }

            if (account == null)
            {
                this.redirector.GoToAccountLoginPage();
            }

            if (account.Profile != null)
            {
                this.privacyFlags = this.privacyFlagQuery.GetPrivacyFlagsByProfile(account.Profile.ProfileId);
            }

            this.view.DisplayInfo(account);
            TogglePrivacy(privacyFlags);

            //_view.SetAvatar(_accountBeingViewed.AccountID);
        }

        public bool IsAttributeVisible(Guid privacyFlagTypeId)
        {
            return profileQuery.ShouldShowAttribute(privacyFlagTypeId, this.privacyFlags);
        }

        private void TogglePrivacy(
            List<GetPrivacyFlagListByProfileReadModel> privacyFlags)
        {
            var mandatoryPrivacyFlagTypes = this.privacyFlagTypeQuery.GetMandatoryPrivacyFlagTypes();
            
            var flagTypeIM = mandatoryPrivacyFlagTypes.FirstOrDefault(x => x.FieldName == "IM");
            var showIMPanel = profileQuery.ShouldShowAttribute(flagTypeIM.Id, privacyFlags);
            this.view.pnlPrivacyIMVisible(showIMPanel);

            var flagTypeAccountInfo = mandatoryPrivacyFlagTypes.FirstOrDefault(x => x.FieldName == "Account Info");
            var showAccountInfoPanel = profileQuery.ShouldShowAttribute(flagTypeAccountInfo.Id, privacyFlags);
            this.view.pnlPrivacyAccountInfoVisible(showAccountInfoPanel);

            var flagTankInfoType = mandatoryPrivacyFlagTypes.FirstOrDefault(x => x.FieldName == "Tank Info");
            var showTankInfo = profileQuery.ShouldShowAttribute(flagTankInfoType.Id, privacyFlags);
            this.view.pnlPrivacyTankInfoVisible(showTankInfo);
        }


    }
}
