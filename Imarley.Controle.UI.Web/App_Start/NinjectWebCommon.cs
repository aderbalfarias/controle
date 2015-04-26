using Imarley.Controle.Application;
using Imarley.Controle.Application.Interface;
using Imarley.Controle.Domain.Interfaces.Repositories;
using Imarley.Controle.Domain.Interfaces.Services;
using Imarley.Controle.Domain.Services;
using Imarley.Controle.Data.Repositories;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Imarley.Controle.UI.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Imarley.Controle.UI.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Imarley.Controle.UI.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
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

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IStatusAppService>().To<StatusAppService>();
            kernel.Bind<ICategoriaAppService>().To<CategoriaAppService>();
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();


            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IStatusService>().To<StatusService>();
            kernel.Bind<ICategoriaService>().To<CategoriaService>();
            kernel.Bind<IClienteService>().To<ClienteService>();


            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IStatusRepository>().To<StatusRepository>();
            kernel.Bind<ICategoriaRepository>().To<CategoriaRepository>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();

        }        
    }
}
