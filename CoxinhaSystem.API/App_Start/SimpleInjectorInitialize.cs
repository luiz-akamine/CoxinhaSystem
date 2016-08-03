using CoxinhaSystem.API.App_Start;
using CoxinhaSystem.Infra.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace CoxinhaSystem.API.App_Start
{
    // install-package simpleinjector
    // install-package simpleinjector.integration.webapi
    // install-package SimpleInjector.Extensions.ExecutionContextScoping
    // install-package webactivator -version 1.5.3
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            Bindings.Start(container);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = 
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}