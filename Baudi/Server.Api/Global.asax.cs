namespace Server.Api
{
    using App_Start;
    using System.Reflection;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DatabaseConfig.Initialize();
            AutoMapperConfig.RegisterMappings(Assembly.Load("Server.Api"));
        }
    }
}
