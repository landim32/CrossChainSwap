import BusinessResult from "../../dto/business/BusinessResult";
import { MaterialMarketBalanceInfo } from "../../dto/domain/MaterialMarketBalanceInfo";
import { IMaterialMarketService } from "../../services/interfaces/IMaterialMarketService";
import { IAuthBusiness } from "./IAuthBusiness";

export interface IMaterialMarketBusiness {
  init: (materialMarketService: IMaterialMarketService, authBusiness: IAuthBusiness) => void;
  marketbalance: ( materialkey: number ) => Promise<BusinessResult<MaterialMarketBalanceInfo>>;
  swapmaterialpergold: (
    materialkey: number,
    qtde: number,
  ) => Promise<BusinessResult<boolean>>;
  swapgoldpermaterial: (
    materialkey: number,
    qtde: number,
  ) => Promise<BusinessResult<boolean>>;
}