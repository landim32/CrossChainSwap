import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import IAuctionBusiness from "../interfaces/IAuctionBusiness";
import IAuctionService from "../../services/interfaces/IAuctionService";
import AuctionFilterInfo from "../../dto/domain/AuctionFilterInfo";
import AuctionInfo from "../../dto/domain/AuctionInfo";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import { AuctionListResult } from "../../dto/services/AuctionListResult";
import AnalyticsFactory from "../factory/AnalyticsFactory";
import AuctionEquipmentFilterInfo from "../../dto/domain/AuctionEquipmentFilterInfo";

let _authBusiness : IAuthBusiness;
let _auctionService : IAuctionService;

const AuctionBusiness : IAuctionBusiness = {
  init: function (auctionService: IAuctionService, authBusiness: IAuthBusiness): void {
    _authBusiness = authBusiness;
    _auctionService = auctionService;
  },
  searchGoblin: async (filter: AuctionFilterInfo) => {
    try {
      let ret: BusinessResult<AuctionListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.searchgoblin(filter, userSession);
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
  },
  searchEquipment: async (filter: AuctionEquipmentFilterInfo) => {
    try {
      let ret: BusinessResult<AuctionListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.searchequipment(filter, userSession);
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
  },
  listbyauction: async (auction: number, page: number) => {
    try {
      let ret: BusinessResult<AuctionListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.listbyauction(auction, page, userSession);
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
  },
  listbyuser: async (auction: number) => {
    try {
      let ret: BusinessResult<AuctionListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.listbyuser(auction, userSession);
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
  },
  listsameequipment: async (itemkey: number) => {
    try {
      let ret: BusinessResult<AuctionListResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.listsameequipment(itemkey, userSession);
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
  },
  getbytoken: async (tokenId: number) => {
    try {
      let ret: BusinessResult<AuctionInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.getbytoken(tokenId, userSession);
      if (retAuction.sucesso) {
        return {
          ...ret,
          dataResult: retAuction.auction,
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
  },
  getbyid: async (IdAuction: number) => {
    try {
      let ret: BusinessResult<AuctionInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.getbyid(IdAuction, userSession);
      if (retAuction.sucesso) {
        return {
          ...ret,
          dataResult: retAuction.auction,
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
  },
  insert: async (param: AuctionInsertInfo) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.insert(param, userSession);
      if (retAuction.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Auction', 'Insert auction');
        return {
          ...ret,
          dataResult: true,
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
  },
  buy: async (idAuction: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.buy(idAuction, userSession);
      if (retAuction.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Auction', 'Sold auction');
        return {
          ...ret,
          dataResult: true,
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
  },
  cancel: async (idAuction: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retAuction = await _auctionService.cancel(idAuction, userSession);
      if (retAuction.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Auction', 'Cancel auction');
        return {
          ...ret,
          dataResult: true,
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

export default AuctionBusiness;