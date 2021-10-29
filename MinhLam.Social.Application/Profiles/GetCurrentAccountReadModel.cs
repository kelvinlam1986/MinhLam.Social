using System;
using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public class GetCurrentAccountReadModel
    {
        public Guid AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Zip { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public CurrentAccountProfileReadModel Profile { get; set; }
    }

    public class CurrentAccountProfileReadModel
    {
        public Guid ProfileId { get; set; }
        public string AolAccountName { get; set; }
        public string GoogleAccountName { get; set; }
        public string IcqAccountName { get; set; }
        public string MsnAccountName { get; set; }
        public string SkypeAccountName { get; set; }
        public string YahooAccountName { get; set; }
        public int NumberOfFishOwned { get; set; }
        public int NumberOfTanksOwned { get; set; }
        public int YearOfFirstTank { get; set; }
        public string LevelOfExperience { get; set; }
        public bool UseGravatar { get; set; }
        public byte[] Avatar { get; set; }
        public string AvatarMimeType { get; set; }

        public List<CurrentAccountProfileAttributeReadModel> Attributes { get; set; }
    }

    public class CurrentAccountProfileAttributeReadModel
    {
        public Guid AttributeId { get; set; }
        public string AttributeTypeName { get; set; }
        public string Response { get; set; }
        public Guid PrivacyFlagTypeId { get; set; }
    }
}
