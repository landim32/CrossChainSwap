import { JobCategoryResult } from "../../dto/services/JobCategoryResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { QuestEstimateResult } from "../../dto/services/QuestEstimateResult";
import StatusRequest from "../../dto/services/StatusRequest";
import { UserQuestListResult } from "../../dto/services/UserQuestListResult";
import { UserQuestResult } from "../../dto/services/UserQuestResult";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IQuestService } from "../interfaces/IQuestService";

let _httpClient : IHttpClient;

const QuestService : IQuestService = {
    init: function (htppClient: IHttpClient): void {
        _httpClient = htppClient;
    },
    list: async (tokenAuth: string) => {
        let ret: UserQuestListResult;
        let request = await _httpClient.doGetAuth<UserQuestListResult>("api/Quest/list", tokenAuth);
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
    listjobs: async (tokenAuth: string) => {
        let ret: UserQuestListResult;
        let request = await _httpClient.doGetAuth<UserQuestListResult>("api/Quest/listjobs", tokenAuth);
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
    listjobscategories: async (tokenAuth: string) => {
        let ret: JobCategoryResult;
        let request = await _httpClient.doGetAuth<JobCategoryResult>("api/Quest/listjobscategories", tokenAuth);
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
    listactivejobs: async (tokenAuth: string) => {
        let ret: UserQuestListResult;
        let request = await _httpClient.doGetAuth<UserQuestListResult>("api/Quest/listactivejobs", tokenAuth);
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
    getbyid: async (idQuest: number, tokenAuth: string) => {
        let ret: UserQuestResult;
        let request = await _httpClient.doGetAuth<UserQuestResult>("api/Quest/getbyid?idQuest=" + idQuest, tokenAuth);
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
    getbykey: async (keyQuest: number, tokenAuth: string) => {
        let ret: UserQuestResult;
        let request = await _httpClient.doGetAuth<UserQuestResult>("api/Quest/getbykey?keyQuest=" + keyQuest, tokenAuth);
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
    calculate: async (idQuest: number, questKey: number, goblins: number[], tokenAuth: string) => {
        let ret: QuestEstimateResult;
        let request = await _httpClient.doPostAuth<QuestEstimateResult>("api/Quest/calculate", 
        {
            IdQuest: idQuest,
            QuestKey: questKey,
            Goblins: goblins
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
    start: async (idQuest: number, questKey: number, goblins: number[], tokenAuth: string) => {
        let ret: StatusRequest;
        let request = await _httpClient.doPostAuth<StatusRequest>("api/Quest/start", 
        {
            IdQuest: idQuest,
            QuestKey: questKey,
            Goblins: goblins
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
    execute: async (idQuest: number, goblins: number[], tokenAuth: string) => {
        let ret: UserQuestResult;
        let request = await _httpClient.doPostAuth<UserQuestResult>("api/Quest/execute", 
        {
            IdQuest: idQuest,
            Goblins: goblins
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
    claim: async (idQuest: number, tokenAuth: string) => {
        let ret: UserQuestResult;
        let request = await _httpClient.doGetAuth<UserQuestResult>("api/Quest/claim?idQuest=" + idQuest, tokenAuth);
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
    listGoblins: async (keyQuest: number, cursorGob: number, tokenAuth: string) => {
        let ret: ListGoblinResult;
        let request = await _httpClient.doGetAuth<ListGoblinResult>("api/Quest/listgoblins?keyQuest=" + keyQuest + "&cursorGob=" + cursorGob, tokenAuth);
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
    }
}

export { QuestService }