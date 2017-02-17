using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Zz
{
    [DependsOn(typeof(ZzCoreModule), typeof(AbpAutoMapperModule))]
    public class ZzApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
