using Dapper;
using MinhLam.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinhLam.Social.Application.Profiles
{
    public class AccountQuery : IAccountQuery
    {
        public GetCurrentAccountReadModel GetCurrentAccount(string username)
        {
            var connectionString = Connection.GetConnectionString("Social");

            string sql = "SELECT A.Id AS AccountId, A.FirstName, A.LastName, A.LastUpdated, A.ZipCode AS Zip, " +
                                "A.BirthDate, A.Email, P.Id As ProfileId, P.AolAccountName, P.IcqAccountName, P.MsnAccountName, " +
                                "P.SkypeAccountName, P.YahooAccountName, P.NumberOfFishOwned, " +
                                "P.NumberOfTanksOwned, P.YearOfFirstTank, P.UseGravatar, P.Avatar, P.AvatarMimeType, L.Name AS LevelOfExperience, " +
                                "PA.Id AS AttributeId, PAT.Name AS AttributeTypeName, PA.Response, PAT.PrivacyFlagTypeId " +
                         "FROM Accounts A " +
                         "LEFT JOIN  Profiles P ON A.Id = P.AccountId " +
                         "LEFT JOIN  LevelOfExperiences L ON P.LevelOfExperienceId = L.Id " +
                         "LEFT JOIN  ProfileAttributes PA ON P.Id = PA.ProfileId " +
                         "LEFT JOIN  ProfileAttributeTypes PAT ON PA.ProfileAttributeTypeId = PAT.Id " +
                         "WHERE A.UserName = @Username";

            using (var connection = new SqlConnection(connectionString))
            {
                var accountDictionary = new Dictionary<Guid, GetCurrentAccountReadModel>();

                var currentAccount =
                    connection.Query<GetCurrentAccountReadModel,
                            CurrentAccountProfileReadModel,
                            CurrentAccountProfileAttributeReadModel,
                            GetCurrentAccountReadModel>(
                    sql, (account, profile, profileAttribute) =>
                    {
                        GetCurrentAccountReadModel accountEntry;
                        if (!accountDictionary.TryGetValue(account.AccountId, out accountEntry))
                        {
                            accountEntry = account;
                            accountDictionary.Add(accountEntry.AccountId, accountEntry);
                        }

                        if (accountEntry.Profile == null)
                        {
                            if (profile == null)
                            {
                                profile = new CurrentAccountProfileReadModel
                                {
                                    ProfileId = Guid.Empty,
                                    AolAccountName = string.Empty,
                                    GoogleAccountName = string.Empty,
                                    IcqAccountName = string.Empty,
                                    LevelOfExperience = string.Empty,
                                    MsnAccountName = string.Empty,
                                    NumberOfFishOwned = 0,
                                    NumberOfTanksOwned = 0,
                                    SkypeAccountName = string.Empty,
                                    YahooAccountName = string.Empty,
                                    YearOfFirstTank = 0,
                                    UseGravatar = false,
                                    Avatar = null,
                                    AvatarMimeType = string.Empty,
                                    Attributes = new List<CurrentAccountProfileAttributeReadModel>()
                                };
                            }

                            accountEntry.Profile = profile;
                        }

                        if (accountEntry.Profile != null)
                        {
                            if (accountEntry.Profile.Attributes == null)
                            {
                                accountEntry.Profile.Attributes = new List<CurrentAccountProfileAttributeReadModel>();
                            }

                            if (profileAttribute != null)
                            {
                                if (!accountEntry.Profile.Attributes.Any(x => x.AttributeId == profileAttribute.AttributeId))
                                {
                                    accountEntry.Profile.Attributes.Add(profileAttribute);
                                }
                            }
                        }

                        return accountEntry;

                    },
                    splitOn: "ProfileId,AttributeId", param: new { Username = username }).FirstOrDefault();
                return currentAccount;
            }
        }

        public GetCurrentAccountReadModel GetCurrentAccount(Guid id)
        {
            var connectionString = Connection.GetConnectionString("Social");

            string sql = "SELECT A.Id AS AccountId, A.FirstName, A.LastName, A.LastUpdated, A.ZipCode AS Zip, " +
                                "A.BirthDate, A.Email, P.Id As ProfileId, P.AolAccountName, P.IcqAccountName, P.MsnAccountName, " +
                                "P.SkypeAccountName, P.YahooAccountName, P.NumberOfFishOwned, " +
                                "P.NumberOfTanksOwned, P.YearOfFirstTank, P.UseGravatar, P.Avatar, P.AvatarMimeType, L.Name AS LevelOfExperience, " +
                                "PA.Id AS AttributeId, PAT.Name AS AttributeTypeName, PA.Response, PAT.PrivacyFlagTypeId " +
                         "FROM Accounts A " +
                         "LEFT JOIN  Profiles P ON A.Id = P.AccountId " +
                         "LEFT JOIN  LevelOfExperiences L ON P.LevelOfExperienceId = L.Id " +
                         "LEFT JOIN  ProfileAttributes PA ON P.Id = PA.ProfileId " +
                         "LEFT JOIN  ProfileAttributeTypes PAT ON PA.ProfileAttributeTypeId = PAT.Id " +
                         "WHERE A.Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                var accountDictionary = new Dictionary<Guid, GetCurrentAccountReadModel>();

                var currentAccount =
                    connection.Query<GetCurrentAccountReadModel,
                            CurrentAccountProfileReadModel,
                            CurrentAccountProfileAttributeReadModel,
                            GetCurrentAccountReadModel>(
                    sql, (account, profile, profileAttribute) =>
                    {
                        GetCurrentAccountReadModel accountEntry;
                        if (!accountDictionary.TryGetValue(account.AccountId, out accountEntry))
                        {
                            accountEntry = account;
                            accountDictionary.Add(accountEntry.AccountId, accountEntry);
                        }

                        if (accountEntry.Profile == null)
                        {
                            if (profile == null)
                            {
                                profile = new CurrentAccountProfileReadModel
                                {
                                    ProfileId = Guid.Empty,
                                    AolAccountName = string.Empty,
                                    GoogleAccountName = string.Empty,
                                    IcqAccountName = string.Empty,
                                    LevelOfExperience = string.Empty,
                                    MsnAccountName = string.Empty,
                                    NumberOfFishOwned = 0,
                                    NumberOfTanksOwned = 0,
                                    SkypeAccountName = string.Empty,
                                    YahooAccountName = string.Empty,
                                    YearOfFirstTank = 0,
                                    UseGravatar = false,
                                    Avatar = null,
                                    AvatarMimeType = string.Empty,
                                    Attributes = new List<CurrentAccountProfileAttributeReadModel>()
                                };
                            }

                            accountEntry.Profile = profile;
                        }

                        if (accountEntry.Profile != null)
                        {
                            if (accountEntry.Profile.Attributes == null)
                            {
                                accountEntry.Profile.Attributes = new List<CurrentAccountProfileAttributeReadModel>();
                            }

                            if (profileAttribute != null)
                            {
                                if (!accountEntry.Profile.Attributes.Any(x => x.AttributeId == profileAttribute.AttributeId))
                                {
                                    accountEntry.Profile.Attributes.Add(profileAttribute);
                                }
                            }
                        }

                        return accountEntry;

                    },
                    splitOn: "ProfileId,AttributeId", param: new { Id = id }).FirstOrDefault();
                return currentAccount;
            }
        }
    }
}
