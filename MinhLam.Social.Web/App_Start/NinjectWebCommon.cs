[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MinhLam.Social.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MinhLam.Social.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MinhLam.Social.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MinhLam.Framework;
    using MinhLam.Social.Application;
    using MinhLam.Social.Application.Memberships;
    using MinhLam.Social.Application.Profiles;
    using MinhLam.Social.Domain.Common;
    using MinhLam.Social.Domain.Memberships;
    using MinhLam.Social.Domain.Profiles;
    using MinhLam.Social.Infrastructure;
    using MinhLam.Social.Infrastructure.Common;
    using MinhLam.Social.Infrastructure.Memberships;
    using MinhLam.Social.Infrastructure.Profiles;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
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
            kernel.Bind<SocialContext>().ToSelf().InRequestScope();
            kernel.Bind<IAccountService>().To<AccountService>().InRequestScope();
            kernel.Bind<IProfileService>().To<ProfileService>().InRequestScope();
            kernel.Bind<IAccountRepository>().To<AccountRepository>().InRequestScope();
            kernel.Bind<ITermRepository>().To<TermRepository>().InRequestScope();
            kernel.Bind<IPermissionRepository>().To<PermissionRepository>().InRequestScope();
            kernel.Bind<IProfileRepository>().To<ProfileRepository>().InRequestScope();
            kernel.Bind<IPrivacyFlagRepository>().To<PrivacyFlagRepository>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<ITermQuery>().To<TermQuery>().InRequestScope();
            kernel.Bind<ILevelOfExperienceTypeQuery>().To<LevelOfExperienceTypeQuery>().InRequestScope();
            kernel.Bind<IProfileAttributeTypeQuery>().To<ProfileAttributeTypeQuery>().InRequestScope();
            kernel.Bind<IProfileQuery>().To<ProfileQuery>().InRequestScope();
            kernel.Bind<IAccountQuery>().To<AccountQuery>().InRequestScope();
            kernel.Bind<IMembershipProfileQuery>().To<MembershipProfileQuery>().InRequestScope();
            kernel.Bind<IPrivacyFlagTypeQuery>().To<PrivacyFlagTypeQuery>().InRequestScope();
            kernel.Bind<IVisibilityQuery>().To<VisibilityQuery>().InRequestScope();
            kernel.Bind<IPrivacyFlagQuery>().To<PrivacyFlagQuery>().InRequestScope();
            kernel.Bind<IAccountSignIn>().To<AccountSignIn>().InRequestScope();
            kernel.Bind<ISendEmail>().To<SendEmail>().InRequestScope();
            kernel.Bind<IAccountCheckExisting>().To<AccountCheckExisting>().InRequestScope();
            kernel.Bind<ITermCheckExisting>().To<TermCheckExisting>().InRequestScope();
            kernel.Bind<IPermissionDefault>().To<PermissionDefault>().InRequestScope();
            kernel.Bind<IUserExperienceLevelChecking>().To<UserExperienceLevelChecking>().InRequestScope();
            kernel.Bind<IProfileAttributeTypeChecking>().To<ProfileAttributeTypeChecking>().InRequestScope();
            kernel.Bind<IPrivacyFlagTypeChecking>().To<PrivacyFlagTypeChecking>().InRequestScope();
            kernel.Bind<IVisibilityChecking>().To<VisibilityChecking>().InRequestScope();
            kernel.Bind<IProfileChecking>().To<ProfileChecking>().InRequestScope();
            kernel.Bind<ICurrentUserSession>().To<CurrentUserSession>();
            kernel.Bind<IConfiguration>().To<Configuration>().InRequestScope();
            kernel.Bind<IUserSession>().To<UserSession>().InRequestScope();
            kernel.Bind<IWebContext>().To<WebContext>().InRequestScope();
            kernel.Bind<IRedirector>().To<Redirector>().InRequestScope();
           
        }
    }
}