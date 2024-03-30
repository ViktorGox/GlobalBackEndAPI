using GlobalBackEndAPI.Global;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class TestRepository : BaseRepository<RTDataContext, Test>, ITestRepository
    {
        public TestRepository(RTDataContext rtDataContext) : base(rtDataContext) { }

        public ICollection<Test> GetCollection()
        {
            return _context.Test.OrderBy(t => t.TestId).ToList();
        }
    }
}
