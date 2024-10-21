import { GoldTransactionEnum } from "../enum/GoldTransactionEnum";

export interface GoldTransactionInfo {
  id: number;
  insertdate: string;
  iduser: number;
  gobidebit? : number;
  gobicredit?: number;
  transactiongobitax?: number;
  debit: number;
  credit: number;
  transactiongoldtax?: number;
  status: GoldTransactionEnum;
}