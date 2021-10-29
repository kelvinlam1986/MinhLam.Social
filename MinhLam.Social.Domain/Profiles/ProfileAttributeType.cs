using MinhLam.Framework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.Social.Domain.Profiles
{
    public class ProfileAttributeType : Entity
    {
        public string Name { get; protected set; }
        public int SortOrder { get; protected set; }
        public Guid PrivacyFlagTypeId { get; protected set; }

        [ForeignKey("PrivacyFlagTypeId")]
        public PrivacyFlagType PrivacyFlagType { get; protected set; }

        protected ProfileAttributeType()
        {
        }
    }
}
