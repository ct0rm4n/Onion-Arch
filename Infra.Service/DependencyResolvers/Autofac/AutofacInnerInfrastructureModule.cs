using Autofac;
using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Microsoft.AspNetCore.Identity;
using Services;
using System.Reflection;
using Module = Autofac.Module;

namespace DependencyResolvers.Autofac
{
    public class AutofacInnerInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericService<,,>))
                .As(typeof(IGenericService<,,>)).InstancePerLifetimeScope();

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            var dataAccess = Assembly.GetExecutingAssembly();
            Assembly repoServiceAssembly = Assembly.GetAssembly(typeof(AppDbContext));
                        
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            //builder.RegisterType<AppRoleStore>().As<IRoleStore<AppRole>>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<AppRoleService>().As<IAppRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductFeatureService>().As<IProductFeatureService>().InstancePerLifetimeScope();
            builder.RegisterType<SupplierService>().As<ISupplierService>().InstancePerLifetimeScope();
            builder.RegisterType<ToDoService>().As<IToDoService>().InstancePerLifetimeScope();            
        }
    }
}
