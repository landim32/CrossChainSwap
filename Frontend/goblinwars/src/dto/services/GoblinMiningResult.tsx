import { GoblinMining } from "../domain/GoblinMining";
import { MiningInfo } from "../domain/MiningInfo";
import StatusRequest from "./StatusRequest";

export interface GoblinMiningResult extends StatusRequest {
  goblinEnergy: GoblinMining;
}