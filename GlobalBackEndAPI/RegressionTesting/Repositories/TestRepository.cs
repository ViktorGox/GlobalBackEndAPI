using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly RTDataContext _context;
        public TestRepository(RTDataContext rtDataContext)
        {
            _context = rtDataContext;
        }

        public Test? GetTest(int id)
        {
            return _context.Test.Where(t => t.TestId == id).FirstOrDefault();
        }

        public ICollection<Test> GetTests()
        {
            return _context.Test.OrderBy(t => t.TestId).ToList();
        }

        public bool CreateTest(Test test)
        {
            _context.Add(test);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
