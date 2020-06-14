using Autofac;
using Microsoft.AspNetCore.Http;
using MyTaskService.Services;

namespace AddressBookAPI
{
    public class AutoFacContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<EmailSender>().As<IEmailSender>();

            //for  register all interfaces for all services 
            builder.RegisterAssemblyTypes(typeof(EmployeeService).Assembly).AsImplementedInterfaces();

            //builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();

        }
    }
}
