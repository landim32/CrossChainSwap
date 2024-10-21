import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import { IGoldFinanceService } from "../../services/interfaces/IGoldFinanceService";
import { IGoldFinanceBusiness } from "../interfaces/IGoldFinanceBusiness";
import { GoldTransactionInfo } from "../../dto/domain/GoldTransactionInfo";
import { TradeBalanceInfo } from "../../dto/domain/TradeBalanceInfo";
import { GoldTradeRateInfo } from "../../dto/domain/GoldTradeRateInfo";
import { GoldTransactionListResult } from "../../dto/services/GoldTransactionListResult";

let _authBusiness : IAuthBusiness;
let _goldFinanceService : IGoldFinanceService;

const GoldFinanceBusiness : IGoldFinanceBusiness = {
  init: function (goldFinanceService: IGoldFinanceService, authBusiness: IAuthBusiness): void {
    _authBusiness = authBusiness;
    _goldFinanceService = goldFinanceService;
  },
  list: async (page: number) => {
    try {
      let ret: BusinessResult<GoldTransactionListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _goldFinanceService.list(page, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get transactions");
    }
  },
  tradebalance: async () => {
    try {
      let ret: BusinessResult<TradeBalanceInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _goldFinanceService.tradebalance(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.tradebalance,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get balance");
    }
  },
  gobipergold: async (gobi: number) => {
    try {
      let ret: BusinessResult<GoldTradeRateInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _goldFinanceService.gobipergold(gobi, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.tradeinfo,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get rate info");
    }
  },
  goldpergobi: async (gold: number) => {
    try {
      let ret: BusinessResult<GoldTradeRateInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _goldFinanceService.goldpergobi(gold, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.tradeinfo,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get rate info");
    }
  },
  swapgold: async (gold: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _goldFinanceService.swapgold(gold, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: true,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to complete swap transaction");
    }
  },
  swapgobi: async (gobi: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _goldFinanceService.swapgobi(gobi, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: true,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to complete swap transaction");
    }
  }
}

export {GoldFinanceBusiness};