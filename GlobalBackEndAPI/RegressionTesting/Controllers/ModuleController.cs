using GlobalBackEndAPI.RegressionTesting.DTO.Module;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBackEndAPI.RegressionTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : Controller
    {
        private readonly IModuleRepository _moduleRepository;
        public ModuleController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        [HttpGet("{moduleId}")]
        [ProducesResponseType(200, Type = typeof(Module))]
        [ProducesResponseType(404)]
        public IActionResult GetModule(Guid moduleId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Module? module = _moduleRepository.Get(moduleId);

            if (module == null) return NotFound();
            return Ok(module);
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(ICollection<Module>))]
        public IActionResult GetModules()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ICollection<Module> modules = _moduleRepository.GetModules();

            return Ok(modules);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateTest([FromBody] ModuleDTO body)
        {
            if (body is null) return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(body.Label))
            {
                return BadRequest($"The label is null");
            }

            Module module = new()
            {
                Label = body.Label
            };

            if (!_moduleRepository.Create(module))
            {
                ModelState.AddModelError("", "Yeh... It failed?");
                return StatusCode(500, ModelState);
            }

            return Created();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTest(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Module? module = _moduleRepository.Get(id);

            if (module is null)
            {
                return NotFound(new ProblemDetails()
                {
                    Title = "Null reference",
                    Status = 404,
                    Detail = $"The requested module with id: {id} was not found."
                });
            }

            if (!_moduleRepository.Delete(module))
            {
                ModelState.AddModelError("", "Yeh... It failed?");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
    }
}
