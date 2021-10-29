using Dapper;
using MinhLam.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinhLam.Social.Application.Profiles
{
    public class ProfileAttributeTypeQuery : IProfileAttributeTypeQuery
    {
        public List<GetProfileAttributeTypeReadModel> GetProfileAttributeTypeReadModelList()
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sql = "SELECT Id, Name, SortOrder FROM ProfileAttributeTypes ORDER BY SortOrder";

            using (var connection = new SqlConnection(connectionString))
            {
                var levelOfExperienceTypeLists = connection.Query<GetProfileAttributeTypeReadModel>(sql).ToList();
                return levelOfExperienceTypeLists;
            }
        }
    }
}
