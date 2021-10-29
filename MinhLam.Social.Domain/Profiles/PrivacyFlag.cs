using MinhLam.Framework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.Social.Domain.Profiles
{
    public class PrivacyFlag : AggregateRoot
    {
        public static PrivacyFlag New(
            Guid privacyFlagTypeId,
            Guid profileId,
            Guid visibilityId,
            IPrivacyFlagTypeChecking privacyFlagTypeChecking,
            IProfileChecking profileChecking,
            IVisibilityChecking visibilityChecking) 
        {
            if (privacyFlagTypeChecking.ExistWithId(privacyFlagTypeId) == false)
            {
                throw new DomainException(
                    ProfileExceptionCodes.PrivacyFlagTypeNotFound,
                    $"Cannot found privacy flag type with id {privacyFlagTypeId}");
            }

            if (profileChecking.ExistWithId(profileId) == false)
            {
                throw new DomainException(
                    ProfileExceptionCodes.ProfileNotFound,
                    $"Cannot found profile with id {profileId}");
            }

            if (visibilityChecking.ExistWithId(visibilityId) == false)
            {
                throw new DomainException(
                    ProfileExceptionCodes.VisibilityNotFound,
                    $"Cannot found visibility with id {visibilityId}");
            }

            return new PrivacyFlag(
                Guid.NewGuid(),
                privacyFlagTypeId,
                profileId,
                visibilityId,
                DateTime.Now);
        }

        public Guid PrivacyFlagTypeId { get; protected set; }

        [ForeignKey("PrivacyFlagTypeId")]
        public PrivacyFlagType PrivacyFlagType { get; protected set; }
        
        public Guid ProfileId { get; protected set; }

        [ForeignKey("ProfileId")]
        public Profile Profile { get; protected set; }

        public Guid VisibilityId { get; protected set; }

        [ForeignKey("VisibilityId")]
        public Visibility Visibility { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        internal PrivacyFlag(
            Guid id,
            Guid privacyFlagTypeId,
            Guid profileId,
            Guid visibilityId,
            DateTime createddDate)
        {
            this.Id = id;
            this.PrivacyFlagTypeId = privacyFlagTypeId;
            this.ProfileId = profileId;
            this.VisibilityId = visibilityId;
            this.CreatedDate = createddDate;
        }

        protected PrivacyFlag()
        {
        }

        public void Update(
            Guid privacyFlagTypeId, 
            Guid profileId, 
            Guid visibilityId,
            IPrivacyFlagTypeChecking privacyFlagTypeChecking,
            IProfileChecking profileChecking,
            IVisibilityChecking visibilityChecking)
        {
            if (privacyFlagTypeChecking.ExistWithId(privacyFlagTypeId) == false)
            {
                throw new DomainException(
                    ProfileExceptionCodes.PrivacyFlagTypeNotFound,
                    $"Cannot found privacy flag type with id {privacyFlagTypeId}");
            }

            if (profileChecking.ExistWithId(profileId) == false)
            {
                throw new DomainException(
                    ProfileExceptionCodes.ProfileNotFound,
                    $"Cannot found profile with id {profileId}");
            }

            if (visibilityChecking.ExistWithId(visibilityId) == false)
            {
                throw new DomainException(
                    ProfileExceptionCodes.VisibilityNotFound,
                    $"Cannot found visibility with id {visibilityId}");
            }

            this.PrivacyFlagTypeId = privacyFlagTypeId;
            this.ProfileId = profileId;
            this.VisibilityId = visibilityId;
        }
    }
}
