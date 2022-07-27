using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonsterHunterApi;
using MonsterHunterApi;
using MonsterHunterAPI.Data;

namespace MonsterHunterApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonstersController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly ILogger<AssociatesController> _logger;

        // Constructor
        public MonstersController(IRepository repo, ILogger<AssociatesController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // Methods

        // GET /api/associates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Associate>>> GetAllAssociates()
        {
            IEnumerable<Associate> associates;

            try
            {
                associates = await _repo.GetAllAssociatesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(500);
            }

            return associates.ToList();

        }
    }
}
