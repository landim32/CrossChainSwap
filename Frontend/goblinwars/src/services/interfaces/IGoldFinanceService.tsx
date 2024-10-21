import { CraftResult } from "../../dto/services/CraftResult";
import { GoldTradeRateResult } from "../../dto/services/GoldTradeRateResult";
import { GoldTransactionListResult } from "../../dto/services/GoldTransactionListResult";
import ItemDestroyResult from "../../dto/services/ItemDestroyResult";
import StatusRequest from "../../dto/services/StatusRequest";
import { TradeBalanceResult } from "../../dto/services/TradeBalanceResult";
import IHttpClient from "../../infra/interface/IHttpClient";


export interface IGoldFinanceService {
    init: (htppClient : IHttpClient) => void;
    list: (
        page: number, 
        tokenAuth: string
    ) => Promise<GoldTransactionListResult>;
    tradebalance: (
        tokenAuth: string
    ) => Promise<TradeBalanceResult>;
    gobipergold: (
        gobi: number,
        tokenAuth: string
    ) => Promise<GoldTradeRateResult>;
    goldpergobi: (
        gold: number,
        tokenAuth: string
    ) => Promise<GoldTradeRateResult>;
    swapgold: (
        gold: number,
        tokenAuth: string
    ) => Promise<StatusRequest>;
    swapgobi: (
        gobi: number,
        tokenAuth: string
    ) => Promise<StatusRequest>;
}