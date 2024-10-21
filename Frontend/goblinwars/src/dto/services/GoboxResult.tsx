import { GoboxInfo } from "../domain/GoboxInfo";
import StatusRequest from "./StatusRequest";

export default interface GoboxResult extends StatusRequest {
  gobox: GoboxInfo;
  tokenid: number;
}