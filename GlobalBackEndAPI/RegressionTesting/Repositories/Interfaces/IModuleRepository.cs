using GlobalBackEndAPI.RegressionTesting.Models;

namespace GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        ICollection<Module> GetModules();
        Module? Get(Guid id);
        bool Create (Module module);
        bool Update(Module module);
        bool Delete(Module module);
        bool Save();
    }
}
