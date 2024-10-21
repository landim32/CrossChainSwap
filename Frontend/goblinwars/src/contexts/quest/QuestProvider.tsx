import React, { useState } from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import { IQuestProvider } from '../../dto/contexts/IQuestProvider';
import QuestContext from './QuestContext';
import { LoadingQuest } from '../../dto/business/LoadingQuest';
import { UserQuestInfo } from '../../dto/domain/UserQuestInfo';
import { GoblinInfo } from '../../dto/domain/GoblinInfo';
import { QuestEstimateInfo } from '../../dto/domain/QuestEstimateInfo';
import QuestFactory from '../../business/factory/QuestFactory';
import GoblinFactory from '../../business/factory/GoblinFactory';
import { UserQuestGoblinInfo } from '../../dto/domain/UserQuestGoblinInfo';
import { QuestStatus } from '../../dto/enum/QuestStatus';

let gettingGoblinList = false;

export default function QuestProvider(props : any) {

  const [quests, setQuests] = useState<UserQuestInfo[]>([]);
  const [goblins, setGoblins] = useState<GoblinInfo[]>([]);
  const [questDetail, setQuestDetail] = useState<UserQuestInfo>(null);
  const [estimateQuest, setEstimateQuest] = useState<QuestEstimateInfo>(null);
  const [cursorGob, setCursorGob] = useState(0);
  const [loading, setLoading] = useState<LoadingQuest>({
    calculate: false,
    claim: false,
    detail: false,
    execute: false,
    list: false,
    listactive: false,
    start: false,
    listGoblins: false,
    listcategories: false,
  });

  const questProviderValue: IQuestProvider = {
    list: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, list: true });
      try {
        let itemResult = await QuestFactory.QuestBusiness.list();
        setLoading({ ...loading, list: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        setQuests(itemResult.dataResult);
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
    listGoblins: async (keyQuest: number, reset: boolean) => {
      if (gettingGoblinList)
        return;

      gettingGoblinList = true;
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, listGoblins: true });
      let goblinsLocal = goblins;
      let cursorGobLocal = cursorGob;
      if (reset) {
        goblinsLocal = [];
        cursorGobLocal = 0;
      }

      try {
        let goblinsResult = await QuestFactory.QuestBusiness.listGoblins(keyQuest, cursorGobLocal);
        setLoading({ ...loading, listGoblins: false });
        gettingGoblinList = false;
        if (!goblinsResult.dataResult || !goblinsResult.dataResult?.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        //No more for load
        if (goblinsResult.dataResult.goblins.length == 0)
          return {
            ...ret,
            sucesso: false
          };

        goblinsResult.dataResult.goblins.forEach(i => goblinsLocal.push(i));
        setGoblins(goblinsLocal);
        setCursorGob(goblinsResult.dataResult.cursorGob);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, listGoblins: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    getbyid: async (idQuest: number) => {
      let ret: Promise<ProviderResult>;
      setQuestDetail(null);
      setEstimateQuest(null);
      setLoading({ ...loading, detail: true });
      try {
        let itemResult = await QuestFactory.QuestBusiness.getbyid(idQuest);
        setLoading({ ...loading, detail: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        setQuestDetail(itemResult.dataResult);

        if(itemResult.dataResult.status != QuestStatus.Waiting) {
          let calcResult = await QuestFactory.QuestBusiness.calculate(itemResult.dataResult.id, itemResult.dataResult.questkey, itemResult.dataResult.goblins.map((item => { return item.goblin.idToken; })));
          if (calcResult.sucesso) {
            setEstimateQuest(calcResult.dataResult);  
          }
        }

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
    getbykey: async (keyQuest: number) => {
      let ret: Promise<ProviderResult>;
      setQuestDetail(null);
      setEstimateQuest(null);
      setLoading({ ...loading, detail: true });
      try {

        let lstResult = await QuestFactory.QuestBusiness.list();
        setLoading({ ...loading, detail: false });
        if (!lstResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: lstResult.mensagem
          };
        }

        var itemResult = lstResult.dataResult.find(x => x.questkey == keyQuest);
        setQuestDetail(itemResult);

        if(itemResult.status != QuestStatus.Waiting) {
          let calcResult = await QuestFactory.QuestBusiness.calculate(itemResult.id, itemResult.questkey, itemResult.goblins.map((item => { return item.goblin.idToken; })));
          if (calcResult.sucesso) {
            setEstimateQuest(calcResult.dataResult);  
          }
        }

        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: lstResult.mensagem
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
    calculate: async () => {
      let ret: Promise<ProviderResult>;
      if(questDetail.goblins.length < questDetail.quest.qtdemin) {
        setEstimateQuest(null);
        return;
      }
      setLoading({ ...loading, calculate: true });
      try {
        let itemResult = await QuestFactory.QuestBusiness.calculate(questDetail.id, questDetail.questkey, questDetail.goblins.map((item => { return item.goblin.idToken; })));
        setLoading({ ...loading, calculate: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }

        setEstimateQuest(itemResult.dataResult);
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, calculate: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    start: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, start: true });
      try {
        let itemResult = await QuestFactory.QuestBusiness.start(questDetail.id, questDetail.questkey, questDetail.goblins.map((item => { return item.goblin.idToken; })));
        setLoading({ ...loading, start: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        questDetail.status = QuestStatus.Started;
        setQuestDetail({ ...questDetail });
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, start: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    execute: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, execute: true });
      try {
        let itemResult = await QuestFactory.QuestBusiness.execute(questDetail.id, questDetail.goblins.map((item => { return item.goblin.idToken; })));
        setLoading({ ...loading, execute: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        questDetail.status = itemResult.dataResult.status;
        setQuestDetail({ ...questDetail });
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, execute: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    claim: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, execute: true });
      try {
        let itemResult = await QuestFactory.QuestBusiness.claim(questDetail.id);
        setLoading({ ...loading, execute: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        questDetail.status = itemResult.dataResult.status;
        setQuestDetail({ ...questDetail });
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, execute: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    addGoblinQuest: function (goblin: GoblinInfo): void {
      if(questDetail.goblins.length < questDetail.quest.qtdemax) {
        questDetail.goblins.push({
          idquest: questDetail.id,
          id: null,
          idgoblin: goblin.id,
          goblin
        });
        setQuestDetail({ ...questDetail });
        questProviderValue.calculate();
      }
    },
    removeGoblinQuest: function (goblin: UserQuestGoblinInfo): void {
      questDetail.goblins.splice(questDetail.goblins.indexOf(goblin), 1);
      setQuestDetail({ ...questDetail });
      questProviderValue.calculate();
    },
    estimateQuest: estimateQuest,
    quests: quests,
    questDetail: questDetail,
    goblins: goblins,
    loading: loading,
    cursorGob: cursorGob,
  };

  return (
    <QuestContext.Provider value={questProviderValue}>
      {props.children}
    </QuestContext.Provider>
  );
}
