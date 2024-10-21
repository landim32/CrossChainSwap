import { CraftResult } from "../../dto/services/CraftResult";
import ItemDestroyResult from "../../dto/services/ItemDestroyResult";
import StatusRequest from "../../dto/services/StatusRequest";
import { UserItemListResult } from "../../dto/services/UserItemListResult";
import { UserItemResult } from "../../dto/services/UserItemResult";
import IHttpClient from "../../infra/interface/IHttpClient";


export interface IItemService {
    init: (htppClient : IHttpClient) => void;
    list: (
        tokenAuth: string
    ) => Promise<UserItemListResult>;
    getbykey: (
        itemKey: number,
        tokenAuth: string
    ) => Promise<UserItemResult>;
    getcraftinfo: (
        itemKey: number,
        tokenAuth: string
    ) => Promise<CraftResult>;
    sell: (
        key: number,
        qtde:number,
        tokenAuth: string
    ) => Promise<StatusRequest>;
    move: (
        idItem: number,
        x: number,
        y: number,
        tokenAuth: string
    ) => Promise<StatusRequest>;
    destroyitem: (idItem: number, qtde:number, tokenAuth: string) => Promise<ItemDestroyResult>;
    sellalltrash: (
        tokenAuth: string
    ) => Promise<StatusRequest>;
}