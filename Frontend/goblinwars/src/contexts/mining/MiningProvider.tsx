import React, {useState} from 'react';
import ProviderResult from '../../dto/contexts/ProviderResult';
import { GoblinInfo } from '../../dto/domain/GoblinInfo';
import IMiningProvider from '../../dto/contexts/IMiningProvider';
import MiningContext from './MiningContext';
import { LoadingMining } from '../../dto/business/LoadingMining';
import MiningFactory from '../../business/factory/MiningFactory';
import { MiningInfo } from '../../dto/domain/MiningInfo';
import GoblinFactory from '../../business/factory/GoblinFactory';
import { GoblinMining } from '../../dto/domain/GoblinMining';
import ProviderResultDetail from '../../dto/contexts/ProviderResultDetail';
import { MiningRankingInfo } from '../../dto/domain/MiningRankingInfo';
import { MinerPosInfo } from '../../dto/domain/MinerPosInfo';
import { MiningGoblinInfo } from '../../dto/domain/MiningGoblinInfo';
import useInterval from '@use-it/interval';
import { MiningRewardInfo } from '../../dto/domain/MiningRewardInfo';
import { MiningHistoryInfo } from '../../dto/domain/MiningHistoryInfo';

let gettingGoblinList = false;

interface PosInfo {
  top: string,
  left: string,
  inverted: boolean
}

const MINER_POS: PosInfo[] = [
  {left: "80px", top: "120px", inverted: false},
  {left: "70px", top: "230px", inverted: false},
  {left: "620px", top: "130px", inverted: true},
  {left: "830px", top: "130px", inverted: false},
  {left: "330px", top: "90px", inverted: true},
  {left: "950px", top: "90px", inverted: true},
  {left: "70px", top: "335px", inverted: true},
  {left: "270px", top: "335px", inverted: false},
  {left: "890px", top: "190px", inverted: true},
  {left: "460px", top: "225px", inverted: true},
  {left: "660px", top: "225px", inverted: false},
  {left: "1115px", top: "190px", inverted: false},
  {left: "660px", top: "300px", inverted: true},
  {left: "865px", top: "300px", inverted: false},
  {left: "515px", top: "335px", inverted: false},
  {left: "250px", top: "190px", inverted: true}
];

export default function MiningProvider(props : any) {

  const [goblinsMining, setGoblinsMining] = useState<GoblinInfo[]>([]);
  const [goblinsCanMining, setGoblinsCanMining] = useState<GoblinInfo[]>([]);
  const [rankTop100, setRankTop100] = useState<MiningRankingInfo[]>([]);
  const [rankWeekly, setRankWeekly] = useState<MiningRankingInfo[]>([]);
  const [rankMonthly, setRankMonthly] = useState<MiningRankingInfo[]>([]);
  const [rankingWeeklyDate, setRankingWeeklyDate] = useState<string>(null);
  const [rankingMonthlyDate, setRankingMonthlyDate] = useState<string>(null);
  const [myMining, setMyMining] = useState<MiningInfo>(null);
  const [minerPos, setMinerPos] = useState<MinerPosInfo[]>([]);
  const [gobCanMiningCursor, setGobCanMiningCursor] = useState<number>(0);
  const [myRewardGobi, setMyRewardGobi] = useState<number>(0);
  const [rewards, setRewards] = useState<MiningRewardInfo[]>([]);
  const [selectedGoblin, setSelectedGoblin] = useState<GoblinInfo>(null);
  const [loading, setLoading] = useState<LoadingMining>({
    info: false,
    rankTop100: false,
    rankWeekly: false,
    rankMonthly: false,
    listGoblinsMining: false,
    listGoblinsCanMining: false,
    start: false,
    stop: false,
    recharge: false,
    infoGoblin: false,
    claim: false,
    listReward: false,
    listHistoryDate: false,
    listHistory: false,
    claimRankingReward: false
  });

  const [historyDateMonth, setHistoryDateMonth] = useState<string[]>([]);
  const [historyDateWeek, setHistoryDateWeek] = useState<string[]>([]);
  const [historyMonth, setHistoryMonth] = useState<MiningHistoryInfo[]>([]);
  const [historyWeek, setHistoryWeek] = useState<MiningHistoryInfo[]>([]);
  const [historyOfUser, setHistoryOfUser] = useState<MiningHistoryInfo[]>([]);

  useInterval(() => {
    if (myMining) {
      setMyRewardGobi(myRewardGobi + myMining.rewardpersecond);
    }
  }, 1000);

  const proccessMiningInfo = (miningInfo: MiningInfo) => {
    
    miningInfo.goblins = miningInfo.goblins.sort((a, b) => {
      if(a.goblinMining.energypercent < b.goblinMining.energypercent)
        return -1;
      if(a.goblinMining.energypercent > b.goblinMining.energypercent)
        return 1;
      return 0;
    });
    setMyMining(miningInfo);
      if (miningInfo.goblins) {
        let minerPos: MinerPosInfo[] = [];
        //const pos
        for (let i = 0; i < miningInfo.goblins.length; i++) {
          let g = miningInfo.goblins[i];
          minerPos.push({
            idtoken: g.idToken,
            sprite: g.sprite,
            top: MINER_POS[i].top,
            left: MINER_POS[i].left,
            inverted: MINER_POS[i].inverted,
            start: Math.trunc(8000 * Math.random()),
            exhausted: g.goblinMining.exhausted,
            spriteTired: g.spritetired,
            goblinMining: g.goblinMining,
            rarityenum: g.rarityenum
          });
        }
        setMinerPos(minerPos);
      }
      setMyRewardGobi(miningInfo.gobi);
  }

  const miningProviderValue: IMiningProvider = {
    listRankTop100: async () => {
      let ret: Promise<ProviderResult>;
      setRankTop100([]);
      setLoading({ ...loading, rankTop100: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.list("T");
        setLoading({ ...loading, rankTop100: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }
        setRankTop100(buResult.dataResult.minings);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, rankTop100: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    listRankMonthly: async () => {
      let ret: Promise<ProviderResult>;
      setRankMonthly([]);
      setLoading({ ...loading, rankMonthly: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.list("M");
        setLoading({ ...loading, rankMonthly: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }
        //alert(buResult.dataResult.rewarddate);
        setRankingMonthlyDate(buResult.dataResult.rewarddate);
        setRankMonthly(buResult.dataResult.minings);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, rankMonthly: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    listRankWeekly: async () => {
      let ret: Promise<ProviderResult>;
      setRankWeekly([]);
      setLoading({ ...loading, rankWeekly: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.list("W");
        setLoading({ ...loading, rankWeekly: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }
        //alert(buResult.dataResult.rewarddate);
        setRankingWeeklyDate(buResult.dataResult.rewarddate);
        setRankWeekly(buResult.dataResult.minings);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, rankWeekly: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    info: async (quiet: boolean) => {
      let ret: Promise<ProviderResult>;
      if (!quiet)
        setLoading({ ...loading, info: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.getmining();
        if (!quiet)
          setLoading({ ...loading, info: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        proccessMiningInfo(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        if (!quiet)
          setLoading({ ...loading, info: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    rechargeGoblin: async (tokenId: number) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, recharge: true });
      try {
        let buResult = await GoblinFactory.GoblinBusiness.rechargeGoblin(tokenId);
        setLoading({ ...loading, recharge: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        if (selectedGoblin && tokenId == selectedGoblin.idToken) {
          setSelectedGoblin(buResult.dataResult);
        } else {
          miningProviderValue.listGoblinsMining();
        }

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, recharge: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    startMining: async (goblin: GoblinInfo) => {
      let ret: Promise<ProviderResult>;
      if (myMining && myMining.goblinqtde >= 16) {
        return {
          ...ret,
          sucesso: false,
          mensagemErro: "You can only have 16 goblins mining at the same time"
        };
      }
      setLoading({ ...loading, start: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.startmining(goblin.idToken);
        setLoading({ ...loading, start: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        goblinsMining.push(goblin);
        setGoblinsMining([...goblinsMining]);
        goblinsCanMining.splice(goblinsCanMining.indexOf(goblin), 1);
        setGoblinsCanMining([...goblinsCanMining]);
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: buResult.mensagem
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
    stopMining: async (goblin: GoblinInfo) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, stop: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.stopmining(goblin.idToken);
        setLoading({ ...loading, stop: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        goblinsMining.splice(goblinsMining.indexOf(goblin), 1);
        setGoblinsMining([...goblinsMining]);
        goblinsCanMining.push(goblin);
        setGoblinsCanMining([...goblinsCanMining]);
        return {
          ...ret,
          sucesso: true,
          mensagemSucesso: buResult.mensagem
        };
      } catch (err) {
        setLoading({ ...loading, stop: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: JSON.stringify(err)
        };
      }
    },
    listGoblinsMining: async () => {
      let ret: Promise<ProviderResult>;
      setGoblinsMining([]);
      setLoading({ ...loading, listGoblinsMining: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.listGoblinsMining();
        setLoading({ ...loading, listGoblinsMining: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }
        setGoblinsMining(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, listGoblinsMining: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    listGoblinsCanMining: async (reset: boolean) => {
      if (gettingGoblinList)
        return;

      gettingGoblinList = true;
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, listGoblinsCanMining: true });
      let goblinsLocal = goblinsCanMining;
      let cursorGobLocal = gobCanMiningCursor;
      if (reset) {
        goblinsLocal = [];
        cursorGobLocal = 0;
      }

      try {
        let goblinsResult = await MiningFactory.MiningBusiness.listGoblinsCanMining(cursorGobLocal);
        setLoading({ ...loading, listGoblinsCanMining: false });
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
        setGoblinsCanMining(goblinsLocal);
        setGobCanMiningCursor(goblinsResult.dataResult.cursorGob);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, listGoblinsCanMining: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    getGoblinMining: async (goblinId: number) => {
      let ret: Promise<ProviderResultDetail<GoblinMining>>;
      setMyMining(null);
      setLoading({ ...loading, infoGoblin: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.getGoblinMining(goblinId);
        setLoading({ ...loading, infoGoblin: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }

        return {
          ...ret,
          sucesso: true,
          dataResult: buResult.dataResult
        };
      } catch (err) {
        setLoading({ ...loading, infoGoblin: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    rechargeall: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, recharge: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.rechargeall();
        setLoading({ ...loading, recharge: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }
        proccessMiningInfo(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, recharge: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    listReward: async () => {
      let ret: Promise<ProviderResult>;
      setRewards([]);
      setLoading({ ...loading, listReward: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.listReward();
        setLoading({ ...loading, listReward: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false
          };
        }
        //alert(JSON.stringify(buResult.dataResult));
        setRewards(buResult.dataResult);

        return {
          ...ret,
          sucesso: true
        };
      } catch (err) {
        setLoading({ ...loading, listReward: false });
        return {
          ...ret,
          sucesso: false
        };
      }
    },
    claimReward: async (idReward: number) => {
      let ret: Promise<ProviderResultDetail<boolean>>;
      setLoading({ ...loading, claim: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.claimReward(idReward);
        setLoading({ ...loading, claim: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }

        return {
          ...ret,
          sucesso: true,
          dataResult: buResult.dataResult
        };
      } catch (err: any) {
        setLoading({ ...loading, claim: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listHistoryDateMonth: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, claim: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.listhistorydate("M");
        setLoading({ ...loading, claim: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setHistoryDateMonth(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading({ ...loading, claim: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listHistoryDateWeek: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, listHistoryDate: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.listhistorydate("W");
        setLoading({ ...loading, listHistoryDate: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setHistoryDateWeek(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading({ ...loading, listHistoryDate: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listHistoryMonth: async (rewardDate: string) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, listHistory: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.listhistory("M", rewardDate);
        setLoading({ ...loading, listHistory: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setHistoryMonth(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading({ ...loading, listHistory: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listHistoryWeek: async (rewardDate: string) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, listHistory: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.listhistory("W", rewardDate);
        setLoading({ ...loading, listHistory: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setHistoryMonth(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading({ ...loading, listHistory: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    listHistoryByUser: async () => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, listHistory: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.listHistoryByUser();
        setLoading({ ...loading, listHistory: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        setHistoryOfUser(buResult.dataResult);
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading({ ...loading, listHistory: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    claimRankingReward: async (idMiningHistory: number) => {
      let ret: Promise<ProviderResult>;
      setLoading({ ...loading, claimRankingReward: true });
      try {
        let buResult = await MiningFactory.MiningBusiness.claimrankingreward(idMiningHistory);
        setLoading({ ...loading, claimRankingReward: false });
        if (!buResult.sucesso) {
          return {
            ...ret,
            sucesso: false,
            mensagemErro: buResult.mensagem
          };
        }
        return {
          ...ret,
          sucesso: true
        };
      } catch (err: any) {
        setLoading({ ...loading, claimRankingReward: false });
        return {
          ...ret,
          sucesso: false,
          mensagemErro: err.message
        };
      }
    },
    goblinsMining: goblinsMining,
    goblinsCanMining: goblinsCanMining,
    rankingTop100: rankTop100,
    rankingMonthlyDate: rankingMonthlyDate,
    rankingMonthly: rankMonthly,
    rankingWeeklyDate: rankingWeeklyDate,
    rankingWeekly: rankWeekly,
    myMining: myMining,
    minerPos: minerPos,
    myRewardGobi: myRewardGobi,
    loading: loading,
    gobCanMiningCursor: gobCanMiningCursor,
    selectedGoblin: selectedGoblin,
    rewards: rewards,
    historyDateMonth: historyDateMonth,
    historyDateWeek: historyDateWeek,
    historyMonth: historyMonth,
    historyWeek: historyWeek,
    historyOfUser: historyOfUser
  };

  return (
    <MiningContext.Provider value={miningProviderValue}>
      {props.children}
    </MiningContext.Provider>
  );
}
