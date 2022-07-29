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

            string cmdText = "SELECT Id, Name, MonsterType, Fire, Water, Thunder, Ice, Dragon, TimesHunted FROM MonsterHunter.Monsters;";


            using SqlCommand cmd = new(cmdText, connection);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string monstertype = reader.GetString(2);
                int fire = reader.GetInt32(3);
                int water = reader.GetInt32(4);
                int thunder = reader.GetInt32(5);
                int ice = reader.GetInt32(6);
                int dragon = reader.GetInt32(7);
                int timeshunted = reader.GetInt32(8);

                Monster tmpMonster = new Monster(id, name, monstertype, fire, water, thunder, ice, dragon, timeshunted);
                result.Add(tmpMonster);
            }

            await connection.CloseAsync();

            _logger.LogInformation("Executed GetAllAssociatesAsync, returned {0} results", result.Count);

            return result;
        }
        public async Task UpdateMonsterAsync(int id)
        {
            string cmdText = "UPDATE MonsterHunter.Monsters SET TimesHunted = TimesHunted + 1 WHERE Id = ";
            string comdText = String.Concat(cmdText, id);
            SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using SqlCommand cmd = new(comdText, connection);
            using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            // Add the parameters for the UpdateCommand.
            sqlDataAdapter.UpdateCommand = cmd;

            await connection.CloseAsync();

        }
    }
}