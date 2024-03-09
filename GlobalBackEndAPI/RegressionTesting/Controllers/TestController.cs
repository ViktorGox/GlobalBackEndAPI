using AutoMapper;
using GlobalBackEndAPI.RegressionTesting.DTO;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBackEndAPI.RegressionTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        public TestController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Test>))]
        public IActionResult GetTest(int testId)
        {
            //TODO: What is model state?
            if (!ModelState.IsValid) return BadRequest(ModelState);
            TestDTO test = _mapper.Map<TestDTO>(_testRepository.GetTest(testId));
            if (test == null) return NotFound();
            return Ok(test);
        }
    }
}
