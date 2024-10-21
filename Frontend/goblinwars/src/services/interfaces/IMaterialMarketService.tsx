import { MaterialMarketBalanceResult } from "../../dto/services/MaterialMarketBalanceResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";


export interface IMaterialMarketService {
    init: (htppClient : IHttpClient) => void;
    marketbalance: (
        materialkey: number,
        tokenAuth: string
    ) => Promise<MaterialMarketBalanceResult>;
    swapmaterialpergold: (
        materialkey: number,
        qtde: number,
        tokenAuth: string
    ) => Promise<StatusRequest>;
    swapgoldpermaterial: (
        materialkey: number,
        qtde: number,
        tokenAuth: string
    ) => Promise<StatusRequest>;
}