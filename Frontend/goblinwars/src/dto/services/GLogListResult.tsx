import GLogInfo from "../domain/GLogInfo";
import StatusRequest from "./StatusRequest";

export default interface GLogListResult extends StatusRequest {
  logs: GLogInfo[];
  page: number;
  totalpages: number;
}