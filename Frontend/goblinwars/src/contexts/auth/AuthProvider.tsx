import React, {useContext, useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult'; 
import IAuthProvider from '../../dto/contexts/IAuthProvider';
import AuthContext from './AuthContext';
import AuthFactory from '../../business/factory/AuthFactory';
import { AuthSession } from '../../dto/domain/AuthSession';
import InicioContext from '../inicio/InicioContext';
import SelectedRoute from '../../dto/enum/SelectedRoute';

export default function AuthProvider(props : any) {

  const [loading, setLoading] = useState(false);
  const [sessionInfo, setSessionInfo] = useState<AuthSession>(null);
  const inicioContext = useContext(InicioContext);

  const authProviderValue: IAuthProvider = {
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
    loading: loading,
    logout: function (): ProviderResult {
      try {
        AuthFactory.AuthBusiness.logOut();
        inicioContext.setSelectedFlow(SelectedRoute.StartFlow);
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
    loadUserSession: () => {
      let session = AuthFactory.AuthBusiness.getSession();
      setSessionInfo(session);
    },
    sessionInfo: sessionInfo,
    updateUser: async (name: string, email: string) => {
      let ret: Promise<ProviderResult>;
      setLoading(true);
      let bindResult = await AuthFactory.AuthBusiness.updateUser(name, email);
      authProviderValue.loadUserSession();
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
    }
  };

  return (
    <AuthContext.Provider value={authProviderValue}>
      {props.children}
    </AuthContext.Provider>
  );
}
