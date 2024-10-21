import GoboxListResult from "../../dto/services/GoboxListResult";
import GoboxResult from "../../dto/services/GoboxResult";
import { ItemBoxResult } from "../../dto/services/ItemBoxResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IGoboxService } from "../interfaces/IGoboxService";

let _httpClient : IHttpClient;

const GoboxService : IGoboxService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  list: async () => {
    let ret: GoboxListResult;
    let request = await _httpClient.doGet<GoboxListResult>("api/Gobox/list", {});
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
  listMyBox: async (tokenAuth: string) => {
    let ret: GoboxListResult;
    let request = await _httpClient.doGetAuth<GoboxListResult>("api/Gobox/listmybox", tokenAuth);
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
  getbygobox: async (boxType: number, tokenAuth: string) => {
    let ret: GoboxResult;
    let request = await _httpClient.doGetAuth<GoboxResult>("api/Gobox/getbygobox?boxType=" + boxType, tokenAuth);
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
  buybox: async (box: number, qtdy: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doGetAuth<StatusRequest>("api/Gobox/buybox?box=" + box + "&qtdy=" + qtdy, tokenAuth);
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
  openbox: async (box: number, tokenAuth: string) => {
    let ret: GoboxResult;
    let request = await _httpClient.doGetAuth<GoboxResult>("api/Gobox/openbox?box=" + box, tokenAuth);
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
  openitembox: async (box: number, tokenAuth: string) => {
    let ret: ItemBoxResult;
    let request = await _httpClient.doGetAuth<ItemBoxResult>("api/Gobox/openitembox?box=" + box, tokenAuth);
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

export default GoboxService;