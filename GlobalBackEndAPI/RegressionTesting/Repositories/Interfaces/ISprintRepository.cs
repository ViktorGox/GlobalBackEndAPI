using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface ISprintRepository
    {
        ICollection<Sprint> GetSprints();
        Sprint GetSprint(int id);
    }
}
