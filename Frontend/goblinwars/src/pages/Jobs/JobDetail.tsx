import { Alert, Backdrop, Box, Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, Paper, Popover, Slide, Snackbar, Stack, Theme, Typography } from "@mui/material";
import { QuestType } from "../../dto/enum/QuestType";
import { GoblinStyles, MainStyles } from "../../utils/style";
import WorkIcon from "../../assets/images/quest/work.png";
import SelectedIcon from "../../assets/images/quest/selected.png";
import Moment from "moment";
import { useContext, useEffect, useRef, useState } from "react";
import { useHistory, useLocation } from "react-router-dom";
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
import { QuestRequeriment } from "../../components/QuestRequeriment";
import { GetCardBackground } from "../../utils/QuestUtils";
import { GetDuration } from "../../utils/utils";
import JobContext from "../../contexts/jobs/JobContext";
import { AnchorElItem } from "../../dto/business/AnchorElItem";
import { ItemInfo } from "../../dto/domain/ItemInfo";
import { ItemPopover } from "../../components/ItemPopover";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { UserItemInfo } from "../../dto/domain/UserItemInfo";
import { AnchorElBuy } from "../../dto/business/AnchorElBuy";
import { BuySellMaterial } from "../Inventory/BuySellMaterial";
import { GetItemAssets } from "../../utils/ItemAssetsUtils";

const topHeader = 70;
const iconSize = 56;
const styleQtde: SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 16,
  bottom: -5,
  right: -1,
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



export function JobDetail() {
  let boxWidth = isMobile ? 350 : 500;
  let goblinWidth = isMobile ? 350 : 600;
  const jobContext = useContext(JobContext);
  const history = useHistory();
  let location = useLocation();
  const [loadMore, setLoadMore] = useState(true);
  const listInnerRef = useRef();
  const [positionGoblins, setPositionGoblins] = useState(false);
  const containerRef = useRef(null);
  const [openDialog, setOpenDialog] = useState(false);
  const [errMessage, setErrMessage] = useState("");
  const [openResult, setOpenResult] = useState(false);
  const [openStart, setOpenStart] = useState(false);
  const [openGoblinDetail, setOpenGoblinDetail] = useState<AnchorElGoblinQuest>(null);
  
  const handleCloseResult = () => {
    setOpenResult(false);
    history.push("/inventory");
  };

  const handleClose = (ev: any) => {
    if (ev?.reason === 'clickaway') {
      return;
    }
    setOpenDialog(false);
  };

  const handleCloseStart = () => {
    setOpenStart(false);
    history.push("/jobs");
  };

  const handleOpenGoblin = (ev: any, goblin: GoblinInfo) => {
    setOpenGoblinDetail({ open: true, anchorEl: ev, goblin: goblin, quest: jobContext.questDetail.quest });
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
  const id = open ? 'itemjobdetail-popover' : undefined;

  const [anchorElBuy, setAnchorElBuy] = useState<AnchorElBuy>(null);

  const handleClickBuy = (event: any, selectUserItem: UserItemInfo) => {
    setAnchorElBuy({anchorEl: event, selectUserItem: selectUserItem});
  };

  const handleClosePopOverBuy = () => {
    setAnchorElBuy(null);
  };

  const openBuy = Boolean(anchorElBuy);
  const idBuy = openBuy ? 'itemjobbuyitem-popover' : undefined;
  
  const refreshPage = () => {
    handleClosePopOver();
    handleClosePopOverBuy();
    let questId = parseInt(new URLSearchParams(location.search).get("questId"));
    let questKey = parseInt(new URLSearchParams(location.search).get("questKey"));

    if(questId != -1) {
      jobContext.getbyid(questId);
    
    } else {
      jobContext.getbykey(questKey);
    }

    jobContext.listGoblins(questKey, true).then((ret) => {
      if(ret)
        setLoadMore(ret.sucesso);
    })
  }

  useEffect(() => {

    refreshPage();
    
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
  }, [location]);

  const [confirm, setConfirm] = useState(false);

  const handleOpenConfirmation = () => {
    setConfirm(true)
  }

  const handleCloseConfirmation = () => {
    setConfirm(false)
  }

  const goblinList = () => {
    return (
    <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"}  >
      {
        [...Array(jobContext.questDetail.quest.qtdemax)].map((i, j) => {
          return (
            <GenericSlot boxSize={90} key={j} rarity={jobContext.questDetail.goblins[j]?.goblin.rarityenum} >
              {
                jobContext.questDetail.goblins[j] && 
                <Slide direction="left" in={jobContext.questDetail.goblins[j] != undefined} container={containerRef.current}>
                  {
                    <Box sx={{ ...MainStyles.container, position: "relative", height: 80, width: 80 }} onClick={(ev: any) => {
                      //handleOpenGoblin(ev.currentTarget, jobContext.questDetail.goblins[j].goblin);
                      var userGoblin = jobContext.questDetail.goblins.find(x => {
                        return x.goblin.idToken == jobContext.questDetail.goblins[j].goblin.idToken;
                      });
                      jobContext.removeGoblinQuest(userGoblin);
                    }}>
                      <img draggable="false"  src={jobContext.questDetail.goblins[j].goblin.headImageURL} style={{ height: 110, top: -2, right: -20, position: "absolute" }} alt={jobContext.questDetail.goblins[j].goblin.name} />
                      <Typography sx={{ ...styleQtde }}>{jobContext.questDetail.goblins[j].goblin.questaffinity}</Typography>
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
    if(jobContext.questDetail.goblins .length < jobContext.questDetail.quest.qtdemin){
      setErrMessage("Select at least " + jobContext.questDetail.quest.qtdemin + " goblins.");
      setOpenDialog(true);
      return;
    }
    let ret : ProviderResult; 
    ret = await jobContext.start();
    handleCloseConfirmation();
    if(ret.sucesso){
      setOpenStart(true);
    } else {
      setErrMessage(ret.mensagemErro);
      setOpenDialog(true);
    }
  }

  const claimJob = async () => {
    if(!checkCanClaim()){
      setErrMessage("Work is still in progress.");
      setOpenDialog(true);
      return;
    }
    let ret : ProviderResult; 
    ret = await jobContext.claim();
    if(ret.sucesso){
      setOpenResult(true);
    } else {
      setErrMessage(ret.mensagemErro);
      setOpenDialog(true);
    }
  }

  const getResultPopup = () => {
      return (
        <ResultDialog onClose={handleCloseResult} open={true} title={"Congratulations"}>
          <Stack sx={{ ...MainStyles.container, ...MainStyles.floatingBox}}>
            <Typography sx={{ ...GoblinStyles.textMain }}>
              {
                "Your goblins managed to get the reward"
              }
            </Typography>
            {
              getRewardBlock()
            }
            <Button sx={{ ...MainStyles.mainButton, width: 150 }} onClick={handleCloseResult} >
              {
                "Yay !"
              }
            </Button>
          </Stack>
        </ResultDialog>
      )
  }

  const getStartPopup = () => {
    return (
      <ResultDialog onClose={handleCloseStart} open={true} title={"Success"}>
        <Stack sx={{ ...MainStyles.container, ...MainStyles.floatingBox}}>
          <Typography sx={{ ...GoblinStyles.textMain }}>Your goblins started the job !</Typography>
          <Button sx={{ ...MainStyles.mainButton, width: 150 }} onClick={handleCloseStart} >
            Ok
          </Button>
        </Stack>
      </ResultDialog>
    )
  }

  const checkGoblinAdd = (value: GoblinInfo) => {
    var ret = jobContext.questDetail.goblins.find(x => {
      return x.goblin.idToken == value.idToken;
    });
    if(ret)
      return true;
    return false;
  };

  const getRewardBlock = () => {
    return (
      <Stack sx={{ ...MainStyles.container }} >
        <Typography sx={{ ...GoblinStyles.textMain }}>Reward</Typography>
        <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"}>
          {
            jobContext.questDetail.quest.reward.items.map((item) => {
              return (
                <GenericSlot boxSize={76} key={item.itemkey} rarity={item.item.rarity}  >
                  {
                    <Box sx={{ height: 56, width: 56, position: "relative" }} onClick={(ev: any) => {
                      handleClick(ev.currentTarget, item.item);
                    }} > 
                      <img draggable="false"  src={item.item.iconAsset} style={{ width: "100%" }} alt={item.item.name} />
                      <Typography sx={{...styleQtde}}>{item.qtde}</Typography>
                    </Box>
                  }
                </GenericSlot>
              )
            })
          }
        </Stack>
      </Stack>
    )
  }

  const getCraftBlock = () => {
    return (
      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 2, width: boxWidth }} elevation={6} >
        <Stack sx={{ ...MainStyles.container }} >
          <Typography sx={{ ...GoblinStyles.textMain }}>Craft Materials</Typography>
          <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"}>
            {
              jobContext.questDetail.quest.requeriments.gold > 0 ?
              <GenericSlot boxSize={76} key={"coin"} >
                {
                  <Box sx={{ height: 56, width: 56, position: "relative" }} > 
                    <img draggable="false"  src={goldPile} style={{ width: "100%" }} alt={"coin"} />
                    <Typography sx={{...styleQtde}}>{jobContext.questDetail.quest.requeriments.gold}</Typography>
                  </Box>
                }
              </GenericSlot>
              :
              <></>
            }
            {
              jobContext.questDetail.quest.requeriments.items.map((item) => {
                return (
                  <Stack sx={{ alignContent: "flex-end", alignItems: "flex-end" }}>
                    <GenericSlot boxSize={76} key={item.itemkey} rarity={item.item.rarity} >
                      {
                        <Box sx={{ height: 56, width: 56, position: "relative" }}>
                          <Box sx={{ height: 56, width: 56, position: "relative" }} onClick={(ev: any) => {
                            handleClick(ev.currentTarget, item.item);
                          }} > 
                            <img draggable="false"  src={item.item.iconAsset} style={{ width: "100%" }} alt={item.item.name} />
                            {
                              jobContext.questDetail.status == QuestStatus.Waiting ?
                              <Typography sx={{...styleQtde, flexDirection: "row", flexWrap: "nowrap"}}><label style={{ color: (item.userqtde < item.qtde ? "red" : "green") }}>{item.userqtde}</label>  /  {item.qtde}</Typography>
                              : <Typography sx={{...styleQtde}}>{item.qtde}</Typography> 
                            }
                          </Box>
                          {
                            (item.userqtde < item.qtde) && 
                            <Paper sx={{ ...MainStyles.container, p: 1, bgcolor: GoblinWarsColors.titleColor, height: 20, cursor: "pointer", 
                              top: -4, right: -4, position: "absolute", zIndex: 99 }} onClick={(ev: any) => {
                                let auxItemUser : UserItemInfo = null;
                                handleClickBuy(ev.currentTarget, {
                                  ...auxItemUser,
                                  item: item.item,
                                  qtde: item.userqtde
                                });
                            }}>
                                <Typography sx={{ ...GoblinStyles.textMain, fontSize: 12 }}>buy</Typography>
                            </Paper>
                          }
                        </Box>
                      }
                    </GenericSlot>
                  </Stack>
                )
              })
            }
          </Stack>
        </Stack>
      </Paper>
    )
  }

  const checkCanClaim = () => {
    let endDate = Moment(jobContext.questDetail.enddate).format("YYYYMMDDHHmmss");
    let now = Moment().utc().format("YYYYMMDDHHmmss");
    return endDate <= now;
  }

  const MyTimer = (param: TimerParam) => {
    const {
      seconds,
      minutes,
      hours,
      days,
      isRunning,
      start,
      pause,
      resume,
      restart,
    } = useTimer({ expiryTimestamp: param.expiryTimestamp, onExpire:  () => jobContext.getbyid(jobContext.questDetail.id) });
  
  
    return (
      <Stack sx={{ ...MainStyles.container }}>
        <Typography sx={{ ...GoblinStyles.sessionTitleText }} >{param.title}</Typography>
        <Typography sx={{ ...GoblinStyles.textMain }} >{days + " days " + hours + " hr " + minutes + " min " + seconds + " sec"}</Typography>
      </Stack>
    );
  }

  const getCurrentAffinity = () => {
    return (jobContext.questDetail.goblins && jobContext.questDetail.goblins.length > 0 ? 
      jobContext.questDetail.goblins.map(x => x.goblin.questaffinity).reduce((a, b) => (a+b)) 
      : 0);
  }

  const getCardInfo = () => {
    return (
      <Paper sx={{ ...MainStyles.container, borderRadius: 3 }} elevation={6}>
        <Box sx={{ ...MainStyles.container, position: "relative", width: boxWidth, height: 300 }}>
          <Box sx={{ position: "absolute", top: 0, width: boxWidth, height: 300 }} >
            <img draggable="false"  src={GetCardBackground(jobContext.questDetail.quest)} style={{ width: "100%", height: "100%", borderTopLeftRadius: 6, borderTopRightRadius: 6, position: "absolute", top: 0 }} />
            <Box sx={{ width: 1, height: 1, position: "absolute", top: 0, background: "linear-gradient(0deg, rgba(0,0,0,0.6) 0%, rgba(239,239,239,0.01) 50%, rgba(0,0,0,0.6) 100%);" }}></Box>
          </Box>
          <Stack sx={{ ...MainStyles.container, width: 1, position: "absolute", top: 20 }} spacing={2}>
            <Typography sx={{ ...GoblinStyles.textMain }}>{jobContext.questDetail.quest.name}</Typography>
            <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={2}>
              <Stack direction={"row"} sx={{ ...MainStyles.container, justifyContent: "space-evenly", width: 1 }}>
                <Stack sx={{ ...MainStyles.container }}>
                  <img draggable="false"  src={WorkIcon} alt={"goblin"} style={{ height: iconSize }} />
                  <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{"Job"}</Typography>
                </Stack>
              </Stack>
            </Stack>
            <Typography sx={{ ...GoblinStyles.sessionTitleText, fontStyle: "italic", px: 2  }}>“{jobContext.questDetail.quest.description}”</Typography>
          </Stack>
        </Box>
      </Paper>
    )
  }

  const getQuestRequeriments = () => {
    return (
      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 2, width: boxWidth }} elevation={6} >
        <QuestRequeriment quest={jobContext.questDetail.quest} 
                  currentAffinity={0} />
      </Paper>
    )
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
            jobContext.questDetail.status == QuestStatus.Waiting &&
            <Button sx={{ ...MainStyles.mainButton, width: 140 }} onClick={handleOpenConfirmation} >Start</Button>
          }
          <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }} >Your Power</Typography>
            <Typography sx={{ ...GoblinStyles.textMain }} >{getCurrentAffinity()}  /  {jobContext.questDetail.quest.maxpowerhash}</Typography>
          </Stack>
          <Stack direction={"row"} spacing={1} >
            <Typography sx={{ ...GoblinStyles.textMain }}>Time cost</Typography>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{
              (jobContext.loading.calculate ? 
                "..."
                :
                GetDuration(
                  (jobContext.estimateQuest ? 
                  jobContext.estimateQuest.time
                  : jobContext.questDetail.quest.timemax)*1000)
              )}</Typography>
          </Stack>
          <Stack sx={{ ...MainStyles.container, width: 1 }}>
            <Typography sx={{ ...GoblinStyles.textMain }}>Choose Your Goblins</Typography>
            <Typography sx={{ ...GoblinStyles.sessionTitleText, fontStyle: "italic" }}>Select at least {jobContext.questDetail.quest.qtdemin} goblins</Typography>
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
            dataLength={jobContext.goblins.length}
            next={async () => {
              var ret = await jobContext.listGoblins(jobContext.questDetail.questkey, false);
              if(ret)
                setLoadMore(ret.sucesso);
            }}
            hasMore={loadMore}
            loader={ jobContext.loading.listGoblins && getLoadingBlock()
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
              jobContext.goblins && jobContext.goblins.length > 0 ? jobContext.goblins.map((value) => (
                
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
                          questRequeriment={jobContext.questDetail.quest.requeriments} 
                          onElemClick={(tokenId:number) => {
                            jobContext.addGoblinQuest(jobContext.goblins.find(x => {
                              return x.idToken == tokenId;
                            }))
                          }}
                        />
                      </Box>
                    </Slide>
                    <Slide direction="left" in={checkGoblinAdd(value)} container={containerRef.current}>
                        <Box sx={{ height: "100%", width: "100%", ...MainStyles.container, position: "absolute", top: 0 }} 
                          onClick={() => {
                        var userGoblin = jobContext.questDetail.goblins.find(x => {
                          return x.goblin.idToken == value.idToken;
                        });
                        jobContext.removeGoblinQuest(userGoblin);
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

  const getQuestCompleteGoblins = () => {
    return (
    <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: isMobile ? 0.5: 2, width: goblinWidth, m: 1 }} elevation={6} >
      <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={2}>
        {
          jobContext.questDetail.status == QuestStatus.Started && jobContext.questDetail.quest.questtype == QuestType.Job && checkCanClaim() &&
          <Button sx={{ ...MainStyles.mainButton, width: 140 }} onClick={claimJob} >Claim</Button>
        }
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0}>
          <Typography sx={{ ...GoblinStyles.sessionTitleText }} >Your Power</Typography>
          <Typography sx={{ ...GoblinStyles.textMain }} >{getCurrentAffinity()}  /  {jobContext.questDetail.quest.maxpowerhash}</Typography>
        </Stack>
        {
          jobContext.questDetail.status == QuestStatus.Started && jobContext.questDetail.quest.questtype == QuestType.Job && !checkCanClaim() && 
          <>
            <MyTimer title={"Time to finish the job"} expiryTimestamp={new Date(Moment(jobContext.questDetail.enddate).add("minutes", (new Date()).getTimezoneOffset() * -1).valueOf())}  />
            <Divider variant="middle" sx={{ color: "#2b211f", width:'100%' }} />
          </>
        }
        {
          goblinList()
        }
        {
          jobContext.estimateQuest &&
          <Stack sx={{ ...MainStyles.container }}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }}>Craft Time</Typography>
            {
              <Typography sx={{ ...GoblinStyles.textMain }}>{GetDuration(jobContext.estimateQuest.time*1000)}</Typography>
            }
          </Stack>
        }
      </Stack>
    </Paper>)
  }

  return (
    <GwViewPort>
    <Stack sx={{ ...MainStyles.container }} >
      <Box sx={{ margin: "2vh 0vh 5vh 0vh;" }}>
        {
          jobContext.questDetail &&
          <Stack sx={{ display: "flex", alignContent: "flex-start", alignItems: "flex-start", justifyContent: "space-evenly", justifyItems: "normal", width: 1, flexWrap: "wrap" }} 
            direction={"row"} spacing={0} ref={containerRef}>
              <Stack sx={{ ...MainStyles.container, width: boxWidth, p: 0, pb: 2, m: 1 }} spacing={2} >
              {
                getCardInfo()
              }
              {
                getRewardCard()
              }
              {
                getCraftBlock()
              }
              {
                getQuestRequeriments()
              }
              </Stack>
              {
                jobContext.questDetail.status != QuestStatus.Waiting && 
                getQuestCompleteGoblins()
              }
              {
                jobContext.questDetail.status == QuestStatus.Waiting &&
                getChanceGoblinBlock()
              }
          </Stack>
        }
      </Box>
      {/*<GoblinQuestDetail anchorEl={openGoblinDetail} closeCb={closeOpenGoblin} id={"goblinEquip"} 
        canRemove={jobContext.questDetail && jobContext.questDetail.status == QuestStatus.Waiting} 
        removeCb={(goblin: GoblinInfo) => {
          closeOpenGoblin();
          var userGoblin = jobContext.questDetail.goblins.find(x => {
            return x.goblin.idToken == goblin.idToken;
          });
          jobContext.removeGoblinQuest(userGoblin);
      }} />*/}
      <Popover
        id={idBuy}
        open={openBuy}
        anchorEl={anchorElBuy?.anchorEl}
        onClose={handleClosePopOverBuy}
        anchorOrigin={{
          vertical: 'center',
          horizontal: 'center',
        }}
      >
        {
          anchorElBuy &&
          <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox }}>
            <Stack sx={{ ...MainStyles.container }} spacing={1.5}>
              <Typography sx={{ ...GoblinStyles.textMain }} >Buy</Typography>
              <GenericSlot boxSize={150} rarity={anchorElBuy.selectUserItem.item.rarity} >
                <img draggable="false" src={GetItemAssets(anchorElBuy.selectUserItem.item.iconAsset)} style={{ width: 120 }} />
              </GenericSlot>
              <BuySellMaterial useriteminfo={anchorElBuy.selectUserItem} isSell={false} successCb={() => {
                refreshPage();
              }} />
            </Stack>
          </Paper>
        }
      </Popover>
      <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
        <Alert onClose={handleClose} severity="error" sx={{ width: '100%' }}>
          {errMessage}
        </Alert>
      </Snackbar>
      <Dialog open={confirm} onClose={handleCloseConfirmation}>
          <DialogTitle>{"Warning"}</DialogTitle>
          <DialogContent>
              <DialogContentText>
                  Are you sure? This operation can't be undone !
              </DialogContentText>
          </DialogContent>
          <DialogActions>
              <Button onClick={startExecuteQuest}>Yes</Button>
              <Button onClick={handleCloseConfirmation}>No</Button>
          </DialogActions>
      </Dialog>
      {
        openResult &&
        getResultPopup()
      }
      {
        openStart && 
        getStartPopup()
      }
      {
        jobContext.loading.detail && 
        <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => 99 }}
            open={true}
        >
            <CircularProgress color="inherit" />
        </Backdrop>
      }
    </Stack>
    <ItemPopover anchorEl={anchorEl} equipCb={() => {}} moreDetail={(item: ItemInfo) => {
      history.push("/equipment?key=" + item.key);
    }} loading={false} open={open} closeCb={handleClosePopOver} id={id} canEquip={false} firstView={1} />
    </GwViewPort>
  )
}