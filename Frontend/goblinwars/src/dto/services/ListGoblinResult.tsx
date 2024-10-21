import { GoblinInfo } from "../domain/GoblinInfo";
import StatusRequest from "./StatusRequest";

export interface ListGoblinResult extends StatusRequest {
  goblins: GoblinInfo[];
  page: number;
  totalPages: number;
  cursorGob: number;
}