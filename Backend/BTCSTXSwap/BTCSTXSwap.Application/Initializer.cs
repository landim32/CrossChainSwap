using Core.Domain;
using Core.Domain.Cloud;
using Core.Domain.Repository;
using DB.Infra;
using DB.Infra.Context;
using DB.Infra.Repository;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Factory;
using BTCSTXSwap.Domain.Impl.Services;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.GLog;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.GLog;
using BTCSTXSwap.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using BTCSTXSwap.Domain;

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
                services.AddDbContext<CrossChainSwapContext>(x => x.UseLazyLoadingProxies().UseNpgsql(connection));
            else
                services.AddDbContextFactory<CrossChainSwapContext>(x => x.UseLazyLoadingProxies().UseNpgsql(connection));

            #region Infra
            injectDependency(typeof(CrossChainSwapContext), typeof(CrossChainSwapContext), services, scoped);
            injectDependency(typeof(IUnitOfWork), typeof(UnitOfWork), services, scoped);
            injectDependency(typeof(ILogCore), typeof(LogCore), services, scoped);
            #endregion

            #region Repository
            injectDependency(typeof(IUserRepository<IUserModel, IUserDomainFactory>), typeof(UserRepository), services, scoped);
            injectDependency(typeof(ITransactionRepository<ITransactionModel, ITransactionDomainFactory>), typeof(TransactionRepository), services, scoped);
            injectDependency(typeof(ITransactionLogRepository<ITransactionLogModel, ITransactionLogDomainFactory>), typeof(TransactionLogRepository), services, scoped);
            #endregion

            #region Service
            injectDependency(typeof(IUserService), typeof(UserService), services, scoped);
            injectDependency(typeof(ITransactionService), typeof(TransactionService), services, scoped);
            injectDependency(typeof(IMempoolService), typeof(MempoolService), services, scoped);
            injectDependency(typeof(ICoinMarketCapService), typeof(CoinMarketCapService), services, scoped);
            injectDependency(typeof(IBitcoinService), typeof(BitcoinService), services, scoped);
            injectDependency(typeof(IStacksService), typeof(StacksService), services, scoped);
            injectDependency(typeof(IGLogService), typeof(GLogService), services, scoped);
            #endregion

            #region Factory
            injectDependency(typeof(IUserDomainFactory), typeof(UserDomainFactory), services, scoped);
            injectDependency(typeof(ITransactionDomainFactory), typeof(TransactionDomainFactory), services, scoped);
            injectDependency(typeof(ITransactionLogDomainFactory), typeof(TransactionLogDomainFactory), services, scoped);
            injectDependency(typeof(IGLogDomainFactory), typeof(GLogDomainFactory), services, scoped);
            #endregion


            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, AuthHandler>("BasicAuthentication", null);

        }
    }
}
