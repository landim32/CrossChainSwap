import { PriceResult } from "../../DTO/Services/PriceResult";
import IHttpClient from "../../Infra/Interface/IHttpClient";
import { IPriceService } from "../Interfaces/IPriceService";

let _httpClient : IHttpClient;

const PriceService : IPriceService = {
    init: function (htppClient: IHttpClient): void {
        _httpClient = htppClient;
    },
    getCurrentPrice: async () => {
        let ret: PriceResult;
        let request = await _httpClient.doGet<PriceResult>("api/CoinMarketCap/getcurrentprice", {});
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

export { PriceService }