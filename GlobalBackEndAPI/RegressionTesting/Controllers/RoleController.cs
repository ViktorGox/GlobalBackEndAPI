using AutoMapper;
using GlobalBackEndAPI.RegressionTesting.DTO;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBackEndAPI.RegressionTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleController(IRoleRepository repoRepository, IMapper mapper)
        {
            _roleRepository = repoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Role>))]
        public IActionResult GetTest(int roleId)
        {
            //TODO: What is model state?
            if (!ModelState.IsValid) return BadRequest(ModelState);
            RoleDTO role = _mapper.Map<RoleDTO>(_roleRepository.GetRole(roleId));
            if (role == null) return NotFound();
            return Ok(role);
        }
    }
}
