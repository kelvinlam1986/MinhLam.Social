using System;
using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public class UpdateProfileCommand
    {
        public UpdateProfileCommand()
        {
        }

        public UpdateProfileCommand(
           Guid profileId,
           string aolAccountName,
           string icqAccountName,
           string googleAccountName,
           string msnAccountName,
           string skypeAccountName,
           string yahooAccountName,
           Guid levelOfExperienceId,
           int firstYearOfTask,
           int numberOfTanksOwned,
           int numberOfFishOwned,
           string signature,
           List<InputProfileAttribute> profileAttributes)
        {
            ProfileId = profileId;
            AolAccountName = aolAccountName;
            IcqAccountName = icqAccountName;
            GoogleAccountName = googleAccountName;
            MsnAccountName = msnAccountName;
            SkypeAccountName = skypeAccountName;
            YahooAccountName = yahooAccountName;
            LevelOfExperienceId = levelOfExperienceId;
            FirstYearOfTank = firstYearOfTask;
            NumberOfTanksOwned = numberOfTanksOwned;
            NumberOfFishesOwned = numberOfFishOwned;
            Signature = signature;
            ProfileAttributes = profileAttributes;
        }

        public Guid ProfileId { get; set; }
        public string AolAccountName { get; set; }
        public string IcqAccountName { get; set; }
        public string GoogleAccountName { get; set; }
        public string MsnAccountName { get; set; }
        public string SkypeAccountName { get; set; }
        public string YahooAccountName { get; set; }
        public Guid LevelOfExperienceId { get; set; }
        public int FirstYearOfTank { get; set; }
        public int NumberOfTanksOwned { get; set; }
        public int NumberOfFishesOwned { get; set; }
        public string Signature { get; set; }
        public List<InputProfileAttribute> ProfileAttributes { get; set; } = new List<InputProfileAttribute>();
    }
}