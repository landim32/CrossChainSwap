import { LoadingItem } from "../business/LoadingItem";
import { CraftInfo } from "../domain/CraftInfo";
import { UserItemInfo } from "../domain/UserItemInfo";
import ProviderResult from "./ProviderResult";
import ProviderResultDetail from "./ProviderResultDetail";


interface IItemProvider {
    list: () => Promise<ProviderResult>;
    getbykey: (idItem: number) => Promise<ProviderResult>;
    getcraftinfo: (
        key: number
    ) => Promise<ProviderResult>;
    sell: (
        key: number,
        qtde:number
    ) => Promise<ProviderResult>;
    move: (
        idItem: number,
        x: number,
        y: number
    ) => Promise<ProviderResult>;
    canDrop: (
        idItem: number,
        x: number,
        y: number
    ) => boolean;
    destroyitem: (idItem: number, qtde:number) => Promise<ProviderResult>;
    sellalltrash: () => Promise<ProviderResult>;
    setItemDetail: (userItem: UserItemInfo) => void;
    destroyItems: UserItemInfo[];
    destroyGobi: number;
    destroyGold: number;
    itens: UserItemInfo[];
    itemDetail: UserItemInfo;
    craftDetail: CraftInfo;
    loading: LoadingItem;
}

export default IItemProvider;