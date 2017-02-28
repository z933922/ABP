using Abp.Configuration.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zz
{
  public class MyNewModuleConfig
    {
        public bool SampleConfig1 { get; set; }

        public string SampleConfig2 { get; set; }
    }

    public static class MyModuleConfigurationExtensions
    {

        /// <summary>
        ///  
        /// </summary>
        /// <param name="moduleConfigurations"></param>
        /// <returns></returns>
        public static MyNewModuleConfig MyModule(this IModuleConfigurations moduleConfigurations)
        {
            return moduleConfigurations.AbpConfiguration
                .GetOrCreate("MyNewModuleConfig",
                    () => moduleConfigurations.AbpConfiguration.IocManager.Resolve<MyNewModuleConfig>()
                );
        }

        public static string  HaHa(this String str)
        {

            return str + str;
        }

    }
}
