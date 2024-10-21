import { TradeBalanceInfo } from "../domain/TradeBalanceInfo";
import StatusRequest from "./StatusRequest";

export interface TradeBalanceResult extends StatusRequest {
  tradebalance: TradeBalanceInfo;
}