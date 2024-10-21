import { AuthSession } from "../../dto/domain/AuthSession";
import { AuthResult } from "../../dto/services/AuthResult";
import IHttpClient from "../../infra/interface/IHttpClient";
import { IAuthService } from "../interfaces/IAuthService"; 

let _httpClient : IHttpClient;

const AuthService : IAuthService = {
    init: function (htppClient: IHttpClient): void {
        _httpClient = htppClient;
    },
    getAuthHash: async (publicAdddress: string, fromReferralCode: string) => {
        let ret: AuthResult;
        console.log(publicAdddress);
        let url = "api/Auth/" + publicAdddress;
        if (fromReferralCode && fromReferralCode.length > 0) {
            url += "/" + fromReferralCode;
        }
        let request = await _httpClient.doGet<AuthResult>(url, {});
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    checkUserRegister: async (publicAdddress: string) => {
        let ret: AuthResult;
        console.log(publicAdddress);
        let request = await _httpClient.doGet<AuthResult>("api/Auth/checkUserRegister/" + publicAdddress, {});
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    register: async (publicAdddress: string, name: string, email: string, fromReferralCode: string) => {
        let ret: AuthResult;
        console.log(publicAdddress);
        let request = await _httpClient.doPost<AuthResult>("api/Auth", { 
            PublicAddress : publicAdddress, 
            Name: name, 
            Email: email,
            FromReferralCode: fromReferralCode
        });
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    },
    updateUser: async (publicAdddress: string, name: string, email: string, tokenAuth: string) => {
        let ret: AuthResult;
        console.log(publicAdddress);
        let request = await _httpClient.doPutAuth<AuthResult>("api/Auth", { PublicAddress : publicAdddress, Name: name, Email: email }, tokenAuth);
        if (request.success) {
            return request.data;
        }
        else {
            ret = {
                mensagem: request.messageError,
                sucesso: false,
                ...ret
            };
        }
        return ret;
    }
}

    export { AuthService }