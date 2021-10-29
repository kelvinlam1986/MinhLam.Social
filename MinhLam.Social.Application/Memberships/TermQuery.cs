using Dapper;
using MinhLam.Framework;
using System.Data.SqlClient;

namespace MinhLam.Social.Application.Memberships
{
    public class TermQuery : ITermQuery
    {
        public GetCurrentTermReadModel GetCurentTerm()
        {
            var connectionString = Connection.GetConnectionString("Social");
            string sql = "SELECT Id as TermId, Terms FROM Terms ORDER BY CreatedDate DESC";
           
            using (var connection = new SqlConnection(connectionString))
            {
                var currentTerm = connection.QueryFirstOrDefault<GetCurrentTermReadModel>(sql);
                return currentTerm;
            }
        }
    }
}
