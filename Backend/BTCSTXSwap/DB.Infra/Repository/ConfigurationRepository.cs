using System;
using System.Linq;
using Core.Domain.Repository;
using DB.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DB.Infra.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private GoblinWarsContext _goblinContext;

        public ConfigurationRepository(GoblinWarsContext goblinContext)
        {
            _goblinContext = goblinContext;
        }

        public string GetWithdrawAddress()
        {
            return _goblinContext.Configurations
                .Where(x => x.Name == "WITHDRAW_ADDRESS")
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public string GetWithdrawKey()
        {
            return _goblinContext.Configurations
                .Where(x => x.Name == "WITHDRAW_PRIVATE_KEY")
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public string GetVersion()
        {
            return _goblinContext.Configurations
                .Where(x => x.Name == "Version")
                .Select(x => x.Value)
                .FirstOrDefault();
        }

        public int GetSwapTax()
        {
            return int.Parse(_goblinContext.Configurations
                .Where(x => x.Name == "SWAP_TAX")
                .Select(x => x.Value)
                .FirstOrDefault());
        }

        public int GetSwapMaterialTax()
        {
            return int.Parse(_goblinContext.Configurations
                .Where(x => x.Name == "SWAP_TAX")
                .Select(x => x.Value)
                .FirstOrDefault());
        }

        public int GetSwapGobiDailyLimit()
        {
            return int.Parse(_goblinContext.Configurations
                .Where(x => x.Name == "SWAP_MATERIAL_TAX")
                .Select(x => x.Value)
                .FirstOrDefault());
        }

        public void CalculateDaily()
        {
            ((DbContext)_goblinContext).Database.ExecuteSqlRaw("EXEC DO_DAILY_REWARD;");
        }
    }
}
