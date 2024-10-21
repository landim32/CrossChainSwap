import { LoadingQuest } from "../business/LoadingQuest";
import { GoblinInfo } from "../domain/GoblinInfo";
import { QuestEstimateInfo } from "../domain/QuestEstimateInfo";
import { UserQuestGoblinInfo } from "../domain/UserQuestGoblinInfo";
import { UserQuestInfo } from "../domain/UserQuestInfo";
import ProviderResult from "./ProviderResult";

export interface IQuestProvider {
    list: () => Promise<ProviderResult>;
    listGoblins: (questId: number, reset: boolean) => Promise<ProviderResult>;
    getbyid: (idQuest: number) => Promise<ProviderResult>;
    getbykey: (keyQuest: number) => Promise<ProviderResult>;
    calculate: () => Promise<ProviderResult>;
    start: () => Promise<ProviderResult>;
    execute: () => Promise<ProviderResult>;
    claim: () => Promise<ProviderResult>;
    addGoblinQuest: (goblin: GoblinInfo) => void;
    removeGoblinQuest: (goblin: UserQuestGoblinInfo) => void;
    estimateQuest: QuestEstimateInfo;
    quests: UserQuestInfo[];
    questDetail: UserQuestInfo;
    goblins: GoblinInfo[];
    loading: LoadingQuest;
    cursorGob: number;
}