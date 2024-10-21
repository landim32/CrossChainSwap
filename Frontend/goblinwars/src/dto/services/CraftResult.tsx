import { CraftInfo } from "../domain/CraftInfo";
import StatusRequest from "./StatusRequest";

export interface CraftResult extends StatusRequest {
  itemcraft: CraftInfo;
}