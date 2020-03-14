using Autofac;
using Business.Base.Impl;
using Business.Base.Interface;
using Business.Impl;
using Business.Interface;
using DataAccess.EntityFramework.Base;
using DataAccess.Interface;

namespace Builder
{
    public class BuilderFactory : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<EntityFrameworkProductDataAccess>().As<IProductDataAccess>();
            builder.RegisterType<LoggerService>().As<ILoggerService>();
            builder.RegisterType<EntityFrameworkLoggerDataAccess>().As<ILoggerDataAccess>();
        }
    }
}
