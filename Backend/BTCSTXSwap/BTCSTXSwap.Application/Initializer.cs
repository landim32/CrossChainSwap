using Auth.Domain;
using Auth.Domain.Impl.Factory;
using Auth.Domain.Impl.Services;
using Auth.Domain.Interfaces.Factory;
using Auth.Domain.Interfaces.Models;
using Auth.Domain.Interfaces.Services;
using Cloud.Infra;
using Core.Domain;
using Core.Domain.Cloud;
using Core.Domain.Repository;
using Core.Domain.Withdraw;
using DB.Infra;
using DB.Infra.Context;
using DB.Infra.Repository;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Factory;
using BTCSTXSwap.Domain.Impl.Factory.Finance;
using BTCSTXSwap.Domain.Impl.Services;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.GLog;
using BTCSTXSwap.Domain.Interfaces.Factory.Withdraw;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.GLog;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using BTCSTXSwap.Domain.Interfaces.Models.WithDraw;
using BTCSTXSwap.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Core.Domain.Repository.Mining;
using Core.Domain.Repository.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Finance;
using BTCSTXSwap.Domain.Interfaces.Factory.Finance;

namespace BTCSTXSwap.Application
{
    public static class Initializer
    {

        private static void injectDependency(Type serviceType, Type implementationType, IServiceCollection services, bool scoped = true)
        {
            if(scoped)
                services.AddScoped(serviceType, implementationType);
            else
                services.AddTransient(serviceType, implementationType);
        }
        public static void Configure(IServiceCollection services, string connection, bool scoped = true)
        {
            if(scoped)
                services.AddDbContext<GoblinWarsContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connection));
            else
                services.AddDbContextFactory<GoblinWarsContext>(x => x.UseLazyLoadingProxies().UseSqlServer(connection));

            #region Infra
            injectDependency(typeof(GoblinWarsContext), typeof(GoblinWarsContext), services, scoped);
            injectDependency(typeof(IUnitOfWork), typeof(UnitOfWork), services, scoped);
            injectDependency(typeof(ILogCore), typeof(LogCore), services, scoped);
            services.AddSingleton(typeof(IAssetsProviders), typeof(AssetsProvider));
            #endregion

            #region Repository
            injectDependency(typeof(IUserRepository<IUserModel, IUserDomainFactory>), typeof(UserRepository), services, scoped);
            injectDependency(typeof(IGLogRepository<IGLogModel, IGLogDomainFactory>), typeof(GLogRepository), services, scoped);
            injectDependency(typeof(IFinanceRepository<IFinanceTransactionModel, IFinanceDomainFactory>), typeof(FinanceRepository), services, scoped);
            injectDependency(typeof(IGoldFinanceRepository<IGoldTransactionModel, IGoldTransactionDomainFactory>), typeof(GoldFinanceRepository), services, scoped);
            injectDependency(typeof(IConfigurationRepository), typeof(ConfigurationRepository), services, scoped);
            #endregion

            #region CoinMarketCap
            injectDependency(typeof(ICoinMarketCapService), typeof(CoinMarketCapService), services, scoped);
            #endregion

            #region Service
            //services.AddScoped(typeof(IActionService), typeof(ActionService));
            injectDependency(typeof(IUserService), typeof(UserService), services, scoped);
            injectDependency(typeof(IGLogService), typeof(GLogService), services, scoped);
            injectDependency(typeof(IFinanceService), typeof(FinanceService), services, scoped);
            injectDependency(typeof(IConfigurationService), typeof(ConfigurationService), services, scoped);
            injectDependency(typeof(IGoldFinanceService), typeof(GoldFinanceService), services, scoped);
            #endregion

            #region Factory
            injectDependency(typeof(IUserDomainFactory), typeof(UserDomainFactory), services, scoped);
            injectDependency(typeof(IBalanceDomainFactory), typeof(BalanceDomainFactory), services, scoped);
            injectDependency(typeof(IGLogDomainFactory), typeof(GLogDomainFactory), services, scoped);
            injectDependency(typeof(IFinanceDomainFactory), typeof(FinanceDomainFactory), services, scoped);
            injectDependency(typeof(IGoldTransactionDomainFactory), typeof(GoldTransactionDomainFactory), services, scoped);
            #endregion


            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, AuthHandler>("BasicAuthentication", null);

        }
    }
}
