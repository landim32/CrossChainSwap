import BusinessResult from "../../dto/business/BusinessResult";
import { GoldTradeRateInfo } from "../../dto/domain/GoldTradeRateInfo";
import { GoldTransactionInfo } from "../../dto/domain/GoldTransactionInfo";
import { TradeBalanceInfo } from "../../dto/domain/TradeBalanceInfo";
import { GoldTransactionListResult } from "../../dto/services/GoldTransactionListResult";
import { IGoldFinanceService } from "../../services/interfaces/IGoldFinanceService";
import { IAuthBusiness } from "./IAuthBusiness";

export interface IGoldFinanceBusiness {
  init: (goldFinanceService: IGoldFinanceService, authBusiness: IAuthBusiness) => void;
  list: (page: number) => Promise<BusinessResult<GoldTransactionListResult>>;
  tradebalance: () => Promise<BusinessResult<TradeBalanceInfo>>;
  gobipergold: (
    gobi: number
  ) => Promise<BusinessResult<GoldTradeRateInfo>>;
  goldpergobi: (
    gold: number
  ) => Promise<BusinessResult<GoldTradeRateInfo>>;
  swapgold: (
      gold: number
  ) => Promise<BusinessResult<boolean>>;
  swapgobi: (
    gobi: number
) => Promise<BusinessResult<boolean>>;
}