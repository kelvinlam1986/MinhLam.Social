using Dapper;
using MinhLam.Framework;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinhLam.Social.Application.Profiles
{
    public class VisibilityQuery : IVisibilityQuery
    {
        public List<GetVisibilityListReadModel> GetVisibilities()
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sql = "SELECT Id, Name FROM Visibilities ";
            using (var connection = new SqlConnection(connectionString))
            {
                var visibilities = connection.Query<GetVisibilityListReadModel>(sql).ToList();
                return visibilities;
            }
        }
    }
}
