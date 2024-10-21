import { BalanceInfo } from "../domain/BalanceInfo";
import { GoblinInfo } from "../domain/GoblinInfo";
import StatusRequest from "./StatusRequest";

export interface BalanceResult extends StatusRequest {
  balance: BalanceInfo
}