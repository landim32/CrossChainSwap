import { UserQuestInfo } from "../domain/UserQuestInfo";

export interface CategoryJobsList {
  category: string;
  open: boolean;
  jobs: UserQuestInfo[];
}