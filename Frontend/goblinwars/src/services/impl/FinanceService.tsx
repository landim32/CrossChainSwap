import DepositConfirmInfo from "../../dto/domain/DepositConfirmInfo";
import FinanceListResult from "../../dto/services/FinanceListResult";
import FinanceNumberResult from "../../dto/services/FinanceNumberResult";
import FinanceResult from "../../dto/services/FinanceResult";
import FinanceTransactionResult from "../../dto/services/FinanceTransactionResult";
import GLogListResult from "../../dto/services/GLogListResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";
import IFinanceService from "../interfaces/IFinanceService";

let _httpClient : IHttpClient;

const FinanceService : IFinanceService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  list: async (page: number, tokenAuth: string) => {
    let ret: FinanceListResult;
    let request = await _httpClient.doGetAuth<FinanceListResult>("api/Finance/list?page=" + page, tokenAuth);
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
  getfinance: async (tokenAuth: string) => {
    let ret: FinanceResult;
    let request = await _httpClient.doGetAuth<FinanceResult>("api/Finance/getfinance", tokenAuth);
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
  confirmdeposit: async (deposit: DepositConfirmInfo, tokenAuth: string) => {
    let ret: FinanceTransactionResult;
    let request = await _httpClient.doPostAuth<FinanceTransactionResult>("api/Finance/confirmdeposit", deposit, tokenAuth);
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
  calculatefee: async (value: number, tokenAuth: string) => {
    let ret: FinanceNumberResult;
    let request = await _httpClient.doGetAuth<FinanceNumberResult>("api/Finance/calculatefee?value=" + value, tokenAuth);
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
  withdrawl: async (value: number, tokenAuth: string) => {
    let ret: FinanceTransactionResult;
    let request = await _httpClient.doGetAuth<FinanceTransactionResult>("api/Finance/withdrawl?value=" + value, tokenAuth);
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

export default FinanceService;