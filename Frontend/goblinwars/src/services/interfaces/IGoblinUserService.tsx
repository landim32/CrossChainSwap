import { AuthResult } from "../../dto/services/AuthResult";
import { BalanceResult } from "../../dto/services/BalanceResult";
import { GoblinResult } from "../../dto/services/GoblinResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import StatusRequest from "../../dto/services/StatusRequest";
import { TransactionSaleResult } from "../../dto/services/TransactionSaleResult";
import IHttpClient from "../../infra/interface/IHttpClient";


export interface IGoblinUserService {
    init: (htppClient : IHttpClient) => void; 
    balance: (
        tokenAuth: string
    ) => Promise<BalanceResult>;
}