using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        ICollection<Status> GetStatuses();
        Status GetStatus(int id);
    }
}
