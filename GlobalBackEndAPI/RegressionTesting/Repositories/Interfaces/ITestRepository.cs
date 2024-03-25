using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface ITestRepository
    {
        ICollection<Test> GetTests();
        Test? GetTest(int id);
        bool CreateTest(Test test);
        bool Save();
    }
}
