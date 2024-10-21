import React, {useContext, useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import DollarContext from './DollarContext';
import IDollarProvider from '../../dto/contexts/IDollarProvider';
import DollarFactory from '../../business/factory/DollarFactory';
import ProviderResultDetail from '../../dto/contexts/ProviderResultDetail';

export default function DollarProvider(props : any) {

  //const [dollarPrice, setDollarPrice] = useState(0.0);

  const dollarProviderValue: IDollarProvider = {
    getDollar: async () => {
      let ret: Promise<ProviderResultDetail<number>>;
      //setLoading({ ...loading, list: true });
      try {
        let dollarResult = await DollarFactory.DollarBusiness.getDollar();
        //setLoading({ ...loading, list: false });
        if (!dollarResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: dollarResult.mensagem
          };
        }
        //setItens(itemResult.dataResult);
        return {
          ...ret,
          sucesso: true,
          dataResult: dollarResult.dataResult
          //mensagemSucesso: dollarResult.mensagem
        };
      } catch (err) {
        //setLoading({ ...loading, list: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    }
  };

  return (
    <DollarContext.Provider value={dollarProviderValue}>
      {props.children}
    </DollarContext.Provider>
  );
}
