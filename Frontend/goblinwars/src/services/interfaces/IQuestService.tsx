import { JobCategoryResult } from "../../dto/services/JobCategoryResult";
import { ListGoblinResult } from "../../dto/services/ListGoblinResult";
import { QuestEstimateResult } from "../../dto/services/QuestEstimateResult";
import StatusRequest from "../../dto/services/StatusRequest";
import { UserQuestListResult } from "../../dto/services/UserQuestListResult";
import { UserQuestResult } from "../../dto/services/UserQuestResult";
import IHttpClient from "../../infra/interface/IHttpClient";

export interface IQuestService {
  init: (htppClient : IHttpClient) => void;
  list: (
    tokenAuth: string
  ) => Promise<UserQuestListResult>;
  listjobs: (
    tokenAuth: string
  ) => Promise<UserQuestListResult>;
  listjobscategories: (
    tokenAuth: string
  ) => Promise<JobCategoryResult>
  listactivejobs: (
    tokenAuth: string
  ) => Promise<UserQuestListResult>;
  getbyid: (
    idQuest: number,
    tokenAuth: string
  ) => Promise<UserQuestResult>;
  getbykey: (
    keyQuest: number,
    tokenAuth: string
  ) => Promise<UserQuestResult>;
  calculate: (
    idQuest: number,
    questKey: number,
    goblins: number[],
    tokenAuth: string
  ) => Promise<QuestEstimateResult>;
  start: (
    idQuest: number,
    questKey: number, 
    goblins: number[],
    tokenAuth: string
  ) => Promise<StatusRequest>;
  execute: (
    idQuest: number,
    goblins: number[],
    tokenAuth: string
  ) => Promise<UserQuestResult>;
  claim: (
    idQuest: number,
    tokenAuth: string
  ) => Promise<UserQuestResult>;
  listGoblins: (keyQuest: number, cursorGob: number, tokenAuth: string) => Promise<ListGoblinResult>;
}