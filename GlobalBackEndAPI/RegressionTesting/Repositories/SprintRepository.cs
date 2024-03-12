using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        private readonly RTDataContext _context;
        public SprintRepository(RTDataContext rtDataContext)
        {
            //TODO: Check if null
            _context = rtDataContext;
        }

        public Sprint GetSprint(int id)
        {
            return _context.Sprint.Where(t => t.SprintId == id).FirstOrDefault();
        }

        public ICollection<Sprint> GetSprints()
        {
            return _context.Sprint.OrderBy(t => t.SprintId).ToList();
        }
    }
}
