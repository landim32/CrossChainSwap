import React, {useContext, useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import { GoblinInfo } from '../../dto/domain/GoblinInfo';
import GoblinFactory from '../../business/factory/GoblinFactory';
import IGoblinBreedProvider from '../../dto/contexts/IGoblinBreedProvider';
import GoblinBreedContext from './GoblinBreedContext';
import { LoadingBreed } from '../../dto/business/LoadingBreed';
import { RarityInfo } from '../../dto/domain/RarityInfo';
import GoblinContext from '../goblin/GoblinContext';
import ProviderResultDetail from '../../dto/contexts/ProviderResultDetail';
import FinanceFactory from '../../business/factory/FinanceFactory';

export default function GoblinBreedProvider(props : any) {
  const [goblin1, setGoblin1] = useState<GoblinInfo>(null);
  const [goblin2, setGoblin2] = useState<GoblinInfo>(null);
  const [breedCost, setBreedCost] = useState<number>(null);
  const [loading, setLoading] = useState<LoadingBreed>({
    breeding: false,
    infoG1: false,
    infoG2: false,
    breedCost: false,
  });
  const [rarity, setRarity] = useState<RarityInfo>({
    commonVisible: true,
    commonValue: '50.19%',
    uncommonVisible: true,
    uncommonValue: '32.15%',
    rareVisible: true,
    rareValue: '12.54%',
    epicVisible: true,
    epicValue: '4.31%',
    legendaryVisible: true,
    legendaryValue: '0.78%' 
  });

  const goblinBreedProviderValue: IGoblinBreedProvider = {
    goblin1: goblin1,
    goblin2: goblin2,
    breedCost: breedCost,
    loading: loading,
    rarity: rarity,
    getGoblin1: async (tokenId: number) => {
      let ret: Promise<ProviderResult>;
      setGoblin1(null);
      setLoading({ ...loading, infoG1: true });
      try {
        let goblinResult = await GoblinFactory.GoblinBusiness.myGoblin(tokenId);
        setLoading({ ...loading, infoG1: false });
        if (!goblinResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        setGoblin1(goblinResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, infoG1: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    getGoblin2: async (tokenId: number) => {
      let ret: Promise<ProviderResult>;
      setGoblin2(null);
      setLoading({ ...loading, infoG2: true });
      try {
        let goblinResult = await GoblinFactory.GoblinBusiness.myGoblin(tokenId);
        setLoading({ ...loading, infoG2: false });
        if (!goblinResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        setGoblin2(goblinResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, infoG2: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    breed: async (goblin1: GoblinInfo, goblin2: GoblinInfo) => {
      let ret: Promise<ProviderResultDetail<number>>;
      setLoading({ ...loading, breeding: true });
      try {
        let goblinResult = await GoblinFactory.GoblinBusiness.breed(goblin1.idToken, goblin2.idToken);
        
        if (!goblinResult.sucesso) {
          setLoading({ ...loading, breeding: false });
          return {
            ...ret,
            sucesso: false,
            mensagemErro: goblinResult.mensagem
          };
        }

        setLoading({ ...loading, breeding: false });
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: goblinResult.mensagem,
          dataResult: goblinResult.dataResult
        };
      } catch (err) {
        setLoading({ ...loading, breeding: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    getBreedCost: async (tokenId1: number, tokenId2: number) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, breedCost: true });
      try {
        let breedCostResult = await GoblinFactory.GoblinBusiness.breedCost(tokenId1, tokenId2);
        setLoading({ ...loading, breedCost: false });
        if (!breedCostResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: breedCostResult.mensagem
          };
        }
        setBreedCost(breedCostResult.dataResult.breedCost);
        let boxRarity: number = breedCostResult.dataResult.breedRarity; 
        //alert(breedCostResult.dataResult.breedRarity);
        if (boxRarity == 0 || boxRarity == 1) {
          setRarity({
            commonVisible: true,
            commonValue: '50.22%',
            uncommonVisible: true,
            uncommonValue: '32.15%',
            rareVisible: true,
            rareValue: '12.54%',
            epicVisible: true,
            epicValue: '4.31%',
            legendaryVisible: true,
            legendaryValue: '0.78%' 
          });
        }
        else if (boxRarity == 2) {
          setRarity({
            commonVisible: false,
            commonValue: '',
            uncommonVisible: true,
            uncommonValue: '64.86%',
            rareVisible: true,
            rareValue: '25.19%',
            epicVisible: true,
            epicValue: '8.66%',
            legendaryVisible: true,
            legendaryValue: '1.28%' 
          });
        }
        else {
          setRarity({
            commonVisible: false,
            commonValue: '',
            uncommonVisible: false,
            uncommonValue: '',
            rareVisible: true,
            rareValue: '71.13%',
            epicVisible: true,
            epicValue: '24.45%',
            legendaryVisible: true,
            legendaryValue: '4.42%' 
          });
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: breedCostResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, breedCost: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    /*
    getBreedRarity: async (tokenId1: number, tokenId2: number) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, breedCost: true });
      try {
        let breedCostResult = await GoblinFactory.GoblinBusiness.breedRarity(tokenId1, tokenId2);
        setLoading({ ...loading, breedCost: false });
        if (!breedCostResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: breedCostResult.mensagem
          };
        }
        let _rarity: number = breedCostResult.dataResult; 
        if (_rarity == 1 || _rarity == 2 || _rarity == 0) {
          setRarity({
            commonVisible: true,
            commonValue: '50.22%',
            uncommonVisible: true,
            uncommonValue: '32.15%',
            rareVisible: true,
            rareValue: '12.54%',
            epicVisible: true,
            epicValue: '4.31%',
            legendaryVisible: true,
            legendaryValue: '0.78%' 
          });
        }
        else if (_rarity == 3) {
          setRarity({
            commonVisible: false,
            commonValue: '',
            uncommonVisible: true,
            uncommonValue: '64.86%',
            rareVisible: true,
            rareValue: '25.19%',
            epicVisible: true,
            epicValue: '8.66%',
            legendaryVisible: true,
            legendaryValue: '1.28%' 
          });
        }
        else {
          setRarity({
            commonVisible: false,
            commonValue: '',
            uncommonVisible: false,
            uncommonValue: '',
            rareVisible: true,
            rareValue: '71.13%',
            epicVisible: true,
            epicValue: '24.45%',
            legendaryVisible: true,
            legendaryValue: '4.42%' 
          });
        }
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: breedCostResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, breedCost: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    }
    */
  };

  return (
    <GoblinBreedContext.Provider value={goblinBreedProviderValue}>
      {props.children}
    </GoblinBreedContext.Provider>
  );
}
