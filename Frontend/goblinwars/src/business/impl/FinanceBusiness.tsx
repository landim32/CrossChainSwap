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

let _authBusiness : IAuthBusiness;
let _gobiBusiness : IGobiBusiness;
let _financeService : IFinanceService;

const FinanceBusiness : IFinanceBusiness = {
  init: function (financeService: IFinanceService, authBusiness: IAuthBusiness, gobiBusiness: IGobiBusiness): void {
    _financeService = financeService;
    _authBusiness = authBusiness;
    _gobiBusiness = gobiBusiness;
  },
  list: async (page: number) => {
    try {
      let ret: BusinessResult<FinanceListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _financeService.list(page, userSession);
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
      throw new Error("Failed to search auction");
    }
  },
  getFinance: async () => {
    try {
      let ret: BusinessResult<FinanceInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _financeService.getfinance(userSession);
      if (retAuction.sucesso) {
        return {
          ...ret,
          dataResult: retAuction.finance,
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
      throw new Error("Failed to search auction");
    }
  },
  deposit: async (value: number) => {
    try {
      let ret: BusinessResult<FinanceTransactionInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "") {
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      }
      const poolReward = process.env.REACT_APP_POOL_REWARD_ADDRESS;
      var retTransfer = await _gobiBusiness.transfer(poolReward, value);
      if (!retTransfer.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Finance', 'Deposit');
        return {
          ...ret,
          sucesso: false,
          mensagem: retTransfer.mensagem
        };
      }
      const deposit: DepositConfirmInfo = {
        transactionhash: retTransfer.dataResult,
        value: value
      };

      let retAuction = await _financeService.confirmdeposit(deposit, userSession);
      if (retAuction.sucesso) {
        return {
          ...ret,
          dataResult: retAuction.transaction,
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
      throw new Error("Failed to search auction");
    }
  },
  calculateFee: async (value: number) => {
    try {
      let ret: BusinessResult<number> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _financeService.calculatefee(value, userSession);
      if (retAuction.sucesso) {
        return {
          ...ret,
          dataResult: retAuction.value,
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
      throw new Error("Failed to search auction");
    }
  },
  withdrawl: async (value: number) => {
    try {
      let ret: BusinessResult<FinanceTransactionInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _financeService.withdrawl(value, userSession);
      if (retAuction.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Finance', 'Withdrawl');
        return {
          ...ret,
          dataResult: retAuction.transaction,
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
      throw new Error("Failed to search auction");
    }
  }
}

export default FinanceBusiness;