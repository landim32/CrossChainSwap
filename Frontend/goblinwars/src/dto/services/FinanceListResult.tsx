import FinanceTransactionInfo from "../domain/FinanceTransactionInfo";
import StatusRequest from "./StatusRequest";

export default interface FinanceListResult extends StatusRequest {
  transactions: FinanceTransactionInfo[];
  page: number;
  totalpages: number;
}