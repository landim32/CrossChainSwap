import FinanceTransactionInfo from "../domain/FinanceTransactionInfo";
import StatusRequest from "./StatusRequest";

export default interface FinanceTransactionResult extends StatusRequest {
  transaction: FinanceTransactionInfo;
}