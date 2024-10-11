using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Factory.Items;
using BTCSTXSwap.Domain.Interfaces.Models.Items;
using BTCSTXSwap.DTO.Finance;
using BTCSTXSwap.DTO.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSTXSwap.Domain.Impl.Models.Items
{
    public class MaterialTradeModel : IMaterialTradeModel
    {
        private readonly IMaterialTradeDomainFactory _materialTradeFactory;
        private readonly IMaterialMarketRepository<IMaterialTradeModel, IMaterialTradeDomainFactory> _materialMarketRepository;

        public MaterialTradeModel(IMaterialTradeDomainFactory materialTradeFactory,
            IMaterialMarketRepository<IMaterialTradeModel, IMaterialTradeDomainFactory> materialMarketRepository)
        {
            TradeInfo = new MaterialTradeInfo();
            _materialTradeFactory = materialTradeFactory;
            _materialMarketRepository = materialMarketRepository;
        }

        public MaterialTradeInfo TradeInfo { get; set; }

        public void Save()
        {
            _materialMarketRepository.Insert(this);
        }

        public long GetTotalMaterial(long keyMaterial)
        {
            return _materialMarketRepository.GetTotalMaterial(keyMaterial);
        }

        public decimal GetTotalGoldMaterial(long keyMaterial)
        {
            return _materialMarketRepository.GetTotalGoldMaterial(keyMaterial);
        }
    }
}
