using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataLibrary
{
    public class DataAccess : IDataAccess
    {
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection conn = new MySqlConnection(connectionString))
            {
                var rows = await conn.QueryAsync<T>(sql, parameters);

                return rows.ToList();
            }
        }
        public Task SavaData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection conn = new MySqlConnection(connectionString))
            {
                return conn.ExecuteAsync(sql, parameters);
            }
        }
    }
}
