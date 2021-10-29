using MinhLam.Framework;
using MinhLam.Social.Application;
using MinhLam.Social.Application.Profiles;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Profiles;
using System;
using System.Collections.Generic;

namespace MinhLam.Social.Presentors.Profiles
{
    public class ManagePrivacyPresenter
    {
        private IProfileService profileService;
        private IPrivacyFlagTypeQuery privacyFlagTypeQuery;
        private IVisibilityQuery visibilityQuery;
        private IPrivacyFlagRepository privacyFlagRepository;
        private IPrivacyFlagQuery privacyFlagQuery;
        private IUserSession userSession;
        private IManagePrivacyView view;
        private IRedirector redirector;

        public ManagePrivacyPresenter(
            IProfileService profileService,
            IPrivacyFlagRepository privacyFlagRepository,
            IPrivacyFlagTypeQuery privacyFlagTypeQuery,
            IVisibilityQuery visibilityQuery,
            IPrivacyFlagQuery privacyFlagQuery,
            IUserSession userSession,
            IRedirector redirector)
        {
            this.profileService = profileService;
            this.privacyFlagRepository = privacyFlagRepository;
            this.privacyFlagTypeQuery = privacyFlagTypeQuery;
            this.visibilityQuery = visibilityQuery;
            this.privacyFlagQuery = privacyFlagQuery;
            this.userSession = userSession;
            this.redirector = redirector;
        }

        public void Init(IManagePrivacyView view, bool isPostBack)
        {
            if (userSession == null || userSession.CurrentUser == null)
            {
                this.view.ShowMessage("Your session is timeout. Please log in again");
                this.redirector.GoToAccountLoginPage();
            }

            this.view = view;
            //if (!isPostBack)
            //{
                var privacyFlagTypes = this.privacyFlagTypeQuery.GetPrivacyFlagTypes();
                var visibilities = this.visibilityQuery.GetVisibilities();
                var profileId = userSession.CurrentUser.ProfileId;
                var privacyFlags = this.privacyFlagQuery.GetPrivacyFlagsByProfile(profileId);
                this.view.ShowPrivacyTypes(privacyFlagTypes, visibilities, privacyFlags);
            //}
        }

        public List<GetPrivacyFlagTypeListReadModel> GetPrivacyFlagTypes()
        {
            return this.privacyFlagTypeQuery.GetPrivacyFlagTypes();
        }

        public void SavePrivacyFlag(Guid privacyFlagTypeId, Guid visibilityId)
        {
            if (userSession == null || userSession.CurrentUser == null)
            {
                this.view.ShowMessage("Your session is timeout. Please log in again");
                this.redirector.GoToAccountLoginPage();
            }

            var profileId = userSession.CurrentUser.ProfileId;
            var privacyFlags = this.privacyFlagRepository.GetByProfileId(profileId);
            foreach (var flag in privacyFlags)
            {
                if (flag.PrivacyFlagTypeId == privacyFlagTypeId)
                {
                    try
                    {
                        var updatePrivacyCommand =
                            new UpdatePrivacyFlagCommand(flag.Id, privacyFlagTypeId, profileId, visibilityId);
                        profileService.Handle(updatePrivacyCommand);
                        this.view.ShowMessage("Your privacy settings were saved successfully!");
                        return;
                    }
                    catch (ApplicationServiceException e)
                    {
                        this.view.ShowMessage(e.Message);
                        return;
                    }
                    catch (Exception e)
                    {
                        this.view.ShowMessage(e.Message);
                        return;
                    }
                  
                }
            }

            // not in collection?  Add a new one
            try
            {
                var newPrivacyCommand =
                       new CreateNewPrivacyFlagCommand(privacyFlagTypeId, profileId, visibilityId);
                this.profileService.Handle(newPrivacyCommand);
                this.view.ShowMessage("Your privacy settings were saved successfully!");
            }
            catch (ApplicationServiceException e)
            {
                this.view.ShowMessage(e.Message);
                return;
            }
            catch (Exception e)
            {
                this.view.ShowMessage(e.Message);
                return;
            }

        }

        public bool IsFlagSelected(
            Guid privacyFlagTypeId, 
            Guid visibilityId,
            List<GetPrivacyFlagListByProfileReadModel> privacyFlags)
        {
            List<GetPrivacyFlagListByProfileReadModel> result =
                privacyFlags.FindAll(pf => (pf.PrivacyFlagTypeId.Equals(privacyFlagTypeId))
                && (pf.VisibilityId.Equals(visibilityId)));

            if (result.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
