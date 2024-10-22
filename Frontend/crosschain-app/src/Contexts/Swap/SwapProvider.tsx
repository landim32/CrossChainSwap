import React, { useContext, useState } from 'react';
import ProviderResult from '../../DTO/Contexts/ProviderResult';
import SwapContext from './SwapContext';
import ISwapProvider from '../../DTO/Contexts/ISwapProvider';
import PoolFactory from '../../Business/Factory/PoolFactory';
import { CoinEnum } from '../../DTO/Enum/CoinEnum';
import PriceFactory from '../../Business/Factory/PriceFactory';

export default function SwapProvider(props: any) {

    const [loadingPoolInfo, setLoadingPoolInfo] = useState(false);
    const [loadingPrice, setLoadingPrice] = useState<boolean>(false);
    const [origCoin, _setOrigCoin] = useState<CoinEnum>(CoinEnum.Bitcoin);
    const [destCoin, setDestCoin] = useState<CoinEnum>(CoinEnum.Stacks);
    const [origPrice, setOrigPrice] = useState<number>(0);
    const [destPrice, setDestPrice] = useState<number>(0);
    const [origAmount, _setOrigAmount] = useState<number>(0);
    const [destAmout, setDestAmount] = useState<number>(0);
    const [btcPoolAddress, setBtcPoolAddress] = useState<string>(null);
    const [stxPoolAddress, setStxPoolAddress] = useState<string>(null);
    const [btcPoolBalance, setBtcPoolBalance] = useState<BigInt>(BigInt(0));
    const [stxPoolBalance, setStxPoolBalance] = useState<BigInt>(BigInt(0));

    const swapProviderValue: ISwapProvider = {
        loadingPoolInfo: loadingPoolInfo,
        loadingPrice: loadingPrice,
        origCoin: origCoin,
        destCoin: destCoin,
        origPrice: origPrice,
        destPrice: destPrice,
        origAmount: origAmount,
        destAmout: destAmout,
        btcPoolAddress: btcPoolAddress,
        stxPoolAddress: stxPoolAddress,
        btcPoolBalance: btcPoolBalance,
        stxPoolBalance: stxPoolBalance,
        setOrigCoin: (value: CoinEnum) => {
            _setOrigCoin(value);
        },
        setOrigAmount: (value: number) => {
            _setOrigAmount(value);
            if (value == CoinEnum.Bitcoin) {
                if (destCoin != CoinEnum.Stacks) {
                    setDestCoin(CoinEnum.Stacks);
                }
            }
            else {
                if (destCoin != CoinEnum.Bitcoin) {
                    setDestCoin(CoinEnum.Bitcoin);
                }
            }
        },
        getFormatedOrigPrice: () => {
            if (origPrice) {
                return origPrice.toLocaleString('en-US', {
                    style: 'currency',
                    currency: 'USD',
                });
            }
            return "~";
        },
        getFormatedDestPrice: () => {
            if (destPrice) {
                return destPrice.toLocaleString('en-US', {
                    style: 'currency',
                    currency: 'USD',
                });
            }
            return "~";
        },
        loadPoolInfo: async () => {
            let ret: Promise<ProviderResult>;
            setLoadingPoolInfo(false);
            try {
                let retPool = await PoolFactory.PoolBusiness.getPoolInfo();
                setLoadingPoolInfo(true);
                if (retPool.sucesso) {
                    setBtcPoolAddress(retPool.dataResult.btcAddress);
                    setStxPoolAddress(retPool.dataResult.stxAddress);
                    setBtcPoolBalance(retPool.dataResult.btcBalance);
                    setStxPoolBalance(retPool.dataResult.stxBalance);
                    return {
                        ...ret,
                        sucesso: true,
                        mensagemSucesso: retPool.mensagem
                    };
                }
                return {
                    ...ret,
                    sucesso: false,
                    mensagemErro: retPool.mensagem
                };
            } catch (err) {
                setLoadingPoolInfo(false);
                return {
                    ...ret,
                    sucesso: false,
                    mensagemErro: JSON.stringify(err)
                };
            }
        },
        loadCurrentPrice: async () => {
            let ret: Promise<ProviderResult>;
            setLoadingPrice(false);
            console.log("Tentando pegar o preço");
            try {
                let retPrice = await PriceFactory.PriceBusiness.getCurrentPrice();
                setLoadingPrice(true);
                console.log("Price:", retPrice);
                if (retPrice.sucesso) {
                    if (origCoin == CoinEnum.Bitcoin) {
                        setOrigPrice(retPrice.dataResult.btcBuyPrice);
                        setDestPrice(retPrice.dataResult.stxSellPrice);
                    }
                    else {
                        setOrigPrice(retPrice.dataResult.stxBuyPrice);
                        setDestPrice(retPrice.dataResult.btcSellPrice);
                    }
                    return {
                        ...ret,
                        sucesso: true,
                        mensagemSucesso: retPrice.mensagem
                    };
                }
                return {
                    ...ret,
                    sucesso: false,
                    mensagemErro: retPrice.mensagem
                };
            } catch (err) {
                setLoadingPrice(false);
                return {
                    ...ret,
                    sucesso: false,
                    mensagemErro: JSON.stringify(err)
                };
            }
        }
    };

    return (
        <SwapContext.Provider value={swapProviderValue}>
            {props.children}
        </SwapContext.Provider>
    );
}
