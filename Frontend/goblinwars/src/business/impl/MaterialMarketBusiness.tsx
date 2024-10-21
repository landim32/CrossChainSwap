import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import { IMaterialMarketService } from "../../services/interfaces/IMaterialMarketService";
import { IMaterialMarketBusiness } from "../interfaces/IMaterialMarketBusiness";
import { MaterialMarketBalanceInfo } from "../../dto/domain/MaterialMarketBalanceInfo";

let _authBusiness : IAuthBusiness;
let _materialMarketService : IMaterialMarketService;

const MaterialMarketBusiness : IMaterialMarketBusiness = {
  init: function (materialMarketService: IMaterialMarketService, authBusiness: IAuthBusiness): void {
    _authBusiness = authBusiness;
    _materialMarketService = materialMarketService;
  },
  marketbalance: async (materialkey: number) => {
    try {
      let ret: BusinessResult<MaterialMarketBalanceInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _materialMarketService.marketbalance(materialkey, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.marketbalance,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get balance");
    }
  },
  swapmaterialpergold: async (materialkey: number, qtde: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _materialMarketService.swapmaterialpergold(materialkey, qtde, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: true,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to swap materials");
    }
  },
  swapgoldpermaterial: async (materialkey: number, qtde: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _materialMarketService.swapgoldpermaterial(materialkey, qtde, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: true,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to swap gold per material");
    }
  }
}

export {MaterialMarketBusiness};