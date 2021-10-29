using Dapper;
using MinhLam.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinhLam.Social.Application.Profiles
{
    public class PrivacyFlagQuery : IPrivacyFlagQuery
    {
        public List<GetPrivacyFlagListByProfileReadModel> GetPrivacyFlagsByProfile(Guid profileId)
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sql = "SELECT P.Id, P.PrivacyFlagTypeId, P.ProfileId, P.VisibilityId, V.Name AS VisibilityName, P.CreatedDate " +
                         "FROM PrivacyFlags P " +
                         "INNER JOIN Visibilities V ON P.VisibilityId = V.Id " +
                         "WHERE ProfileId = @ProfileId";
            using (var connection = new SqlConnection(connectionString))
            {
                var privacyFlags = 
                    connection.Query<GetPrivacyFlagListByProfileReadModel>(sql, 
                        new { ProfileId = profileId }).ToList();
                return privacyFlags;
;
            }
        }
    }
}