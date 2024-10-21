import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import { IGoblinUserService } from "../../services/interfaces/IGoblinUserService";
import { IGoblinUserBusiness } from "../interfaces/IGoblinUserBusiness";
import { BalanceInfo } from "../../dto/domain/BalanceInfo";

let _goblinUserService : IGoblinUserService;
let _authBusiness : IAuthBusiness;

const GoblinUserBusiness : IGoblinUserBusiness = {
  init: function (goblinUserService: IGoblinUserService, authBusiness: IAuthBusiness): void {
    _goblinUserService = goblinUserService;
    _authBusiness = authBusiness;
  },
  getBalance: async () => {
    try {
      let ret: BusinessResult<BalanceInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if(userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _goblinUserService.balance(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.balance,
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
      throw new Error("Failed to get goblin");
    }
  }
}

export {GoblinUserBusiness};