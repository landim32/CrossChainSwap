import { Alert, Backdrop, Box, Button, CircularProgress, Divider, Paper, Slide, Snackbar, Stack, Theme, Tooltip, Typography } from "@mui/material";
import { QuestPeriod } from "../../dto/enum/QuestPeriod";
import { QuestType } from "../../dto/enum/QuestType";
import { GoblinStyles, MainStyles } from "../../utils/style";
import DailyIcon from "../../assets/images/quest/daily.png";
import QuestIcon from "../../assets/images/quest/quest.png";
import WeeklyIcon from "../../assets/images/quest/weekly.png";
import WorkIcon from "../../assets/images/quest/work.png";
import SelectedIcon from "../../assets/images/quest/selected.png";
import Moment from "moment";
import { useContext, useEffect, useRef, useState } from "react";
import { useHistory, useLocation } from "react-router-dom";
import QuestContext from "../../contexts/quest/QuestContext";
import { Header } from "../../components/Header";
import { GoblinProgress } from "../../components/GoblinProgress";
import goldPile from '../../assets/images/quest/goldPile.png';
import { GenericSlot } from "../../components/GenericSlot";
import { SxProps } from "@mui/system";
import InfiniteScroll from "react-infinite-scroll-component";
import { Goblin } from "../../components/Goblin";
import SizeGoblinCard from "../../dto/enum/SizeGoblinCard";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import { isMobile } from 'react-device-detect';
import ProviderResult from "../../dto/contexts/ProviderResult";
import { ResultDialog } from "../../components/ResultDialog";
import { QuestStatus } from "../../dto/enum/QuestStatus";
import { useTimer } from "react-timer-hook";
import { GwViewPort } from "../../components/GwViewPort";
import { AnchorElGoblinQuest } from "../../dto/business/AnchorElGoblinQuest";
import { GoblinQuestDetail } from "../../components/GoblinQuestDetails";
import { QuestRequeriment } from "../../components/QuestRequeriment";
import { GetCardBackground, GetRewardBlock, GetStatusColor, GetStatusName } from "../../utils/QuestUtils";
import { GetDuration } from "../../utils/utils";
import { AnchorElItem } from "../../dto/business/AnchorElItem";
import { ItemInfo } from "../../dto/domain/ItemInfo";
import { ItemPopover } from "../../components/ItemPopover";

const topHeader = 70;
const iconSize = 56;
const styleQtde: SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 16,
  bottom: 0,
  right: 2,
  position: "absolute"
}

interface TimerParam {
  expiryTimestamp: Date;
  title: string;
}

const getLoadingBlock = () => {
  return (
    <Box sx={{ width: 1 }}>
      <Stack direction={"row"} sx={{ ...MainStyles.container, pb: 4, pt: 1 }} spacing={1}>
        <CircularProgress />
        <Typography variant={"subtitle1"} color="white" >Loading...</Typography>
      </Stack>
    </Box>
  );
}



export function QuestDetail() {
  let boxWidth = isMobile ? 350 : 400;
  let goblinWidth = isMobile ? 350 : 600;
  const questContext = useContext(QuestContext);
  const history = useHistory();
  let location = useLocation();
  const [loadMore, setLoadMore] = useState(true);
  const listInnerRef = useRef();
  const [positionGoblins, setPositionGoblins] = useState(false);
  const containerRef = useRef(null);
  const [openDialog, setOpenDialog] = useState(false);
  const [errMessage, setErrMessage] = useState("");
  const [openResult, setOpenResult] = useState(false);
  const [openGoblinDetail, setOpenGoblinDetail] = useState<AnchorElGoblinQuest>(null);
  
  const handleCloseResult = () => {
    setOpenResult(false);
  };

  const handleClose = (ev: any) => {
    if (ev?.reason === 'clickaway') {
      return;
    }

    setOpenDialog(false);
  };

  const handleOpenGoblin = (ev: any, goblin: GoblinInfo) => {
    setOpenGoblinDetail({ open: true, anchorEl: ev, goblin: goblin, quest: questContext.questDetail.quest });
  }

  const closeOpenGoblin = () => {
    setOpenGoblinDetail(null);
  }

  const [anchorEl, setAnchorEl] = useState<AnchorElItem>(null);

  const handleClick = (event: any, selectItem: ItemInfo) => {
      setAnchorEl({anchorEl: event, selectItem: selectItem});
  };

  const handleClosePopOver = () => {
      setAnchorEl(null);
  };

  const open = Boolean(anchorEl);
  const id = open ? 'questrewarddetail-popover' : undefined;
  
  useEffect(() => {
    let questId = parseInt(new URLSearchParams(location.search).get("questId"));
    let questKey = parseInt(new URLSearchParams(location.search).get("questKey"));

    if(questId == -1) {
      questContext.getbykey(questKey);
    } else {
      questContext.getbyid(questId);
    }
    questContext.listGoblins(questKey, true).then((ret) => {
      if(ret)
        setLoadMore(ret.sucesso);
    })
    const onScroll = (e : any) => {
      
      if (listInnerRef.current) {
        const { offsetTop } = listInnerRef.current;
        if((window.pageYOffset + topHeader) >= offsetTop)
          setPositionGoblins(true);
        else{
          setPositionGoblins(false);
        }
      }
    };
    window.addEventListener("scroll", onScroll);      
  }, []);

  const getCurrentAffinity = () => {
    return (questContext.questDetail.goblins && questContext.questDetail.goblins.length > 0 ? 
      questContext.questDetail.goblins.map(x => x.goblin.questaffinity).reduce((a, b) => (a+b)) 
      : 0);
  }

  const goblinList = () => {
    return (
    <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"}  >
      {
        [...Array(questContext.questDetail.quest.qtdemax)].map((i, j) => {
          return (
            <GenericSlot boxSize={90} key={j} rarity={questContext.questDetail.goblins[j]?.goblin.rarityenum} >
              {
                questContext.questDetail.goblins[j] && 
                <Slide direction="left" in={questContext.questDetail.goblins[j] != undefined} container={containerRef.current}>
                  {
                    <Box sx={{ ...MainStyles.container, position: "relative", height: 80, width: 80 }} onClick={(ev: any) => {
                      //handleOpenGoblin(ev.currentTarget, questContext.questDetail.goblins[j].goblin);
                      var userGoblin = questContext.questDetail.goblins.find(x => {
                        return x.goblin.idToken == questContext.questDetail.goblins[j].goblin.idToken;
                      });
                      questContext.removeGoblinQuest(userGoblin);
                    }}>
                      <img draggable="false"  src={questContext.questDetail.goblins[j].goblin.headImageURL} style={{ height: 110, top: -2, right: -20, position: "absolute" }} alt={questContext.questDetail.goblins[j].goblin.name} />
                      <Typography sx={{ ...styleQtde }}>{questContext.questDetail.goblins[j].goblin.questaffinity}</Typography>
                    </Box>
                  }
                </Slide>
              }
              
            </GenericSlot>
          )
        })
      }
    </Stack>)
  }

  const startExecuteQuest = async () => {
    if(questContext.questDetail.goblins .length < questContext.questDetail.quest.qtdemin){
      setErrMessage("Select at least " + questContext.questDetail.quest.qtdemin + " goblins.");
      setOpenDialog(true);
      return;
    }
    let ret : ProviderResult; 
    ret = await questContext.execute();
    if(ret.sucesso){
      setOpenResult(true);
    } else {
      setErrMessage(ret.mensagemErro);
      setOpenDialog(true);
    }
  }

  const getResultPopup = () => {
    return (
      <ResultDialog onClose={handleCloseResult} open={true} title={questContext.questDetail.status == QuestStatus.Success ? "Congratulations" : "Fail"}>
        <Stack sx={{ ...MainStyles.container, ...MainStyles.floatingBox}} spacing={1.5}>
          <Typography sx={{ ...GoblinStyles.textMain, color: GetStatusColor(questContext.questDetail.status) }}>{GetStatusName(questContext.questDetail.status)}</Typography>
          
          <Typography sx={{ ...GoblinStyles.textMain }}>
            {
              questContext.questDetail.status == QuestStatus.Success ? "Your goblins managed to get the reward" : "Your goblins failed to get the reward."
            }
          </Typography>
          {
            questContext.questDetail.status == QuestStatus.Success &&
            getRewardBlock()
          }
          <Button sx={{ ...MainStyles.mainButton, width: 150 }} onClick={handleCloseResult} >
            {
              questContext.questDetail.status == QuestStatus.Success ? "Yay !" : "Okay"
            }
          </Button>
        </Stack>
      </ResultDialog>
    )
  }

  const checkGoblinAdd = (value: GoblinInfo) => {
    var ret = questContext.questDetail.goblins.find(x => {
      return x.goblin.idToken == value.idToken;
    });
    if(ret)
      return true;
    return false;
  };

  const getRewardBlock = () => {
    return GetRewardBlock(questContext.questDetail.quest, (ev: any, item: ItemInfo) => {
      handleClick(ev.currentTarget, item);
    })
  }

  const getRewardCard = () => {
    return (
      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 2, width: boxWidth }} elevation={6} >
        { getRewardBlock() }
      </Paper>
    )
  }

  const getChanceGoblinBlock = () => {
    return (
      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: isMobile ? 0.5: 2, width: goblinWidth, m: 1 }} elevation={6} >
        <Stack sx={{ ...MainStyles.container, p: 2 }} spacing={2}>
          {
            questContext.questDetail.status == QuestStatus.Waiting &&
            <Button sx={{ ...MainStyles.mainButton, width: 140 }} onClick={startExecuteQuest} >Start</Button>
          }
          <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }} >Your Power</Typography>
            <Typography sx={{ ...GoblinStyles.textMain }} >{getCurrentAffinity()}  /  {questContext.questDetail.quest.maxpowerhash}</Typography>
            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, fontSize: 14 }} >Min Power: {questContext.questDetail.quest.minpowerhash}</Typography>
          </Stack>
          <Stack sx={{ ...MainStyles.container, width: 1 }}>
            <Stack sx={{ ...MainStyles.container, width: 1 }} direction={"row"} spacing={1}>
              <Typography sx={{ ...GoblinStyles.textMain }}>Success Chance</Typography>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{
                questContext.loading.calculate ? 
                "..."
                :(questContext.estimateQuest ? 
                  (questContext.estimateQuest.percent)
                  : 0
                ).toString()+"%"
              }</Typography>
            </Stack>
            <GoblinProgress sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f" }} variant={"determinate"}
              value={(questContext.estimateQuest ? (questContext.estimateQuest.percent) : 0)} />
          </Stack>
          <Stack direction={"row"} spacing={1} >
            <Typography sx={{ ...GoblinStyles.textMain }}>Time cost</Typography>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{
              (questContext.loading.calculate ? 
                "..."
                :
                GetDuration(
                  (questContext.estimateQuest ? 
                  questContext.estimateQuest.time
                  : questContext.questDetail.quest.timemax)*1000)
              )}</Typography>
          </Stack>
          <Stack sx={{ ...MainStyles.container, width: 1 }}>
            <Typography sx={{ ...GoblinStyles.textMain }}>Choose Your Goblins</Typography>
            <Typography sx={{ ...GoblinStyles.sessionTitleText, fontStyle: "italic" }}>Select at least {questContext.questDetail.quest.qtdemin} goblins</Typography>
            <Box ref={listInnerRef}></Box>
            {
              goblinList()
            }
            <Slide direction="down" in={positionGoblins} container={containerRef.current}>
              <Paper sx={{ ...MainStyles.container, border: 0, position: "fixed", top: 0, pt: topHeader.toString() + "px", ml: 1, mr: 1, zIndex: 10, bgcolor: "#2b211f" }} elevation={12}  >
              {
                goblinList() 
              }
              </Paper>
            </Slide>
            
          </Stack>
          <InfiniteScroll
            style={{ padding: 1, margin: 1, display: "flex", flexWrap: "wrap", alignItems: "center", alignContent: "center", justifyContent: "center", overflowX: "hidden" }}
            dataLength={questContext.goblins.length}
            next={async () => {
              var ret = await questContext.listGoblins(questContext.questDetail.questkey, false);
              if(ret)
                setLoadMore(ret.sucesso);
            }}
            hasMore={loadMore}
            loader={ questContext.loading.listGoblins && getLoadingBlock()
            }
            endMessage={
              <Box sx={{ width: 1 }}>
                <Stack direction={"row"} sx={{ ...MainStyles.container, pb: 4, pt: 1 }} spacing={1}>
                  <Typography variant={"subtitle1"} color="white" >No more goblins for fetch !</Typography>
                </Stack>
              </Box>
            }
          >
            {
              questContext.goblins && questContext.goblins.length > 0 ? questContext.goblins.map((value) => (
                
                  <Box sx={{ ...MainStyles.container, m: 0.5, position: "relative" }}>
                    <Slide direction="right" in={!checkGoblinAdd(value)} container={containerRef.current}>
                      <Box >
                        <Goblin
                          id={value.id}
                          idToken={value.idToken}
                          name={value.name}
                          image={value.imageURL}
                          size={SizeGoblinCard.VerySmall}
                          mainColor={value.skincolor}
                          goblinSkillList={value.goblinSkillList}
                          rarity={value.rarityenum}
                          questRequeriment={questContext.questDetail.quest.requeriments}
                          onElemClick={(tokenId:number) => {
                            questContext.addGoblinQuest(questContext.goblins.find(x => {
                              return x.idToken == tokenId;
                            }))
                          }}
                        />
                      </Box>
                    </Slide>
                    <Slide direction="left" in={checkGoblinAdd(value)} container={containerRef.current}>
                        <Box sx={{ height: "100%", width: "100%", ...MainStyles.container, position: "absolute", top: 0 }} 
                          onClick={() => {
                        var userGoblin = questContext.questDetail.goblins.find(x => {
                          return x.goblin.idToken == value.idToken;
                        });
                        questContext.removeGoblinQuest(userGoblin);
                      }}>
                        <img draggable="false"  src={SelectedIcon} style={{ height: 70 }} />
                      </Box>
                    </Slide>
                  </Box>
            )) : getLoadingBlock()
          }
          </InfiniteScroll>
        </Stack>
      </Paper>
    );
  }

  const getCardInfo = () => {
    return (
      <Paper sx={{ ...MainStyles.container, borderRadius: 3 }} elevation={6}>
        <Box sx={{ ...MainStyles.container, position: "relative", width: boxWidth, height: 320 }}>
          <Box sx={{ position: "absolute", top: 0, width: boxWidth, height: 320 }} >
            <img draggable="false"  src={GetCardBackground(questContext.questDetail.quest)} style={{ width: "100%", height: "100%", borderTopLeftRadius: 6, borderTopRightRadius: 6, position: "absolute", top: 0 }} />
            <Box sx={{ width: 1, height: 1, position: "absolute", top: 0, background: "linear-gradient(0deg, rgba(0,0,0,0.6) 0%, rgba(239,239,239,0.01) 50%, rgba(0,0,0,0.6) 100%);" }}></Box>
          </Box>
          <Stack sx={{ ...MainStyles.container, width: 1, position: "absolute", top: 20, 
              opacity: (questContext.questDetail.status == QuestStatus.Success || questContext.questDetail.status == QuestStatus.Failed) ? 0.3 : 1 }} spacing={2}>
            <Typography sx={{ ...GoblinStyles.textMain }}>{questContext.questDetail.quest.name}</Typography>
            <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={2}>
              <Stack direction={"row"} sx={{ ...MainStyles.container, justifyContent: "space-evenly", width: 1 }}>
                <Stack sx={{ ...MainStyles.container }}>
                  <img draggable="false"  src={questContext.questDetail.quest.period == QuestPeriod.Daily ? DailyIcon : WeeklyIcon} alt={"goblin"} style={{ height: iconSize }} />
                  <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{questContext.questDetail.quest.period == QuestPeriod.Daily ? "Daily" : "Weekly"}</Typography>
                </Stack>
                <Stack sx={{ ...MainStyles.container }}>
                  <img draggable="false"  src={QuestIcon} alt={"goblin"} style={{ height: iconSize }} />
                  <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{"Mission"}</Typography>
                </Stack>
              </Stack>
            </Stack>
            <Typography sx={{ ...GoblinStyles.sessionTitleText, fontStyle: "italic", px: 2 }}>“{questContext.questDetail.quest.description}”</Typography>
          </Stack>
          {
            (questContext.questDetail.status == QuestStatus.Success || questContext.questDetail.status == QuestStatus.Failed) &&
            <Box sx={{ ...MainStyles.container, top: 0, height: 1, width: 1, position: "absolute" }}>
              <Typography sx={{ ...GoblinStyles.textMain, color: GetStatusColor(questContext.questDetail.status), fontSize: 62 }}>{GetStatusName(questContext.questDetail.status)}</Typography>
            </Box>
          }
        </Box>
      </Paper>
    )
  }

  const getQuestRequeriments = () => {
    return (
      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 2, width: boxWidth }} elevation={6} >
        <QuestRequeriment quest={questContext.questDetail.quest} 
          currentAffinity={0} />
      </Paper>
    )
  }

  const getQuestCompleteGoblins = () => {
    return (
    <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: isMobile ? 0.5: 2, width: goblinWidth, m: 1 }} elevation={6} >
      <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={2}>
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0}>
          <Typography sx={{ ...GoblinStyles.sessionTitleText }} >Your Power</Typography>
          <Typography sx={{ ...GoblinStyles.textMain }} >{getCurrentAffinity()}  /  {questContext.questDetail.quest.maxpowerhash}</Typography>
        </Stack>
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={2}>
          {
            questContext.estimateQuest ?
            <Stack sx={{ ...MainStyles.container, width: 1 }}>
              <Stack sx={{ ...MainStyles.container, width: 1 }} direction={"row"} spacing={1}>
                <Typography sx={{ ...GoblinStyles.textMain }}>Success Chance</Typography>
                <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{
                  questContext.estimateQuest ? 
                    (questContext.estimateQuest.percent)
                    : "-"
                }%</Typography>
              </Stack>
              <GoblinProgress sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f" }} variant={"determinate"}
                value={(questContext.estimateQuest.percent)} />
            </Stack>
            : <CircularProgress />
          }
          {
            goblinList()
          }
          {
            questContext.estimateQuest &&
            <Stack sx={{ ...MainStyles.container }}>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }}>Goblins cooldown penalty</Typography>
              {
                <Typography sx={{ ...GoblinStyles.textMain }}>{GetDuration(questContext.estimateQuest.time*1000)}</Typography>
              }
            </Stack>
          }
        </Stack>
      </Stack>
    </Paper>)
  }

  return (
    <GwViewPort>
    <Stack sx={{ ...MainStyles.container }} >
      <Box sx={{ margin: "2vh 0vh 5vh 0vh;" }}>
        {
          questContext.questDetail ?
          <Stack sx={{ display: "flex", alignContent: "flex-start", alignItems: "flex-start", justifyContent: "space-evenly", justifyItems: "normal", width: 1, flexWrap: "wrap" }} 
            direction={"row"} spacing={0} ref={containerRef}>
            <Stack sx={{ ...MainStyles.container, width: boxWidth, p: 0, pb: 2, m: 1 }} spacing={2} >
              {
                getCardInfo()
              }
              {
                (questContext.questDetail.status == QuestStatus.Waiting|| questContext.questDetail.status == QuestStatus.Success) && 
                getRewardCard()
              }
              {
                getQuestRequeriments()
              }
            </Stack>
            {
              questContext.questDetail.status != QuestStatus.Waiting && 
              getQuestCompleteGoblins()
            }
            {
              questContext.questDetail.status == QuestStatus.Waiting &&
              getChanceGoblinBlock()
            }
          </Stack>
          :
          <Backdrop
              sx={{ color: '#fff', zIndex: (theme) => 99 }}
              open={true}
          >
              <CircularProgress color="inherit" />
          </Backdrop>
        }
      </Box>
      {/*<GoblinQuestDetail anchorEl={openGoblinDetail} closeCb={closeOpenGoblin} id={"goblinEquip"} 
        canRemove={questContext.questDetail && questContext.questDetail.status == QuestStatus.Waiting} 
        removeCb={(goblin: GoblinInfo) => {
          closeOpenGoblin();
          var userGoblin = questContext.questDetail.goblins.find(x => {
            return x.goblin.idToken == goblin.idToken;
          });
          questContext.removeGoblinQuest(userGoblin);
      }} />*/}
      <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
        <Alert onClose={handleClose} severity="error" sx={{ width: '100%' }}>
          {errMessage}
        </Alert>
      </Snackbar>
      {
        openResult &&
        getResultPopup()
      }
    </Stack>
    <ItemPopover anchorEl={anchorEl} equipCb={() => {}} moreDetail={(item: ItemInfo) => {
      history.push("/equipment?key=" + item.key);
    }} loading={false} open={open} closeCb={handleClosePopOver} id={id} canEquip={false} firstView={1} />
    </GwViewPort>
  )
}