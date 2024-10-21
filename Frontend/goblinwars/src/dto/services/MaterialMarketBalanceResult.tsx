import { MaterialMarketBalanceInfo } from "../domain/MaterialMarketBalanceInfo";
import StatusRequest from "./StatusRequest";

export interface MaterialMarketBalanceResult extends StatusRequest {
    marketbalance: MaterialMarketBalanceInfo;
}