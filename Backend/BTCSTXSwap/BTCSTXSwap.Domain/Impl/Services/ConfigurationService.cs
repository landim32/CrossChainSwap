using System;
using Core.Domain.Repository;
using BTCSTXSwap.Domain.Interfaces.Services;

namespace BTCSTXSwap.Domain.Impl.Services
{
    public class ConfigurationService : IConfigurationService
    {

        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public string GetWithdrawAddress()
        {
            return _configurationRepository.GetWithdrawAddress();
        }

        public string GetWithdrawKey()
        {
            return _configurationRepository.GetWithdrawKey();
        }
        public void CalculateDaily()
        {
            _configurationRepository.CalculateDaily();
        }

        public string GetAppVersion()
        {
            return _configurationRepository.GetVersion();
        }

        public int GetSwapTax()
        {
            return _configurationRepository.GetSwapTax();
        }

        public int GetSwapMaterialTax()
        {
            return _configurationRepository.GetSwapMaterialTax();
        }

        public int GetSwapGobiDailyLimit()
        {
            return _configurationRepository.GetSwapGobiDailyLimit();
        }
    }
}
