import { AuthResult } from "../../dto/services/AuthResult";
import { BreedCostResult } from "../../dto/services/BreedCostResult";
import { GoblinResult } from "../../dto/services/GoblinResult";
import { GoblinTokenResult } from "../../dto/services/GoblinTokenResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import StatusRequest from "../../dto/services/StatusRequest";
import { TransactionSaleResult } from "../../dto/services/TransactionSaleResult";
import IHttpClient from "../../infra/interface/IHttpClient";


export interface IGoblinService {
    init: (htppClient : IHttpClient) => void;
    listbyuser: (page: number, itemsPerPage: number, tokenAuth: string) => Promise<ListGoblinResult>;
    listInfinityGoblins: (cursorGob: number, tokenAuth: string) => Promise<ListGoblinResult>;
    myGoblin: (tokenId: number, tokenAuth: string) => Promise<GoblinResult>;
    rechargeGoblin: (tokenId: number, tokenAuth: string) => Promise<GoblinResult>;
    lastGoblin: (tokenAuth: string) => Promise<GoblinResult>;
    updateGoblinName: (tokenId: number, name: string, tokenAuth: string) => Promise<GoblinResult>;
    goblin: (tokenId: number, tokenAuth: string) => Promise<GoblinResult>;
    goblinBrothers: (tokenId: number, page: number, tokenAuth: string) => Promise<ListGoblinResult>;
    goblinsCanFuse: (tokenId: number, tokenAuth: string) => Promise<ListGoblinResult>;
    goblinSons: (tokenId: number, page: number, tokenAuth: string) => Promise<ListGoblinResult>;
    spouseCandidate: (tokenId: number, cursorGob: number, tokenAuth: string) => Promise<ListGoblinResult>;
    breedCost: (parent1: number, parent2: number, tokenAuth: string) => Promise<BreedCostResult>;
    //refreshNftWallet: (tokens: number[], tokenAuth: string) => Promise<boolean>;
    fusionCost: (tokenId: number, tokenAuth: string) => Promise<BreedCostResult>;
    fusion: (tokenId1: number, tokenId2: number, tokenAuth: string) => Promise<GoblinTokenResult>;
    breed: (parent1: number, parent2: number, tokenAuth: string) => Promise<GoblinTokenResult>;
    transfer: (tokenId: number, userAddress: string, tokenAuth: string) => Promise<StatusRequest>;
}