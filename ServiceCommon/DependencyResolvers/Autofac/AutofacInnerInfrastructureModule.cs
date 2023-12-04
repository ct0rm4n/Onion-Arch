using Autofac;
using Infraestrutura.Context;
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

            //builder.RegisterAssemblyTypes(dataAccess)
            //.Where(x => x.Name.EndsWith("Service"))
            //.AsImplementedInterfaces();//.InstancePerLifetimeScope();
            //builder.RegisterType<GenericRepository>().As<IGenericRepository<T>>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<AppRoleService>().As<IAppRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductFeatureService>().As<IProductFeatureService>().InstancePerLifetimeScope();
            builder.RegisterType<SupplierService>().As<ISupplierService>().InstancePerLifetimeScope();
            builder.RegisterType<ToDoService>().As<IToDoService>().InstancePerLifetimeScope();
            //builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        }
    }
}
