using AutoMapper;
using GlobalBackEndAPI.RegressionTesting.DTO;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBackEndAPI.RegressionTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        public StatusController(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Status>))]
        public IActionResult GetTest(int statusId)
        {
            //TODO: What is model state?
            if (!ModelState.IsValid) return BadRequest(ModelState);
            StatusDTO status = _mapper.Map<StatusDTO>(_statusRepository.GetStatus(statusId));
            if (status == null) return NotFound();
            return Ok(status);
        }
    }
}
