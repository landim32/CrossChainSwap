using System;
namespace BTCSTXSwap.Domain.Interfaces.Services
{
    public interface IConfigurationService
    {
        string GetWithdrawAddress();
        string GetWithdrawKey();
        string GetAppVersion();
        void CalculateDaily();
        int GetSwapTax();
        int GetSwapMaterialTax();
        int GetSwapGobiDailyLimit();
    }
}
