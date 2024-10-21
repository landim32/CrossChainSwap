import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import IGLogBusiness from "../interfaces/IGLogBusiness";
import IGLogService from "../../services/interfaces/IGLogService";
import GLogListResult from "../../dto/services/GLogListResult";

let _authBusiness : IAuthBusiness;
let _glogService : IGLogService;

const GLogBusiness : IGLogBusiness = {
  init: function (glogService: IGLogService, authBusiness: IAuthBusiness): void {
    _authBusiness = authBusiness;
    _glogService = glogService;
  },
  list: async (page: number) => {
    try {
      let ret: BusinessResult<GLogListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _glogService.list(page, userSession);
      if (retAuction.sucesso) {
        return {
          ...ret,
          dataResult: retAuction,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retAuction.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  }
}

export default GLogBusiness;