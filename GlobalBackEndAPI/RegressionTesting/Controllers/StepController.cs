using AutoMapper;
using GlobalBackEndAPI.RegressionTesting.DTO;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBackEndAPI.RegressionTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepController : Controller
    {
        private readonly IStepRepository _stepRepository;
        private readonly IMapper _mapper;
        public StepController(IStepRepository stepRepository, IMapper mapper)
        {
            _stepRepository = stepRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Step>))]
        public IActionResult GetTest(int stepId)
        {
            //TODO: What is model state?
            if (!ModelState.IsValid) return BadRequest(ModelState);
            StepDTO step = _mapper.Map<StepDTO>(_stepRepository.GetStep(stepId));
            if (step == null) return NotFound();
            return Ok(step);
        }
    }
}
