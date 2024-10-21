import { JobCategoryInfo } from "../domain/JobCategoryInfo";
import StatusRequest from "./StatusRequest";

export interface JobCategoryResult extends StatusRequest {
  categories: JobCategoryInfo[]
}