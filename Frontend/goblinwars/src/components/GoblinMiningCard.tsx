import { Box, CircularProgress, Grid, Paper, Stack, SxProps, Theme, Typography, Button, Dialog, Alert, AlertColor, Snackbar } from "@mui/material";
import { useState } from "react";
import { GoblinStyles, MainStyles } from "../utils/style";
import PickaxeIcon from '../assets/images/menu/pickaxe.png';
import { GoblinHealthGood, GoblinHealthMedium, GoblinHealthLow } from './GoblinProgress';
import { useTimer } from "react-timer-hook";
import Moment from 'moment';
import gobiCoin from '../assets/images/coins/gobiCoin.png';
import AccessTimeIcon from '@mui/icons-material/AccessTime';
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import { TransactionGobi } from "./TransactionGobi";
import { GoblinMining } from "../dto/domain/GoblinMining";
import { useHistory } from "react-router-dom";
// @ts-ignore
import Spritesheet from 'react-responsive-spritesheet';
import { GoblinInfo } from "../dto/domain/GoblinInfo";

interface GoblinMiningCardParam {
  goblinMining: GoblinInfo;
  rechargeCb: (goblin: GoblinInfo) => void;
  stopMining: (goblin: GoblinInfo) => void;
  walletBalance: number;
  loading: boolean;
  loadingMining: boolean; 
  titleSectionStyle: SxProps<Theme>;
  statsText: SxProps<Theme>;
  subInfoStyle: SxProps<Theme>;
  infoText: SxProps<Theme>;
  geneIconSize: number;
  isMobile: boolean;
}

interface TimerParam {
  expiryTimestamp: Date;
}

export function GoblinMiningCard(param: GoblinMiningCardParam) {
  const [openDialog, setOpenDialog] = useState(false);
  const [message, setMessage] = useState("");
  const [severity, setSeverity] = useState<AlertColor>("success");
  const [transactionGobi, setTransactionGobi] = useState(false);
  const history = useHistory();

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

  const goblinMining = param.goblinMining;

  return (
    <>
      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 0, width: 300 }}>
          <Grid container sx={{ ...MainStyles.container, p: 1 }}>
            <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1 }}>
              <Typography sx={{ ...GoblinStyles.textMain }} flexWrap={"wrap"} >{goblinMining.name}</Typography>
            </Grid>
            <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1 }}>
              <Stack direction={"row"} spacing={1} sx={{ ...MainStyles.container, width: 1, alignItems: "flex-start" }} >
                  <Box sx={{ ...MainStyles.container, height: param.geneIconSize, width: param.geneIconSize, position: "relative" }}>
                    <Box sx={{ transform: "scale(" + (param.geneIconSize/180).toString() + ");", position: "absolute", bottom: (180*(param.geneIconSize/180)) - 15}}>
                      {
                        goblinMining.goblinMining.exhausted  ? 
                          <Spritesheet 
                              image={goblinMining.spritetired} 
                              steps={1}
                              fps={9}
                              timeout={0}
                              widthFrame={180}
                              heightFrame={180}
                              autoplay={true}
                              loop={true}
                              key={goblinMining.idToken}
                          />
                          :
                          <Spritesheet 
                          image={goblinMining.sprite} 
                              steps={12}
                              fps={9}
                              timeout={0}
                              widthFrame={180}
                              heightFrame={180}
                              autoplay={true}
                              loop={true}
                              key={goblinMining.idToken}
                          />
                      }
                    </Box>
                  </Box>
                  <Stack sx={{ ...MainStyles.container, flexGrow: 1}} spacing={0.3} >
                      {
                        goblinMining.goblinMining.energypercent >= 66 ?
                        <GoblinHealthGood sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f" }} variant={"determinate"}
                            value={goblinMining.goblinMining.energypercent} />
                        : goblinMining.goblinMining.energypercent >=33 ?
                        <GoblinHealthMedium sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f" }} variant={"determinate"}
                            value={goblinMining.goblinMining.energypercent} />
                        :
                        <GoblinHealthLow sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f" }} variant={"determinate"}
                            value={goblinMining.goblinMining.energypercent} /> 
                      }
                    <Typography sx={{ ...param.subInfoStyle }} flexWrap={"wrap"} >{goblinMining.goblinMining.energypercent}% of Energy</Typography>
                  </Stack>
              </Stack>
            </Grid>
            {
              goblinMining.goblinMining.exhausted && 
              <>
                <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1, width: 1 }}>
                    <Stack sx={{ ...MainStyles.container, width: 1 }} >
                      <Typography sx={{ ...param.infoText, textAlign: "center" }} flexWrap={"wrap"} >
                        The goblin has been exhausted from mining since {Moment(goblinMining.goblinMining.chargeexpiration).format("MM/DD/YYYY [at] HH:mm:ss [(GMT)]")}. You need to recharge your energy to continue mining.
                      </Typography>
                    </Stack>
                </Grid>
                <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                    <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                        <img draggable="false"  src={gobiCoin} style={{ height: param.geneIconSize }} alt={"Cost GOBI"} />
                        <Stack sx={{ ...MainStyles.container }} spacing={0} >
                            <Typography sx={{ ...param.statsText }} flexWrap={"wrap"} >{goblinMining.goblinMining.energycost.toFixed(2)}</Typography>
                            <Typography sx={{ ...param.subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Charge Cost</Typography>
                        </Stack>
                    </Stack>
                </Grid>
                <Grid item xs={6} sx={{ ...MainStyles.container, mb: 1 }}>
                    <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                        <AccessTimeIcon sx={{ color: GoblinWarsColors.titleColor }} fontSize={"large"} />
                        <Stack sx={{ ...MainStyles.container }} spacing={0} >
                            <Typography sx={{ ...param.statsText }} flexWrap={"wrap"} >{goblinMining.goblinMining.chargeduration} Hours</Typography>
                            <Typography sx={{ ...param.subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Charge Duration</Typography>
                        </Stack>
                    </Stack>
                </Grid>
                
              </>
            }
            {
              !goblinMining.goblinMining.exhausted && 
              <>
                <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1, width: 1 }}>
                    <Stack sx={{ ...MainStyles.container, width: 1 }} >
                      <MyTimer expiryTimestamp={new Date(Moment(goblinMining.goblinMining.chargeexpiration).add("minutes", (new Date()).getTimezoneOffset() * -1).valueOf())} />
                      <Typography sx={{ ...param.subInfoStyle }} flexWrap={"wrap"} >Energy Countdown</Typography>
                    </Stack>
                </Grid>
                <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1 }}>
                  <Stack direction={"row"} spacing={1} sx={{ justifyContent: "flex-start", alignItems: "center" }} >
                      <img draggable="false"  src={gobiCoin} style={{ height: param.geneIconSize }} alt={"Cost GOBI"} />
                      <Stack sx={{ ...MainStyles.container }} spacing={0} >
                          <Typography sx={{ ...param.statsText }} flexWrap={"wrap"} >{goblinMining.goblinMining.energycost.toFixed(2)}</Typography>
                          <Typography sx={{ ...param.subInfoStyle, mt: -1 }} flexWrap={"wrap"} >Charge Cost</Typography>
                      </Stack>
                  </Stack>
                </Grid>
              </>
            }
            <Grid item xs={12} sx={{ ...MainStyles.container, mb: 1, width: 1 }}>
              <Stack spacing={1} sx={{ ...MainStyles.container }} >
                <Stack direction={"row"} spacing={0.5} sx={{ ...MainStyles.container }} >
                  <Button sx={{ ...MainStyles.mainButton, width: 100 }} onClick={() => {
                    history.push("/goblin?tokenId=" + goblinMining.idToken);
                  }} >{"Details"}</Button>
                  <Button sx={{ ...MainStyles.mainButton, width: 150 }} onClick={() => {
                    param.stopMining(goblinMining);
                  }} >{param.loadingMining ? "Stopping..." : "Stop Mining"}</Button>
                </Stack>
                {
                  (param.walletBalance || param.walletBalance == 0) ?
                  <Button sx={{ ...MainStyles.mainButton, width: 150 }} onClick={() => {
                    if(param.loading)
                      return;
                    if(param.walletBalance >= goblinMining.goblinMining.energycost) {
                      openTransaction();
                    }
                    else{
                      showDialog("Insufficient GOBI for transaction ", "error");
                    }
                  }} >{param.loading ? "Recharging..." : "Recharge"}</Button>
                  : <CircularProgress />
                }
              </Stack>
              
            </Grid>
        </Grid>
      </Paper>
      <Dialog
          open={transactionGobi}
          keepMounted
          onClose={closeTransaction}
      >
        {
          !param.loading && param.walletBalance &&
          <TransactionGobi close={closeTransaction} approve={() => { param.rechargeCb(goblinMining); }} 
            gobiCost={goblinMining.goblinMining.energycost} 
            text={"Are you sure you would like to make the goblin energy recharge (Value is estimated and may vary depending on mining entropy) ?"} />
        }
      </Dialog>
      <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
        <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
          {message}
        </Alert>
      </Snackbar>
    </>
  )
}