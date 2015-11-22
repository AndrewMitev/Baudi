namespace Server.Api.Controllers
{
    using Baudi.Services.Data.Contracts;
    using System.Web.Http;

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
