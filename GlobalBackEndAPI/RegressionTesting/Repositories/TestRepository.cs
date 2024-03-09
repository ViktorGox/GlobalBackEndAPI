using GlobalBackEndAPI.RegressionTesting.Data;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly RTDataContext _context;
        public TestRepository(RTDataContext rtDataContext)
        {
            //TODO: Check if null
            _context = rtDataContext;
        }

        public Test GetTest(int id)
        {
            return _context.Tests.Where(t => t.Id == id).FirstOrDefault();
        }

        public ICollection<Test> GetTests()
        {
            return _context.Tests.OrderBy(t => t.Id).ToList();
        }
    }
}
