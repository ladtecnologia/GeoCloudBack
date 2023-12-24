using System;
using System.Data;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace GeoCloudAI.Persistence.Data
{
    public class DbSession : IDisposable
        {
            public IDbConnection Connection { get; }

            public DbSession(IConfiguration configuration)
            {
                Connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));

                Connection.Open();
            }
            public void Dispose() => Connection?.Dispose();
        }
}