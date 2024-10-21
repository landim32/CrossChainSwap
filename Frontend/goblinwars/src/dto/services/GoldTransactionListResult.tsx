import { GoldTransactionInfo } from "../domain/GoldTransactionInfo";
import StatusRequest from "./StatusRequest";

export interface GoldTransactionListResult extends StatusRequest {
  transactions: GoldTransactionInfo[];
  page: number;
  totalpages: number;
}