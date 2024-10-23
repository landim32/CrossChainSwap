import TxLogInfo from "../Domain/TxLogInfo";
import StatusRequest from "./StatusRequest";

export interface TxLogListResult extends StatusRequest {
  logs : TxLogInfo[];
}