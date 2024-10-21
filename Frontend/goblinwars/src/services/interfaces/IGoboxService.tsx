import GoboxListResult from "../../dto/services/GoboxListResult";
import GoboxResult from "../../dto/services/GoboxResult";
import { ItemBoxResult } from "../../dto/services/ItemBoxResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";

export interface IGoboxService {
    init: (htppClient : IHttpClient) => void;
    list: () => Promise<GoboxListResult>;
    listMyBox: (tokenAuth: string) => Promise<GoboxListResult>;
    getbygobox: (boxType: number, tokenAuth: string) => Promise<GoboxResult>;
    buybox: (box: number, qtdy: number, tokenAuth: string) => Promise<StatusRequest>;
    openbox: (box: number, tokenAuth: string) => Promise<GoboxResult>;
    openitembox: (box: number, tokenAuth: string) => Promise<ItemBoxResult>;
}