import { BalanceResult } from "../../dto/services/BalanceResult";
import { CraftResult } from "../../dto/services/CraftResult";
import ItemDestroyResult from "../../dto/services/ItemDestroyResult";
import StatusRequest from "../../dto/services/StatusRequest";
import { UserItemListResult } from "../../dto/services/UserItemListResult";
import { UserItemResult } from "../../dto/services/UserItemResult";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IGoblinUserService } from "../interfaces/IGoblinUserService";
import { IItemService } from "../interfaces/IItemService";

let _httpClient : IHttpClient;

const ItemService : IItemService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  list: async (tokenAuth: string) => {
    let ret: UserItemListResult;
    let request = await _httpClient.doGetAuth<UserItemListResult>("api/Item/list", tokenAuth);
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
  getbykey: async (itemKey: number, tokenAuth: string) => {
    let ret: UserItemResult;
    let request = await _httpClient.doGetAuth<UserItemResult>("api/Item/getbykey?itemKey=" + itemKey, tokenAuth);
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
  getcraftinfo: async (itemKey: number, tokenAuth: string) => {
    let ret: CraftResult;
    let request = await _httpClient.doGetAuth<CraftResult>("api/Item/getcraftinfo?itemKey=" + itemKey, tokenAuth);
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
  sell: async (key: number, qtde: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/Item/sell", {
      Key: key,
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
  move: async (idItem: number, x: number, y: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/Item/move", {
      IdItem: idItem,
      X: x,
      Y: y
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
  destroyitem: async (idItem: number, qtde: number, tokenAuth: string) => {
    let ret: ItemDestroyResult;
    let request = await _httpClient.doPostAuth<ItemDestroyResult>("api/Item/destroyitem", {
      IdItem: idItem,
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
  sellalltrash: async (tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doGetAuth<StatusRequest>("api/Item/sellalltrash", tokenAuth);
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

    export { ItemService }