using Dapper;
using MinhLam.Framework;
using System;
using System.Data.SqlClient;

namespace MinhLam.Social.Application.Memberships
{
    public class MembershipProfileQuery : IMembershipProfileQuery
    {
        public GetMembershipCurrentProfileReadModel GetCurrentProfile(Guid accountId)
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sql = "SELECT Id as ProfileId FROM Profiles WHERE AccountId = @AccountId";

            using (var connection = new SqlConnection(connectionString))
            {
                var currentProfile = 
                    connection.QueryFirstOrDefault<GetMembershipCurrentProfileReadModel>(sql, new { AccountId = accountId  });
                return currentProfile;
            }
        }
    }
}
