using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TC_CS03_API.Data
{
    /// <summary>
    /// An abstract class that implements a few methods to perform basic database operations.
    /// It uses Dapper as a data access mechanism to communicate with the database. Dapper was chosen because of its speed and simplicity.
    /// Dapper can be replaced with other ORMs, including Entity Framework Core if desired.
    /// </summary>
    public abstract class DBFactoryBase
    {
        private readonly IConfiguration _config;
        protected readonly ILogger _logger;

        public DBFactoryBase(IConfiguration config)
        {
            _config = config;
        }

        internal IDbConnection DbConnection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("SQLDBConnectionString"));
            }
        }

        public virtual async Task<IEnumerable<T>> DbQueryAsync<T>(string sql, object parameters = null)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    dbCon.Open();
                    if (parameters == null)
                        return await dbCon.QueryAsync<T>(sql);

                    return await dbCon.QueryAsync<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"some error message while trying to run sql: {0}", sql);
                throw;
            }
        }

        public virtual async Task<T> DbQuerySingleAsync<T>(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    dbCon.Open();
                    return await dbCon.QueryFirstOrDefaultAsync<T>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"some error message while trying to run sql: {0}", sql);
                throw;
            }
        }

        public virtual async Task<bool> DbExecuteAsync<T>(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    dbCon.Open();
                    return await dbCon.ExecuteAsync(sql, parameters) > 0;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"some error message while trying to run sql: {0}", sql);
                throw;
            }
        }

        public virtual async Task<bool> DbExecuteScalarAsync(string sql, object parameters)
        {
            try
            {
                using (IDbConnection dbCon = DbConnection)
                {
                    dbCon.Open();
                    return await dbCon.ExecuteScalarAsync<bool>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"some error message while trying to run sql: {0}", sql);
                throw;
            }
        }
    }
}
