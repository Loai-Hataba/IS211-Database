using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental
{
    public static class DatabaseManager
    {
        private static readonly string _connectionString;

        static DatabaseManager()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = config.GetConnectionString("MovieDB");
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public static string ConnectionString => _connectionString;

        public static DataTable FetchData(string query)
        {

            var dt = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
