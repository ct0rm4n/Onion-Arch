using Application.Repositories;
using Autofac;
using Domain.Entities.Concrates;
using Infraestrutura.Context;
using Infraestrutura.Repositories;
using Microsoft.AspNetCore.Identity;
using Service.Application.Services;
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

            builder.RegisterAssemblyTypes(executingAssembly, repoServiceAssembly)
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
