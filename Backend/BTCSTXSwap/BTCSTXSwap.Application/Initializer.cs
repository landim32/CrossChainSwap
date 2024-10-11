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
using DB.Infra.Repository.Referral;
using BTCSTXSwap.Domain.Impl.Core;
using BTCSTXSwap.Domain.Impl.Factory;
using BTCSTXSwap.Domain.Impl.Factory.Auctions;
using BTCSTXSwap.Domain.Impl.Factory.Items;
using BTCSTXSwap.Domain.Impl.Factory.Mining;
using BTCSTXSwap.Domain.Impl.Factory.Finance;
using BTCSTXSwap.Domain.Impl.Services;
using BTCSTXSwap.Domain.Interfaces.Core;
using BTCSTXSwap.Domain.Interfaces.Factory;
using BTCSTXSwap.Domain.Interfaces.Factory.Auctions;
using BTCSTXSwap.Domain.Interfaces.Factory.GLog;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Factory.Mining;
using BTCSTXSwap.Domain.Interfaces.Factory.Referral;
using BTCSTXSwap.Domain.Interfaces.Factory.Withdraw;
using BTCSTXSwap.Domain.Interfaces.Models;
using BTCSTXSwap.Domain.Interfaces.Models.Auctions;
using BTCSTXSwap.Domain.Interfaces.Models.GLog;
using BTCSTXSwap.Domain.Interfaces.Models.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Referral;
using BTCSTXSwap.Domain.Interfaces.Models.WithDraw;
using BTCSTXSwap.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Core.Domain.Repository.Mining;
using DB.Infra.Repository.Mining;
using BTCSTXSwap.Domain.Interfaces.Models.Goblins;
using BTCSTXSwap.Domain.Interfaces.Factory.Goblins;
using DB.Infra.Repository.Goblins;
using Core.Domain.Repository.Goblins;
using BTCSTXSwap.Domain.Impl.Factory.Goblins;
using BTCSTXSwap.Domain.Interfaces.Models.Gobox;
using BTCSTXSwap.Domain.Interfaces.Factory.Gobox;
using BTCSTXSwap.Domain.Impl.Factory.Gobox;
using BTCSTXSwap.Domain.Interfaces.Models.Finance;
using BTCSTXSwap.Domain.Interfaces.Factory.Finance;
using BTCSTXSwap.Domain.Interfaces.Models.Items;

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
            //services.AddScoped(typeof(IActionRepository<IActionModel, IActionDomainFactory>), typeof(ActionRepository));
            injectDependency(typeof(IGoblinRepository<IGoblinModel, IGoblinDomainFactory>), typeof(GoblinRepository), services, scoped);
            injectDependency(typeof(IEquipmentRepository<IGoblinEquipment, IGoblinEquipmentDomainFactory>), typeof(EquipmentRepository), services, scoped);
            injectDependency(typeof(IGoblinIdleRepository<IGoblinIdleModel, IGoblinIdleDomainFactory>), typeof(GoblinIdleRepository), services, scoped);
            injectDependency(typeof(IGoblinPerkRepository<IGoblinPerkModel, IGoblinPerkDomainFactory>), typeof(GoblinPerkRepository), services, scoped);
            injectDependency(typeof(IUserItemRepository<IUserItemModel, IUserItemDomainFactory>), typeof(UserItemRepository), services, scoped);
            injectDependency(typeof(IUserRepository<IUserModel, IUserDomainFactory>), typeof(UserRepository), services, scoped);
            injectDependency(typeof(IMiningRepository<IMiningModel, IMiningDomainFactory>), typeof(MiningRepository), services, scoped);
            injectDependency(typeof(IMiningRewardRepository<IMiningRewardModel, IMiningRewardDomainFactory>), typeof(MiningRewardRepository), services, scoped);
            injectDependency(typeof(IMiningHistoryRepository<IMiningHistoryModel, IMiningHistoryDomainFactory>), typeof(MiningHistoryRepository), services, scoped);
            injectDependency(typeof(IAuctionRepository<IAuctionDomainFactory, IAuctionModel, IAuctionFilterModel, IAuctionEquipmentFilterModel>), typeof(AuctionRepository), services, scoped);
            injectDependency(typeof(IReferralRepository<IReferralModel, IReferralDomainFactory>), typeof(ReferralRepository), services, scoped);
            injectDependency(typeof(IRetweetRepository<IRetweetModel, IRetweetDomainFactory>), typeof(RetweetRepository), services, scoped);
            injectDependency(typeof(IReferralUserRepository<IReferralUserModel, IReferralUserDomainFactory>), typeof(ReferralUserRepository), services, scoped);
            injectDependency(typeof(IRechargeRepository<IGoblinEnergyModel, IRechargeDomainFactory>), typeof(RechargeRepository), services, scoped);
            injectDependency(typeof(IGLogRepository<IGLogModel, IGLogDomainFactory>), typeof(GLogRepository), services, scoped);
            injectDependency(typeof(IFinanceRepository<IFinanceTransactionModel, IFinanceDomainFactory>), typeof(FinanceRepository), services, scoped);
            injectDependency(typeof(IGoboxRepository<IGoboxModel, IGoboxDomainFactory>), typeof(GoboxRepository), services, scoped);
            injectDependency(typeof(IGoldFinanceRepository<IGoldTransactionModel, IGoldTransactionDomainFactory>), typeof(GoldFinanceRepository), services, scoped);
            injectDependency(typeof(IMaterialMarketRepository<IMaterialTradeModel, IMaterialTradeDomainFactory>), typeof(MaterialMarketRepository), services, scoped);
            injectDependency(typeof(IConfigurationRepository), typeof(ConfigurationRepository), services, scoped);
            #endregion

            #region CoinMarketCap
            injectDependency(typeof(ICoinMarketCapService), typeof(CoinMarketCapService), services, scoped);
            #endregion

            #region Service
            //services.AddScoped(typeof(IActionService), typeof(ActionService));
            injectDependency(typeof(IUserService), typeof(UserService), services, scoped);
            injectDependency(typeof(IGoblinIdleService), typeof(GoblinIdleService), services, scoped);
            injectDependency(typeof(IGoblinService), typeof(GoblinService), services, scoped);
            injectDependency(typeof(IGoblinNftService), typeof(GoblinNftService), services, scoped);
            injectDependency(typeof(IEquipmentService), typeof(EquipmentService), services, scoped);
            injectDependency(typeof(IUserItemService), typeof(UserItemService), services, scoped);
            injectDependency(typeof(IGeneService), typeof(GeneService), services, scoped);
            injectDependency(typeof(IAvatarService), typeof(AvatarService), services, scoped);
            injectDependency(typeof(IBuildGoblinService), typeof(BuildGoblinService), services, scoped);
            injectDependency(typeof(IGoblinBreedService), typeof(GoblinBreedService), services, scoped);
            injectDependency(typeof(IGoblinUserService), typeof(GoblinUserService), services, scoped);
            injectDependency(typeof(IMiningSpriteService), typeof(MiningSpriteService), services, scoped);
            injectDependency(typeof(IMiningService), typeof(MiningService), services, scoped);
            injectDependency(typeof(IItemService), typeof(ItemService), services, scoped);
            injectDependency(typeof(IGoblinMiningService), typeof(GoblinMiningService), services, scoped);
            injectDependency(typeof(IGLogService), typeof(GLogService), services, scoped);
            injectDependency(typeof(IFinanceService), typeof(FinanceService), services, scoped);
            injectDependency(typeof(IGoboxService), typeof(GoboxService), services, scoped);
            injectDependency(typeof(IConfigurationService), typeof(ConfigurationService), services, scoped);
            injectDependency(typeof(IGoldFinanceService), typeof(GoldFinanceService), services, scoped);
            injectDependency(typeof(IMaterialMarketService), typeof(MaterialMarketService), services, scoped);
            injectDependency(typeof(IGoblinSkillService), typeof(GoblinSkillService), services, scoped);
            #endregion

            #region Factory
            injectDependency(typeof(IGoblinDNADomainFactory), typeof(GoblinDNADomainFactory), services, scoped);
            injectDependency(typeof(IUserDomainFactory), typeof(UserDomainFactory), services, scoped);
            injectDependency(typeof(IGoblinDomainFactory), typeof(GoblinDomainFactory), services, scoped);
            injectDependency(typeof(IGoblinIdleDomainFactory), typeof(GoblinIdleDomainFactory), services, scoped);
            injectDependency(typeof(IGoblinPerkDomainFactory), typeof(GoblinPerkDomainFactory), services, scoped);
            injectDependency(typeof(IGoblinEquipmentDomainFactory), typeof(GoblinEquipmentDomainFactory), services, scoped);
            injectDependency(typeof(IItemCategoryDomainFactory), typeof(ItemCategoryDomainFactory), services, scoped);
            injectDependency(typeof(IItemListDomainFactory), typeof(ItemListDomainFactory), services, scoped);
            injectDependency(typeof(IItemDomainFactory), typeof(ItemDomainFactory), services, scoped);
            injectDependency(typeof(IDestroyRewardDomainFactory), typeof(DestroyRewardDomainFactory), services, scoped);
            injectDependency(typeof(IItemDestroyRewardDomainFactory), typeof(ItemDestroyRewardDomainFactory), services, scoped);
            injectDependency(typeof(IUserItemDomainFactory), typeof(UserItemDomainFactory), services, scoped);
            injectDependency(typeof(IRaceDomainFactory), typeof(RaceDomainFactory), services, scoped);
            injectDependency(typeof(IBalanceDomainFactory), typeof(BalanceDomainFactory), services, scoped);
            injectDependency(typeof(IMiningDomainFactory), typeof(MiningDomainFactory), services, scoped);
            injectDependency(typeof(IMiningRewardDomainFactory), typeof(MiningRewardDomainFactory), services, scoped);
            injectDependency(typeof(IMiningHistoryDomainFactory), typeof(MiningHistoryDomainFactory), services, scoped);
            injectDependency(typeof(IGoblinSpriteDomainFactory), typeof(GoblinSpriteDomainFactory), services, scoped);
            injectDependency(typeof(IAuctionDomainFactory), typeof(AuctionDomainFactory), services, scoped);
            injectDependency(typeof(IAuctionFilterDomainFactory), typeof(AuctionFilterDomainFactory), services, scoped);
            injectDependency(typeof(IAuctionEquipmentFilterDomainFactory), typeof(AuctionEquipmentFilterDomainFactory), services, scoped);
            injectDependency(typeof(IReferralDomainFactory), typeof(ReferralDomainFactory), services, scoped);
            injectDependency(typeof(IRetweetDomainFactory), typeof(RetweetDomainFactory), services, scoped);
            injectDependency(typeof(IReferralUserDomainFactory), typeof(ReferralUserDomainFactory), services, scoped);
            injectDependency(typeof(IRechargeDomainFactory), typeof(RechargeDomainFactory), services, scoped);
            injectDependency(typeof(IGLogDomainFactory), typeof(GLogDomainFactory), services, scoped);
            injectDependency(typeof(IFinanceDomainFactory), typeof(FinanceDomainFactory), services, scoped);
            injectDependency(typeof(IGoldTransactionDomainFactory), typeof(GoldTransactionDomainFactory), services, scoped);
            injectDependency(typeof(IMaterialTradeDomainFactory), typeof(MaterialTradeDomainFactory), services, scoped);
            injectDependency(typeof(IGoboxDomainFactory), typeof(GoboxDomainFactory), services, scoped);
            #endregion


            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, AuthHandler>("BasicAuthentication", null);

        }
    }
}
