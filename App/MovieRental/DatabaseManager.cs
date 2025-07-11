﻿using Microsoft.Data.SqlClient;
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

            _connectionString = config.GetConnectionString("MovieRentalDB");
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public static string ConnectionString => _connectionString;

        public static List<T> FetchData<T>(string query, Func<SqlDataReader, T> mapFunction)
        {
            var list = new List<T>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(mapFunction(reader));
                    }
                }
            }

            return list;
        }
        public static List<genreItem> GetGenreById(int genreId)
        {
            string query = $"SELECT * FROM Genre WHERE GenreID = {genreId}";

            List<genreItem> genreItemss = DatabaseManager.FetchData(query, reader => new genreItem
            {
                id = reader.GetInt32(0),
                title = reader.GetString(1)
            });

            return genreItemss;
        }
        public static void InsertData(string query, Dictionary<string, object> parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
