using Dapper;
using MinhLam.Framework;
using MinhLam.Social.Domain.Profiles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinhLam.Social.Application.Profiles
{
    public class ProfileQuery : IProfileQuery
    {
        public GetCurrentProfileReadModel GetCurrentProfile(string username)
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sqlAccount = "SELECT Id, UserName FROM Accounts WHERE UserName = @UserName";
            AccountReadModel accountReadModel = null;
            using (var connection = new SqlConnection(connectionString))
            {
                accountReadModel = connection.QueryFirstOrDefault<AccountReadModel>(
                    sqlAccount, new { UserName = username });
            }

            if (accountReadModel == null)
            {
                return null;
            }

            string sql = "SELECT P.Id, " +
                         "P.AccountId, " +
                         "P.AolAccountName, " +
                         "P.IcqAccountName, " +
                         "P.GoogleAccountName, " +
                         "P.MsnAccountName, " +
                         "P.SkypeAccountName, " +
                         "P.YahooAccountName, " +
                         "P.LevelOfExperienceId, " +
                         "P.YearOfFirstTank, " +
                         "P.NumberOfTanksOwned, " +
                         "P.NumberOfFishOwned, " +
                         "P.Signature, " +
                         "A.Id as ProfileAttributeId, " +
                         "A.ProfileAttributeTypeId, " +
                         "A.Response " +
                         "FROM Profiles P " +
                         "INNER JOIN ProfileAttributes A ON P.Id = A.ProfileId " +
                         "WHERE p.AccountId = @AccountId";

            using (var connection = new SqlConnection(connectionString))
            {
                var profileDictionary = new Dictionary<Guid, GetCurrentProfileReadModel>();

                var currentProfile = connection.Query<GetCurrentProfileReadModel, ProfileAttributeReadModel, GetCurrentProfileReadModel>(
                    sql, (profile, profileAttribute) =>
                    {
                        GetCurrentProfileReadModel profileEntry;
                        if (!profileDictionary.TryGetValue(profile.Id, out profileEntry))
                        {
                            profileEntry = profile;
                            profileEntry.Attributes = new List<ProfileAttributeReadModel>();
                            profileDictionary.Add(profileEntry.Id, profileEntry);
                        }

                        profileEntry.Attributes.Add(profileAttribute);
                        return profileEntry;

                    },
                    splitOn: "ProfileAttributeId", param: new { AccountId = accountReadModel.Id }).FirstOrDefault();
                return currentProfile;
            }
        }

        public bool ShouldShowAttribute(
            Guid privacyFlagTypeId, 
            List<GetPrivacyFlagListByProfileReadModel> profileFlags)
        {
            bool result = false;
            bool isFriend = false;

            if (profileFlags.Where(x => x.PrivacyFlagTypeId == privacyFlagTypeId 
                && x.VisibilityName == Visibility.Private).Any())
            {
                result = false;
            }
            else if (profileFlags.Where(x => x.PrivacyFlagTypeId == privacyFlagTypeId
                && x.VisibilityName == Visibility.Friend).Any() && isFriend)
            {
                 result = true;
            }
            else if (profileFlags.Where(x => x.PrivacyFlagTypeId == privacyFlagTypeId
                && x.VisibilityName == Visibility.Public).Any())
            {
                result = true;
            }
            else
            {
                result = false;
            }
                
            return result;
        }
    }
}