using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace StorePOS.API.Helpers
{
    public class DbHelper
    {
        private readonly IConfiguration _config;
        public DbHelper(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection GetConnection()
        {
            var connStr = _config.GetConnectionString("DB");
            var con = new SqlConnection(connStr);
            return con;
        }


    }
}
