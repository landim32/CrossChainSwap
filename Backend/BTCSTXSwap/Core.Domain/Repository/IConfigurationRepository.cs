using System;
namespace Core.Domain.Repository
{
    public interface IConfigurationRepository
    {
        string GetWithdrawAddress();
        string GetWithdrawKey();
        void CalculateDaily();
        string GetVersion();
        int GetSwapTax();
        int GetSwapMaterialTax();
        int GetSwapGobiDailyLimit();
    }
}
