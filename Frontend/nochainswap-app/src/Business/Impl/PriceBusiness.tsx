import BusinessResult from "../../DTO/Business/BusinessResult";
import { PriceResult } from "../../DTO/Services/PriceResult";
import { IPriceService } from "../../Services/Interfaces/IPriceService";
import { IPriceBusiness } from "../Interfaces/IPriceBusiness";

let _priceService: IPriceService;

const PriceBusiness: IPriceBusiness = {
  init: function (priceService: IPriceService): void {
    _priceService = priceService;
  },
  getCurrentPrice: async () => {
    try {
      let ret: BusinessResult<PriceResult> = null;
      let retPool = await _priceService.getCurrentPrice();
      if (retPool.sucesso) {
        return {
          ...ret,
          dataResult: retPool,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retPool.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get price information");
    }
  }
}

export { PriceBusiness };