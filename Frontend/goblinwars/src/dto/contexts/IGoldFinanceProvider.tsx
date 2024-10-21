import { LoadingGoldFinance } from "../business/LoadingGoldFinance";
import { GoldTransactionInfo } from "../domain/GoldTransactionInfo";
import { TradeBalanceInfo } from "../domain/TradeBalanceInfo";
import { GoldTransactionListResult } from "../services/GoldTransactionListResult";
import ProviderResult from "./ProviderResult";

export interface IGoldFinanceProvider {
  list: (page: number) => Promise<ProviderResult>;
  balance: () => Promise<ProviderResult>;
  swapGold: () => Promise<ProviderResult>;
  swapGobi: () => Promise<ProviderResult>;
  setGold: (value: string) => void;
  setGobi: (value: string) => void;
  setIsGobiToGold: () => void;
  transactions: GoldTransactionListResult;
  tradeBalance: TradeBalanceInfo;
  isGobiToGold: boolean;
  swapRateGold: number;
  swapRateGobi: number;
  gold: string;
  gobi: string;
  loading: LoadingGoldFinance;
}