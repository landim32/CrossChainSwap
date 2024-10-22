import { CoinEnum } from "../Enum/CoinEnum";
import ProviderResult from "./ProviderResult";

interface ISwapProvider {
    loadingPoolInfo: boolean;
    loadingPrice: boolean;
    origCoin: CoinEnum;
    destCoin: CoinEnum;
    origPrice: number;
    destPrice: number;
    origAmount: number;
    destAmout: number;
    btcPoolAddress: string;
    stxPoolAddress: string;
    btcPoolBalance: BigInt;
    stxPoolBalance: BigInt;
    getFormatedOrigPrice: () => string;
    getFormatedDestPrice: () => string;
    setOrigCoin: (value: CoinEnum) => void;
    setOrigAmount: (value: number) => void;
    loadPoolInfo: () => Promise<ProviderResult>;
    loadCurrentPrice: () => Promise<ProviderResult>;
}

export default ISwapProvider;