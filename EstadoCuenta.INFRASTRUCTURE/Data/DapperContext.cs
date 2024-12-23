using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EstadoCuenta.INFRASTRUCTURE.Configurations
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration, string connectionString)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
       
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}


