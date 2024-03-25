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
        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet("{testId}")]
        [ProducesResponseType(200, Type = typeof(Test))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetTest(int testId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Test? test = _testRepository.GetTest(testId);

            if (test == null) return NotFound();
            return Ok(test);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Test>))]
        public IActionResult GetTests()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            ICollection<Test> tests = _testRepository.GetTests();

            return Ok(tests);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateTest([FromBody] Test body)
        {
            if (body is null) return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_testRepository.CreateTest(body))
            {
                ModelState.AddModelError("", "Yeh... It failed?");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");
        }
    }
}
