import BusinessResult from "../../dto/business/BusinessResult";
import { BalanceInfo } from "../../dto/domain/BalanceInfo";
import { IGoblinUserService } from "../../services/interfaces/IGoblinUserService";
import { IAuthBusiness } from "./IAuthBusiness";

export interface IGoblinUserBusiness {
  init: (goblinUserService: IGoblinUserService, authBusiness: IAuthBusiness) => void;
  getBalance: () => Promise<BusinessResult<BalanceInfo>>;
}