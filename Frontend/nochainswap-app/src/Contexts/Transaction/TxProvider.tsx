import React, { useContext, useState } from 'react';
import ProviderResult from '../../DTO/Contexts/ProviderResult';
import ITxProvider from '../../DTO/Contexts/ITxProvider';
import TxContext from './TxContext';
import TxInfo from '../../DTO/Domain/TxInfo';
import TxLogInfo from '../../DTO/Domain/TxLogInfo';
import TxFactory from '../../Business/Factory/TxFactory';

export default function TxProvider(props: any) {

  const [loadingTxInfo, setLoadingTxInfo] = useState<boolean>(false);
  const [loadingAllTxInfo, setLoadingAllTxInfo] = useState<boolean>(false);
  const [loadingTxLogs, setLoadingTxLogs] = useState<boolean>(false);
  const [txInfo, _setTxInfo] = useState<TxInfo>(null);
  const [allTxInfo, setAllTxInfo] = useState<TxInfo[]>(null);
  const [txLogs, setTxLogs] = useState<TxLogInfo[]>(null);

  const txProviderValue: ITxProvider = {
    loadingTxInfo: loadingTxInfo,
    loadingAllTxInfo: loadingAllTxInfo,
    loadingTxLogs: loadingTxLogs,
    txInfo: txInfo,
    allTxInfo: allTxInfo,
    txLogs: txLogs,
    setTxInfo: (txInfo: TxInfo) => {
      _setTxInfo(txInfo);
    },
    loadTx: async (txid: string) => {
      let ret: Promise<ProviderResult>;
      setLoadingTxInfo(true);
      try {
        let brt = await TxFactory.TxBusiness.getTx(txid);
        if (brt.sucesso) {
          setLoadingTxInfo(false);
          _setTxInfo(brt.dataResult);
          return {
            ...ret,
            sucesso: true,
            mensagemSucesso: "Transaction load"
          };
        }
        else {
          setLoadingTxInfo(false);
          return {
            ...ret,
            sucesso: false,
            mensagemErro: brt.mensagem
          };
        }
      }
      catch (err) {
        setLoadingTxInfo(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    loadListAllTx: async () => {
      let ret: Promise<ProviderResult>;
      setLoadingTxInfo(true);
      try {
        let brt = await TxFactory.TxBusiness.listAllTx();
        if (brt.sucesso) {
          setLoadingTxInfo(false);
          setAllTxInfo(brt.dataResult);
          return {
            ...ret,
            sucesso: true,
            mensagemSucesso: "Transactions load"
          };
        }
        else {
          setLoadingTxInfo(false);
          return {
            ...ret,
            sucesso: false,
            mensagemErro: brt.mensagem
          };
        }
      }
      catch (err) {
        setLoadingTxInfo(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    loadTxLogs: async (txid: number) => {
      let ret: Promise<ProviderResult>;
      setLoadingTxInfo(true);
      try {
        let brt = await TxFactory.TxBusiness.listTxLogs(txid);
        if (brt.sucesso) {
          setLoadingTxInfo(false);
          setTxLogs(brt.dataResult);
          return {
            ...ret,
            sucesso: true,
            mensagemSucesso: "Transaction logs load"
          };
        }
        else {
          setLoadingTxInfo(false);
          return {
            ...ret,
            sucesso: false,
            mensagemErro: brt.mensagem
          };
        }
      }
      catch (err) {
        setLoadingTxInfo(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    }
  };

  return (
    <TxContext.Provider value={txProviderValue}>
      {props.children}
    </TxContext.Provider>
  );
}
