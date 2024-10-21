import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import BusinessResult from "../../dto/business/BusinessResult";
import { IGoblinBusiness } from "../interfaces/IGoblinBusiness";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import { IGoblinService } from "../../services/interfaces/IGoblinService";
import Web3 from "web3";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { StatusEnum } from "../../dto/enum/StatusEnum";
import AnalyticsFactory from "../factory/AnalyticsFactory";
import { BodyPartEnum } from "../../dto/enum/BodyPartEnum";
import { IEquipmentService } from "../../services/interfaces/IEquipmentService";
import { BreedCostResult } from "../../dto/services/BreedCostResult";

let _goblinService : IGoblinService;
let _equipmentService : IEquipmentService;
let _authBusiness : IAuthBusiness;

const GoblinBusiness : IGoblinBusiness = {
  init: function (goblinService: IGoblinService, equipmentService: IEquipmentService, authBusiness: IAuthBusiness): void {
    _goblinService = goblinService;
    _equipmentService = equipmentService;
    _authBusiness = authBusiness;
  },
  listByUser: async (page: number, itemsPerPage: number) => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblins = await _goblinService.listbyuser(page, itemsPerPage, userSession);
      if (retGoblins.sucesso) {
        return {
          ...ret,
          dataResult: retGoblins,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblins.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin list");
    }
  },
  myGoblin: async (tokenId: number) => {
    try {
      let ret: BusinessResult<GoblinInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblin = await _goblinService.myGoblin(tokenId, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.goblin,
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
  rechargeGoblin: async (tokenId: number) => {
    try {
      let ret: BusinessResult<GoblinInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblin = await _goblinService.rechargeGoblin(tokenId, userSession);
      if (retGoblin.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Goblin', 'Recharge goblin');
        return {
          ...ret,
          dataResult: retGoblin.goblin,
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
  updateGoblinName: async (tokenId: number, name: string) => {
    try {
      let ret: BusinessResult<GoblinInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblin = await _goblinService.updateGoblinName(tokenId, name, userSession);
      if (retGoblin.sucesso) {
        AnalyticsFactory.Analytics.sendEvent('Goblin', 'Update name');
        return {
          ...ret,
          dataResult: retGoblin.goblin,
          sucesso: true,
          mensagem: "Name changed"
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblin.mensagem
        };
      }
    } catch {
      throw new Error("Failed to update goblin name");
    }
  },
  goblin: async (tokenId: number) => {
    try {
      let ret: BusinessResult<GoblinInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblin = await _goblinService.goblin(tokenId, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.goblin,
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
  goblinBrothers: async (tokenId: number, page: number) => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblins = await _goblinService.goblinBrothers(tokenId, page, userSession);
      if (retGoblins.sucesso) {
        return {
          ...ret,
          dataResult: retGoblins,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblins.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin list");
    }
  },
  equipPart: async (goblinId: number, tokenId: number, itemKey: number, part: BodyPartEnum) => {
    try {
      let ret: BusinessResult<GoblinInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblin = await _equipmentService.equipPart(goblinId, tokenId, itemKey, part, userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.goblin,
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
      throw new Error("Failed to equip goblin");
    }
  },
  goblinSons: async (tokenId: number, page: number) => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblins = await _goblinService.goblinSons(tokenId, page, userSession);
      if (retGoblins.sucesso) {
        return {
          ...ret,
          dataResult: retGoblins,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblins.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin list");
    }
  },
  spouseCandidates: async (tokenId: number, cursorGob: number) => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblins = await _goblinService.spouseCandidate(tokenId, cursorGob, userSession);
      if (retGoblins.sucesso) {
        return {
          ...ret,
          dataResult: retGoblins
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblins.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin list");
    }
  },
  /*
  breedGoblin: async (goblin1: GoblinInfo, goblin2: GoblinInfo) => {
    let ret: BusinessResult<number>;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    try {

      if (goblin1.status == StatusEnum.Minning || goblin2.status == StatusEnum.Minning) {
        return buildErro('You cannot breed a goblin that is in the mine');
      }

      let web3: Web3 | undefined = undefined;
      web3 = new Web3((window as any).ethereum);
      const publicAddress = await web3.eth.getCoinbase();
      if (!publicAddress) {
        return buildErro('Please activate MetaMask first.');
      }
      const bornContract = ContractFactory.getBornContract(web3);
      let receipt = await bornContract.methods.born(goblin1.idToken, goblin2.idToken).send({ from: publicAddress });
      if (receipt.transactionHash) {
        AnalyticsFactory.Analytics.sendEvent('Goblin', 'Breed goblin');
        return ret = {
          ...ret,
          sucesso: true,
          mensagem: "Breed complete !!!"
        };
      }



      else
        buildErro("Error in transaction");

    } catch (err: any) {
      return buildErro('Error: ' + err.message);
    }
  },
  buyGoblin: async () => {
    let ret: BusinessResult<boolean>;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    try {
      let web3: Web3 | undefined = undefined;

      web3 = new Web3((window as any).ethereum);
      const publicAddress = await web3.eth.getCoinbase();
      if (!publicAddress) {
        return buildErro('Please activate MetaMask first.');
      }
      const bornContract = ContractFactory.getBornContract(web3);
      let receipt = await bornContract.methods.buyGoblin().send({ from: publicAddress });
      if (receipt.transactionHash)
        return ret = {
          ...ret,
          sucesso: true,
          mensagem: "Great! You get a new Goblin!!!"
        };



      else
        buildErro("Error in transaction");

    } catch (err: any) {
      return buildErro('Error: ' + err.message);
    }
  },
  */
  breedCost: async (tokenId1: number, tokenId2: number) => {
    try {
      let ret: BusinessResult<BreedCostResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retCost = await _goblinService.breedCost(tokenId1, tokenId2, userSession);
      if (retCost.sucesso) {
        return {
          ...ret,
          dataResult: retCost,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retCost.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin");
    }
    /*
    let ret: BusinessResult<BreedCostResult>;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    try {
      let web3: Web3 | undefined = undefined;

      web3 = new Web3((window as any).ethereum);
      const publicAddress = await web3.eth.getCoinbase();
      if (!publicAddress) {
        return buildErro('Please activate MetaMask first.');
      }
      const bornContract = ContractFactory.getBornContract(web3);
      let receipt = await bornContract.methods.bornCost(tokenId1, tokenId2).call();
      if (receipt)
        return ret = {
          ...ret,
          sucesso: true,
          dataResult: receipt / (10 ** 18)
        };
      else {
        buildErro("Error in transaction");
      }

    } catch (err: any) {
      return buildErro('Error: ' + err.message);
    }
    */
  },
  /*
  breedRarity: async (tokenId1: number, tokenId2: number) => {
    let ret: BusinessResult<number>;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    try {
      let web3: Web3 | undefined = undefined;

      web3 = new Web3((window as any).ethereum);
      const publicAddress = await web3.eth.getCoinbase();
      if (!publicAddress) {
        return buildErro('Please activate MetaMask first.');
      }
      const bornContract = ContractFactory.getBornContract(web3);
      let receipt = await bornContract.methods.bornRarity(tokenId1, tokenId2).call();
      if (receipt)
        return ret = {
          ...ret,
          sucesso: true,
          dataResult: receipt
        };
      else {
        buildErro("Error in transaction");
      }

    } catch (err: any) {
      return buildErro('Error: ' + err.message);
    }
  },
  */
  transfer: async (tokenId: number, userAddress: string) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      let retTransfer = await _goblinService.transfer(tokenId, userAddress, userSession);
      if (retTransfer.sucesso) {
        return {
          ...ret,
          dataResult: retTransfer.sucesso,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retTransfer.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin can fuse list");
    }
  },
  /*
  transferGoblin: async (goblin: GoblinInfo, toAddress: string) => {
    let ret: BusinessResult<boolean>;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    try {

      let web3: Web3 | undefined = undefined;


      web3 = new Web3((window as any).ethereum);
      const publicAddress = await web3.eth.getCoinbase();
      if (!publicAddress) {
        return buildErro('Please activate MetaMask first.');
      }
      const bornContract = ContractFactory.getGoblinContract(web3);
      let receipt = await bornContract.methods.safeTransferFrom(publicAddress, toAddress, goblin.idToken).send({ from: publicAddress });
      if (receipt.transactionHash) {
        AnalyticsFactory.Analytics.sendEvent('Goblin', 'Transfer goblin');
        return ret = {
          ...ret,
          sucesso: true,
          mensagem: "Transfer complete !!!"
        };
      }


      else
        buildErro("Error in transaction");

    } catch (err: any) {
      return buildErro('Error: ' + err.message);
    }
  },
  getApproved: async (tokenId: number) => {
    let ret: BusinessResult<string>;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    try {
      let web3: Web3 | undefined = undefined;

      web3 = new Web3((window as any).ethereum);
      const publicAddress = await web3.eth.getCoinbase();
      if (!publicAddress) {
        return buildErro('Please activate MetaMask first.');
      }
      const bornContract = ContractFactory.getGoblinContract(web3);
      let receipt = await bornContract.methods.getApproved(tokenId).call();
      if (receipt)
        return ret = {
          ...ret,
          sucesso: true,
          dataResult: receipt
        };
      else {
        buildErro("Error in transaction");
      }

    } catch (err: any) {
      return buildErro('Error: ' + err.message);
    }
  },
  approve: async (to: string, tokenId: number) => {
    let ret: BusinessResult<boolean>;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    try {
      let web3: Web3 | undefined = undefined;

      web3 = new Web3((window as any).ethereum);
      const publicAddress = await web3.eth.getCoinbase();
      if (!publicAddress) {
        return buildErro('Please activate MetaMask first.');
      }
      const bornContract = ContractFactory.getGoblinContract(web3);
      let receipt = await bornContract.methods.approve(to, tokenId).send({
        from: publicAddress
      });
      if (receipt.transactionHash)
        return ret = {
          ...ret,
          sucesso: true,
          dataResult: true,
          mensagem: "Approved!"
        };





      else
        buildErro("Error in transaction");

    } catch (err: any) {
      return buildErro('Error: ' + err.message);
    }
  },
  */
  listInfityGoblins: async (cursorGob: number) => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblins = await _goblinService.listInfinityGoblins(cursorGob, userSession);
      if (retGoblins.sucesso) {
        return {
          ...ret,
          dataResult: retGoblins
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblins.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin list");
    }
  },
  lastGoblin: async () => {
    try {
      let ret: BusinessResult<GoblinInfo> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblin = await _goblinService.lastGoblin(userSession);
      if (retGoblin.sucesso) {
        return {
          ...ret,
          dataResult: retGoblin.goblin,
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
  goblinCanFuse: async (tokenId: number) => {
    try {
      let ret: BusinessResult<ListGoblinResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblins = await _goblinService.goblinsCanFuse(tokenId, userSession);
      if (retGoblins.sucesso) {
        return {
          ...ret,
          dataResult: retGoblins,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retGoblins.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin can fuse list");
    }
  },
  /*
  refreshNftWallet: async (tokens: number[]) => {
    try {
      let ret: BusinessResult<boolean> = null;
      let userSession = _authBusiness.getGokenSession();
      let retGoblin = await _goblinService.refreshNftWallet(tokens, userSession);
      return {
        ...ret,
        dataResult: true,
        sucesso: retGoblin
      };
    } catch {
      throw new Error("Failed to get goblin");
    }
  },  
  getBreedCount: async (tokenId: number) => {
    let ret: BusinessResult<number>;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    try {
      let web3: Web3 | undefined = undefined;

      web3 = new Web3((window as any).ethereum);
      const publicAddress = await web3.eth.getCoinbase();
      if (!publicAddress) {
        return buildErro('Please activate MetaMask first.');
      }
      const goblinContract = ContractFactory.getGoblinContract(web3);
      let receipt = await goblinContract.methods.balanceOfSons(tokenId).call();
      return ret = {
        ...ret,
        sucesso: true,
        dataResult: receipt,
        mensagem: "Approved!"
      };

    } catch (err: any) {
      return buildErro('Error: ' + err.message);
    }
  },*/
  fusionCost: async (tokenId: number) => {
    try {
      let ret: BusinessResult<BreedCostResult> = null;
      let userSession = _authBusiness.getGokenSession();
      let retFusion = await _goblinService.fusionCost(tokenId, userSession);
      if (retFusion.sucesso) {
        return {
          ...ret,
          dataResult: retFusion,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retFusion.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin can fuse list");
    }
  },
  fusion: async (tokenId1: number, tokenId2: number) => {
    try {
      let ret: BusinessResult<number> = null;
      let userSession = _authBusiness.getGokenSession();
      let retFusion = await _goblinService.fusion(tokenId1, tokenId2, userSession);
      if (retFusion.sucesso) {
        return {
          ...ret,
          dataResult: retFusion.tokenid,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retFusion.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin can fuse list");
    }
  },
  breed: async (parent1: number, parent2: number) => {
    try {
      let ret: BusinessResult<number> = null;
      let userSession = _authBusiness.getGokenSession();
      let retFusion = await _goblinService.breed(parent1, parent2, userSession);
      if (retFusion.sucesso) {
        return {
          ...ret,
          dataResult: retFusion.tokenid,
          sucesso: true
        };
      } else {
        return {
          ...ret,
          sucesso: false,
          mensagem: retFusion.mensagem
        };
      }
    } catch {
      throw new Error("Failed to get goblin can fuse list");
    }
  }
}

export {GoblinBusiness};