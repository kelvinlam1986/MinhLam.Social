using Dapper;
using MinhLam.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinhLam.Social.Application.Profiles
{
    public class PrivacyFlagTypeQuery : IPrivacyFlagTypeQuery
    {
        public List<GetPrivacyFlagTypeListReadModel> GetMandatoryPrivacyFlagTypes()
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sql = "SELECT Id, FieldName, SortOrder FROM PrivacyFlagTypes " +
                         "WHERE FieldName = 'IM' " +
                         "OR FieldName = 'Account Info' " +
                         "OR FieldName = 'Tank Info' " +
                         "ORDER BY SortOrder";
            using (var connection = new SqlConnection(connectionString))
            {
                var privacyFlagTypes = connection.Query<GetPrivacyFlagTypeListReadModel>(sql).ToList();
                return privacyFlagTypes;
            }
        }

        public List<GetPrivacyFlagTypeListReadModel> GetPrivacyFlagTypes()
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sql = "SELECT Id, FieldName, SortOrder FROM PrivacyFlagTypes ORDER BY SortOrder";
            using (var connection = new SqlConnection(connectionString))
            {
                var privacyFlagTypes = connection.Query<GetPrivacyFlagTypeListReadModel>(sql).ToList();
                return privacyFlagTypes;
            }
        }
    }
}
