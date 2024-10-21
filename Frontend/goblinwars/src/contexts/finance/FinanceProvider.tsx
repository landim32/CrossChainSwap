import React, {useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import IFinanceProvider from '../../dto/contexts/IFinanceProvider';
import FinanceListResult from '../../dto/services/FinanceListResult';
import FinanceFactory from '../../business/factory/FinanceFactory';
import FinanceInfo from '../../dto/domain/FinanceInfo';
import DepositConfirmInfo from '../../dto/domain/DepositConfirmInfo';
import FinanceTransactionInfo from '../../dto/domain/FinanceTransactionInfo';
import FinanceContext from './FinanceContext';

export default function FinanceProvider(props : any) {

  const [financeList, setFinanceList] = useState<FinanceListResult>(null);
  const [finance, setFinance] = useState<FinanceInfo>(null);
  const [transaction, setTransaction] = useState<FinanceTransactionInfo>(null);
  const [curretFee, setCurrentFee] = useState<number>(0.0);
  const [loading, setLoading] = useState<boolean>(false);
  const [loadingCalculate, setLoadingCalculate] = useState<boolean>(false);
  const [loadingTransaction, setLoadingTransaction] = useState<boolean>(false);
  const [loadingActive, setLoadingActive] = useState<boolean>(false);
  const [loadingDeposit, setLoadingDeposit] = useState<boolean>(false);
  const [loadingWithdraw, setLoadingWithdraw] = useState<boolean>(false);

  const financeProviderValue: IFinanceProvider = {

    list: async (page: number) => {
      let ret: Promise<ProviderResult>;
      setFinanceList(null);
      setLoadingTransaction(true);
      try {
        let buResult = await FinanceFactory.FinanceBusiness.list(page);
        setLoadingTransaction(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setFinanceList(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoadingTransaction(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    getFinance: async () => {
      let ret: Promise<ProviderResult>;
      setFinance(null);
      setLoading(true);
      try {
        let buResult = await FinanceFactory.FinanceBusiness.getFinance();
        setLoading(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setFinance(buResult.dataResult);

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
    deposit: async (value: number) => {
      let ret: Promise<ProviderResult>;
      setLoadingDeposit(true);
      try {
        let buResult = await FinanceFactory.FinanceBusiness.deposit(value);
        setLoadingDeposit(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setTransaction(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoadingDeposit(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    calculateFee: async (value: number) => {
      let ret: Promise<ProviderResult>;
      setLoadingCalculate(true);
      try {
        let buResult = await FinanceFactory.FinanceBusiness.calculateFee(value);
        setLoadingCalculate(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setCurrentFee(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoadingCalculate(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    withdrawl: async (value: number) => {
      let ret: Promise<ProviderResult>;
      setLoadingWithdraw(true);
      try {
        let buResult = await FinanceFactory.FinanceBusiness.withdrawl(value);
        setLoadingWithdraw(false);
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setTransaction(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoadingWithdraw(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    transactions: financeList,
    finance: finance,
    currentTransaction: transaction,
    currentFee: curretFee,
    loading: loading,
    loadingCalculate: loadingCalculate,
    loadingTransaction: loadingTransaction,
    loadingActive: loadingActive,
    loadingDeposit: loadingDeposit,
    loadingWithdraw: loadingWithdraw
  };

  return (
    <FinanceContext.Provider value={financeProviderValue}>
      {props.children}
    </FinanceContext.Provider>
  );
}
