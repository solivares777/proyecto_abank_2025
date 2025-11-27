
namespace ApiRestABankMySql.data
{
    using MySql.Data.MySqlClient;
    using System.Data;

    public class MySqlContext
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public MySqlContext(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("MySqlConnection");
        }

        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}
