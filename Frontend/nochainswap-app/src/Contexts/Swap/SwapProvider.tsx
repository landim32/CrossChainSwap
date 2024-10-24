import React, { useContext, useState } from 'react';
import ProviderResult from '../../DTO/Contexts/ProviderResult';
import SwapContext from './SwapContext';
import ISwapProvider from '../../DTO/Contexts/ISwapProvider';
import PoolFactory from '../../Business/Factory/PoolFactory';
import { CoinEnum } from '../../DTO/Enum/CoinEnum';
import PriceFactory from '../../Business/Factory/PriceFactory';
import TxFactory from '../../Business/Factory/TxFactory';
import TxParamInfo from '../../DTO/Domain/TxParamInfo';
import AuthFactory from '../../Business/Factory/AuthFactory';
import { openSTXTransfer } from '@stacks/connect';
import { AnchorMode, PostConditionMode } from '@stacks/transactions';

export default function SwapProvider(props: any) {

    const [loadingPoolInfo, setLoadingPoolInfo] = useState(false);
    const [loadingPrice, setLoadingPrice] = useState<boolean>(false);
    const [loadingExecute, setLoadingExecute] = useState<boolean>(false);
    const [origCoin, _setOrigCoin] = useState<CoinEnum>(CoinEnum.Bitcoin);
    const [destCoin, _setDestCoin] = useState<CoinEnum>(CoinEnum.Stacks);
    const [btcMinPrice, setBtcMinPrice] = useState<number>(0);
    const [btcMaxPrice, setBtcMaxPrice] = useState<number>(0);
    const [stxMinPrice, setStxMinPrice] = useState<number>(0);
    const [stxMaxPrice, setStxMaxPrice] = useState<number>(0);
    const [origAmount, _setOrigAmount] = useState<number>(0);
    const [destAmount, _setDestAmount] = useState<number>(0);
    const [btcProportion, setBtcProportion] = useState<number>(0);
    const [stxProportion, setStxProportion] = useState<number>(0);
    const [btcToStxText, setBtcToStxText] = useState<string>(null);
    const [stxToBtcText, setStxToBtcText] = useState<string>(null);
    const [btcPoolAddress, setBtcPoolAddress] = useState<string>(null);
    const [stxPoolAddress, setStxPoolAddress] = useState<string>(null);
    const [btcPoolBalance, setBtcPoolBalance] = useState<BigInt>(BigInt(0));
    const [stxPoolBalance, setStxPoolBalance] = useState<BigInt>(BigInt(0));
    const [currentTxId, setCurrentTxId] = useState<string>(null);

    const swapProviderValue: ISwapProvider = {
        loadingPoolInfo: loadingPoolInfo,
        loadingPrice: loadingPrice,
        origCoin: origCoin,
        destCoin: destCoin,
        btcMinPrice: btcMinPrice,
        btcMaxPrice: btcMaxPrice,
        stxMinPrice: stxMinPrice,
        stxMaxPrice: stxMaxPrice,
        origAmount: origAmount,
        destAmount: destAmount,
        btcProportion: btcProportion,
        stxProportion: stxProportion,
        btcToStxText: btcToStxText,
        stxToBtcText: stxToBtcText,
        btcPoolAddress: btcPoolAddress,
        stxPoolAddress: stxPoolAddress,
        btcPoolBalance: btcPoolBalance,
        stxPoolBalance: stxPoolBalance,
        currentTxId: currentTxId,
        getFormatedOrigAmount: () => {
            if (origAmount) {
                if (origCoin == CoinEnum.Bitcoin) {
                    return Number(origAmount).toFixed(5).toString() + " BTC";
                }
                else {
                    return Number(origAmount).toFixed(5).toString() + " STX";
                }
            }
            return "~";
        },
        getFormatedDestAmount: () => {
            if (destAmount) {
                if (destCoin == CoinEnum.Bitcoin) {
                    return Number(destAmount).toFixed(5).toString() + " BTC";
                }
                else {
                    return Number(destAmount).toFixed(5).toString() + " STX";
                }
            }
            return "~";
        },
        setOrigCoin: (value: CoinEnum) => {
            _setOrigCoin(value);
            if (value == CoinEnum.Bitcoin) {
                if (destCoin != CoinEnum.Stacks) {
                    _setDestCoin(CoinEnum.Stacks);
                    let amount = origAmount;
                    _setOrigAmount(destAmount);
                    _setDestAmount(amount);
                }
            }
            else {
                if (destCoin != CoinEnum.Bitcoin) {
                    _setDestCoin(CoinEnum.Bitcoin);
                    let amount = origAmount;
                    _setOrigAmount(destAmount);
                    _setDestAmount(amount);
                }
            }
        },
        setDestCoin: (value: CoinEnum) => {
            _setDestCoin(value);
            if (value == CoinEnum.Bitcoin) {
                if (origCoin != CoinEnum.Stacks) {
                    _setOrigCoin(CoinEnum.Stacks);
                    let amount = origAmount;
                    _setOrigAmount(destAmount);
                    _setDestAmount(amount);
                }
            }
            else {
                if (origCoin != CoinEnum.Bitcoin) {
                    _setOrigCoin(CoinEnum.Bitcoin);
                    let amount = origAmount;
                    _setOrigAmount(destAmount);
                    _setDestAmount(amount);
                }
            }
        },
        setOrigAmount: (value: number) => {
            _setOrigAmount(value);
            if (origCoin == CoinEnum.Bitcoin) {
                let price = btcProportion * value;
                _setDestAmount(parseFloat(price.toFixed(5)));
            }
            else {
                let price = stxProportion * value;
                _setDestAmount(parseFloat(price.toFixed(5)));
            }
        },
        getFormatedOrigPrice: () => {
            if (origCoin == CoinEnum.Bitcoin) {
                if (btcMinPrice) {
                    return btcMinPrice.toLocaleString('en-US', {
                        style: 'currency',
                        currency: 'USD',
                    });
                }
            }
            else {
                if (stxMinPrice) {
                    return stxMinPrice.toLocaleString('en-US', {
                        style: 'currency',
                        currency: 'USD',
                    });
                }
            }
            return "~";
        },
        getFormatedDestPrice: () => {
            if (destCoin == CoinEnum.Bitcoin) {
                if (btcMaxPrice) {
                    return btcMaxPrice.toLocaleString('en-US', {
                        style: 'currency',
                        currency: 'USD',
                    });
                }
            }
            else {
                if (stxMaxPrice) {
                    return stxMaxPrice.toLocaleString('en-US', {
                        style: 'currency',
                        currency: 'USD',
                    });
                }
            }
            return "~";
        },
        getFormatedOrigBalance: () => {
            if (origCoin == CoinEnum.Bitcoin) {
                if (btcPoolBalance) {
                    return (Number(btcPoolBalance) / 10000000).toFixed(5).toString() + " BTC";
                }
            }
            else {
                if (stxPoolBalance) {
                    return (Number(stxPoolBalance) / 10000000).toFixed(5).toString() + " STX";
                }
            }
            return "~";
        },
        getFormatedDestBalance: () => {
            if (destCoin == CoinEnum.Bitcoin) {
                if (btcPoolBalance) {
                    return (Number(btcPoolBalance) / 10000000).toFixed(5).toString() + " BTC";
                }
            }
            else {
                if (stxPoolBalance) {
                    return (Number(stxPoolBalance) / 10000000).toFixed(5).toString() + " STX";
                }
            }
            return "~";
        },
        getCoinText: () => {
            return (destCoin == CoinEnum.Bitcoin) ? btcToStxText : stxToBtcText;
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
            try {
                let retPrice = await PriceFactory.PriceBusiness.getCurrentPrice();
                setLoadingPrice(true);
                console.log("Price:", retPrice);
                if (retPrice.sucesso) {
                    setBtcMinPrice(retPrice.dataResult.btcBuyPrice);
                    setBtcMaxPrice(retPrice.dataResult.btcSellPrice);
                    setStxMinPrice(retPrice.dataResult.stxBuyPrice);
                    setStxMaxPrice(retPrice.dataResult.stxSellPrice);
                    setBtcProportion(retPrice.dataResult.btcProportion);
                    setStxProportion(retPrice.dataResult.stxProportion);
                    setBtcToStxText(retPrice.dataResult.btcToStxText);
                    setStxToBtcText(retPrice.dataResult.stxToBtcText);
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
        },
        execute: async (callback: any) => {
            let ret: Promise<ProviderResult>;
            setLoadingExecute(true);
            let retSession = await AuthFactory.AuthBusiness.getSession();
            if (!retSession.sucesso) {
                let retErro = {
                    ...ret,
                    sucesso: false,
                    mensagemErro: retSession.mensagem
                };
                setLoadingExecute(false);
                callback(retErro);
                return;
            }
            let userSession = retSession.dataResult;
            if (origCoin == CoinEnum.Bitcoin) {
                let amount = parseInt((origAmount * 100000000).toFixed(0));
                window.transferBitcoin(btcPoolAddress, amount, "testnet", (txid: string) => {
                    setCurrentTxId(txid);
                    let param: TxParamInfo = {
                        btcToStx: true,
                        btcAddress: userSession.btcAddress,
                        stxAddress: userSession.stxAddress,
                        btcTxid: txid,
                        stxTxid: null
                    }
                    TxFactory.TxBusiness.createTx(param).then((ret) => {
                        if (ret.sucesso) {
                            let retSuccess = {
                                ...ret,
                                sucesso: true,
                                mensagemSucesso: "Transaction started successfully"
                            };
                            setLoadingExecute(false);
                            callback(retSuccess);
                        }
                        else {
                            let retErro = {
                                ...ret,
                                sucesso: false,
                                mensagemErro: ret.mensagem
                            };
                            setLoadingExecute(false);
                            callback(retErro);
                        }
                    });
                });
            }
            else {
                // transaction in STX
                let amount = parseInt((origAmount * 1000000).toFixed(0));
                openSTXTransfer({
                    network: 'testnet', // which network to use; ('mainnet' or 'testnet')
                    anchorMode: AnchorMode.Any, // which type of block the tx should be mined in
                  
                    recipient: stxPoolAddress, // which address we are sending to
                    amount: BigInt(amount), // tokens, denominated in micro-STX
                  
                    onFinish: (response: any) => {
                      // WHEN user confirms pop-up
                      console.log(response.txid); // the response includes the txid of the transaction
                      setCurrentTxId(response.txid);
                      let param: TxParamInfo = {
                          btcToStx: false,
                          btcAddress: userSession.btcAddress,
                          stxAddress: userSession.stxAddress,
                          stxTxid: response.txid,
                          btcTxid: null
                      }
                      TxFactory.TxBusiness.createTx(param).then((ret) => {
                          if (ret.sucesso) {
                              let retSuccess = {
                                  ...ret,
                                  sucesso: true,
                                  mensagemSucesso: "Transaction started successfully"
                              };
                              setLoadingExecute(false);
                              callback(retSuccess);
                          }
                          else {
                              let retErro = {
                                  ...ret,
                                  sucesso: false,
                                  mensagemErro: ret.mensagem
                              };
                              setLoadingExecute(false);
                              callback(retErro);
                          }
                      });
                    },
                    onCancel: () => {
                      // WHEN user cancels/closes pop-up
                      console.log('User canceled');
                    },
                });
            }
            return ret;
        }
    };

    return (
        <SwapContext.Provider value={swapProviderValue}>
            {props.children}
        </SwapContext.Provider>
    );
}
