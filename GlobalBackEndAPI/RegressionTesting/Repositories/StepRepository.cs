using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class StepRepository : IStepRepository
    {
        private readonly RTDataContext _context;
        public StepRepository(RTDataContext rtDataContext)
        {
            //TODO: Check if null
            _context = rtDataContext;
        }
        public Step GetStep(int id)
        {
            return _context.Steps.Where(t => t.StepId == id).FirstOrDefault();
        }

        public ICollection<Step> GetSteps()
        {
            return _context.Steps.OrderBy(t => t.StepId).ToList();
        }
    }
}
