import AuctionEquipmentFilterInfo from "../../dto/domain/AuctionEquipmentFilterInfo";
import AuctionFilterInfo from "../../dto/domain/AuctionFilterInfo";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import { AuctionListResult } from "../../dto/services/AuctionListResult";
import { AuctionResult } from "../../dto/services/AuctionResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";
import IAuctionService from "../interfaces/IAuctionService";

let _httpClient : IHttpClient;

const AuctionService : IAuctionService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  searchgoblin: async (filter: AuctionFilterInfo, tokenAuth: string) => {
    let ret: AuctionListResult;
    let request = await _httpClient.doPostAuth<AuctionListResult>("api/Auction/searchgoblin", filter, tokenAuth);
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
  searchequipment: async (filter: AuctionEquipmentFilterInfo, tokenAuth: string) => {
    let ret: AuctionListResult;
    let request = await _httpClient.doPostAuth<AuctionListResult>("api/Auction/searchequipment", filter, tokenAuth);
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
  listbyauction: async (auction: number, page: number, tokenAuth: string) => {
    let ret: AuctionListResult;
    let url: string = "api/Auction/listbyauction?auction=" + auction + "&page=" + page;
    let request = await _httpClient.doGetAuth<AuctionListResult>(url, tokenAuth);
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
  listbyuser: async (auction: number, tokenAuth: string) => {
    let ret: AuctionListResult;
    let url: string = "api/Auction/listbyuser?auction=" + auction;
    let request = await _httpClient.doGetAuth<AuctionListResult>(url, tokenAuth);
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
  listsameequipment: async (itemkey: number, tokenAuth: string) => {
    let ret: AuctionListResult;
    let url: string = "api/Auction/listsameequipment?itemKey=" + itemkey;
    let request = await _httpClient.doGetAuth<AuctionListResult>(url, tokenAuth);
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
  getbytoken: async (tokenId: number, tokenAuth: string) => {
    let ret: AuctionResult;
    const url = "api/Auction/getbytoken?tokenId=" + tokenId;
    let request = await _httpClient.doGetAuth<AuctionResult>(url, tokenAuth);
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
  getbyid: async (IdAuction: number, tokenAuth: string) => {
    let ret: AuctionResult;
    const url = "api/Auction/getbyid?IdAuction=" + IdAuction;
    let request = await _httpClient.doGetAuth<AuctionResult>(url, tokenAuth);
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
  insert: async (param: AuctionInsertInfo, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/Auction/insert", param, tokenAuth);
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
  buy: async (idAuction: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doGetAuth<StatusRequest>("api/Auction/buy?idAuction=" + idAuction, tokenAuth);
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
  cancel: async (idAuction: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doGetAuth<StatusRequest>("api/Auction/cancel?idAuction=" + idAuction, tokenAuth);
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

export { AuctionService }