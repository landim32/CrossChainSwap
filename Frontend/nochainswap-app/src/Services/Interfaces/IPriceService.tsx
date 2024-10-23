import { PriceResult } from "../../DTO/Services/PriceResult";
import IHttpClient from "../../Infra/Interface/IHttpClient";


export interface IPriceService {
    init: (httpClient : IHttpClient) => void;
    getCurrentPrice: () => Promise<PriceResult>;
}