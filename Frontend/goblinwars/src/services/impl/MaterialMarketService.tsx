import { MaterialMarketBalanceResult } from "../../dto/services/MaterialMarketBalanceResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IMaterialMarketService } from "../interfaces/IMaterialMarketService";

let _httpClient : IHttpClient;

const MaterialMarketService : IMaterialMarketService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  marketbalance: async (materialkey: number, tokenAuth: string) => {
    let ret: MaterialMarketBalanceResult;
    let request = await _httpClient.doGetAuth<MaterialMarketBalanceResult>("api/MaterialMarket/marketbalance?materialKey=" + materialkey, tokenAuth);
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
  swapmaterialpergold: async (materialkey: number, qtde: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/MaterialMarket/swapmaterialpergold", {
      MaterialKey: materialkey,
      Qtde: qtde
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
  swapgoldpermaterial: async (materialkey: number, qtde: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/MaterialMarket/swapgoldpermaterial", {
      MaterialKey: materialkey,
      Qtde: qtde
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

export { MaterialMarketService }