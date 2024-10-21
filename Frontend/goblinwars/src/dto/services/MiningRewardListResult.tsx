import { MiningRewardInfo } from "../domain/MiningRewardInfo";
import StatusRequest from "./StatusRequest";

export interface MiningRewardListResult extends StatusRequest {
  rewards: MiningRewardInfo[];
}