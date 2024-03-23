using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly RTDataContext _context;
        public StatusRepository(RTDataContext rtDataContext)
        {
            //TODO: Check if null
            _context = rtDataContext;
        }
        public Status GetStatus(int id)
        {
            return _context.Statuses.Where(t => t.StatusId == id).FirstOrDefault();
        }

        public ICollection<Status> GetStatuses()
        {
            return _context.Statuses.OrderBy(t => t.StatusId).ToList();
        }
    }
}
