import { PoolResult } from "../../DTO/Services/PoolResult";
import IHttpClient from "../../Infra/Interface/IHttpClient";
import { IPoolService } from "../Interfaces/IPoolService";

let _httpClient : IHttpClient;

const PoolService : IPoolService = {
    init: function (htppClient: IHttpClient): void {
        _httpClient = htppClient;
    },
    getPoolInfo: async () => {
        let ret: PoolResult;
        let request = await _httpClient.doGet<PoolResult>("api/Pool/getpoolinfo", {});
        if (request.success) {
            request.data.sucesso = true;
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
}

export { PoolService }