using GlobalBackEndAPI.Global;
using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class ModuleRepository : BaseRepository<RTDataContext, Module>, IModuleRepository
    {
        public ModuleRepository(RTDataContext rtDataContext) : base(rtDataContext) { }

        public ICollection<Module> GetCollection()
        {
            return _context.Module.OrderBy(m => m.ModuleId).ToList();
        }
    }
}
