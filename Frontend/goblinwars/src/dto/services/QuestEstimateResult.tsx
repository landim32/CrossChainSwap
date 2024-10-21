import { QuestEstimateInfo } from "../domain/QuestEstimateInfo";
import StatusRequest from "./StatusRequest";

export interface QuestEstimateResult extends StatusRequest {
  estimate: QuestEstimateInfo;
}