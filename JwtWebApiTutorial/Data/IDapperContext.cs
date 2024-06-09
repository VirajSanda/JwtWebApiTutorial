using System.Data;

namespace JwtWebApiTutorial.Data
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
