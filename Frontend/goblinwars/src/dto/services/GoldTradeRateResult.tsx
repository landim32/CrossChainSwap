import { GoldTradeRateInfo } from "../domain/GoldTradeRateInfo";
import StatusRequest from "./StatusRequest";

export interface GoldTradeRateResult extends StatusRequest {
  tradeinfo: GoldTradeRateInfo;
}