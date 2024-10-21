import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import { IGoblinUserService } from "../../services/interfaces/IGoblinUserService";
import { IGoblinUserBusiness } from "../interfaces/IGoblinUserBusiness";
import { BalanceInfo } from "../../dto/domain/BalanceInfo";
import { IItemBusiness } from "../interfaces/IItemBusiness";
import { UserItemInfo } from "../../dto/domain/UserItemInfo";
import { IItemService } from "../../services/interfaces/IItemService";
import { ItemInfo } from "../../dto/domain/ItemInfo";
import { RarityEnum } from "../../dto/enum/RarityEnum";
import ItemDestroyResult from "../../dto/services/ItemDestroyResult";
import { CraftInfo } from "../../dto/domain/CraftInfo";

let _authBusiness : IAuthBusiness;
let _itemService : IItemService;

const ItemBusiness : IItemBusiness = {
  init: function (itemService: IItemService, authBusiness: IAuthBusiness): void {
    _authBusiness = authBusiness;
    _itemService = itemService;
  },
  list: async () => {
    try {
      let ret: BusinessResult<UserItemInfo[]> = null;
      let userSession = _authBusiness.getGokenSession();
      if(userSession === "")
        throw new Error("Need to login");
      let retGoblin = await _itemService.list(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.itens,
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
  },
  getbykey: async (itemKey: number) =>{
    try {
      let ret: BusinessResult<UserItemInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if(userSession === "")
        throw new Error("Need to login");
      let retService = await _itemService.getbykey(itemKey, userSession);
      if (retService.sucesso) {
        return {
          ...ret,
          dataResult: retService.item,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retService.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get item");
    }
  },
  getcraftinfo: async (itemKey: number) =>{
    try {
      let ret: BusinessResult<CraftInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if(userSession === "")
        throw new Error("Need to login");
      let retService = await _itemService.getcraftinfo(itemKey, userSession);
      if (retService.sucesso) {
        return {
          ...ret,
          dataResult: retService.itemcraft,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retService.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get item");
    }
  },
  sell: async (key: number, qtde: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if(userSession === "")
        throw new Error("Need to login");
      let retService = await _itemService.sell(key, qtde, userSession);
      if (retService.sucesso) {
        return {
          ...ret,
          dataResult: retService.sucesso,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retService.mensagem
        };
      }
    } catch {
      throw new Error("Failed to sell item");
    }
  },
  move: async (idItem: number, x: number, y: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if(userSession === "")
        throw new Error("Need to login");
      let retService = await _itemService.move(idItem, x, y, userSession);
      if (retService.sucesso) {
        return {
          ...ret,
          dataResult: retService.sucesso,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retService.mensagem
        };
      }
    } catch {
      throw new Error("Failed to move item");
    }
  },
  destroyitem: async (idItem: number, qtde: number) => {
    try {
      let ret: BusinessResult<ItemDestroyResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if(userSession === "")
        throw new Error("Need to login");
      let retService = await _itemService.destroyitem(idItem, qtde, userSession);
      if (retService.sucesso) {
        return {
          ...ret,
          dataResult: retService,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retService.mensagem
        };
      }
    } catch  {
      throw new Error("Failed to open item");
    }
  },
  sellalltrash: async () => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if(userSession === "")
        throw new Error("Need to login");
      let retService = await _itemService.sellalltrash(userSession);
      if (retService.sucesso) {
        return {
          ...ret,
          dataResult: retService.sucesso,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retService.mensagem
        };
      }
    } catch {
      throw new Error("Failed to sell all trash");
    }
  }
}

export {ItemBusiness};