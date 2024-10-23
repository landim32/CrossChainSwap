import TxInfo from "../Domain/TxInfo";
import StatusRequest from "./StatusRequest";

export interface TxListResult extends StatusRequest {
  transactions : TxInfo[];
}