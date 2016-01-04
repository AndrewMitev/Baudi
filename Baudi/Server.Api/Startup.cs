using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using Server.Api;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace Server.Api
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      app.UseCors(CorsOptions.AllowAll);

      ConfigureAuth(app);

      var httpConfig = new HttpConfiguration();
      WebApiConfig.Register(httpConfig);

      httpConfig.EnsureInitialized();

      app
          .UseNinjectMiddleware(NinjectConfig.CreateKernel)
          .UseNinjectWebApi(httpConfig);
    }
  }
}