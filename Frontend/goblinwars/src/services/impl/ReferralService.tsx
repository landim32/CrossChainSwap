import ReferralParamInfo from "../../dto/domain/ReferralParamInfo";
import TweetUrlInfo from "../../dto/domain/TweetUrlInfo";
import ReferralResult from "../../dto/services/ReferralResult";
import StatusRequest from "../../dto/services/StatusRequest";
import TweetUrlResult from "../../dto/services/TweetUrlResult";
import IHttpClient from "../../infra/interface/IHttpClient";

import IReferralService from "../interfaces/IReferralService";
let _httpClient : IHttpClient;

const ReferralService : IReferralService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  getreferral: async (tokenAuth: string) => {
    let ret: ReferralResult;
    let request = await _httpClient.doGetAuth<ReferralResult>("api/Referral/getreferral", tokenAuth);
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
  updatereferral: async (param: ReferralParamInfo, tokenAuth: string) => {
    let ret: StatusRequest;
    let request = await _httpClient.doPostAuth<StatusRequest>("api/Referral/updatereferral", param, tokenAuth);
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
  addtweet: async (tweet: TweetUrlInfo, tokenAuth: string) => {
    let ret: TweetUrlResult;
    let request = await _httpClient.doPostAuth<TweetUrlResult>("api/Referral/addtweet", tweet, tokenAuth);
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

export default ReferralService;