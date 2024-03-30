using GlobalBackEndAPI.RegressionTesting.DTO.Test;
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
        public IActionResult GetTest(Guid testId)
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
        public IActionResult CreateTest([FromBody] TestPostDTO body)
        {
            if (body is null) return BadRequest(ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrWhiteSpace(body.Name))
            {
                return BadRequest($"The name is null");
            }

            Test test = new()
            {
                Name = body.Name,
                Description = body.Description,
                LastUpdate = DateTime.Now,
                CreatedOn = DateTime.Now,
            };

            if (!_testRepository.CreateTest(test))
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
        public IActionResult DeleteTest(Guid id) //TODO: what if I alter the test?
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Test? test = _testRepository.GetTest(id);

            if (test is null)
            {
                return NotFound(new ProblemDetails()
                {
                    Title = "Null reference",
                    Status = 404,
                    Detail = $"The requested test with id: {id} was not found."
                }); 
            }

            if (!_testRepository.DeleteTest(test))
            {
                ModelState.AddModelError("", "Yeh... It failed?");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [HttpPatch("{id}/name")] //TODO: Accpte multiple differnet things from the body?
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTestName(Guid id, [FromBody] TestPatchNameDTO body)
        {
            Test? test = _testRepository.GetTest(id);

            if (test is null)
            {
                return NotFound($"Test with id: {id} was not found. ");
            }

            if (string.IsNullOrWhiteSpace(body.Name))
            {
                return BadRequest($"Name cannot be empty or null.");
            }

            test.Name = body.Name;

            if (!_testRepository.UpdateTest(test))
            {
                ModelState.AddModelError("", "Yeh... It failed?");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        [HttpPatch("{id}/description")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTestDescription(Guid id, [FromBody] TestPatchDescriptionDTO body)
        {
            Test? test = _testRepository.GetTest(id);

            if (test is null)
            {
                return NotFound($"Test with id: {id} was not found. ");
            }

            test.Description = body.Description;

            if (!_testRepository.UpdateTest(test))
            {
                ModelState.AddModelError("", "Yeh... It failed?");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
    }
}
