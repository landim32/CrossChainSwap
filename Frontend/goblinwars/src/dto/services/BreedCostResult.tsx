import StatusRequest from "./StatusRequest";

export interface BreedCostResult extends StatusRequest {
  breedCost: number;
  breedRarity: number;
}