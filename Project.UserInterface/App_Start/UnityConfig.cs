using Project.BusinessLayer;
using Project.BusinessLayer.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Project.UserInterface
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
           // container.RegisterType<Employee>(new Unity.Injection.InjectionConstructor(10));
            container.RegisterType<IEmployee, Employee>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}