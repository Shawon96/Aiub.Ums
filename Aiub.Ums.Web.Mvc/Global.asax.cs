using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Aiub.Ums.Core.Service;
using Aiub.Ums.Core.Service.Interfaces;
using Aiub.Ums.Infrastructure;
using Unity;
using Unity.AspNet.Mvc;

namespace Aiub.Ums.Web.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            /* Unity Configuration*/
            IUnityContainer container = new UnityContainer();
            container.RegisterType<DbContext, UmsDbContext>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<ISectionService, SectionService>();
            container.RegisterType<IRegistrationService, RegistrationService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //new HomeController(new StudentService(new StudentRepository(new UmsDbContext())));
        }

        protected void Sessiont_Start()
        {
            
        }
    }
}
