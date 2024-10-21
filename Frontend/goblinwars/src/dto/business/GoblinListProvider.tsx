import { GoblinInfo } from "../domain/GoblinInfo";

export interface GoblinListProvider {
  goblins: GoblinInfo[],
  page: number,
  totalPages: number
}