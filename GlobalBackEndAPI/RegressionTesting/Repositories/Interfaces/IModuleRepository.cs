using GlobalBackEndAPI.Global;
using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface IModuleRepository : IBaseEntityRepository<Module>, IGetListRepository<Module>
    {
    }
}
