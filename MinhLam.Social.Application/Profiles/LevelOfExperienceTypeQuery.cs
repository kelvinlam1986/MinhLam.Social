using Dapper;
using MinhLam.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinhLam.Social.Application.Profiles
{
    public class LevelOfExperienceTypeQuery : ILevelOfExperienceTypeQuery
    {
        public List<GetLevelOfExperienceTypeListReadModel> GetLevelOfExperienceTypeList()
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sql = "SELECT Id, Name, SortOrder FROM LevelOfExperiences ORDER BY SortOrder";

            using (var connection = new SqlConnection(connectionString))
            {
                var levelOfExperienceTypeLists = connection.Query<GetLevelOfExperienceTypeListReadModel>(sql).ToList();
                return levelOfExperienceTypeLists;
            }
        }
    }
}
