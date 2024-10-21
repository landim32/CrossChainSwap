import BusinessResult from "../../dto/business/BusinessResult";
import AuctionFilterInfo from "../../dto/domain/AuctionFilterInfo";
import AuctionInfo from "../../dto/domain/AuctionInfo";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import DepositConfirmInfo from "../../dto/domain/DepositConfirmInfo";
import FinanceInfo from "../../dto/domain/FinanceInfo";
import FinanceTransactionInfo from "../../dto/domain/FinanceTransactionInfo";
import FinanceListResult from "../../dto/services/FinanceListResult";
import IFinanceService from "../../services/interfaces/IFinanceService";
import { IAuthBusiness } from "./IAuthBusiness";
import IGobiBusiness from "./IGobiBusiness";

export default interface IFinanceBusiness {
  init: (financeService: IFinanceService, authBusiness: IAuthBusiness, gobiBusiness: IGobiBusiness) => void;
  list: (page: number) => Promise<BusinessResult<FinanceListResult>>;
  getFinance: () => Promise<BusinessResult<FinanceInfo>>;
  deposit: (value: number) => Promise<BusinessResult<FinanceTransactionInfo>>;
  calculateFee: (value: number) => Promise<BusinessResult<number>>;
  withdrawl: (value: number) => Promise<BusinessResult<FinanceTransactionInfo>>;
}