import { BreedCostResult } from "../../dto/services/BreedCostResult";
import { GoblinResult } from "../../dto/services/GoblinResult";
import { GoblinTokenResult } from "../../dto/services/GoblinTokenResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import StatusRequest from "../../dto/services/StatusRequest";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IGoblinService } from "../interfaces/IGoblinService";

let _httpClient : IHttpClient;

const GoblinService : IGoblinService = {
    init: function (htppClient: IHttpClient): void {
        _httpClient = htppClient;
    },
    listbyuser: async (page: number, itemsPerPage: number, tokenAuth: string) => {
        let ret: ListGoblinResult;
        let url: string = "api/Goblin/listbyuser?page=" + page + "&itemsPerPage=" + itemsPerPage;
        let request = await _httpClient.doGetAuth<ListGoblinResult>(url, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    myGoblin: async (tokenId: number, tokenAuth: string) => {
        let ret: GoblinResult;
        let request = await _httpClient.doGetAuth<GoblinResult>("api/Goblin/goblin?idToken=" + tokenId, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    updateGoblinName: async (tokenId: number, name: string, tokenAuth: string) => {
        let ret: GoblinResult;
        let request = await _httpClient.doPutAuth<GoblinResult>("api/Goblin/updateGoblinName", {
            TokenId: tokenId,
            Name: name
        }, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    goblin: async (tokenId: number, tokenAuth: string) => {
        let ret: GoblinResult;
        let request = await _httpClient.doGetAuth<GoblinResult>("api/Goblin/goblin?idToken=" + tokenId, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    goblinBrothers: async (tokenId: number, page: number, tokenAuth: string) => {
        let ret: ListGoblinResult;
        let request = await _httpClient.doGetAuth<ListGoblinResult>("api/Goblin/goblinBrothers?idToken=" + tokenId + "&page=" + page, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    goblinSons: async (tokenId: number, page: number, tokenAuth: string) => {
        let ret: ListGoblinResult;
        let request = await _httpClient.doGetAuth<ListGoblinResult>("api/Goblin/goblinSons?idToken=" + tokenId + "&page=" + page, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    spouseCandidate: async (tokenId: number, cursorGob: number, tokenAuth: string) => {
        let ret: ListGoblinResult;
        let request = await _httpClient.doGetAuth<ListGoblinResult>("api/Goblin/spouseCandidates?idToken=" + tokenId + "&cursorGob=" + cursorGob, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    breedCost: async (parent1: number, parent2: number, tokenAuth: string) => {
        let ret: BreedCostResult;
        let request = await _httpClient.doGetAuth<BreedCostResult>("api/Goblin/breedCost?parent1=" + parent1 + "&parent2=" + parent2, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    listInfinityGoblins: async (cursorGob: number, tokenAuth: string) => {
        let ret: ListGoblinResult;
        let request = await _httpClient.doGetAuth<ListGoblinResult>("api/Goblin/listinfinity?cursorGob=" + cursorGob, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    lastGoblin: async (tokenAuth: string) => {
        let ret: GoblinResult;
        let request = await _httpClient.doGetAuth<GoblinResult>("api/Goblin/lastGoblin", tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    rechargeGoblin: async (tokenId: number, tokenAuth: string) => {
        let ret: GoblinResult;
        let request = await _httpClient.doPostAuth<GoblinResult>("api/Goblin/recharge", {
            TokenId: tokenId
        }, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    goblinsCanFuse: async (tokenId: number, tokenAuth: string) => {
        let ret: ListGoblinResult;
        let request = await _httpClient.doGetAuth<ListGoblinResult>("api/Goblin/goblinscanfuse?idToken=" + tokenId, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    /*
    refreshNftWallet: async (tokens: number[], tokenAuth: string) => {
        let request = await _httpClient.doPostAuth<any>("api/Goblin/refreshNftWallet", {
            Tokens: tokens
        }, tokenAuth);
        if (request.success) {
            return true;
        }
        else {
            return false;
        }
    },
    */
    fusionCost: async (tokenId: number, tokenAuth: string) => {
        let ret: BreedCostResult;
        let request = await _httpClient.doGetAuth<BreedCostResult>("api/Goblin/fusionCost?tokenId=" + tokenId, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    fusion: async (tokenId1: number, tokenId2: number, tokenAuth: string) => {
        let ret: GoblinTokenResult;
        let request = await _httpClient.doGetAuth<GoblinTokenResult>("api/Goblin/fusion?token1=" + tokenId1 + "&token2=" + tokenId2, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    breed: async (parent1: number, parent2: number, tokenAuth: string) => {
        let ret: GoblinTokenResult;
        let url: string = "api/Goblin/breed?token1=" + parent1 + "&token2=" + parent2;
        let request = await _httpClient.doGetAuth<GoblinTokenResult>(url, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    transfer: async (tokenId: number, userAddress: string, tokenAuth: string) => {
        let ret: StatusRequest;
        let url: string = "api/Goblin/transfer?tokenId=" + tokenId + "&address=" + userAddress;
        let request = await _httpClient.doGetAuth<StatusRequest>(url, tokenAuth);
        if (request.success) {
            ret = {
                sucesso: true,
                ...ret
            };
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    }
}

export { GoblinService }