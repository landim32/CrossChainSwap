import StatusRequest from "./StatusRequest";

export interface MiningHistoryDateResult extends StatusRequest {
  dates: string[];
}