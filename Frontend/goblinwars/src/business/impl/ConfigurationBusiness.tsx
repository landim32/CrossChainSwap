import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import IGLogBusiness from "../interfaces/IGLogBusiness";
import IGLogService from "../../services/interfaces/IGLogService";
import GLogListResult from "../../dto/services/GLogListResult";
import IFinanceService from "../../services/interfaces/IFinanceService";
import IFinanceBusiness from "../interfaces/IFinanceBusiness";
import FinanceListResult from "../../dto/services/FinanceListResult";
import FinanceInfo from "../../dto/domain/FinanceInfo";
import DepositConfirmInfo from "../../dto/domain/DepositConfirmInfo";
import FinanceTransactionInfo from "../../dto/domain/FinanceTransactionInfo";
import IGobiBusiness from "../interfaces/IGobiBusiness";
import AnalyticsFactory from "../factory/AnalyticsFactory";
import { IConfigurationService } from "../../services/interfaces/IConfigurationService";
import { IConfigurationBusiness } from "../interfaces/IConfigurationBusiness";
import { VersionResult } from "../../dto/services/VersionResult";

let _configurationService : IConfigurationService;

const ConfigurationBusiness : IConfigurationBusiness = {
  init: function (configurationService: IConfigurationService): void {
    _configurationService = configurationService;
  },
  getAppVersion: async () => {
    try {
      let ret: BusinessResult<VersionResult> = null;
      let retAuction = await _configurationService.getAppVersion();
      if (retAuction.sucesso) {
        return {
          ...ret,
          dataResult: retAuction,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retAuction.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get version");
    }
  }
}

export default ConfigurationBusiness;