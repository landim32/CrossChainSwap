import { AuthSession } from "../Domain/AuthSession";
import StatusRequest from "./StatusRequest";

export interface PoolResult extends StatusRequest {
  btcAddress : string;
  stxAddress : string;
  btcBalance : BigInt;
  stxBalance : BigInt;
}