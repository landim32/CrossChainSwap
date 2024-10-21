import { GoldTradeRateResult } from "../../dto/services/GoldTradeRateResult";
import { GoldTransactionListResult } from "../../dto/services/GoldTransactionListResult";
import StatusRequest from "../../dto/services/StatusRequest";
import { TradeBalanceResult } from "../../dto/services/TradeBalanceResult";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IGoldFinanceService } from "../interfaces/IGoldFinanceService";

let _httpClient : IHttpClient;

const GoldFinanceService : IGoldFinanceService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  list: async (page: number, tokenAuth: string) => {
    let ret: GoldTransactionListResult;
    let request = await _httpClient.doGetAuth<GoldTransactionListResult>("api/GoldFinance/list?page=" + page, tokenAuth);
    if (request.success) {
      return request.data;
    }
    else {
      ret = {
        mensagem: request.messageError,
        sucesso: false,
        ...ret
      };
    }
    return ret;
  },
  tradebalance: async (tokenAuth: string) => {
    let ret: TradeBalanceResult;
    let request = await _httpClient.doGetAuth<TradeBalanceResult>("api/GoldFinance/tradebalance", tokenAuth);
    if (request.success) {
      return request.data;
    }
    else {
      ret = {
        mensagem: request.messageError,
        sucesso: false,
        ...ret
      };
    }
    return ret;
  },
  gobipergold: async (gobi: number, tokenAuth: string) => {
    let ret: GoldTradeRateResult;
    let request = await _httpClient.doGetAuth<GoldTradeRateResult>("api/GoldFinance/gobipergold?gobi=" + gobi, tokenAuth);
    if (request.success) {
      return request.data;
    }
    else {
      ret = {
        mensagem: request.messageError,
        sucesso: false,
        ...ret
      };
    }
    return ret;
  },
  goldpergobi: async (gold: number, tokenAuth: string) => {
    let ret: GoldTradeRateResult;
    let request = await _httpClient.doGetAuth<GoldTradeRateResult>("api/GoldFinance/goldpergobi?gold=" + gold, tokenAuth);
    if (request.success) {
      return request.data;
    }
    else {
      ret = {
        mensagem: request.messageError,
        sucesso: false,
        ...ret
      };
    }
    return ret;
  },
  swapgold: async (gold: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/GoldFinance/swapgold", {
      Gold: gold,
      Gobi: 0
    }, tokenAuth);
    if (request.success) {
      return request.data;
    }
    else {
      ret = {
        mensagem: request.messageError,
        sucesso: false,
        ...ret
      };
    }
    return ret;
  },
  swapgobi: async (gobi: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/GoldFinance/swapgobi", {
      Gold: 0,
      Gobi: gobi
    }, tokenAuth);
    if (request.success) {
      return request.data;
    }
    else {
      ret = {
        mensagem: request.messageError,
        sucesso: false,
        ...ret
      };
    }
    return ret;
  }
}

    export { GoldFinanceService }