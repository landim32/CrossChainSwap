import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";
import IGoblinNftService from "../interfaces/IGoblinNftService";

let _httpClient : IHttpClient;

const GoblinNftService : IGoblinNftService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  list: async (tokenAuth: string) => {
    let ret: ListGoblinResult;
    let request = await _httpClient.doGetAuth<ListGoblinResult>("api/GoblinNft/list", tokenAuth);
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
  mint: async (tokenId: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let url: string = "api/GoblinNft/mint?tokenId=" + tokenId;
    //alert(JSON.stringify(url));
    let request = await _httpClient.doGetAuth<StatusRequest>(url, tokenAuth);
    //alert(JSON.stringify(request));
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
  claim: async (tokenId: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doGetAuth<StatusRequest>("api/GoblinNft/claim?tokenId=" + tokenId, tokenAuth);
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
  confirmdeposit: async (tokenId: number, transactionHash: string, tokenAuth: string) => {
    let ret: StatusRequest;
    let url: string = "api/GoblinNft/confirmdeposit?tokenId=" + tokenId + "&transactionHash=" + transactionHash;
    let request = await _httpClient.doGetAuth<StatusRequest>(url, tokenAuth);
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

export default GoblinNftService;