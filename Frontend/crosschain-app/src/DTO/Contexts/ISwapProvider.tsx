import { CoinEnum } from "../Enum/CoinEnum";
import ProviderResult from "./ProviderResult";

interface ISwapProvider {
    loadingPoolInfo: boolean;
    loadingPrice: boolean;
    origCoin: CoinEnum;
    destCoin: CoinEnum;
    btcMinPrice: number;
    btcMaxPrice: number;
    stxMinPrice: number;
    stxMaxPrice: number;
    origAmount: number;
    destAmount: number;
    btcProportion: number;
    stxProportion: number;
    btcToStxText: string;
    stxToBtcText: string;
    btcPoolAddress: string;
    stxPoolAddress: string;
    btcPoolBalance: BigInt;
    stxPoolBalance: BigInt;
    getFormatedOrigAmount: () => string;
    getFormatedDestAmount: () => string;
    getFormatedOrigPrice: () => string;
    getFormatedDestPrice: () => string;
    getFormatedOrigBalance: () => string;
    getFormatedDestBalance: () => string;
    setOrigCoin: (value: CoinEnum) => void;
    setDestCoin: (value: CoinEnum) => void;
    setOrigAmount: (value: number) => void;
    getCoinText: () => string;
    loadPoolInfo: () => Promise<ProviderResult>;
    loadCurrentPrice: () => Promise<ProviderResult>;
    execute: () => Promise<ProviderResult>;
}

export default ISwapProvider;