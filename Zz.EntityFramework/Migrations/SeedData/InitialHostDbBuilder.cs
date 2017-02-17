using Zz.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Zz.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly ZzDbContext _context;

        public InitialHostDbBuilder(ZzDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
