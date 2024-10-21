import React, {useContext, useState} from 'react';
import ProviderResult from '../../DTO/Contexts/ProviderResult'; 
import IAuthProvider from '../../DTO/Contexts/IAuthProvider';
import AuthContext from './AuthContext';
import AuthFactory from '../../Business/Factory/AuthFactory';
import { AuthSession } from '../../DTO/Domain/AuthSession';
//import InicioContext from '../inicio/InicioContext';
//import SelectedRoute from '../../dto/enum/SelectedRoute';

export default function AuthProvider(props : any) {

  const [loading, setLoading] = useState(false);
  const [sessionInfo, setSessionInfo] = useState<AuthSession>(null);
  //const inicioContext = useContext(InicioContext);

  const authProviderValue: IAuthProvider = {
    /*
    bindMetaMaskWallet: async (name: string, email: string, fromReferralCode: string) => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      let bindResult = await AuthFactory.AuthBusiness.bindMetaMaskWallet(name, email, fromReferralCode);
      setLoading(false);
      if (!bindResult.sucesso) {
        return {
          ...ret,
          sucesso: false,
          mensagemErro: bindResult.mensagem
        };
      }
      return {
        ...ret,
        sucesso: true
      };
    },
    */
    loading: loading,
    login: (callback?: any) => {
      setLoading(true);
      //let session = await AuthFactory.AuthBusiness.getSession();
      //console.log("session:", session);
      AuthFactory.AuthBusiness.logIn(callback);
      setLoading(false);
    },
    logout: function (): ProviderResult {
      try {
        AuthFactory.AuthBusiness.logOut();
        setSessionInfo(null);
        //inicioContext.setSelectedFlow(SelectedRoute.StartFlow);
        return {
          sucesso: true,
          mensagemErro: "",
          mensagemSucesso: ""
        };
      } catch (err) {
        return {
          sucesso: false,
          mensagemErro: "Falha ao tenta executar o logout",
          mensagemSucesso: ""
        };
      }


    },
    checkUserRegister: async () => {
      setLoading(true);
      let bindResult = await AuthFactory.AuthBusiness.checkUserRegister();
      setLoading(false);
      return {
        sucesso: bindResult.dataResult,
        mensagemErro: bindResult.mensagem,
        mensagemSucesso: bindResult.mensagem
      };
    },
    loadUserSession: async () => {
      let session = await AuthFactory.AuthBusiness.getSession();
      //console.log("session:", session);
      if (session.sucesso) {
        console.log(session.dataResult);
        setSessionInfo(session.dataResult);
      }
    },
    sessionInfo: sessionInfo
  };

  return (
    <AuthContext.Provider value={authProviderValue}>
      {props.children}
    </AuthContext.Provider>
  );
}
