import { AuthResult } from "../../DTO/Services/AuthResult";
import IHttpClient from "../../Infra/Interface/IHttpClient";


export interface IAuthService {
    init: (httpClient : IHttpClient) => void;
    getAuthHash: (publicAdddress: string) => Promise<AuthResult>;
    checkUserRegister: (publicAdddress: string) => Promise<AuthResult>;
    register: (publicAdddress: string, stxAdddress: string) => Promise<AuthResult>;
}