import BusinessResult from "../../DTO/Business/BusinessResult";
import { PriceResult } from "../../DTO/Services/PriceResult";
import { IPriceService } from "../../Services/Interfaces/IPriceService";

export interface IPriceBusiness {
  init: (priceService: IPriceService) => void;
  getCurrentPrice: () => Promise<BusinessResult<PriceResult>>;
}