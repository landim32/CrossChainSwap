import React, {useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import GLogListResult from '../../dto/services/GLogListResult';
import IGLogProvider from '../../dto/contexts/IGLogProvider';
import GLogFactory from '../../business/factory/GLogFactory';
import GLogContext from './GLogContext';

export default function GLogProvider(props : any) {

  const [glogList, setGLogList] = useState<GLogListResult>(null);
  const [loading, setLoading] = useState<boolean>(false);

  const auctionProviderValue: IGLogProvider = {

    list: async (page: number) => {
      let ret: Promise<ProviderResult>;
      setGLogList(null);
      setLoading(true);
      try {
        let buResult = await GLogFactory.GLogBusiness.list(page);
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setGLogList(buResult.dataResult);

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
    loading: loading,
    glogList: glogList
  };

  return (
    <GLogContext.Provider value={auctionProviderValue}>
      {props.children}
    </GLogContext.Provider>
  );
}
