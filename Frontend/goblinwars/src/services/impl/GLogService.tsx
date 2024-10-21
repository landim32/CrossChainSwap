import GLogListResult from "../../dto/services/GLogListResult";
import IHttpClient from "../../infra/interface/IHttpClient";
import IGLogService from "../interfaces/IGLogService";

let _httpClient : IHttpClient;

const GLogService : IGLogService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  list: async (page: number, tokenAuth: string) => {
    let ret: GLogListResult;
    let request = await _httpClient.doGetAuth<GLogListResult>("api/GLog/list?page=" + page, tokenAuth);
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

export default GLogService;