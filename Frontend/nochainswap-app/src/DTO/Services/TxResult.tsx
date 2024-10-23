import TxInfo from "../Domain/TxInfo";
import StatusRequest from "./StatusRequest";

export interface TxResult extends StatusRequest {
  transaction : TxInfo;
}