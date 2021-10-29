using MinhLam.Framework;
using MinhLam.Social.Domain.Profiles;
using System;

namespace MinhLam.Social.Application.Profiles
{
    public class ProfileService : IProfileService
    {
        private ICurrentUserSession currentUserSession;
        private IUserExperienceLevelChecking userExperienceLevelChecking;
        private IProfileAttributeTypeChecking profileAttributeTypeChecking;
        private IPrivacyFlagTypeChecking privacyFlagTypeChecking;
        private IProfileChecking profileChecking;
        private IVisibilityChecking visibilityChecking;
        private IProfileRepository profileRepository;
        private IPrivacyFlagRepository privacyFlagRepository;
        private IUnitOfWork unitOfWork;

        public ProfileService(
            ICurrentUserSession currentUserSession,
            IUserExperienceLevelChecking userExperienceLevelChecking,
            IProfileAttributeTypeChecking profileAttributeTypeChecking,
            IPrivacyFlagTypeChecking privacyFlagTypeChecking,
            IProfileChecking profileChecking,
            IVisibilityChecking visibilityChecking,
            IProfileRepository profileRepository,
            IPrivacyFlagRepository privacyFlagRepository,
            IUnitOfWork unitOfWork)
        {
            this.currentUserSession = currentUserSession;
            this.userExperienceLevelChecking = userExperienceLevelChecking;
            this.profileAttributeTypeChecking = profileAttributeTypeChecking;
            this.privacyFlagTypeChecking = privacyFlagTypeChecking;
            this.profileChecking = profileChecking;
            this.visibilityChecking = visibilityChecking;
            this.profileRepository = profileRepository;
            this.privacyFlagRepository = privacyFlagRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Handle(object command)
        {
            switch (command)
            {
                case CreateNewProfileCommand cmd:
                    HandleCreateNewProfile(cmd);
                    break;
                case UpdateProfileCommand cmd:
                    HandleUpdateProfile(cmd);
                    break;
                case CreateNewPrivacyFlagCommand cmd:
                    HandleCreateNewPrivacyFlag(cmd);
                    break;
                case UpdatePrivacyFlagCommand cmd:
                    HandleUpdatePrivacyFlag(cmd);
                    break;
                case UploadAvatarCommand cmd:
                    HandleUploadAvatar(cmd);
                    break;
                case CropAvatarFileCommand cmd:
                    HandleCropAvatarFile(cmd);
                    break;
                case SetUseGravatarCommand cmd:
                    HandleSetUseGravatarCommand(cmd);
                    break;
            }
                
        }

        private void HandleSetUseGravatarCommand(SetUseGravatarCommand cmd)
        {
            var profile = this.profileRepository.GetById(cmd.ProfileId);
            if (profile == null)
            {
                throw new ApplicationServiceException(
                    null, ProfileAppExceptionCodes.ProfileNotFound, "Cannot found profile");
            }

            profile.SetUseGravatar();
            this.profileRepository.Update(profile);
            this.unitOfWork.Commit();
        }

        private void HandleCropAvatarFile(CropAvatarFileCommand cmd)
        {
            var profile = this.profileRepository.GetById(cmd.ProfileId);
            if (profile == null)
            {
                throw new ApplicationServiceException(
                    null, ProfileAppExceptionCodes.ProfileNotFound, "Cannot found profile");
            }

            profile.CropFile(cmd.CroppedFile, profileChecking);
            this.profileRepository.Update(profile);
            this.unitOfWork.Commit();
        }

        private void HandleUploadAvatar(UploadAvatarCommand cmd)
        {
            var profile = this.profileRepository.GetById(cmd.ProfileId);
            if (profile == null)
            {
                throw new ApplicationServiceException(
                    null, ProfileAppExceptionCodes.ProfileNotFound, "Cannot found profile");
            }

            profile.UploadAvatar(cmd.UploadFile, cmd.MimeType, profileChecking);
            this.profileRepository.Update(profile);
            this.unitOfWork.Commit();
        }

        private void HandleUpdatePrivacyFlag(UpdatePrivacyFlagCommand cmd)
        {
            var privacy = this.privacyFlagRepository.GetById(cmd.Id);
            if (privacy == null)
            {
                throw new ApplicationServiceException(
                    null, ProfileExceptionCodes.PrivacyFlagNotFound, "Cannot found privacy flag"
                    );
            }
            try
            {
                privacy.Update(
                  cmd.PrivacyFlagTypeId,
                  cmd.ProfileId,
                  cmd.VisibilityId,
                  privacyFlagTypeChecking,
                  profileChecking,
                  visibilityChecking);

                this.privacyFlagRepository.Update(privacy);
                this.unitOfWork.Commit();
            }
            catch (DomainException e)
            {
                switch (e.Code)
                {
                    case ProfileExceptionCodes.PrivacyFlagNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.PrivacyFlagNotFound,
                            "Cannot found privacy flag");
                    case ProfileExceptionCodes.PrivacyFlagTypeNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.PrivacyFlagTypeNotFound,
                            "Cannot found privacy flag type");
                    case ProfileExceptionCodes.ProfileNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.ProfileNotFound,
                            "Cannot found profile");
                    case ProfileExceptionCodes.VisibilityNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.VisibilityNotFound,
                            "Cannot found visibility");
                }
            }
            catch (Exception e)
            {
                throw new ApplicationServiceException(
                    e,
                    ProfileAppExceptionCodes.SystemException,
                    "System has some wrong operation. Please contact administrator"
                    );
            }

        }

        private void HandleCreateNewPrivacyFlag(CreateNewPrivacyFlagCommand cmd)
        {
            try
            {
                var privacyFlag = PrivacyFlag.New(
                  cmd.PrivacyFlagTypeId,
                  cmd.ProfileId,
                  cmd.VisibilityId,
                  privacyFlagTypeChecking,
                  profileChecking,
                  visibilityChecking
                  );
                this.privacyFlagRepository.Add(privacyFlag);
                this.unitOfWork.Commit();
            }
            catch (DomainException e)
            {
                switch (e.Code)
                {
                    case ProfileExceptionCodes.PrivacyFlagTypeNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.PrivacyFlagTypeNotFound,
                            "Cannot found privacy flag type");
                    case ProfileExceptionCodes.ProfileNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.ProfileNotFound,
                            "Cannot found profile");
                    case ProfileExceptionCodes.VisibilityNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.VisibilityNotFound,
                            "Cannot found visibility");
                }
            }
            catch (Exception e)
            {
                throw new ApplicationServiceException(
                    e,
                    ProfileAppExceptionCodes.SystemException,
                    "System has some wrong operation. Please contact administrator"
                    );
            }
          
        }

        private void HandleUpdateProfile(UpdateProfileCommand cmd)
        {
            try
            {
                var tankYear = TankYear.New(cmd.FirstYearOfTank);
                var currentProfile =
                    this.profileRepository.GetCurrentProfileIncludeAttributes(cmd.ProfileId);
                if (currentProfile == null)
                {
                    throw new ApplicationServiceException(
                        null,
                        ProfileAppExceptionCodes.ProfileNotFound,
                            "Cannot found profile to update");
                }

                currentProfile.UpdateProfile(
                    cmd.AolAccountName,
                    cmd.IcqAccountName,
                    cmd.GoogleAccountName,
                    cmd.MsnAccountName,
                    cmd.SkypeAccountName,
                    cmd.YahooAccountName,
                    cmd.LevelOfExperienceId,
                    tankYear,
                    cmd.NumberOfTanksOwned,
                    cmd.NumberOfFishesOwned,
                    cmd.Signature,
                    this.userExperienceLevelChecking);
                foreach (var item in cmd.ProfileAttributes)
                {
                    currentProfile.UpdateProfileAttribute(
                        item.Id,
                        item.ProfileAtributeTypeId,
                        item.Response,
                        profileAttributeTypeChecking);
                }

                this.profileRepository.Update(currentProfile);
                this.unitOfWork.Commit();

            }
            catch (DomainException e)
            {
                switch (e.Code)
                {
                    case ProfileExceptionCodes.TankYearOutOfRange:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.TankYearOutOfRange,
                            "Please enter the 4 digit year that you started your first tank!");
                    case ProfileExceptionCodes.YearOfFirstTankCanNotBeNull:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.SystemException,
                            "System has some wrong operation. Please contact administrator");
                    case ProfileExceptionCodes.NumberOfTanksOwnCannotNegative:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.NumberOfTanksOwnCannotNegative,
                            "Must be a number");
                    case ProfileExceptionCodes.NumberOfFishOwnCannotNegative:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.NumberOfFishOwnCannotNegative,
                            "Must be a number");
                    case ProfileExceptionCodes.UserExperienceLevelNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.UserExperienceLevelNotFound,
                            $"Cannot found user experience level you choose");
                    case ProfileExceptionCodes.ProfileAttributeTypeNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.ProfileAttributeTypeNotFound,
                            $"Cannot found attribute type you choose");
                    case ProfileExceptionCodes.AttributeResponseMaxLength2000:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.AttributeResponseMaxLength2000,
                            "Response can only be 2000 characters long!");
                    case ProfileExceptionCodes.ProfileNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.ProfileNotFound,
                            $"Cannot found profile to update");
                }
            }
           
        }

        private void HandleCreateNewProfile(CreateNewProfileCommand cmd)
        {
            try
            {
                var tankYear = TankYear.New(cmd.FirstYearOfTank);
                var profile = Profile.New(
                    cmd.Username,
                    cmd.AolAccountName,
                    cmd.IcqAccountName,
                    cmd.GoolgeAccountName,
                    cmd.MsnAccountName,
                    cmd.SkypeAccountName,
                    cmd.YahooAccountName,
                    cmd.LevelOfExperienceId,
                    tankYear,
                    cmd.NumberOfTanksOwned,
                    cmd.NumberOfFishOwned,
                    cmd.Signature,
                    this.currentUserSession,
                    this.userExperienceLevelChecking
                    );

                foreach (var item in cmd.InputProfileAttributeList)
                {
                    var newProfileAttribute = ProfileAttribute.New(profile.Id,
                        item.ProfileAtributeTypeId, item.Response, DateTime.Now);
                    profile.AddProfileAttribute(newProfileAttribute, profileAttributeTypeChecking);
                }

                this.profileRepository.Add(profile);
                this.unitOfWork.Commit();
                
            }
            catch (DomainException e)
            {
                switch (e.Code)
                {
                    case ProfileExceptionCodes.TankYearOutOfRange:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.TankYearOutOfRange,
                            "Please enter the 4 digit year that you started your first tank!");
                    case ProfileExceptionCodes.YearOfFirstTankCanNotBeNull:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.SystemException,
                            "System has some wrong operation. Please contact administrator");
                    case ProfileExceptionCodes.UsernameIsBlank:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.UsernameIsBlank,
                            "Username is blank");
                    case ProfileExceptionCodes.UserNameIsNotCorrectFormat:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.UserNameIsNotCorrectFormat,
                            "Your username must be at least 6 letters or numbers and no more than 30.");
                    case ProfileExceptionCodes.NumberOfTanksOwnCannotNegative:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.NumberOfTanksOwnCannotNegative,
                            "Must be a number");
                    case ProfileExceptionCodes.NumberOfFishOwnCannotNegative:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.NumberOfFishOwnCannotNegative,
                            "Must be a number");
                    case ProfileExceptionCodes.UserNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.UserNotFound,
                            $"Cannot found the account with username {cmd.Username}");
                    case ProfileExceptionCodes.UserExperienceLevelNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.UserExperienceLevelNotFound,
                            $"Cannot found user experience level you choose");
                    case ProfileExceptionCodes.ProfileAttributeTypeNotFound:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.ProfileAttributeTypeNotFound,
                            $"Cannot found attribute type you choose");
                    case ProfileExceptionCodes.AttributeResponseMaxLength2000:
                        throw new ApplicationServiceException(
                            e,
                            ProfileAppExceptionCodes.AttributeResponseMaxLength2000,
                            "Response can only be 2000 characters long!");
                }
            }
        }
    }
}
