import { GoblinMiningResult } from "../../dto/services/GoblinMiningResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { MiningHistoryDateResult } from "../../dto/services/MiningHistoryDateResult";
import { MiningHistoryResult } from "../../dto/services/MiningHistoryResult";
import MiningListResult from "../../dto/services/MiningListResult";
import { MiningResult } from "../../dto/services/MiningResult";
import { MiningRewardListResult } from "../../dto/services/MiningRewardListResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IMiningService } from "../interfaces/IMiningService";

let _httpClient : IHttpClient;

const MiningService : IMiningService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  list: async (miningType: string, tokenAuth: string) => {
    let ret: MiningListResult;
    let request = await _httpClient.doGetAuth<MiningListResult>("api/Mining/list?miningType=" + miningType, tokenAuth);
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
  getmining: async (tokenAuth: string) => {
    let ret: MiningResult;
    let request = await _httpClient.doGetAuth<MiningResult>("api/Mining/getmining", tokenAuth);
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
  rechargeall: async (tokenAuth: string) => {
    let ret: MiningResult;
    let request = await _httpClient.doPostAuth<MiningResult>("api/Mining/rechargeall", {}, tokenAuth);
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
  getGoblinMining: async (goblinId: number, tokenAuth: string) => {
    let ret: GoblinMiningResult;
    let request = await _httpClient.doGetAuth<GoblinMiningResult>("api/Mining/getgoblinmining?idGoblin=" + goblinId, tokenAuth);
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
  startmining: async (tokenId: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/Mining/startmining", {
      TokenId: tokenId
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
  stopmining: async (tokenId: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/Mining/stopmining", {
      TokenId: tokenId
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
  listGoblinsMining: async (tokenAuth: string) => {
    let ret: ListGoblinResult;
    let request = await _httpClient.doGetAuth<ListGoblinResult>("api/Mining/listgoblinsmining", tokenAuth);
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
  listGoblinsCanMining: async (cursor: number, tokenAuth: string) =>{
    let ret: ListGoblinResult;
    let request = await _httpClient.doGetAuth<ListGoblinResult>("api/Mining/listgoblinscanmining?cursor=" + cursor, tokenAuth);
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
  listreward: async (tokenAuth: string) => {
    let ret: MiningRewardListResult;
    let request = await _httpClient.doGetAuth<MiningRewardListResult>("api/Mining/listreward", tokenAuth);
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
  claimreward: async (idReward: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doGetAuth<StatusRequest>("api/Mining/claimreward?idReward=" + idReward, tokenAuth);
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
  listhistorydate: async (miningType: string, tokenAuth: string) => {
    let ret: MiningHistoryDateResult;
    let url: string = "api/Mining/listhistorydate?miningType=" + miningType;
    let request = await _httpClient.doGetAuth<MiningHistoryDateResult>(url, tokenAuth);
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
  listhistory: async (miningType: string, rewardDate: string, tokenAuth: string) => {
    let ret: MiningHistoryResult;
    let url: string = "api/Mining/listhistorydate?miningType=" + miningType + "&rewardDate=" + rewardDate;
    let request = await _httpClient.doGetAuth<MiningHistoryResult>(url, tokenAuth);
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
  listhistorybyuser: async (tokenAuth: string) => {
    let ret: MiningHistoryResult;
    let url: string = "api/Mining/listhistorybyuser";
    let request = await _httpClient.doGetAuth<MiningHistoryResult>(url, tokenAuth);
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
  claimrankingreward: async (idMiningHistory: number, tokenAuth: string) => {
    let ret: StatusRequest;
    let url: string = "api/Mining/claimrankingreward?idMiningHistory=" + idMiningHistory;
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

export { MiningService }