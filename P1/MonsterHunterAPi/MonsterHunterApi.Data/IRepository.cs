using MonsterHunterApi.Objects;

namespace MonsterHunterAPI.Data
{
    public interface IRepository
    {
        Task<IEnumerable<Monster>> GetAllMonstersAsync();

        
       // Task DeleteAssociatesAsync();
        
    }
}