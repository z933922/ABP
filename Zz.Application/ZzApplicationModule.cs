using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Zz.DTOS;
using Model;
using System;

namespace Zz
{
    [DependsOn(typeof(ZzCoreModule), typeof(AbpAutoMapperModule))]
    public class ZzApplicationModule : AbpModule
    {
         /// <summary>
         ///   该模块里面所有要初始化的东西都应该这个方法里面执行  包括 automapper   配置缓存  注册管理模型等等
         ///    大部分要初始化的类 都在Module 里面的 PreInitialize 中执行了
         /// </summary>
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
                mapper.CreateMap<ZPeopleInput, Person>();
                var tt = mapper.CreateMap<Person, ZPeopleOutput>();
                tt.ForMember<string>(dto => dto.DoubleName, p => p.MapFrom(person => person.Name+person.Name));
                mapper.CreateMap<ZPeopleInput, Person>();

            });


            ///   这个是定义缓存  默认的是两小时
            Configuration.Caching.ConfigureAll(cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromHours(2);
            });

            //为特定的缓存配置有效期
            Configuration.Caching.Configure("MyCache", cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromHours(8);
            });

            //  注册设置管理
            Configuration.Settings.Providers.Add<MySettingProvider>();

            // 设置 审计日志 默认情况匿名登录是不惠济路日志的， 现在设置为匿名也可以记录日志
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
          
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
