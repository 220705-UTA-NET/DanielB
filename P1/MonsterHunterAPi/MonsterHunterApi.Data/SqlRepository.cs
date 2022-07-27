using Microsoft.Extensions.Logging;
using MonsterHunterApi.Objects;
using MonsterHunterAPI.Data;
using System.Data.SqlClient;

namespace MonsterHunterApi.Data
{
    public class SqlRepository : IRepository
    { 
        private readonly string _connectionString;
        private readonly ILogger<SqlRepository> _logger;

        public SqlRepository(string connectionString, ILogger<SqlRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<IEnumerable<Monster>> GetAllMonstersAsync()
        {
            List<Monster> result = new();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdText = "SELECT Id, Name, MonsterType FROM Monster.Monsters;";

            using SqlCommand cmd = new(cmdText, connection);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string monstertype = reader.GetString(2);

                Monster tmpMonster = new Monster(id, name, monstertype);
                result.Add(tmpMonster);
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed GetAllAssociatesAsync, returned {0} results", result.Count);

            return result;
        }
    }
}