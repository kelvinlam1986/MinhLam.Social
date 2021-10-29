using MinhLam.Framework;
using MinhLam.Social.Domain.Common;
using MinhLam.Social.Domain.Memberships;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace MinhLam.Social.Domain.Profiles
{
    public class Profile : AggregateRoot
    {
        public Guid AccountId { get;  protected set; }

        [ForeignKey("AccountId")]
        public Account Account { get; protected set; }
        public string AolAccountName { get; protected set; }
        public string IcqAccountName { get; protected set; }
        public string GoogleAccountName { get; protected set; }
        public string MsnAccountName { get; protected set; }
        public string SkypeAccountName { get; protected set; }
        public string YahooAccountName { get; protected set; }
        public LevelOfExperience LevelOfExperience { get; protected set; }
        public Guid LevelOfExperienceId { get; protected set; }
        public TankYear YearOfFirstTank { get; protected set; }
        public int NumberOfTanksOwned { get; protected set; }
        public int NumberOfFishOwned { get; protected set; }
        public string Signature { get; protected set; }
        public byte[] Avatar { get; protected set; }
        public string AvatarMimeType { get; protected set; }
        public bool UseGravatar { get; protected set; }


        public virtual ICollection<ProfileAttribute> ProfileAttributes { get; protected set; }

        public static Profile New(
            string username,
            string aolAccountName,
            string icqAccountName,
            string googleAccountName,
            string msnAccountName,
            string skypeAccountName,
            string yahooAccountName,
            Guid levelOfExperienceId,
            TankYear yearOfFirstTank,
            int numberOfTanksOwned,
            int numberOfFishOwned,
            string signature,
            ICurrentUserSession currentUserSession,
            IUserExperienceLevelChecking userExperienceLevelChecking)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException(ProfileExceptionCodes.UsernameIsBlank,
                    "Username is blank");
            }

            if (Regex.IsMatch(username, "^[a-zA-Z0-9.]{6,30}") == false)
            {
                throw new DomainException(ProfileExceptionCodes.UserNameIsNotCorrectFormat,
                    "Your username must be at least 6 letters or numbers and no more than 30.");
            }

            if (yearOfFirstTank == null)
            {
                throw new DomainException(ProfileExceptionCodes.YearOfFirstTankCanNotBeNull,
                    "Year of first tank cannot be null");
            }

            if (numberOfTanksOwned < 0)
            {
                throw new DomainException(ProfileExceptionCodes.NumberOfTanksOwnCannotNegative,
                    "Number of tanks owned cannot negative number");
            }

            if (numberOfFishOwned < 0)
            {
                throw new DomainException(ProfileExceptionCodes.NumberOfFishOwnCannotNegative,
                    "Number of fishs owned cannot negative number");
            }

            var accountId = currentUserSession.GetAccountIdByUsername(username);
            if (accountId == null || accountId == Guid.Empty)
            {
                throw new DomainException(ProfileExceptionCodes.UserNotFound,
                   $"User not found with username {username}");
            }

            if (userExperienceLevelChecking.ExistWithId(levelOfExperienceId) == false)
            {
                throw new DomainException(ProfileExceptionCodes.UserExperienceLevelNotFound,
                    $"User experience level not found");
            }

            return new Profile(
                accountId,
                aolAccountName,
                icqAccountName,
                googleAccountName,
                msnAccountName,
                skypeAccountName,
                yahooAccountName,
                levelOfExperienceId,
                yearOfFirstTank,
                numberOfTanksOwned,
                numberOfFishOwned,
                signature,
                false);
        } 

        internal Profile(Guid accountId,
            string aolAccountName,
            string icqAccountName,
            string googleAccountName,
            string msnAccountName,
            string skypeAccountName,
            string yahooAccountName,
            Guid levelOfExperienceId,
            TankYear yearOfFirstTank,
            int numberOFTanksOwned,
            int numberOfFishOwned,
            string signature,
            bool useGravatar)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            AolAccountName = aolAccountName;
            IcqAccountName = icqAccountName;
            GoogleAccountName = googleAccountName;
            MsnAccountName = msnAccountName;
            SkypeAccountName = skypeAccountName;
            YahooAccountName = yahooAccountName;
            LevelOfExperienceId = levelOfExperienceId;
            YearOfFirstTank = yearOfFirstTank;
            NumberOfTanksOwned = numberOFTanksOwned;
            NumberOfFishOwned = numberOfFishOwned;
            Signature = signature;
            UseGravatar = useGravatar;
            ProfileAttributes = new List<ProfileAttribute>();
        }

        protected Profile()
        {
        }

        public void AddProfileAttribute(ProfileAttribute profileAttribute, 
            IProfileAttributeTypeChecking profileAttributeTypeChecking)
        {
            if (profileAttributeTypeChecking.ExistWithId(profileAttribute.ProfileAttributeTypeId) == false)
            {
                throw new DomainException(
                    ProfileExceptionCodes.ProfileAttributeTypeNotFound,
                    $"Cannot found attribute type with {profileAttribute.ProfileAttributeTypeId}");
            }

            this.ProfileAttributes.Add(profileAttribute);
        }

        public void UpdateProfile(
            string aolAccountName,
            string icqAccountName,
            string googleAccountName,
            string msnAccountName,
            string skypeAccountName,
            string yahooAccountName,
            Guid levelOfExperienceId,
            TankYear yearOfFirstTank,
            int numberOfTanksOwned,
            int numberOfFishesOwned,
            string signalture,
            IUserExperienceLevelChecking userExperienceLevelChecking)
        {
            if (yearOfFirstTank == null)
            {
                throw new DomainException(ProfileExceptionCodes.YearOfFirstTankCanNotBeNull,
                    "Year of first tank cannot be null");
            }

            if (numberOfTanksOwned < 0)
            {
                throw new DomainException(ProfileExceptionCodes.NumberOfTanksOwnCannotNegative,
                    "Number of tanks owned cannot negative number");
            }

            if (numberOfFishesOwned < 0)
            {
                throw new DomainException(ProfileExceptionCodes.NumberOfFishOwnCannotNegative,
                    "Number of fishs owned cannot negative number");
            }

            if (userExperienceLevelChecking.ExistWithId(levelOfExperienceId) == false)
            {
                throw new DomainException(ProfileExceptionCodes.UserExperienceLevelNotFound,
                    $"User experience level not found");
            }

            this.AolAccountName = aolAccountName;
            this.IcqAccountName = icqAccountName;
            this.GoogleAccountName = googleAccountName;
            this.MsnAccountName = msnAccountName;
            this.SkypeAccountName = skypeAccountName;
            this.YahooAccountName = yahooAccountName;
            this.LevelOfExperienceId = levelOfExperienceId;
            this.YearOfFirstTank = yearOfFirstTank;
            this.NumberOfTanksOwned = numberOfTanksOwned;
            this.NumberOfFishOwned = numberOfFishesOwned;
            this.Signature = signalture;
    }

        public void UpdateProfileAttribute(
            Guid attributeId,
            Guid attributeTypeId,
            string response,
            IProfileAttributeTypeChecking profileAttributeTypeChecking)
        {
            if (Id == null || Id == Guid.Empty)
            {
                throw new DomainException(
                  ProfileExceptionCodes.ProfileNotFound,
                  $"Cannot found Profile to update");
            }

            if (profileAttributeTypeChecking.ExistWithId(attributeTypeId) == false)
            {
                throw new DomainException(
                    ProfileExceptionCodes.ProfileAttributeTypeNotFound,
                    $"Cannot found attribute type with {attributeTypeId}");
            }

            var existingProfileAttribute =
               this.ProfileAttributes.FirstOrDefault(x => x.Id == attributeId);

            if (existingProfileAttribute != null)
            {
                existingProfileAttribute.UpdateResponse(response);
            }
            else
            {
                var atribute = ProfileAttribute.New(
                    Id,
                    attributeTypeId,
                    response,
                    DateTime.Now);
                ProfileAttributes.Add(atribute);
            }
        }

        public void UploadAvatar(byte[] uploadFile, string mimeType, IProfileChecking profileChecking)
        {
            if (profileChecking.ExistWithId(Id) == false)
            {
                throw new DomainException(
                     ProfileExceptionCodes.ProfileNotFound,
                        $"Cannot found Profile to upload");
            }

            if (uploadFile.Length == 0)
            {
                throw new DomainException(
                    CommonExceptionCodes.EmptyUploadFile, "File upload is empty");
            }

            if (string.IsNullOrWhiteSpace(mimeType))
            {
                throw new DomainException(
                    CommonExceptionCodes.MimeTypeCannotEmpty, "Mime type is empty");
            }

            Avatar = uploadFile;
            AvatarMimeType = mimeType;
            UseGravatar = false;
        }

        public void CropFile(
            byte[] cropedFile,
            IProfileChecking profileChecking)
        {
            if (profileChecking.ExistWithId(Id) == false)
            {
                throw new DomainException(
                     ProfileExceptionCodes.ProfileNotFound,
                        $"Cannot found Profile to crop");
            }

            if (cropedFile.Length == 0)
            {
                throw new DomainException(
                    CommonExceptionCodes.EmptyUploadFile, "File upload is empty");
            }


            AvatarMimeType = "image/jpeg";
            Avatar = cropedFile;
        }

        public void SetUseGravatar()
        {
            UseGravatar = true;
        }
    }
}
