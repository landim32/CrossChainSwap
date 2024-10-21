import { MiningRankingInfo } from "../domain/MiningRankingInfo";
import StatusRequest from "./StatusRequest";

export default interface MiningListResult extends StatusRequest {
  rewarddate?: string;
  minings: MiningRankingInfo[];
}