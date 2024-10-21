import { GoblinInfo } from "../domain/GoblinInfo";
import StatusRequest from "./StatusRequest";

export interface GoblinResult extends StatusRequest {
  goblin: GoblinInfo
}