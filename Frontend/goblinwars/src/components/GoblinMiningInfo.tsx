import { Box, CircularProgress, Grid, Paper, Stack, SxProps, Theme, Typography, Button, Dialog, Alert, AlertColor, Snackbar } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import GoblinUserContext from "../contexts/goblinUser/GoblinUserContext";
import { BalanceInfo } from "../dto/domain/BalanceInfo";
import { GoblinInfo } from "../dto/domain/GoblinInfo";
import { GoblinStyles, MainStyles } from "../utils/style";
import PickaxeIcon from '../assets/images/menu/pickaxe.png';
import { GoblinProgress } from "./GoblinProgress";
import { useTimer } from "react-timer-hook";
import Moment from 'moment';
import MiningContext from "../contexts/mining/MiningContext";
import gobiCoin from '../assets/images/coins/gobiCoin.png';
import Wallet from '../assets/images/wallet.png';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import { TransactionGobi } from "./TransactionGobi";
// @ts-ignore
import Spritesheet from 'react-responsive-spritesheet';
import { GoblinHealthGood, GoblinHealthMedium, GoblinHealthLow } from './GoblinProgress';
import useInterval from '@use-it/interval';

interface GoblinMiningInfoParam {
  goblinInfo?: GoblinInfo;
  rechargeCb: (goblin: GoblinInfo) => void;
  changeMining: () => void;
  loadingMining: boolean; 
  loading: boolean; 
  titleSectionStyle: SxProps<Theme>;
  statsText: SxProps<Theme>;
  subInfoStyle: SxProps<Theme>;
  infoText: SxProps<Theme>;
  geneIconSize: number;
}

interface TimerParam {
  expiryTimestamp: Date;
}

export function GoblinMiningInfo(param: GoblinMiningInfoParam) {
  const goblinUserContext = useContext(GoblinUserContext);
  const miningContext = useContext(MiningContext);
  const [goblinInfo, setGoblinInfo] = useState(param.goblinInfo);
  const [openDialog, setOpenDialog] = useState(false);
  const [message, setMessage] = useState("");
  const [severity, setSeverity] = useState<AlertColor>("success");
  const [transactionGobi, setTransactionGobi] = useState(false);

  useInterval(() => {
    miningContext.getGoblinMining(param.goblinInfo.id).then(ret => {
      if(ret.sucesso)
      setGoblinInfo({ ...goblinInfo, goblinMining: ret.dataResult });
    });
  }, 30000);

  function MyTimer(props: TimerParam) {
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
    } = useTimer({ expiryTimestamp: props.expiryTimestamp, onExpire:  () => console.warn('onExpire called') });
  
    let countDownStyle : SxProps<Theme> = {
      ...param.statsText
    }
    return (
      <Typography sx={{ ...countDownStyle }} >{days + " days " + hours + " hr " + minutes + " min " + seconds + " sec"}</Typography>
    );
  }
   
  const handleClose = (ev: any) => {
      if (ev?.reason === 'clickaway') {
          return;
      }
      setOpenDialog(false);
  };

  const showDialog = (message: string, severity: AlertColor) => {
      setSeverity(severity);
      setMessage(message);
      setOpenDialog(true);
  }

  const openTransaction = () => {
    setTransactionGobi(true);
  };

  const closeTransaction = () => {
    setTransactionGobi(false);
  };

  return (
    <>
      <Paper sx={{ ...GoblinStyles.sessionTitle }}>
          <Typography sx={{ ...param.titleSectionStyle }} >Mining</Typography>
      </Paper>
      { goblinInfo ?
          <>
              <Grid container sx={{ ...MainStyles.container, p: 1 }}>
                {
                  goblinInfo.status== 3 &&
                  <>
                    <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1 }}>
                      <Stack direction={"row"} spacing={1} sx={{ ...MainStyles.container, width: 1, alignItems: "flex-start" }} >
                          <Box sx={{ ...MainStyles.container, height: param.geneIconSize, width: param.geneIconSize, position: "relative" }}>
                            <Box sx={{ transform: "scale(" + (param.geneIconSize/180).toString() + ");", position: "absolute", bottom: (180*(param.geneIconSize/180)) - 15}}>
                              <Spritesheet 
                                image={goblinInfo.goblinMining.exhausted ? goblinInfo.spritetired: goblinInfo.sprite} 
                                steps={goblinInfo.goblinMining.exhausted ? 1 : 12}
                                fps={9}
                                timeout={0}
                                widthFrame={180}
                                heightFrame={180}
                                autoplay={true}
                                loop={true}
                              />
                            </Box>
                          </Box>
                          
                          <Stack sx={{ ...MainStyles.container, flexGrow: 1}} spacing={0.3} >
                            {
                              goblinInfo.goblinMining.energypercent >= 66 ?
                              <GoblinHealthGood sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f" }} variant={"determinate"}
                                  value={goblinInfo.goblinMining.energypercent} />
                              : goblinInfo.goblinMining.energypercent >=33 ?
                              <GoblinHealthMedium sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f" }} variant={"determinate"}
                                  value={goblinInfo.goblinMining.energypercent} />
                              :
                              <GoblinHealthLow sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f" }} variant={"determinate"}
                                  value={goblinInfo.goblinMining.energypercent} /> 
                            }
                            <Typography sx={{ ...param.subInfoStyle }} flexWrap={"wrap"} >{goblinInfo.goblinMining.energypercent}% of Energy</Typography>
                          </Stack>
                      </Stack>
                    </Grid>
                    {
                      goblinInfo.goblinMining.exhausted && 
                      <>
                        <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1, width: 1 }}>
                            <Stack sx={{ ...MainStyles.container, width: 1 }} >
                              <Typography sx={{ ...param.infoText, textAlign: "center" }} flexWrap={"wrap"} >
                                The goblin has been exhausted from mining since {Moment(goblinInfo.goblinMining.chargeexpiration).format("MM/DD/YYYY [at] HH:mm:ss (GMT)")}. You need to recharge your energy to continue mining.
                              </Typography>
                            </Stack>
                        </Grid>
                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                <img draggable="false"  src={gobiCoin} style={{ height: param.geneIconSize }} alt={"Cost GOBI"} />
                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                    <Typography sx={{ ...param.statsText }} flexWrap={"wrap"} >{goblinInfo.goblinMining.energycost.toFixed(2)}</Typography>
                                    <Typography sx={{ ...param.subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Charge Cost</Typography>
                                </Stack>
                            </Stack>
                        </Grid>
                        <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                <AccessTimeIcon sx={{ color: GoblinWarsColors.titleColor }} fontSize={"large"} />
                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                    <Typography sx={{ ...param.statsText }} flexWrap={"wrap"} >{goblinInfo.goblinMining.chargeduration} Hours</Typography>
                                    <Typography sx={{ ...param.subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Charge Duration</Typography>
                                </Stack>
                            </Stack>
                        </Grid>
                      </>
                    }
                    {
                      !goblinInfo.goblinMining.exhausted && 
                      <>
                        <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1, width: 1 }}>
                            <Stack sx={{ ...MainStyles.container, width: 1 }} >
                              <MyTimer expiryTimestamp={new Date(Moment(goblinInfo.goblinMining.chargeexpiration).add("minutes", (new Date()).getTimezoneOffset() * -1).valueOf())} />
                              <Typography sx={{ ...param.subInfoStyle }} flexWrap={"wrap"} >Energy Countdown</Typography>
                            </Stack>
                        </Grid>
                        <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1 }}>
                            <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                                <img draggable="false"  src={gobiCoin} style={{ height: param.geneIconSize }} alt={"Cost GOBI"} />
                                <Stack sx={{ ...MainStyles.container }} spacing={0} >
                                    <Typography sx={{ ...param.statsText }} flexWrap={"wrap"} >{goblinInfo.goblinMining.energycost.toFixed(2)}</Typography>
                                    <Typography sx={{ ...param.subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Charge Cost</Typography>
                                </Stack>
                            </Stack>
                        </Grid>
                      </>
                    }
                    {
                      goblinUserContext.balance && !goblinUserContext.loading &&
                      <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1, width: 1 }}>
                          <Button sx={{ ...MainStyles.mainButton }} onClick={() => {
                            if(param.loading)
                              return;
                            if(goblinUserContext.balance.cloudWalletGobiBalance >= goblinInfo.goblinMining.energycost) {
                              openTransaction();
                            }
                            else{
                              showDialog("Insufficient GOBI for transaction ", "error");
                            }
                          }} >{param.loading ? "Recharging..." : "Recharge"}</Button>
                      </Grid>
                    }
                    <Dialog
                        open={transactionGobi}
                        keepMounted
                        onClose={closeTransaction}
                    >
                      {
                        !param.loading && goblinInfo && goblinUserContext.balance && !goblinUserContext.loading && 
                        <TransactionGobi close={closeTransaction} approve={() => { param.rechargeCb(goblinInfo); }} 
                          gobiCost={goblinInfo.goblinMining.energycost} 
                          text={"Are you sure you would like to make the goblin energy recharge (Value is estimated and may vary depending on mining entropy) ?"} />
                      }
                    </Dialog>
                  </>
                }
                <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1 }}>
                  <Box sx={{ width: 1 }}>
                    <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={param.changeMining}>{
                        !param.loadingMining ?
                        (goblinInfo.status == 3 ? "Stop mining" : "Start mining")
                        :
                        (goblinInfo.status == 3 ? "Stoping..." : "Starting...")
                    }</Button>
                  </Box>
                </Grid>
            </Grid>
          </>
          : <CircularProgress />
      }
      
      <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
        <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
          {message}
        </Alert>
      </Snackbar>
    </>
  )
}