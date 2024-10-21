import { AuthResult } from "../../dto/services/AuthResult";
import IHttpClient from "../../infra/interface/IHttpClient";


export interface IAuthService {
    init: (htppClient : IHttpClient) => void;
    getAuthHash: (
        publicAdddress: string,
        fromReferralCode: string
    ) => Promise<AuthResult>;
    checkUserRegister: (
        publicAdddress: string
    ) => Promise<AuthResult>;
    register: (
        publicAdddress: string,
        name: string,
        email: string,
        fromReferralCode: string
    ) => Promise<AuthResult>;
    updateUser: (
        publicAdddress: string,
        name: string,
        email: string,
        tokenAuth: string
    ) => Promise<AuthResult>;
}