import React, {useContext, useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import IGoblinUserProvider from '../../dto/contexts/IGoblinUserProvider';
import GoblinUserContext from './GoblinUserContext';
import { BalanceInfo } from '../../dto/domain/BalanceInfo';
import GoblinUserFactory from '../../business/factory/GoblinUserFactory';
import GoblinFactory from '../../business/factory/GoblinFactory';

export default function GoblinUserProvider(props : any) {
  
  const [balance, setBalance] = useState<BalanceInfo>(null);
  const [loading, setLoading] = useState(false);
  const [buyGoblinLoading, setBuyGoblinLoading] = useState(false);

  const goblinUserProviderValue: IGoblinUserProvider = {
    loadBalance: async () => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      setBalance(null);
      try {
        let balanceResult = await GoblinUserFactory.GoblinUserBusiness.getBalance();
        setLoading(false);
        if (!balanceResult.sucesso) {
          return {
            ...ret,
            mensagemErro: balanceResult.mensagem,
            sucesso: false
          };
        }
        setBalance(balanceResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading(false);
        return {
          ...ret,
          mensagemErro: err.message,
          sucesso: false
        };
      }
    },
    balance: balance,
    loading: loading,
    buyGoblinLoading: buyGoblinLoading,
  };

  return (
    <GoblinUserContext.Provider value={goblinUserProviderValue}>
      {props.children}
    </GoblinUserContext.Provider>
  );
}
