import BusinessResult from "../../dto/business/BusinessResult";
import IGoboxBusiness from "../interfaces/IGoboxBusiness";
import { GoboxInfo } from "../../dto/domain/GoboxInfo";
import { IGoboxService } from "../../services/interfaces/IGoboxService";
import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import { ItemInfo } from "../../dto/domain/ItemInfo";

let _authBusiness : IAuthBusiness;
let _goboxService : IGoboxService;

const GoboxBusiness : IGoboxBusiness = {
  init: function (goboxService: IGoboxService, authBusiness: IAuthBusiness): void {
    _authBusiness = authBusiness;
    _goboxService = goboxService;
  },
  list: async () => {
    try {
      let ret: BusinessResult<GoboxInfo[]> = null;
      let retGobox = await _goboxService.list();
      if (retGobox.sucesso) {
        return {
          ...ret,
          dataResult: retGobox.goboxes,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGobox.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  },
  listMyBox: async () => {
    try {
      let ret: BusinessResult<GoboxInfo[]> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGobox = await _goboxService.listMyBox(userSession);
      if (retGobox.sucesso) {
        return {
          ...ret,
          dataResult: retGobox.goboxes,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGobox.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  },
  getbygobox: async (boxType: number) => {
    try {
      let ret: BusinessResult<GoboxInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGobox = await _goboxService.getbygobox(boxType, userSession);
      if (retGobox.sucesso) {
        return {
          ...ret,
          dataResult: retGobox.gobox,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGobox.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }

  },
  buybox: async (box: number, qtdy: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGobox = await _goboxService.buybox(box, qtdy, userSession);
      if (retGobox.sucesso) {
        return {
          ...ret,
          dataResult: retGobox.sucesso,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGobox.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  },
  openbox: async (box: number) => {
    try {
      let ret: BusinessResult<number> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGobox = await _goboxService.openbox(box, userSession);
      if (retGobox.sucesso) {
        return {
          ...ret,
          dataResult: retGobox.tokenid,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGobox.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  },
  openitembox: async (box: number) => {
    try {
      let ret: BusinessResult<ItemInfo[]> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGobox = await _goboxService.openitembox(box, userSession);
      if (retGobox.sucesso) {
        return {
          ...ret,
          dataResult: retGobox.itens,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGobox.mensagem
        };
      }
    } catch {
      throw new Error("Failed to search auction");
    }
  }
};

export default GoboxBusiness;