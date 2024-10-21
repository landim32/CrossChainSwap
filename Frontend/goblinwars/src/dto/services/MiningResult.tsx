import { MiningInfo } from "../domain/MiningInfo";
import StatusRequest from "./StatusRequest";

export interface MiningResult extends StatusRequest {
  mining: MiningInfo;
}