import React, {useContext, useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import IGoblinProvider from '../../dto/contexts/IGoblinProvider';
import { GoblinInfo } from '../../dto/domain/GoblinInfo';
import GoblinFactory from '../../business/factory/GoblinFactory';
import GoblinContext from './GoblinContext';
import { LoadingGoblin } from '../../dto/business/LoadingGoblin';
import { GoblinListProvider } from '../../dto/business/GoblinListProvider';
import BusinessResult from '../../dto/business/BusinessResult';
import { ListGoblinResult } from '../../dto/services/ListGoblinResult';
import ProviderResultDetail from '../../dto/contexts/ProviderResultDetail';
import AuthFactory from '../../business/factory/AuthFactory';
import { ItemInfo } from '../../dto/domain/ItemInfo';
import { BodyPartEnum } from '../../dto/enum/BodyPartEnum';

let gettingGoblinList = false;

export default function GoblinProvider(props : any) {

  const [currentPage, setCurrentPage] = useState<number>(0);
  const [totalPages, setTotalPages] = useState<number>(0);
  const [goblins, setGoblins] = useState<GoblinInfo[]>([]);
  //const [breedCount, setBreedCount] = useState<number>(null);
  const [goblin, setGoblin] = useState<GoblinInfo>(null);
  const [goblinFather, setGoblinFather] = useState<GoblinInfo>(null);
  const [goblinMother, setGoblinMother] = useState<GoblinInfo>(null);
  const [goblinSpouse, setGoblinSpouse] = useState<GoblinInfo>(null);
  const [brothers, setBrothers] = useState<GoblinListProvider>(null);
  const [sons, setSons] = useState<GoblinListProvider>(null);
  const [spouseCandidates, setSpouseCandidates] = useState<GoblinInfo[]>([]);
  const [loading, setLoading] = useState<LoadingGoblin>({
    list: false,
    breedCandidates: false,
    breeding: false,
    brothers: false,
    sons: false,
    father: false,
    mother: false,
    info: false,
    updateName: false,
    spouse: false,
    breedCost: false,
    transferGoblin: false,
    recharge: false,
    listCanFuse: false,
    //breedCount: false,
    equipGoblin: false,
  });
  const [genesis, setGenesis] = useState(false);
  const [cursorGobBreed, setCursorGobBreed] = useState(0);
  const [cursorGob, setCursorGob] = useState(0);
  const [goblinsCanFuse, setGoblinsCanFuse] = useState<GoblinInfo[]>(null);

  const getMother = async (tokenId: number) => {
    setLoading({ ...loading, mother: true });
    let goblinResult = await GoblinFactory.GoblinBusiness.goblin(tokenId);
    setLoading({ ...loading, mother: false });
    if(goblinResult.sucesso)
      setGoblinMother(goblinResult.dataResult);
  };

  const getFather = async (tokenId: number) => {
    setLoading({ ...loading, father: true });
    let goblinResult = await GoblinFactory.GoblinBusiness.goblin(tokenId);
    setLoading({ ...loading, father: false });
    if(goblinResult.sucesso)
      setGoblinFather(goblinResult.dataResult);
  };

  const getSpouse= async (tokenId: number) => {
    setLoading({ ...loading, spouse: true });
    let goblinResult = await GoblinFactory.GoblinBusiness.goblin(tokenId);
    setLoading({ ...loading, spouse: false });
    if(goblinResult.sucesso)
      setGoblinSpouse(goblinResult.dataResult);
  };

  const getBrothers = async (tokenId: number, page: number) => {
    setLoading({ ...loading, brothers: true });
    let goblinResult : BusinessResult<ListGoblinResult> = null;
    goblinResult = await GoblinFactory.GoblinBusiness.goblinBrothers(tokenId, page);
    setLoading({ ...loading, brothers: false });
    if(goblinResult.sucesso)
      setBrothers({
        goblins: goblinResult.dataResult.goblins,
        page: goblinResult.dataResult.page,
        totalPages: goblinResult.dataResult.totalPages
      });
  };

  const getSons = async (tokenId: number, page: number) => {
    setLoading({ ...loading, sons: true });
    let goblinResult : BusinessResult<ListGoblinResult> = null;
    goblinResult = await GoblinFactory.GoblinBusiness.goblinSons(tokenId, page);
    setLoading({ ...loading, sons: false });
    if(goblinResult.sucesso)
      setSons({
        goblins: goblinResult.dataResult.goblins,
        page: goblinResult.dataResult.page,
        totalPages: goblinResult.dataResult.totalPages
      });
  };
  
  /*
  const getBreedCount = async (tokenId: number) => {
    setLoading({ ...loading, breedCount: true });
    let goblinResult : BusinessResult<number> = null;
    goblinResult = await GoblinFactory.GoblinBusiness.getBreedCount(tokenId);
    setLoading({ ...loading, breedCount: false });
    if(goblinResult.sucesso)
      setBreedCount(goblinResult.dataResult);
  }
  */

  const listCanFuse = async (tokenId: number) => {
    let ret: Promise<ProviderResultDetail<GoblinInfo>>;
    setLoading({ ...loading, listCanFuse: true });
    try {
      let goblinResult = await GoblinFactory.GoblinBusiness.goblinCanFuse(tokenId);
      setLoading({ ...loading, listCanFuse: false });
      if (!goblinResult.sucesso) {
        return {
          ...ret,
          sucesso: false,
          mensagemErro: goblinResult.mensagem,
          dataResult: null
        };
      }
      setGoblinsCanFuse(goblinResult.dataResult.goblins);
      return {
        ...ret,
        sucesso: true,
        mensagemSucesso: goblinResult.mensagem,
        dataResult: goblinResult.dataResult
      };
    } catch (err) {
      setLoading({ ...loading, listCanFuse: false });
      return {
        ...ret,
        sucesso: false,
        mensagemErro: JSON.stringify(err)
      };
    }
  }

  let gettingBreedList = false;

  const goblinProviderValue: IGoblinProvider = {
    currentPage: currentPage,
    totalPages: totalPages,
    goblin: goblin,
    //breedCount: breedCount,
    goblinFather: goblinFather,
    goblinMother: goblinMother,
    brothers: brothers,
    sons: sons,
    genesis: genesis,
    spouseCandidates: spouseCandidates,
    goblins: goblins,
    loading: loading,
    goblinSpouse: goblinSpouse,
    cursorGobBreed: cursorGobBreed,
    goblinsCanFuse: goblinsCanFuse,
    listByUser: async (page: number, itemsPerPage: number) => {
      let ret: Promise<ProviderResult>;
      setGoblins([]);
      setLoading({ ...loading, list: true });
      try {
        let buResult = await  GoblinFactory.GoblinBusiness.listByUser(page, itemsPerPage);
        setLoading({ ...loading, list: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setGoblins(buResult.dataResult.goblins);
        setTotalPages(buResult.dataResult.totalPages);
        setCurrentPage(buResult.dataResult.page);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading({ ...loading, list: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listGoblins: async (reset: boolean) => {
      if (gettingGoblinList)
        return;

      gettingGoblinList = true;
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, list: true });
      let goblinsLocal = goblins;
      let cursorGobLocal = cursorGob;
      if (reset) {
        goblinsLocal = [];
        cursorGobLocal = 0;
      }

      try {
        let goblinsResult = await GoblinFactory.GoblinBusiness.listInfityGoblins(cursorGobLocal);
        setLoading({ ...loading, list: false });
        gettingGoblinList = false;
        if (!goblinsResult.dataResult || !goblinsResult.dataResult?.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        //No more for load
        if (goblinsResult.dataResult.goblins.length == 0)
          return {
            ...ret,
            sucesso: false
          };

        goblinsResult.dataResult.goblins.forEach(i => goblinsLocal.push(i));
        setGoblins(goblinsLocal);
        setCursorGob(goblinsResult.dataResult.cursorGob);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, list: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    listSpouseCandidates: async (tokenId: number, reset: boolean) => {
      if (gettingBreedList)
        return;

      gettingBreedList = true;
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, breedCandidates: true });
      let spouseCandidateLocal = spouseCandidates;
      let cursorGobBreedLocal = cursorGobBreed;
      if (reset) {
        spouseCandidateLocal = [];
        cursorGobBreedLocal = 0;
      }

      try {
        let goblinsResult = await GoblinFactory.GoblinBusiness.spouseCandidates(tokenId, cursorGobBreedLocal);
        setLoading({ ...loading, breedCandidates: false });
        gettingBreedList = false;
        if (!goblinsResult.dataResult || !goblinsResult.dataResult?.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        //No more for load
        if (goblinsResult.dataResult.goblins.length == 0)
          return {
            ...ret,
            sucesso: false
          };

        goblinsResult.dataResult.goblins.forEach(i => spouseCandidateLocal.push(i));
        setSpouseCandidates(spouseCandidateLocal);
        setCursorGobBreed(goblinsResult.dataResult.cursorGob);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, breedCandidates: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    myGoblin: async (tokenId: number) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, info: true });
      setGoblin(null);
      setGoblinFather(null);
      setGoblinMother(null);
      setBrothers({ goblins: null, page: 1, totalPages: 1 });
      setSons({ goblins: null, page: 1, totalPages: 1 });
      setGoblinSpouse(null);
      setGenesis(false);
      //setBreedCount(null);
      setSpouseCandidates([]);
      try {
        let goblinResult = await GoblinFactory.GoblinBusiness.myGoblin(tokenId);
        setLoading({ ...loading, info: false });
        if (!goblinResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }
        setGoblin(goblinResult.dataResult);
        if (!goblinResult.dataResult.idTokenFather || goblinResult.dataResult.idTokenFather == 0) {
          setGenesis(true);
        } else {
          getFather(goblinResult.dataResult.idTokenFather);
          getMother(goblinResult.dataResult.idTokenMother);
          getSons(goblinResult.dataResult.idToken, 1);
          getBrothers(goblinResult.dataResult.idToken, 1);
        }
        if (goblinResult.dataResult.idTokenSpouse) {
          if (goblinResult.dataResult.idTokenSpouse == 0) { }
          else {
            getSpouse(goblinResult.dataResult.idTokenSpouse);
          }
        }
        //getBreedCount(goblinResult.dataResult.idToken);

        //alert(goblinResult.dataResult.userAddress);
        //alert(AuthFactory.AuthBusiness.getSession().publicAddress.toLowerCase());
        if(AuthFactory.AuthBusiness.getSession() && goblinResult.dataResult.userAddress == AuthFactory.AuthBusiness.getSession().publicAddress.toLowerCase()) {
          //alert(JSON.stringify(goblinResult.dataResult));
          listCanFuse(goblinResult.dataResult.idToken);
        }
          
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, info: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    updateGoblinName: async (tokenId: number, name: string) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, updateName: true });
      try {
        let goblinResult = await GoblinFactory.GoblinBusiness.updateGoblinName(tokenId, name);
        setLoading({ ...loading, updateName: false });
        if (!goblinResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goblinResult.mensagem
          };
        }
        setGoblin({
          ...goblin,
          name: name
        });
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: goblinResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, updateName: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    rechargeGoblin: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, recharge: true });
      try {
        let buResult = await GoblinFactory.GoblinBusiness.rechargeGoblin(goblin.idToken);
        setLoading({ ...loading, recharge: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        setGoblin(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, recharge: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    transferGoblin: async (goblin: GoblinInfo, toAddress: string) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, transferGoblin: true });
      try {
        let goblinResult = await GoblinFactory.GoblinBusiness.transfer(goblin.idToken, toAddress);
        setLoading({ ...loading, transferGoblin: false });
        if (!goblinResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goblinResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: "Goblin transferred successful."
        };
      } catch (err) {
        setLoading({ ...loading, transferGoblin: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    listBrothers: (tokenId: number, page: number) => {
      getBrothers(tokenId, page);
    },
    listSons: (tokenId: number, page: number) => {
      getSons(tokenId, page);
    },
    lastGoblin: async () => {
      let ret: Promise<ProviderResultDetail<GoblinInfo>>;
      try {
        let goblinResult = await GoblinFactory.GoblinBusiness.lastGoblin();
        if (!goblinResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goblinResult.mensagem,
            dataResult: null
          };
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: goblinResult.mensagem,
          dataResult: goblinResult.dataResult
        };
      } catch (err) {
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    listGoblinsCanFuse: async () => {
      return await listCanFuse(goblin.idToken);
    },
    equipGoblin: async (goblin: GoblinInfo, item: ItemInfo, part: BodyPartEnum) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, equipGoblin: true });
      try {
        let goblinResult = await GoblinFactory.GoblinBusiness.equipPart(goblin.id, goblin.idToken, item.key, part);
        setLoading({ ...loading, equipGoblin: false });
        if (!goblinResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goblinResult.mensagem
          };
        }
        
        setGoblin(goblinResult.dataResult);
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: goblinResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, equipGoblin: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    }
  };

  return (
    <GoblinContext.Provider value={goblinProviderValue}>
      {props.children}
    </GoblinContext.Provider>
  );
}
