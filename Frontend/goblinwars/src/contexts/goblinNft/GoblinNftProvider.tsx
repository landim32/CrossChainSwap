import React, {useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import IGoblinNftProvider from '../../dto/contexts/IGoblinNftProvider';
import { GoblinInfo } from '../../dto/domain/GoblinInfo';
import GoblinNftFactory from '../../business/factory/GoblinNftFactory';
import GoblinNftContext from './GoblinNftContext';

export default function GoblinNftProvider(props : any) {

  const [goblinList, setGoblinList] = useState<GoblinInfo[]>(null);
  const [loadingList, setLoadingList] = useState<boolean>(false);
  const [loadingAction, setLoadingAction] = useState<boolean>(false);

  const goblinNftProviderValue: IGoblinNftProvider = {

    list: async () => {
      let ret: Promise<ProviderResult>;
      setGoblinList(null);
      setLoadingList(true);
      try {
        let buResult = await GoblinNftFactory.GoblinNftBusiness.list();
        setLoadingList(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setGoblinList(buResult.dataResult.goblins);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoadingList(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    mint: async (tokenId: number) => {
      let ret: Promise<ProviderResult>;
      setLoadingAction(true);
      try {
        let buResult = await GoblinNftFactory.GoblinNftBusiness.mint(tokenId);
        setLoadingAction(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: 'Goblin minted successfully!'
        };
      } catch (err: any) {
        setLoadingAction(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    claim: async (tokenId: number) => {
      let ret: Promise<ProviderResult>;
      setLoadingAction(true);
      try {
        let buResult = await GoblinNftFactory.GoblinNftBusiness.claim(tokenId);
        setLoadingAction(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: 'Goblin claimed successfully!'
        };
      } catch (err: any) {
        setLoadingAction(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    deposit: async (tokenId: number) => {
      let ret: Promise<ProviderResult>;
      setLoadingAction(true);
      try {
        let buResult = await GoblinNftFactory.GoblinNftBusiness.deposit(tokenId);
        setLoadingAction(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: 'Goblin deposited successfully!'
        };
      } catch (err: any) {
        setLoadingAction(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    goblins: goblinList,
    loadingList: loadingList,
    loadingAction: loadingAction

  };

  return (
    <GoblinNftContext.Provider value={goblinNftProviderValue}>
      {props.children}
    </GoblinNftContext.Provider>
  );
}
