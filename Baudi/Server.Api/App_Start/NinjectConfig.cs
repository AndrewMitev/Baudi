﻿namespace Server.Api
{
    using System;
    using System.Web;

    using Ninject;
    using Ninject.Web.Common;
    using Data;
    using Data.Repositories;
    using Baudi.Services.Data;
    using Baudi.Services.Data.Contracts;

    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBaudiDbContext>().To<BaudiDbContext>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            kernel.Bind<ITestServices>().To<TestServices>();
            kernel.Bind<ICarService>().To<CarService>();
        }
    }
}