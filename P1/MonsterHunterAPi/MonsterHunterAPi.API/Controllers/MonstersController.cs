using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonsterHunterAPI.Data;
using MonsterHunterApi.Objects;

namespace MonsterHunterApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonstersController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly ILogger<MonstersController> _logger;

        // Constructor
        public MonstersController(IRepository repo, ILogger<MonstersController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // Methods

        // GET /api/monsters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monster>>> GetAllMonsters()
        {
            IEnumerable<Monster> monsters;

            try
            {
                monsters = await _repo.GetAllMonstersAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }

            return monsters.ToList();

        }
        
        
        // PUT /api/monsters
        [HttpPut]
        public async Task<ActionResult> UpdateMonster(int id)
        {
            try
            {
                StatusCodeResult rep = await _repo.UpdateMonsterAsync(id); 
                if (rep.StatusCode == 500) return StatusCode(500, "Monster could not be updated!");
            }
            catch (Exception e)
            {
                _logger.LogInformation("Error encountered: connecting to database in UpdateMonster");
                _logger.LogError(e.Message);
                return StatusCode(500, "Monster could not be inserted!");
            }
            return StatusCode(200);
        }
        

    }
}
