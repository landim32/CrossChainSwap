import React, {useContext, useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import { IMaterialMarketProvider } from '../../dto/contexts/IMaterialMarketProvider';
import MaterialMarketContext from './MaterialMarketContext';
import { LoadingMaterialMarket } from '../../dto/business/LoadingMaterialMarket';
import { MaterialMarketBalanceInfo } from '../../dto/domain/MaterialMarketBalanceInfo';
import MaterialMarketFactory from '../../business/factory/MaterialMarketFactory';

export default function MaterialMarketProvider(props : any) {
  
  const [materialkey, setMaterialkey] = useState<number>(null);
  const [materialBalance, setMaterialBalance] = useState<MaterialMarketBalanceInfo>(null);
  const [swapRateBuy, setSwapRateBuy] = useState<number>(0.0);
  const [swapRateSell, setSwapRateSell] = useState<number>(0.0);
  const [qtdeMaterial, setQtdeMaterial] = useState<string>("");
  const [priceForBuy, setPriceForBuy] = useState<number>(0);
  const [priceForSell, setPriceForSell] = useState<number>(0);
  const [buyTax, setBuyTax] = useState<number>(0);
  const [sellTax, setSellTax] = useState<number>(0);
  const [priceForBuyBase, setPriceForBuyBase] = useState<number>(0);
  const [priceForSellBase, setPriceForSellBase] = useState<number>(0);
  const [loading, setLoading] = useState<LoadingMaterialMarket>({
    swap: false,
    materialbalance: false,
  });

  const calculateSwapRateBuy = (newqtde: number) => {
    if(materialBalance != null) {
      if(newqtde == 0){
        setPriceForBuyBase(0);
        setBuyTax(0);
        setPriceForBuy(0);
        setSwapRateBuy(0);
        return;
      }
      let totalGold = materialBalance.totalgold;
      let totalMaterial = materialBalance.totalmaterial;
      let rateGold = 0
      rateGold = parseFloat(totalGold.toString()) / (parseFloat(totalMaterial.toString()) - parseFloat(newqtde.toString()));
      let basePrice = newqtde * rateGold;
      let auxTax = (basePrice * 0.10);
      setPriceForBuyBase(basePrice);
      setBuyTax(auxTax);
      setPriceForBuy(basePrice + auxTax);
      setSwapRateBuy(rateGold);
    }
  }

  const calculateSwapRateSell = (newqtde: number) => {
    if(materialBalance != null) {
      if(newqtde == 0){
        setPriceForSellBase(0);
        setSellTax(0);
        setPriceForSell(0);
        setSwapRateSell(0);
        return;
      }
      let totalGold = materialBalance.totalgold;
      let totalMaterial = materialBalance.totalmaterial;
      let rateGold = 0
      rateGold = parseFloat(totalGold.toString()) / (parseFloat(totalMaterial.toString()) + parseFloat(newqtde.toString()));
      let basePrice = newqtde * rateGold;
      let auxTax = (basePrice * 0.10);
      setPriceForSellBase(basePrice);
      setSellTax(auxTax);
      setPriceForSell(basePrice - auxTax);
      setSwapRateSell(rateGold);
    }
  }

  const materialMarketProviderValue: IMaterialMarketProvider = {
    refresh: () => {
      setMaterialBalance(null);
      setQtdeMaterial("");
      calculateSwapRateBuy(0);
      calculateSwapRateSell(0);
    },
    balance: async (materialkey: number) => {
      let ret: Promise<ProviderResult>;
      setMaterialBalance(null);
      setMaterialkey(materialkey);
      setLoading({ ...loading, materialbalance: true });
      try {
        let result = await MaterialMarketFactory.MaterialMarketBusiness.marketbalance(materialkey);
        setLoading({ ...loading, materialbalance: false });
        if (!result.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: result.mensagem
          };
        }

        setMaterialBalance(result.dataResult);
        if (parseInt(qtdeMaterial) > 0) {
          calculateSwapRateBuy(parseInt(qtdeMaterial));
          calculateSwapRateSell(parseInt(qtdeMaterial));
        }


        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: result.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, materialbalance: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    swapMaterialPerGold: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, swap: true });
      try {
        let result = await MaterialMarketFactory.MaterialMarketBusiness.swapmaterialpergold(materialkey, parseInt(qtdeMaterial));
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
    swapGoldPerMaterial: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, swap: true });
      try {
        let result = await MaterialMarketFactory.MaterialMarketBusiness.swapgoldpermaterial(materialkey, parseInt(qtdeMaterial));
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
    setQtdeMaterial: (value: string, isSell: boolean) => {
      value.replace(',', '');
      value.replace('.', '');
      if (value == "") {
        setQtdeMaterial("");
        calculateSwapRateBuy(0);
        calculateSwapRateSell(0);
        return;
      }
      if (/^(\d)+$/.test(value)) {
        var auxValue = value;
        if (parseInt(auxValue) >= 0) {
          setQtdeMaterial(value);
          if (!isSell && parseInt(auxValue) > materialBalance.totalmaterial) {
            calculateSwapRateBuy(0);
            calculateSwapRateSell(0);
            return;
          }
          calculateSwapRateBuy(parseInt(auxValue));
          calculateSwapRateSell(parseInt(auxValue));
        } else {
          setQtdeMaterial("");
          calculateSwapRateBuy(0);
          calculateSwapRateSell(0);
        }
      }
    },
    materialkey: materialkey,
    materialBalance: materialBalance,
    swapRateBuy: swapRateBuy,
    swapRateSell: swapRateSell,
    qtdeMaterial: qtdeMaterial,
    priceForBuy: priceForBuy,
    priceForSell: priceForSell,
    loading: loading,
    buyTax: buyTax,
    sellTax: sellTax,
    priceForBuyBase: priceForBuyBase,
    priceForSellBase: priceForSellBase
  };

  return (
    <MaterialMarketContext.Provider value={materialMarketProviderValue}>
      {props.children}
    </MaterialMarketContext.Provider>
  );
}
