using starkdev.spreadrecon.jobs;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace starkdev.spreadrecon.web
{
	public class Global : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Job's
            //EmailJobScheduler.Start();
            ImportarPlanilhaJobScheduler.Start();
            ConciliarPlanilhaJobScheduler.Start();
        }
	}
}
