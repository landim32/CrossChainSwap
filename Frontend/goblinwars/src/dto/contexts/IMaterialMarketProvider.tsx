import { LoadingMaterialMarket } from "../business/LoadingMaterialMarket";
import { MaterialMarketBalanceInfo } from "../domain/MaterialMarketBalanceInfo";
import ProviderResult from "./ProviderResult";

export interface IMaterialMarketProvider {
  refresh: () => void;
  balance: (materialkey: number) => Promise<ProviderResult>;
  swapMaterialPerGold: () => Promise<ProviderResult>;
  swapGoldPerMaterial: () => Promise<ProviderResult>;
  setQtdeMaterial: (value: string, isSell: boolean) => void;
  materialkey: number;
  materialBalance: MaterialMarketBalanceInfo;
  swapRateBuy: number;
  swapRateSell: number;
  qtdeMaterial: string;
  priceForBuy: number;
  priceForSell: number;
  buyTax: number;
  sellTax: number;
  priceForBuyBase: number;
  priceForSellBase: number;
  loading: LoadingMaterialMarket;
}