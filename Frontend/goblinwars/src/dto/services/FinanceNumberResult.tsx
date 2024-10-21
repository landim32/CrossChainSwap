import StatusRequest from "./StatusRequest";

export default interface FinanceNumberResult extends StatusRequest {
  value: number;
}