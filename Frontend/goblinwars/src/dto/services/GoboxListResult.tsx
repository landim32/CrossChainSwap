import { GoboxInfo } from "../domain/GoboxInfo";
import StatusRequest from "./StatusRequest";

export default interface GoboxListResult extends StatusRequest {
  goboxes: GoboxInfo[];
}