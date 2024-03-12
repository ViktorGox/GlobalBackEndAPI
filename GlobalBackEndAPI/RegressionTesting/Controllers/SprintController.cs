using AutoMapper;
using GlobalBackEndAPI.RegressionTesting.DTO;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBackEndAPI.RegressionTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : Controller
    {
        private readonly ISprintRepository _sprintRepository;
        private readonly IMapper _mapper;
        public SprintController(ISprintRepository sprintRepository, IMapper mapper)
        {
            _sprintRepository = sprintRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Sprint>))]
        public IActionResult GetTest(int sprintId)
        {
            //TODO: What is model state?
            if (!ModelState.IsValid) return BadRequest(ModelState);
            SprintDTO sprint = _mapper.Map<SprintDTO>(_sprintRepository.GetSprint(sprintId));
            if (sprint == null) return NotFound();
            return Ok(sprint);
        }
    }
}
