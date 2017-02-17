using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Zz.EntityFramework;

namespace Zz.Migrator
{
    [DependsOn(typeof(ZzDataModule))]
    public class ZzMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<ZzDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}