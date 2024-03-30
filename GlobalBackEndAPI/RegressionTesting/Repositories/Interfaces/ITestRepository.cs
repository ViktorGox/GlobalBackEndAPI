using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface ITestRepository
    {
        ICollection<Test> GetTests();
        Test? Get(Guid id);
        bool Create(Test test);
        bool Update(Test test);
        bool Delete(Test test);
        bool Save();
    }
}
