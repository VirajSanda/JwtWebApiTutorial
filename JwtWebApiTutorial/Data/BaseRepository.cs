using Microsoft.Data.SqlClient;
using System.Data;

namespace JwtWebApiTutorial.Data
{
    public class BaseRepository
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            string connectionString = "Server=TVM\\SQLEXPRESS; Database=InvestmentSummary; Trusted_Connection=true; TrustServerCertificate=true";
            con = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();  
        }
    }
}
