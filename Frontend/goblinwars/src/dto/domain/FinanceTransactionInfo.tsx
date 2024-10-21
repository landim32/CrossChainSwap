export default interface FinanceTransactionInfo {
    id: number;
    iduser: number;
    address: string;
    insertdate: string;
    credit: number;
    debit: number;
    fee?: number;
    balance: number;
    gas?: number;
    message: string;
    txhash: string;
    status: number;
    statusmsg: string;
    success: boolean;
  }