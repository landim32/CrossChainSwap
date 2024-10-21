import { BalanceResult } from "../../dto/services/BalanceResult";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IGoblinUserService } from "../interfaces/IGoblinUserService";

let _httpClient : IHttpClient;

const GoblinUserService : IGoblinUserService = {
    init: function (htppClient: IHttpClient): void {
        _httpClient = htppClient;
    },
    balance: async (tokenAuth: string) => {
        let ret: BalanceResult;
        let request = await _httpClient.doGetAuth<BalanceResult>("api/GoblinUser/balance", tokenAuth);
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

    export { GoblinUserService }