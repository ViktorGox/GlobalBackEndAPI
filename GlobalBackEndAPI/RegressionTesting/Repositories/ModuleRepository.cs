using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly RTDataContext _context;
        public ModuleRepository(RTDataContext rtDataContext)
        {
            //TODO: Check if null
            _context = rtDataContext;
        }
        public Module GetModule(int id)
        {
            return _context.Modules.Where(t => t.ModuleId == id).FirstOrDefault();
        }

        public ICollection<Module> GetModules()
        {
            return _context.Modules.OrderBy(t => t.ModuleId).ToList();
        }
    }
}
