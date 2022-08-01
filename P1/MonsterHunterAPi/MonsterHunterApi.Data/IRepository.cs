using MonsterHunterApi.Objects;
using Microsoft.AspNetCore.Mvc;


namespace MonsterHunterAPI.Data
{
    public interface IRepository
    {
        Task<IEnumerable<Monster>> GetAllMonstersAsync();
        Task<Monster> GetAMonsterAsync(int id);

        Task<StatusCodeResult> UpdateMonsterAsync(int id);


    }
}