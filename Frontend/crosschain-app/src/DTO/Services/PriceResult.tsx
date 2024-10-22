import StatusRequest from "./StatusRequest";

export interface PriceResult extends StatusRequest {
    spread: number,
    btcBuyPrice: number,
    btcSellPrice: number,
    stxBuyPrice: number,
    stxSellPrice: number,
    btcProportion: number,
    stxProportion: number,
    btcToStxText: string,
    stxToBtcText: string,
    original: {
        id: string,
        convertCurrency: string,
        lastUpdated: string,
        marketCapConvert: number,
        marketCapUsd: number,
        name: string,
        percentChange1h: number,
        percentChange24h: number,
        percentChange7d: number,
        price: number,
        rank: string,
        symbol: string,
        volume24hUsd: number
    },
    destiny: {
        id: string,
        convertCurrency: string,
        lastUpdated: string,
        marketCapConvert: number,
        marketCapUsd: number,
        name: string,
        percentChange1h: number,
        percentChange24h: number,
        percentChange7d: number,
        price: number,
        rank: string,
        symbol: string,
        volume24hUsd: number
    }
}
