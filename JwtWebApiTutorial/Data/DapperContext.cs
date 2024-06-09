using Microsoft.Data.SqlClient;
using System.Data;

namespace JwtWebApiTutorial.Data
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _iConfiguration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            _connectionString = _iConfiguration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
