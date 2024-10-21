import BusinessResult from "../../dto/business/BusinessResult";
import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import IGoblinNftBusiness from "../interfaces/IGoblinNftBusiness";
import IGoblinNftService from "../../services/interfaces/IGoblinNftService";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import IGoblinContractBusiness from "../interfaces/IGoblinContractBusiness";

let _authBusiness : IAuthBusiness;
let _goblinContractBusiness: IGoblinContractBusiness;
let _goblinNftService : IGoblinNftService;

const GoblinNftBusiness : IGoblinNftBusiness = {
  init: function (
    goblinNftService: IGoblinNftService, 
    goblinContractBusiness: IGoblinContractBusiness, 
    authBusiness: IAuthBusiness
  ): void {
    _goblinNftService = goblinNftService;
    _goblinContractBusiness = goblinContractBusiness;
    _authBusiness = authBusiness;
  },
  list: async () => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _goblinNftService.list(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin,
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
      throw new Error("Failed to search auction");
    }
  },
  mint: async (tokenId: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _goblinNftService.mint(tokenId, userSession);
      //alert(JSON.stringify(retGoblin));
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.sucesso,
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
      throw new Error("Failed to search auction");
    }
  },
  claim: async (tokenId: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "")
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      let retGoblin = await _goblinNftService.claim(tokenId, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.sucesso,
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
      throw new Error("Failed to search auction");
    }
  },
  deposit: async (tokenId: number) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      if (userSession === "") {
        return {
          ...ret,
          sucesso: false,
          mensagem: "Need to login"
        };
      }
      const poolReward = process.env.REACT_APP_POOL_NFT_ADDRESS;
      var retTransfer = await _goblinContractBusiness.transferFrom(poolReward, tokenId);
      if (!retTransfer.sucesso) {
        return {
          ...ret,
          sucesso: false,
          mensagem: retTransfer.mensagem
        };
      }
      let retGoblin = await _goblinNftService.confirmdeposit(tokenId, retTransfer.dataResult, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.sucesso,
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
      throw new Error("Failed to search auction");
    }
  }
};

export default GoblinNftBusiness;