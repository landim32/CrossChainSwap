import React, {useContext, useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import IItemProvider from '../../dto/contexts/IItemProvider';
import { UserItemInfo } from '../../dto/domain/UserItemInfo';
import { LoadingItem } from '../../dto/business/LoadingItem';
import ItemFactory from '../../business/factory/ItemFactory';
import ProviderResultDetail from '../../dto/contexts/ProviderResultDetail';
import { CraftInfo } from '../../dto/domain/CraftInfo';
import { IGoldFinanceProvider } from '../../dto/contexts/IGoldFinanceProvider';
import { LoadingGoldFinance } from '../../dto/business/LoadingGoldFinance';
import GoldFinanceContext from './GoldFinanceContext';
import { GoldTransactionInfo } from '../../dto/domain/GoldTransactionInfo';
import { TradeBalanceInfo } from '../../dto/domain/TradeBalanceInfo';
import GoldFinanceFactory from '../../business/factory/GoldFinanceFactory';
import { GoldTransactionListResult } from '../../dto/services/GoldTransactionListResult';

export default function GoldFinanceProvider(props : any) {
  
  const [transactions, setTransactions] = useState<GoldTransactionListResult>(null);
  const [tradeBalance, setTradeBalance] = useState<TradeBalanceInfo>(null);
  const [swapRateGold, setSwapRateGold] = useState<number>(0.0);
  const [swapRateGobi, setSwapRateGobi] = useState<number>(0.0);
  const [gold, setGold] = useState<string>("");
  const [gobi, setGobi] = useState<string>("");
  const [isGobiToGold, setIsGobiToGold] = useState<boolean>(true);
  const [loading, setLoading] = useState<LoadingGoldFinance>({
    list: false,
    swap: false,
    balance: false,
  });

  const calculateSwapRateGold = (newGold: number, newGobi?: number) => {
    if(tradeBalance != null) {
      let totalGold = tradeBalance.totalgold;
      let totalGobi = tradeBalance.totalgobi;
      let rateGold = 0
      if(!newGobi) {
        rateGold = totalGobi / (parseFloat(totalGold.toString()) + parseFloat(newGold.toString()));
        setGobi((parseFloat(rateGold.toString()) * parseFloat(newGold.toString())).toFixed(4));
      } else {
        rateGold = (parseFloat(totalGobi.toString()) - parseFloat(newGobi.toString())) / parseFloat(totalGold.toString());
        setGold((parseFloat(newGobi.toString()) / rateGold).toFixed(4));
      }
      setSwapRateGold(rateGold);
    }
  }

  const calculateSwapRateGobi = (newGobi: number, newGold?: number) => {
    if(tradeBalance != null) {
      let totalGold = tradeBalance.totalgold;
      let totalGobi = tradeBalance.totalgobi;
      let rateGobi = 0.0;
      if(!newGold) {
        rateGobi = totalGold / (parseFloat(totalGobi.toString()) + parseFloat(newGobi.toString()));
        setGold((parseFloat(rateGobi.toString()) * parseFloat(newGobi.toString())).toFixed(4));
        setSwapRateGobi(rateGobi);
      } else {
        rateGobi = (parseFloat(totalGold.toString()) - parseFloat(newGold.toString())) / parseFloat(totalGobi.toString());
        setGobi((parseFloat(newGold.toString()) / rateGobi).toFixed(4));
      }
      setSwapRateGobi(rateGobi);
    }
  }

  const goldFinanceProviderValue: IGoldFinanceProvider = {
    list: async (page: number) => {
      let ret: Promise<ProviderResult>;
      setTransactions(null);
      setLoading({ ...loading, list: true });
      try {
        let result = await GoldFinanceFactory.GoldFinanceBusiness.list(page);
        setLoading({ ...loading, list: false });
        if (!result.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: result.mensagem
          };
        }
        setTransactions(result.dataResult);
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: result.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, list: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    balance: async () => {
      let ret: Promise<ProviderResult>;
      setTradeBalance(null);
      setLoading({ ...loading, balance: true });
      try {
        let result = await GoldFinanceFactory.GoldFinanceBusiness.tradebalance();
        setLoading({ ...loading, balance: false });
        if (!result.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: result.mensagem
          };
        }

        setTradeBalance(result.dataResult);
        if(isGobiToGold) {
          if(parseFloat(gobi) > 0){
            setGobi(gobi);
            calculateSwapRateGobi(parseFloat(gobi), 0);
          }
        } else {
          if(parseFloat(gold) > 0){
            setGold(gold);
            calculateSwapRateGold(parseFloat(gold), 0);
          }
        }
        

        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: result.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, balance: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    swapGold: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, swap: true });
      try {
        let result = await GoldFinanceFactory.GoldFinanceBusiness.swapgold(parseFloat(gold));
        setLoading({ ...loading, swap: false });
        if (!result.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: result.mensagem
          };
        }

        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: result.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, swap: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    swapGobi: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, swap: true });
      try {
        let result = await GoldFinanceFactory.GoldFinanceBusiness.swapgobi(parseFloat(gobi));
        setLoading({ ...loading, swap: false });
        if (!result.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: result.mensagem
          };
        }
        
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: result.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, swap: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    setGold: (value: string) => {
      value.replace(',', '.');
      if(value == "") {
        setGold("");
        calculateSwapRateGold(0.0);
        return;
      }
      if(/^(^\d+\.\d*$)|(^\d+$)|(^\d*\.\d+$)|(^\d+\.\d+$)$/.test(value)){
        var auxValue = value;
        if(auxValue.toString()[auxValue.toString().length-1] == '.')
          auxValue = auxValue + '0';
        if(auxValue.toString()[0] == '.')
          auxValue = '0' + auxValue;
        if(parseFloat(auxValue) >= 0){
          setGold(value);
          if(isGobiToGold) {
            if(parseFloat(auxValue) < tradeBalance.totalgold){
              calculateSwapRateGobi(0, parseFloat(auxValue));
            }
            else {
              setGobi("");
            }
          } else {
            calculateSwapRateGold(parseFloat(auxValue), 0);
          }
        } else {
          setGold("");
          calculateSwapRateGold(0.0);
        }
      }
    },
    setGobi: (value: string) => {
      value.replace(',', '.');
      if(value == "") {
        setGobi("");
        calculateSwapRateGobi(0.0);
        return;
      }
      if(/^(^\d+\.\d*$)|(^\d+$)|(^\d*\.\d+$)|(^\d+\.\d+$)$/.test(value)){
        var auxValue = value;
        if(auxValue.toString()[auxValue.toString().length-1] == '.')
          auxValue = auxValue + '0';
        if(auxValue.toString()[0] == '.')
          auxValue = '0' + auxValue;
        if(parseFloat(auxValue) >= 0){
          setGobi(value);
          if(isGobiToGold) {
            calculateSwapRateGobi(parseFloat(auxValue), 0)
          } else {
            if(parseFloat(auxValue) < tradeBalance.totalgobi){
              calculateSwapRateGold(0, parseFloat(auxValue));
            }
            else {
              setGold("");
            }
          }
        } else {
          setGobi("");
          calculateSwapRateGobi(0.0);
        }
      }
    },
    setIsGobiToGold: () => {
      setIsGobiToGold(!isGobiToGold);
    },
    transactions: transactions,
    tradeBalance: tradeBalance,
    isGobiToGold: isGobiToGold,
    swapRateGold: swapRateGold,
    swapRateGobi: swapRateGobi,
    gold: gold,
    gobi: gobi,
    loading: loading
  };

  return (
    <GoldFinanceContext.Provider value={goldFinanceProviderValue}>
      {props.children}
    </GoldFinanceContext.Provider>
  );
}
