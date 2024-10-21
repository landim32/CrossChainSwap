import { MiningHistoryInfo } from "../domain/MiningHistoryInfo";
import StatusRequest from "./StatusRequest";

export interface MiningHistoryResult extends StatusRequest {
  histories: MiningHistoryInfo[];
}