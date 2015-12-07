namespace Server.Api.Controllers
{
    using Baudi.Services.Data.Contracts;
    using System.Web.Http;
    using System.Web.Http.Cors;

    [EnableCors("*", "*", "*")]
    public class TestController : ApiController
    {
        private ITestServices tests;

        public TestController(ITestServices testServices)
        {
            this.tests = testServices;
        }

        public IHttpActionResult Get()
        {
            return this.Ok("Petya");
        }
    }
}
