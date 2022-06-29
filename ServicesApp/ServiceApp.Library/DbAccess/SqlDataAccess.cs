﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ServiceApp.Library.DbAccess
{

    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<T>> LoadDataAsyncViews<T>(string view, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(view, commandType: CommandType.Text);
        }

        public async Task SaveDataAsync<T>(string storedProcedire, T parameters, string connectionId = "Default")
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId)))
            {
                connection.Open();
                await connection.ExecuteAsync(storedProcedire, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
