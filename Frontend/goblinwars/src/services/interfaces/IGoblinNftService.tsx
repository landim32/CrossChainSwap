import GLogListResult from "../../dto/services/GLogListResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";


export default interface IGoblinNftService {
    init: (htppClient : IHttpClient) => void;
    list: (tokenAuth: string) => Promise<ListGoblinResult>;
    mint: (tokenId: number, tokenAuth: string) => Promise<StatusRequest>;
    claim: (tokenId: number, tokenAuth: string) => Promise<StatusRequest>;
    confirmdeposit: (tokenId: number, transactionHash: string, tokenAuth: string) => Promise<StatusRequest>;
}