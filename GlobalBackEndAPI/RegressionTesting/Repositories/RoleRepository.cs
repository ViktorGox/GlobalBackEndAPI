using GlobalBackEndAPI.RegressionTesting.Models;
using GlobalBackEndAPI.RegressionTesting.Repositories.Interfaces;
using GlobalBackEndAPI.RegressionTesting.SetUp;

namespace GlobalBackEndAPI.RegressionTesting.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RTDataContext _context;
        public RoleRepository(RTDataContext rtDataContext)
        {
            //TODO: Check if null
            _context = rtDataContext;
        }

        public Role GetRole(int id)
        {
            return _context.Roles.Where(t => t.RoleId == id).FirstOrDefault();
        }

        public ICollection<Role> GetRoles()
        {
            return _context.Roles.OrderBy(t => t.RoleId).ToList();
        }
    }
}
