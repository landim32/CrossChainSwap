import FinanceInfo from "../domain/FinanceInfo";
import StatusRequest from "./StatusRequest";

export default interface FinanceResult extends StatusRequest {
  finance: FinanceInfo;
}