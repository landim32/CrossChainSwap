import React, {useState} from 'react';
import InicioContext from './InicioContext';
import IInicioProvider from '../../dto/contexts/IInicioProvider';
import SelectedRoute from '../../dto/enum/SelectedRoute';
import ProviderResult from '../../dto/contexts/ProviderResult';
import AuthFactory from '../../business/factory/AuthFactory';
import { ConfigurationFactory } from '../../business/factory/ConfigurationFactory';

const package_json = require('../../../package.json');

export default function InicioProvider(props : any) {

  const [selectedFlow, setSelectedFlow] = useState<SelectedRoute>(SelectedRoute.StartFlow);

  const inicioProviderValue: IInicioProvider = {
    selectedFlow: selectedFlow,
    checkSession: () => {
      let ret: ProviderResult = null;
      let session = AuthFactory.AuthBusiness.getSession();
      if (session) {
        return {
          sucesso: true,
          ...ret
        };
      } else {
        return {
          sucesso: false,
          ...ret
        };
      }
    },
    setSelectedFlow: (flow: SelectedRoute) => {
      setSelectedFlow(flow);
    },
    checkNetwork: async () => {
      let ret: Promise<ProviderResult>;
      let bindResult = await AuthFactory.AuthBusiness.checkNetwork()
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
    checkVersion: async () => {
      let ret: Promise<ProviderResult>;
      let bindResult = await ConfigurationFactory.ConfigurationBusiness.getAppVersion();
      if (bindResult.sucesso) {
        if(bindResult.dataResult.version == package_json.version){
          return {
            ...ret,
            sucesso: true
          };
        } else {
          return {
            ...ret,
            sucesso: false
          };
        }
      }
      return {
        ...ret,
        sucesso: true
      };
    }
  };

  return (
    <InicioContext.Provider value={inicioProviderValue}>
      {props.children}
    </InicioContext.Provider>
  );
}
