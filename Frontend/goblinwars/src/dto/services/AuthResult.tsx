import { AuthSession } from "../domain/AuthSession";
import StatusRequest from "./StatusRequest";

export interface AuthResult extends StatusRequest {
  user? : AuthSession;
}