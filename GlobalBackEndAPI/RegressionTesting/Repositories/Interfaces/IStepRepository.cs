using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface IStepRepository
    {
        ICollection<Step> GetSteps();
        Step GetStep(int id);
    }
}
