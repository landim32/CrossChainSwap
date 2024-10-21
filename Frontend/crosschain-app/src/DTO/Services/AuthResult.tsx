import { AuthSession } from "../Domain/AuthSession";
import StatusRequest from "./StatusRequest";

export interface AuthResult extends StatusRequest {
  user? : AuthSession;
}