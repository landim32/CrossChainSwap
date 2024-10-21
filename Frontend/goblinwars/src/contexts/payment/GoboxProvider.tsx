import GoboxContext from './GoboxContext';
import IGoboxProvider from '../../dto/contexts/IGoboxProvider';
import GoboxFactory from '../../business/factory/GoboxFactory';
import ProviderResultDetail from '../../dto/contexts/ProviderResultDetail';
import ProviderResult from '../../dto/contexts/ProviderResult';
import { useState } from 'react';
import { GoboxInfo } from '../../dto/domain/GoboxInfo';
import { ItemInfo } from '../../dto/domain/ItemInfo';

export default function GoboxProvider(props : any) {

  const GOBOX_COMMON: number = 1;
  const GOBOX_UNCOMMON: number = 2;
  const GOBOX_RARE: number = 3;
  const ITEMBOX_COMMON: number = 4;
  const ITEMBOX_UNCOMMON: number = 5;
  const ITEMBOX_RARE: number = 6;
  const ITEMBOX_EPIC: number = 7;
  const ITEMBOX_LEGENDARY: number = 8;

  const [goboxList, setGoboxList] = useState<GoboxInfo[]>(null);
  const [goboxCommon, setGoboxCommon] = useState<GoboxInfo>(null);
  const [goboxUncommon, setGoboxUncommon] = useState<GoboxInfo>(null);
  const [goboxRare, setGoboxRare] = useState<GoboxInfo>(null);
  const [itemBoxCommon, setItemBoxCommon] = useState<GoboxInfo>(null);
  const [itemBoxUncommon, setItemBoxUncommon] = useState<GoboxInfo>(null);
  const [itemBoxRare, setItemBoxRare] = useState<GoboxInfo>(null);
  const [itemBoxEpic, setItemBoxEpic] = useState<GoboxInfo>(null);
  const [itemBoxLegendary, setItemBoxLegendary] = useState<GoboxInfo>(null);
  const [commonAmount, setGoboxCommonAmount] = useState<number>(1);
  const [uncommonAmount, setGoboxUncommonAmount] = useState<number>(1);
  const [rareAmount, setGoboxRareAmount] = useState<number>(1);
  const [loading, setLoading] = useState(false); 

  const goboxProviderValue: IGoboxProvider = {
    list: async () => {
      let ret: Promise<ProviderResult>;
      try {
        setLoading(true);
        let goboxResult = await GoboxFactory.GoboxBusiness.list();
        setLoading(false);
        if (!goboxResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goboxResult.mensagem
          };
        }
        setGoboxList(goboxResult.dataResult);
        goboxResult.dataResult.forEach((item) => {
          if (item.boxtype == GOBOX_COMMON) {
            setGoboxCommon(item);
          }
          else if (item.boxtype == GOBOX_UNCOMMON) {
            setGoboxUncommon(item);
          }
          else if (item.boxtype == GOBOX_RARE) {
            setGoboxRare(item);
          }
          else if (item.boxtype == ITEMBOX_COMMON) {
            setItemBoxCommon(item);
          }
          else if (item.boxtype == ITEMBOX_UNCOMMON) {
            setItemBoxUncommon(item);
          }
          else if (item.boxtype == ITEMBOX_RARE) {
            setItemBoxRare(item);
          }
          else if (item.boxtype == ITEMBOX_EPIC) {
            setItemBoxEpic(item);
          }
          else if (item.boxtype == ITEMBOX_LEGENDARY) {
            setItemBoxLegendary(item);
          }
        });
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    listMyBox: async () => {
      let ret: Promise<ProviderResult>;
      try {
        setLoading(true);
        let goboxResult = await GoboxFactory.GoboxBusiness.listMyBox();
        setLoading(false);
        if (!goboxResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goboxResult.mensagem
          };
        }
        setGoboxList(goboxResult.dataResult);
        goboxResult.dataResult.forEach((item) => {
          if (item.boxtype == GOBOX_COMMON) {
            setGoboxCommon(item);
          }
          else if (item.boxtype == GOBOX_UNCOMMON) {
            setGoboxUncommon(item);
          }
          else if (item.boxtype == GOBOX_RARE) {
            setGoboxRare(item);
          }
          else if (item.boxtype == ITEMBOX_COMMON) {
            setItemBoxCommon(item);
          }
          else if (item.boxtype == ITEMBOX_UNCOMMON) {
            setItemBoxUncommon(item);
          }
          else if (item.boxtype == ITEMBOX_RARE) {
            setItemBoxRare(item);
          }
          else if (item.boxtype == ITEMBOX_EPIC) {
            setItemBoxEpic(item);
          }
          else if (item.boxtype == ITEMBOX_LEGENDARY) {
            setItemBoxLegendary(item);
          }
        });
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    buyToken: async (box: number, amount: number) => {
      let ret: Promise<ProviderResult>;
      try {
        setLoading(true);
        let goboxResult = await GoboxFactory.GoboxBusiness.buybox(box, amount);
        setLoading(false);
        if (!goboxResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goboxResult.mensagem
          };
        }
        return {
          ...ret,
          mensagemSucesso: 'Gobox buyed with success.',
          sucesso: true
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    openBox: async (box: number) => {
      let ret: Promise<ProviderResultDetail<number>>;
      try {
        setLoading(true);
        let goboxResult = await GoboxFactory.GoboxBusiness.openbox(box);
        setLoading(false);
        if (!goboxResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goboxResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true,
          dataResult: goboxResult.dataResult,
          mensagemSucesso: "Gobox opened successfully."
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    openItemBox: async (box: number) => {
      let ret: Promise<ProviderResultDetail<ItemInfo[]>>;
      try {
        setLoading(true);
        let goboxResult = await GoboxFactory.GoboxBusiness.openitembox(box);
        setLoading(false);
        if (!goboxResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goboxResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true,
          dataResult: goboxResult.dataResult,
          mensagemSucesso: "Item Box opened successfully."
        };
      } catch (err) {
        setLoading(false);
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    setCommonAmount: (value: number) => {
      setGoboxCommonAmount(value);
    },
    setUncommonAmount: (value: number) => {
      setGoboxUncommonAmount(value);
    },
    setRareAmount: (value: number) => {
      setGoboxRareAmount(value);
    },
    COMMON_ID: 1,
    UNCOMMON_ID: 2,
    RARE_ID: 3,
    ITEM_COMMON_ID: 4,
    ITEM_UNCOMMON_ID: 5,
    ITEM_RARE_ID: 6,
    ITEM_EPIC_ID: 7,
    ITEM_LEGENDARY_ID: 8,
    loading: loading,
    goboxes: goboxList,
    goboxCommon: goboxCommon,
    goboxUncommon: goboxUncommon,
    goboxRare: goboxRare,
    itemBoxCommon: itemBoxCommon,
    itemBoxUncommon: itemBoxUncommon,
    itemBoxRare: itemBoxRare,
    itemBoxEpic: itemBoxEpic,
    itemBoxLegendary: itemBoxLegendary,
    commonAmount: commonAmount,
    uncommonAmount: uncommonAmount,
    rareAmount: rareAmount,
  };

  return (
    <GoboxContext.Provider value={goboxProviderValue}>
      {props.children}
    </GoboxContext.Provider>
  );
}
