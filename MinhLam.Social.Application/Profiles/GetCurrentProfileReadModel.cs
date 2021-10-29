using System;
using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public class GetCurrentProfileReadModel
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string AolAccountName { get; set; }
        public string IcqAccountName { get; set; }
        public string GoogleAccountName { get; set; }
        public string MsnAccountName { get; set; }
        public string SkypeAccountName { get; set; }
        public string YahooAccountName { get; set; }
        public Guid LevelOfExperienceId { get; set; }
        public int YearOfFirstTank { get; set; }
        public int NumberOfTanksOwned { get; set; }
        public int NumberOfFishOwned { get; set; }
        public string Signature { get; set; }
        public List<ProfileAttributeReadModel> Attributes { get; set; }
    }

    public class ProfileAttributeReadModel
    {
        public Guid ProfileAttributeId { get; set; }
        public Guid ProfileAttributeTypeId { get; set; }
        public string Response { get; set; }
    }

    public class AccountReadModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
