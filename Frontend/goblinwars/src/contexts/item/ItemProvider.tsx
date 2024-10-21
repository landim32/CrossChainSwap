import React, {useContext, useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import ItemContext from './ItemContext';
import IItemProvider from '../../dto/contexts/IItemProvider';
import { UserItemInfo } from '../../dto/domain/UserItemInfo';
import { LoadingItem } from '../../dto/business/LoadingItem';
import ItemFactory from '../../business/factory/ItemFactory';
import ProviderResultDetail from '../../dto/contexts/ProviderResultDetail';
import { CraftInfo } from '../../dto/domain/CraftInfo';

export default function ItemProvider(props : any) {

  const [destroyItems, setDestroyItems] = useState<UserItemInfo[]>([]);
  const [destroyGobi, setDestroyGobi] = useState<number>(0);
  const [destroyGold, setDestroyGold] = useState<number>(0);

  const [itens, setItens] = useState<UserItemInfo[]>([]);
  const [itemDetail, setItemDetail] = useState<UserItemInfo>(null);
  const [craftDetail, setCraftDetail] = useState<CraftInfo>(null);
  const [loading, setLoading] = useState<LoadingItem>({
    detail: false,
    list: false,
    openItem: false,
    sell: false,
    sellAllTrash: false,
    craftDeatil: false
  });

  const itemProviderValue: IItemProvider = {
    list: async () => {
      let ret: Promise<ProviderResult>;
      setItens([]);
      setItemDetail(null);
      setLoading({ ...loading, list: true });
      try {
        let itemResult = await ItemFactory.ItemBusiness.list();
        setLoading({ ...loading, list: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        setItens(itemResult.dataResult);
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, list: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    getbykey: async (key: number) => {
      let ret: Promise<ProviderResult>;
      setItemDetail(null);
      setLoading({ ...loading, detail: true });
      try {
        let itemResult = await ItemFactory.ItemBusiness.getbykey(key);
        setLoading({ ...loading, detail: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        setItemDetail(itemResult.dataResult);
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, detail: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    getcraftinfo: async (key: number) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, craftDeatil: true });
      setCraftDetail(null);
      try {
        let itemResult = await ItemFactory.ItemBusiness.getcraftinfo(key);
        setLoading({ ...loading, craftDeatil: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }

        setCraftDetail(itemResult.dataResult);

        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, craftDeatil: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    sell: async (key: number, qtde: number) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, sell: true });
      try {
        let itemResult = await ItemFactory.ItemBusiness.sell(key, qtde);
        setLoading({ ...loading, sell: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, sell: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    move: async (idItem: number, x: number, y: number) => {
      let ret: Promise<ProviderResult>;
      var auxArr = itens.map((item) => {
        if (item.id == idItem) {
          item.posX = x;
          item.posY = y;
          return item;
        }
        return item;
      });
      setItens(auxArr);
      await ItemFactory.ItemBusiness.move(idItem, x, y);
      return ret;
    },
    canDrop: (idItem: number, x: number, y: number) => {
      var aux = itens.find((item) => {
        if (item.posX == x && item.posY == y)
          return item;
      });
      if (aux)
        return false;
      return true;
    },
    destroyitem: async (idItem: number, qtde: number) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, openItem: true });
      try {
        let itemResult = await ItemFactory.ItemBusiness.destroyitem(idItem, qtde);
        setLoading({ ...loading, openItem: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        setDestroyGobi(itemResult.dataResult.gobi);
        setDestroyGold(itemResult.dataResult.gold);
        setDestroyItems(itemResult.dataResult.items);
        return {
          ...ret,
          sucesso: true,
          dataResult: itemResult.dataResult,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, openItem: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    sellalltrash: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, sellAllTrash: true });
      try {
        let itemResult = await ItemFactory.ItemBusiness.sellalltrash();
        setLoading({ ...loading, sellAllTrash: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, sellAllTrash: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    destroyItems: destroyItems,
    destroyGobi: destroyGobi,
    destroyGold: destroyGold,
    itens: itens,
    itemDetail: itemDetail,
    loading: loading,
    craftDetail: craftDetail,
    setItemDetail: function (userItem: UserItemInfo): void {
      setItemDetail(userItem);
    }
  };

  return (
    <ItemContext.Provider value={itemProviderValue}>
      {props.children}
    </ItemContext.Provider>
  );
}
