import React, { useState } from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import { IQuestProvider } from '../../dto/contexts/IQuestProvider';
import { LoadingQuest } from '../../dto/business/LoadingQuest';
import { UserQuestInfo } from '../../dto/domain/UserQuestInfo';
import { GoblinInfo } from '../../dto/domain/GoblinInfo';
import { QuestEstimateInfo } from '../../dto/domain/QuestEstimateInfo';
import QuestFactory from '../../business/factory/QuestFactory';
import GoblinFactory from '../../business/factory/GoblinFactory';
import { UserQuestGoblinInfo } from '../../dto/domain/UserQuestGoblinInfo';
import { QuestStatus } from '../../dto/enum/QuestStatus';
import { IJobProvider } from '../../dto/contexts/IJobProvider';
import JobContext from './JobContext';
import { CategoryJobsList } from '../../dto/business/CategoryJobsList';
import { CategoryList } from '../../dto/business/CategoryList';

let gettingGoblinList = false;

export default function JobProvider(props : any) {

  const [jobs, setJobs] = useState<CategoryJobsList[]>([]);
  const [activejobs, setActiveJobs] = useState<UserQuestInfo[]>([]);
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

  const jobProviderValue: IJobProvider = {
    list: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, list: true });
      try {
        let listResult = await QuestFactory.QuestBusiness.listjobs();
        let categoriesResult = await QuestFactory.QuestBusiness.listjobscategories();
        setLoading({ ...loading, list: false });
        if (!listResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: listResult.mensagem
          };
        }
        if (!categoriesResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: listResult.mensagem
          };
        }
        categoriesResult.dataResult.sort((a, b) => a.order - b.order);
        let categoriesList = categoriesResult.dataResult.map(x => x.category);
        let jobsCategoryList : CategoryJobsList[] = [];
        categoriesList.forEach((ele, i) => {
          jobsCategoryList.push({
            category: ele,
            jobs: listResult.dataResult.filter(x => x.quest.category == ele),
            open: i == 0 ? true : false
          })
        })

        setJobs(jobsCategoryList);

        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: listResult.mensagem
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
    setOpenCategory: (category: string) => {
      let categorieItem = jobs.find(x => x.category == category);
      jobs[jobs.indexOf(categorieItem)] = {
        ...categorieItem,
        open: !categorieItem.open
      }
      setJobs([...jobs]);
    },
    listactive: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, listactive: true });
      try {
        let itemResult = await QuestFactory.QuestBusiness.listactivejobs();
        setLoading({ ...loading, listactive: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        setActiveJobs(itemResult.dataResult);
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: itemResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, listactive: false });
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

        if (itemResult.dataResult.status != QuestStatus.Waiting) {
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
        let itemResult = await QuestFactory.QuestBusiness.getbykey(keyQuest);
        setLoading({ ...loading, detail: false });
        if (!itemResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: itemResult.mensagem
          };
        }
        setQuestDetail(itemResult.dataResult);

        if (itemResult.dataResult.status != QuestStatus.Waiting) {
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
    calculate: async () => {
      let ret: Promise<ProviderResult>;
      if (questDetail.goblins.length < questDetail.quest.qtdemin) {
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
      if (questDetail.goblins.length < questDetail.quest.qtdemax) {
        questDetail.goblins.push({
          idquest: questDetail.id,
          id: null,
          idgoblin: goblin.id,
          goblin
        });
        setQuestDetail({ ...questDetail });
        jobProviderValue.calculate();
      }
    },
    removeGoblinQuest: function (goblin: UserQuestGoblinInfo): void {
      questDetail.goblins.splice(questDetail.goblins.indexOf(goblin), 1);
      setQuestDetail({ ...questDetail });
      jobProviderValue.calculate();
    },
    estimateQuest: estimateQuest,
    jobs: jobs,
    activejobs: activejobs,
    questDetail: questDetail,
    goblins: goblins,
    loading: loading,
    cursorGob: cursorGob,
  };

  return (
    <JobContext.Provider value={jobProviderValue}>
      {props.children}
    </JobContext.Provider>
  );
}
