import DepositConfirmInfo from "../domain/DepositConfirmInfo";
import FinanceInfo from "../domain/FinanceInfo";
import FinanceTransactionInfo from "../domain/FinanceTransactionInfo";
import FinanceListResult from "../services/FinanceListResult";
import ProviderResult from "./ProviderResult";

interface IFinanceProvider {
    list: (page: number) => Promise<ProviderResult>;
    getFinance: () => Promise<ProviderResult>;
    deposit: (value: number) => Promise<ProviderResult>;
    calculateFee: (value: number) => Promise<ProviderResult>;
    withdrawl: (value: number) => Promise<ProviderResult>;
    transactions: FinanceListResult;
    finance: FinanceInfo;
    currentTransaction: FinanceTransactionInfo;
    currentFee: number;
    loading: boolean;
    loadingCalculate: boolean;
    loadingTransaction: boolean;
    loadingActive: boolean;
    loadingDeposit: boolean;
    loadingWithdraw: boolean;
}

export default IFinanceProvider;