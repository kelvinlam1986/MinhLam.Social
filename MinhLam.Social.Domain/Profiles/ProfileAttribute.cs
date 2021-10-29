using MinhLam.Framework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.Social.Domain.Profiles
{
    public class ProfileAttribute : Entity
    {
        public Guid ProfileAttributeTypeId { get; protected set; }

        [ForeignKey("ProfileAttributeTypeId")]
        public ProfileAttributeType ProfileAttributeType { get; protected set; }
        public Guid ProfileId { get; protected set; }

        [ForeignKey("ProfileId")]
        public Profile Profile { get; protected set; }

        public string Response { get; protected set; }
        public DateTime CreatedDate { get; protected set; }

        public static ProfileAttribute New(
            Guid profileId,
            Guid profileAttributeTypeId,
            string response,
            DateTime createdDate)
        {
            if (response.Length > 2000)
            {
                throw new DomainException(
                    ProfileExceptionCodes.AttributeResponseMaxLength2000, 
                    "Response can only be 2000 characters long!");
            }

            return new ProfileAttribute(
                Guid.NewGuid(), 
                profileId,
                profileAttributeTypeId, 
                response, 
                createdDate);
        }
        
        internal ProfileAttribute(
            Guid id,
            Guid profileId,
            Guid profileAtrributeTypeId,
            string response,
            DateTime createdDate)
        {
            this.Id = id;
            this.ProfileId = profileId;
            this.ProfileAttributeTypeId = profileAtrributeTypeId;
            this.Response = response;
            this.CreatedDate = createdDate;
        }

        protected ProfileAttribute()
        {
        }

        public void UpdateResponse(string response)
        {
            if (response.Length > 2000)
            {
                throw new DomainException(
                    ProfileExceptionCodes.AttributeResponseMaxLength2000,
                    "Response can only be 2000 characters long!");
            }

            Response = response;
        }

    }
}
