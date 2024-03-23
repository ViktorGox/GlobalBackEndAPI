using AutoMapper;
using GlobalBackEndAPI.RegressionTesting.DTO;
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
        private readonly IMapper _mapper;
        public ModuleController(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Module>))]
        public IActionResult GetTest(int moduleId)
        {
            //TODO: What is model state?
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ModuleDTO module = _mapper.Map<ModuleDTO>(_moduleRepository.GetModule(moduleId));
            if (module == null) return NotFound();
            return Ok(module);
        }
    }
}
