using Autofac;
using AutoMapper;
using Hastane.Business.AutoMapper;
using Hastane.Business.Services.AdminService;
using Hastane.DataAccess.Abstract;
using Hastane.DataAccess.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Business.IoC
{
    //Autofac // Ninject !! --> 
    public class DependencyResolver : Module
    {
        //IoC ---> Nested Lifetime --> 
        protected override void Load(ContainerBuilder builder)
        {
            //REPOSİTORY
            builder.RegisterType<AdminRepo>().As<IAdminRepo>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeRepo>().As<IEmployeeRepo>().InstancePerLifetimeScope();

            //SERVİCES
            builder.RegisterType<AdminService>().As<IAdminService>().InstancePerLifetimeScope();

            //AUTOMAPPER
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                //Mapping dosyamızıda buraya ekliyoruz gidip startup'ta eklemek zorunda kalmayalım zaten burasının görevi oraya sağlamak olacak.
                cfg.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();


            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            base.Load(builder);
        }

    }
}
