import { TransactionSaleInfo } from "../domain/TransactionSaleInfo";
import StatusRequest from "./StatusRequest";

export interface TransactionSaleResult extends StatusRequest {
  transactionSale: TransactionSaleInfo;
}