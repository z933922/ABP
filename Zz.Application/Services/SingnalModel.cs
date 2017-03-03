using Abp.Application.Services;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zz.DTOS;

namespace Zz.Services
{
    /// <summary>
    ///   ISingletonDependency   正常的依赖注入按照它默认的  接口继承一个空接口IApplicationService
    ///    可是这个在实现接口的时候实现ISingletonDependency  是个单例模式的注入
    /// </summary>
    public class SingnalModel : ISingnalModel, ISingletonDependency
    {

        public IAbpSession AbpSession { get; set; }

        public SingnalModel()
        {
            AbpSession = NullAbpSession.Instance;
        }

    }


    /// <summary>
    ///  IWindsorInstaller 注册
    /// </summary>
    //public class MyInstaller : IWindsorInstaller
    //{
    //    //public void Install(IWindsorContainer container, IConfigurationStore store)
    //    //{
    //    //    container.Register(Classes.FromThisAssembly().BasedOn<ISingnalModel>().LifestylePerThread().WithServiceSelf());
    //    //}
    //}

    public class MyClass : ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }

        public MyClass()
        {
            AbpSession = NullAbpSession.Instance;
        }

        public void MyMethod()
        {
            var currentUserId = AbpSession.UserId;
           
        }
    }
}
