import GLogListResult from "../../dto/services/GLogListResult";
import IHttpClient from "../../infra/interface/IHttpClient";


export default interface IGLogService {
    init: (htppClient : IHttpClient) => void;
    list: (page: number, tokenAuth: string) => Promise<GLogListResult>;
}