import React, {useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import AuctionContext from './AuctionContext';
import IAuctionProvider from '../../dto/contexts/IAuctionProvider';
import AuctionInfo from '../../dto/domain/AuctionInfo';
import AuctionFilterInfo from '../../dto/domain/AuctionFilterInfo';
import AuctionInsertInfo from '../../dto/domain/AuctionInsertInfo';
import AuctionFactory from '../../business/factory/AuctionFactory';
import { AuctionListResult } from '../../dto/services/AuctionListResult';
import FinanceFactory from '../../business/factory/FinanceFactory';
import AuctionEquipmentFilterInfo from '../../dto/domain/AuctionEquipmentFilterInfo';

export default function AuctionProvider(props : any) {

  const [myAuction, setAuction] = useState<AuctionInfo>(null);
  const [filter, setFilter] = useState<AuctionFilterInfo>({
    rarity: 0,
    page: 1
  });
  const [filterEquipment, setFilterEquipment] = useState<AuctionEquipmentFilterInfo>({
    equipmenttype: null,
    rarity: null,
    page: 1
  });
  const [goblinList, setGoblinList] = useState<AuctionListResult>(null);
  const [equipmentList, setEquipmentList] = useState<AuctionListResult>(null);
  const [auctionList, setAuctionList] = useState<AuctionListResult>(null);
  const [myAuctionList, setMyAuctionList] = useState<AuctionListResult>(null);
  const [sameEquipment, setSameEquipment] = useState<AuctionListResult>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [loadingAction, setLoadingAction] = useState<boolean>(false);

  const auctionProviderValue: IAuctionProvider = {

    searchGoblin: async (filter: AuctionFilterInfo) => {
      let ret: Promise<ProviderResult>;
      setGoblinList(null);
      setLoading(true);
      try {
        let buResult = await AuctionFactory.AuctionBusiness.searchGoblin(filter);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setFilter(filter);
        setGoblinList(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    searchEquipment: async (filter: AuctionEquipmentFilterInfo) => {
      let ret: Promise<ProviderResult>;
      setEquipmentList(null);
      setLoading(true);
      try {
        let buResult = await AuctionFactory.AuctionBusiness.searchEquipment(filter);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setFilterEquipment(filter);
        setEquipmentList(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listByAuction: async (auction: number, page: number) => {
      let ret: Promise<ProviderResult>;
      setAuctionList(null);
      setLoading(true);
      try {
        let buResult = await AuctionFactory.AuctionBusiness.listbyauction(auction, page);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setFilter(filter);
        setAuctionList(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listByUser: async (auction: number) => {
      let ret: Promise<ProviderResult>;
      setMyAuctionList(null);
      setLoading(true);
      try {
        let buResult = await AuctionFactory.AuctionBusiness.listbyuser(auction);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setFilter(filter);
        setMyAuctionList(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listsameequipment: async (itemkey: number) => {
      let ret: Promise<ProviderResult>;
      setSameEquipment(null);
      setLoading(true);
      try {
        let buResult = await AuctionFactory.AuctionBusiness.listsameequipment(itemkey);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setSameEquipment(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    getbytoken: async (tokenId: number) => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      try {
        let buResult = await AuctionFactory.AuctionBusiness.getbytoken(tokenId);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        //alert(JSON.stringify(buResult.dataResult));
        setAuction(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    getById: async (IdAuction: number) => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      try {
        let buResult = await AuctionFactory.AuctionBusiness.getbyid(IdAuction);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        //alert(JSON.stringify(buResult.dataResult));
        setAuction(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    insert: async (param: AuctionInsertInfo) => {
      let ret: Promise<ProviderResult>;
      setLoadingAction(true);
      try {

        let bResult = await AuctionFactory.AuctionBusiness.insert(param);
        if (bResult.sucesso) {
          setLoadingAction(false);
          return {
            ...ret,
            sucesso: true,
            mensagemSucesso: bResult.mensagem
          };
        }
        else {
          setLoadingAction(false);
          return {
            ...ret,
            sucesso: false,
            mensagemErro: bResult.mensagem
          };
        }
      } catch (err) {
        setLoadingAction(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    cancel: async (idAuction: number) => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      try {
        let bResult = await AuctionFactory.AuctionBusiness.cancel(idAuction);
        if (bResult.sucesso) {
          setLoadingAction(false);
          return {
            ...ret,
            sucesso: true,
            mensagemSucesso: bResult.mensagem
          };
        }
        else {
          setLoadingAction(false);
          return {
            ...ret,
            sucesso: false,
            mensagemErro: bResult.mensagem
          };
        }
      } catch (err) {
        setLoadingAction(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    buy: async (idAuction: number) => {
      let ret: Promise<ProviderResult>;
      setLoadingAction(true);
      try {
        let bResult = await AuctionFactory.AuctionBusiness.buy(idAuction)
        if (bResult.sucesso) {
          setLoadingAction(false);
          return {
            ...ret,
            sucesso: true,
            mensagemSucesso: bResult.mensagem
          };
        }
        setLoadingAction(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: bResult.mensagem
        };
      } catch (err) {
        setLoadingAction(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    setFilter: (filter: AuctionFilterInfo) => {
      setFilter(filter);
    },
    loading: loading,
    loadingAction: loadingAction,
    myAuction: myAuction,
    filter: filter,
    filterEquipment: filterEquipment,
    goblinList: goblinList,
    equipmentList: equipmentList,
    auctionList: auctionList,
    myAuctionList: myAuctionList,
    sameEquipment: sameEquipment
  };

  return (
    <AuctionContext.Provider value={auctionProviderValue}>
      {props.children}
    </AuctionContext.Provider>
  );
}
