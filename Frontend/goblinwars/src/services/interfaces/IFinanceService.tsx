import DepositConfirmInfo from "../../dto/domain/DepositConfirmInfo";
import FinanceListResult from "../../dto/services/FinanceListResult";
import FinanceNumberResult from "../../dto/services/FinanceNumberResult";
import FinanceResult from "../../dto/services/FinanceResult";
import FinanceTransactionResult from "../../dto/services/FinanceTransactionResult";
import IHttpClient from "../../infra/interface/IHttpClient";


export default interface IFinanceService {
    init: (htppClient : IHttpClient) => void;
    list: (page: number, tokenAuth: string) => Promise<FinanceListResult>;
    getfinance: (tokenAuth: string) => Promise<FinanceResult>;
    confirmdeposit: (deposit: DepositConfirmInfo, tokenAuth: string) => Promise<FinanceTransactionResult>;
    calculatefee: (value: number, tokenAuth: string) => Promise<FinanceNumberResult>;
    withdrawl: (value: number, tokenAuth: string) => Promise<FinanceTransactionResult>;
}