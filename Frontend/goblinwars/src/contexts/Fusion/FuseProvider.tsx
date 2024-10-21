import React, {useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import FuseContext from './FuseContext';
import IFuseProvider from '../../dto/contexts/IFuseProvider';
import { GoblinInfo } from '../../dto/domain/GoblinInfo';
import GoblinFactory from '../../business/factory/GoblinFactory';
import ProviderResultDetail from '../../dto/contexts/ProviderResultDetail';
import { AsyncLocalStorage } from 'async_hooks';
import GobiFactory from '../../business/factory/GobiFactory';

export default function FinanceProvider(props : any) {

  const [goblinTarget, setGoblinTarget] = useState<GoblinInfo>(null);
  const [goblinSacrifice, setGoblinSacrifice] = useState<GoblinInfo>(null);
  const [fuseCost, setFuseCost] = useState<number>(null);
  const [loadingCost, setLoadingCost] = useState(false);
  const [loadingFuse, setLoadingFuse] = useState(false);
  //const [loadingTargetAproved, setLoadingTargetAproved] = useState(false);
  //const [loadingSacrificeAproved, setLoadingSacrificeAproved] = useState(false);
  //const [loadingGobiApproved, setLoadingGobiAproved] = useState<boolean>(false);
  //const [goblinTargetAproved, setGoblinTargetAproved] = useState(false);
  //const [goblinSacrificeAproved, setGoblinSacrificeAproved] = useState(false);
  //const [gobiApproved, setGobiApproved] = useState<boolean>(false);

  /*
  const isAproved = (aprovedResult: string) => {
    if(aprovedResult.toLocaleLowerCase() == process.env.REACT_APP_CONTRACT_FUSION_ADDRESS.toLowerCase()){
      return true;
    }
    return false;
  }
  */

  const getGoblinTarget = async (tokenId: number) => {
    //setLoadingTargetAproved(true);
    setGoblinTarget(null);
    //setGoblinTargetAproved(false);
    //let aprovedResult = await GoblinFactory.GoblinBusiness.getApproved(tokenId);
    //if(aprovedResult.sucesso && isAproved(aprovedResult.dataResult))
    //  setGoblinTargetAproved(true);
    //setLoadingTargetAproved(false);
    let buResult = await GoblinFactory.GoblinBusiness.goblin(tokenId);
    if(buResult.sucesso == true) {
      setGoblinTarget(buResult.dataResult);
    }
  }

  const getGoblinSacrifice = async (tokenId: number) => {
    //setLoadingSacrificeAproved(true);
    setGoblinSacrifice(null);
    //setGoblinSacrificeAproved(false);
    //let aprovedResult = await GoblinFactory.GoblinBusiness.getApproved(tokenId);
    //if(aprovedResult.sucesso && isAproved(aprovedResult.dataResult))
    //  setGoblinSacrificeAproved(true);
    //setLoadingSacrificeAproved(false);
    let buResult = await GoblinFactory.GoblinBusiness.goblin(tokenId);
    if(buResult.sucesso == true) {
      setGoblinSacrifice(buResult.dataResult);
    }
  }

  const fuseProviderValue: IFuseProvider = {
    getGoblins: async (targetTokenId: number, sacrificeTokenId: number) => {
      let ret: Promise<ProviderResult>;
      try {
        getGoblinTarget(targetTokenId);
        getGoblinSacrifice(sacrificeTokenId);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    getFuseCost: async (tokenId: number) => {
      let ret: Promise<ProviderResultDetail<number>>;
      setLoadingCost(true);
      try {
        var buResult = await GoblinFactory.GoblinBusiness.fusionCost(tokenId);
        setLoadingCost(false);
        if (!buResult.sucesso)
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };

        //alert(buResult.dataResult);
        setFuseCost(buResult.dataResult.breedCost);

        return {
          ...ret,
          sucesso: true,
          dataResult: buResult.dataResult
        };
      } catch (err: any) {
        setLoadingCost(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    fuse: async () => {
      let ret: Promise<ProviderResultDetail<number>>;
      setLoadingFuse(true);
      try {
        var buResult = await GoblinFactory.GoblinBusiness.fusion(goblinTarget.idToken, goblinSacrifice.idToken);
        if (!buResult.sucesso)
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };

        //var retNewGoblin = await GoblinFactory.GoblinBusiness.lastGoblin();
        //await GoblinFactory.GoblinBusiness.refreshNftWallet([goblinTarget.idToken, goblinSacrifice.idToken]);
        setLoadingFuse(false);
        /*
        if(retNewGoblin.sucesso)
          return {
            ...ret,
            sucesso: true,
            dataResult: retNewGoblin.dataResult.idToken
          };
        */  

        return {
          ...ret,
          sucesso: true,
          dataResult: buResult.dataResult
        };
      } catch (err: any) {
        setLoadingFuse(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    /*
    aproveTarget: async () => {
      let ret: Promise<ProviderResult>;
      setLoadingTargetAproved(true);
      try {
        let addressContract = process.env.REACT_APP_CONTRACT_FUSION_ADDRESS;
        let buResult = await GoblinFactory.GoblinBusiness.approve(addressContract, goblinTarget.idToken);
        setLoadingTargetAproved(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setGoblinTargetAproved(true);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoadingTargetAproved(false);
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    aproveSacrifice: async () => {
      let ret: Promise<ProviderResult>;
      setLoadingSacrificeAproved(true);
      try {
        let addressContract = process.env.REACT_APP_CONTRACT_FUSION_ADDRESS;
        let buResult = await GoblinFactory.GoblinBusiness.approve(addressContract, goblinSacrifice.idToken);
        setLoadingSacrificeAproved(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setGoblinSacrificeAproved(true);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoadingSacrificeAproved(false);
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    isGobiApproved: async (_fuseCost: number) => {
      let ret: Promise<ProviderResult>;
      try {
        let addressContract = process.env.REACT_APP_CONTRACT_FUSION_ADDRESS;
        let retApprove = await GobiFactory.GobiBusiness.allowance(addressContract);
        if (!retApprove.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: retApprove.mensagem
          };
        }
        setGobiApproved(retApprove.dataResult >= _fuseCost);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    approveGobi: async () => {
      let ret: Promise<ProviderResult>;
      setLoadingGobiAproved(true);
      try {
        let addressContract = process.env.REACT_APP_CONTRACT_FUSION_ADDRESS;
        let retBalance = await GobiFactory.GobiBusiness.balanceOf();
        if (!retBalance.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: retBalance.mensagem
          };
        }
        if (retBalance.dataResult <= 0) {
          setLoadingGobiAproved(false);
          return {
            ...ret,
            sucesso: false,
            mensagemErro: "You dont have any balance in GOBI"
          };
        }
        let retApprove = await GobiFactory.GobiBusiness.approve(addressContract, retBalance.dataResult);
        setLoadingGobiAproved(false);
        if (!retApprove.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: retApprove.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoadingGobiAproved(false);
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    */
    goblinTarget: goblinTarget,
    goblinSacrifice: goblinSacrifice,
    fuseCost: fuseCost,
    loadingCost: loadingCost,
    loadingFuse: loadingFuse,
    //loadingTargetAproved: loadingTargetAproved,
    //loadingGobiApproved: loadingGobiApproved,
    //goblinTargetAproved: goblinTargetAproved,
    //loadingSacrificeAproved: loadingSacrificeAproved,
    //goblinSacrificeAproved: goblinSacrificeAproved,
    //gobiApproved: gobiApproved
  };

  return (
    <FuseContext.Provider value={fuseProviderValue}>
      {props.children}
    </FuseContext.Provider>
  );
}
