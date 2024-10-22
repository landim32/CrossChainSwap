import { PoolResult } from "../../DTO/Services/PoolResult";
import IHttpClient from "../../Infra/Interface/IHttpClient";


export interface IPoolService {
    init: (httpClient : IHttpClient) => void;
    getPoolInfo: () => Promise<PoolResult>;
}