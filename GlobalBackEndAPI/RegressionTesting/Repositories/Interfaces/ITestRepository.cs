using GlobalBackEndAPI.Global;
using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface ITestRepository : IBaseEntityRepository<Test>, IGetListRepository<Test>
    {
    }
}
