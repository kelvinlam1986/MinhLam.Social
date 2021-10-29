using System;
using System.Collections.Generic;

namespace MinhLam.Social.Application.Profiles
{
    public class CreateNewProfileCommand
    {
        public CreateNewProfileCommand(
            string username,
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
            Username = username;
            AolAccountName = aolAccountName;
            IcqAccountName = icqAccountName;
            GoolgeAccountName = googleAccountName;
            MsnAccountName = msnAccountName;
            SkypeAccountName = skypeAccountName;
            YahooAccountName = yahooAccountName;
            LevelOfExperienceId = levelOfExperienceId;
            FirstYearOfTank = firstYearOfTask;
            NumberOfTanksOwned = numberOfTanksOwned;
            NumberOfFishOwned = numberOfFishOwned;
            Signature = signature;
            InputProfileAttributeList = profileAttributes;
        }

        public string Username { get; set; }
        public string AolAccountName { get; set; }
        public string IcqAccountName { get; set; }
        public string GoolgeAccountName { get; set; }
        public string MsnAccountName { get; set; }
        public string SkypeAccountName { get; set; }
        public string YahooAccountName { get; set; }
        public Guid LevelOfExperienceId { get; set; }
        public int FirstYearOfTank { get; set; }
        public int NumberOfTanksOwned { get; set; }
        public int NumberOfFishOwned { get; set; }
        public string Signature { get; set; }
        public List<InputProfileAttribute> InputProfileAttributeList { get; set; } = new List<InputProfileAttribute>();
    }
}
