import { VersionResult } from "../../dto/services/VersionResult";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IConfigurationService } from "../interfaces/IConfigurationService";

let _httpClient : IHttpClient;

const ConfigurationService : IConfigurationService = {
  init: function (htppClient: IHttpClient): void {
    _httpClient = htppClient;
  },
  getAppVersion: async () =>  {
    let ret: VersionResult;
    let request = await _httpClient.doGet<VersionResult>("api/Configuration/getappversion", {});
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

export default ConfigurationService;