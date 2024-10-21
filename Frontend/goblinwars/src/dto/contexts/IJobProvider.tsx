import { CategoryJobsList } from "../business/CategoryJobsList";
import { CategoryList } from "../business/CategoryList";
import { LoadingQuest } from "../business/LoadingQuest";
import { GoblinInfo } from "../domain/GoblinInfo";
import { QuestEstimateInfo } from "../domain/QuestEstimateInfo";
import { UserQuestGoblinInfo } from "../domain/UserQuestGoblinInfo";
import { UserQuestInfo } from "../domain/UserQuestInfo";
import ProviderResult from "./ProviderResult";

export interface IJobProvider {
    list: () => Promise<ProviderResult>;
    setOpenCategory: (category: string) => void;
    listactive: () => Promise<ProviderResult>;
    listGoblins: (questId: number, reset: boolean) => Promise<ProviderResult>;
    getbyid: (idQuest: number) => Promise<ProviderResult>;
    getbykey: (keyQuest: number) => Promise<ProviderResult>;
    calculate: () => Promise<ProviderResult>;
    start: () => Promise<ProviderResult>;
    claim: () => Promise<ProviderResult>;
    addGoblinQuest: (goblin: GoblinInfo) => void;
    removeGoblinQuest: (goblin: UserQuestGoblinInfo) => void;
    estimateQuest: QuestEstimateInfo;
    jobs: CategoryJobsList[];
    activejobs: UserQuestInfo[];
    questDetail: UserQuestInfo;
    goblins: GoblinInfo[];
    loading: LoadingQuest;
    cursorGob: number;
}