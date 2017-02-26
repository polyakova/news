using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using News.Api;
using Unity.Mvc5;

namespace News.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();

			var apiKey = WebConfigurationManager.AppSettings["NewsApiClient"];

			container.RegisterType<IClient, Client>(new InjectionConstructor(apiKey));
			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
		}
    }
}