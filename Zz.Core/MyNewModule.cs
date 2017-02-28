using Abp.Localization;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Abp.Web;
using System.Threading.Tasks;

namespace Zz
{

    //  我自己定义的MyNewModule 依赖 ZzCoreModule
     [DependsOn(typeof(ZzCoreModule))] 
    public class MyNewModule :AbpModule
    {

        // 通过构造函数 把 ZzCoreModule 注入到了 MyNewModul 里面
        private ZzCoreModule CoreModule;

        public MyNewModule(ZzCoreModule _ZzCoreModule)
        {
            CoreModule = _ZzCoreModule;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            base.Initialize();
        }

        public override void PreInitialize()
        {

            //  在这个方法里面 注册 MyNewModuleConfig 这个类。 MyNewModule的配置类
            IocManager.Register<MyNewModuleConfig>();

            //IModuleConfigurations 扩展方法
            Configuration.Modules.MyModule().SampleConfig1 = false;


            /// 扩展的string 
            string str = "abc";
            str=str.HaHa();


            //  Configuration.Modules.AbpWeb().SendAllExceptionsToClients = true;
            /// 调用其他模块里面的方法，依赖模块
            CoreModule.Logger.Info("自己定义的模块，在MyNewModule中调用ZzCoreModule里面的方法"); //Call MyModule1's method

            //为应用添加语言
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
        }
    }
}
