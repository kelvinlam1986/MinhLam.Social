using MinhLam.Social.Application;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Profiles;
using System;
using System.Collections.Generic;

namespace MinhLam.Social.Presentors.Profiles
{
    public class ManageProfilePresenter
    {
        private IProfileService profileService;
        private ILevelOfExperienceTypeQuery levelOfExperienceTypeQuery;
        private IProfileAttributeTypeQuery profileAttributeTypeQuery;
        private IProfileQuery profileQuery;
        private IUserSession userSession;
        private IRedirector redirector;
        private IManageProfileView view;

        public ManageProfilePresenter(
            IProfileService profileService,
            ILevelOfExperienceTypeQuery levelOfExperienceTypeQuery,
            IProfileAttributeTypeQuery profileAttributeTypeQuery,
            IProfileQuery profileQuery,
            IUserSession userSession,
            IRedirector redirector)
        {
            this.profileService = profileService;
            this.levelOfExperienceTypeQuery = levelOfExperienceTypeQuery;
            this.profileAttributeTypeQuery = profileAttributeTypeQuery;
            this.profileQuery = profileQuery;
            this.userSession = userSession;
            this.redirector = redirector;
        }

        public void Init(IManageProfileView view, bool isPostBack)
        {
            this.view = view;
            var listOfLevelExperienceType = levelOfExperienceTypeQuery.GetLevelOfExperienceTypeList();
            var listOfProfileAttributeType = this.profileAttributeTypeQuery.GetProfileAttributeTypeReadModelList();
            this.view.LoadLevelOfExperienceTypes(listOfLevelExperienceType);
            this.view.LoadProfileAttributeTypes(listOfProfileAttributeType);

            if (!isPostBack)
            {
                if (this.userSession == null || string.IsNullOrEmpty(this.userSession.Username))
                {
                    this.view.ShowMessage("Your session is timeout. Please log in again");
                    this.redirector.GoToAccountLoginPage();
                }
                else
                {
                    var username = this.userSession.Username;
                    var currentProfile = this.profileQuery.GetCurrentProfile(username);
                    this.view.LoadProfile(currentProfile);
                }    
            }
        }

        public GetCurrentProfileReadModel GetProfile()
        {
            var account = GetAccount();
            return this.profileQuery.GetCurrentProfile(account.UserName);
        }

        public SharedAccountProfile GetAccount()
        {
            return this.userSession.CurrentUser;
        }

        public List<GetProfileAttributeTypeReadModel> GetProfileAttributeTypes()
        {
            return this.profileAttributeTypeQuery.GetProfileAttributeTypeReadModelList();
        }

        public void NewProfle(
            string aolAccountName,
            string icqAccountName,
            string googleAccountName,
            string msnAccountName,
            string skypeAccountName,
            string yahooAccountName,
            Guid levelOfExperienceId,
            int firstYearOfTank,
            int numberOfTanksOwned,
            int numberOfFishsOwned,
            string signature,
            List<InputProfileAttribute> profileAttributes
            )
        {
            try
            {
                var currentAccount = GetAccount();
                if (currentAccount == null)
                {
                    this.view.ShowMessage("Your session is timeout. Please log in again");
                    this.redirector.GoToAccountLoginPage();
                }

                var createProfileCommand = new CreateNewProfileCommand(
                    currentAccount.UserName,
                    aolAccountName,
                    icqAccountName,
                    googleAccountName,
                    msnAccountName,
                    skypeAccountName,
                    yahooAccountName,
                    levelOfExperienceId,
                    firstYearOfTank,
                    numberOfTanksOwned,
                    numberOfFishsOwned,
                    signature,
                    profileAttributes
                    );

                this.profileService.Handle(createProfileCommand);
                this.redirector.GoToProfilesProfile();
            }
            catch (ApplicationException e)
            {
                this.view.ShowMessage(e.Message);
            }
            catch (Exception)
            {
                this.view.ShowMessage("System has some wrong operation.Please contact administrator");
            }
        }

        public void UpdateProfile(
            string aolAccountName,
            string icqAccountName,
            string googleAccountName,
            string msnAccountName,
            string skypeAccountName,
            string yahooAccountName,
            Guid levelOfExperienceId,
            int firstYearOfTank,
            int numberOfTanksOwned,
            int numberOfFishsOwned,
            string signature,
            List<InputProfileAttribute> profileAttributes
            )
        {
            var currentAccount = GetAccount();
            if (currentAccount == null)
            {
                this.view.ShowMessage("Your session is timeout. Please log in again");
                this.redirector.GoToAccountLoginPage();
            }

            var currentProfile = GetProfile();
            var updateProfileCommand = new UpdateProfileCommand(
                currentProfile.Id,
                aolAccountName,
                icqAccountName,
                googleAccountName,
                msnAccountName,
                skypeAccountName,
                yahooAccountName,
                levelOfExperienceId,
                firstYearOfTank,
                numberOfTanksOwned,
                numberOfFishsOwned,
                signature,
                profileAttributes);
            this.profileService.Handle(updateProfileCommand);
            this.redirector.GoToProfilesProfile();
        }
    }
}
