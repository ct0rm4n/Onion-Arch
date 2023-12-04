using Application.Repositories;
using Autofac;
using Infraestrutura.Context;
using Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Module = Autofac.Module;
namespace DependencyResolvers.Autofac
{
    public class AutofacPersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();

            //Assembly executingAssembly = Assembly.GetExecutingAssembly();

            //Assembly repoServiceAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            //builder.RegisterAssemblyTypes(executingAssembly)
            //    .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();
            var dataAccess = Assembly.GetExecutingAssembly();
            Assembly repoServiceAssembly = Assembly.GetAssembly(typeof(AppDbContext));

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();//.InstancePerLifetimeScope();
            builder.Register(c =>
            {
                IConfiguration config = c.Resolve<IConfiguration>();

                DbContextOptionsBuilder<AppDbContext> opt = new DbContextOptionsBuilder<AppDbContext>();
                opt.UseSqlServer(config.GetSection("ConnectionStrings:SqlConnection").Value);
                return new AppDbContext(opt.Options);
            }).AsSelf().InstancePerLifetimeScope();

        }
    }
}
