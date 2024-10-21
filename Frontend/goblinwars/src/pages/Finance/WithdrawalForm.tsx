import { Alert, Backdrop, Box, Button, CircularProgress, Grid, IconButton, Paper, Snackbar, Stack, TextField, Typography } from "@mui/material";
import { SxProps } from "@mui/system";
import { useState } from "react";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { OulinedInput } from "../../components/OutlinedInput";
import CloseIcon from '@mui/icons-material/Close';
import { isMobile } from 'react-device-detect';
import gobiCoin from '../../assets/images/coins/gobiCoin.png';
import gobiCoinOrange from '../../assets/images/coins/gobiCoinOrange.png';
import FinanceInfo from "../../dto/domain/FinanceInfo";
import Moment from "moment";

interface WithdrawalFormParam {
  close: () => void,
  withdrawl: (value: number) => void,
  calculateFee: (value: number) => void,
  currentFee: number,
  finance: FinanceInfo,
  loading: boolean,
  loadingCalculate: boolean
}

const textInputProps = {
  color: "white",
  inputMode: 'numeric', 
  pattern: '[0-9]*'
}

export function WithdrawalForm(param: WithdrawalFormParam) {
  
  //const [dollarPrice, setDollarPrice] = useState<number>(0);
  const [canWithdrawl, setCanWithdrawl] = useState<boolean>(false);
  const [canCalculate, setCanCalculate] = useState<boolean>(false);
  const [valueGobi, setValueGobi] = useState<number>(null);
  const [errMessage, setErrMessage] = useState("");
  const [open, setOpen] = useState(false);

  const showError = (message: string) => {
    setErrMessage(message);
    setOpen(true);
  }

  const handleClose = (ev: any) => {
    if (ev?.reason === 'clickaway') {
      return;
    }

    setOpen(false);
  };

  return (
    <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
      <Paper sx={{ ...MainStyles.popUp, bgcolor: "#2b211f" }}>
        <Stack sx={{...MainStyles.container}}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            
            <Stack direction={"row"} sx={{ display: "flex", justifyContent: "space-between", pl: 1, pr: 1 }}>
                <Typography sx={{ ...GoblinStyles.textMain }} >WITHDRAWAL GOBI</Typography>
                <IconButton onClick={param.close}>
                  <CloseIcon sx={{ color: "white" }} fontSize={"large"} />
                </IconButton>
              </Stack>
          </Paper>
          <Stack sx={{ ...MainStyles.container, p: 2 }} spacing={2}>
            <Grid container spacing={2} sx={{ ...MainStyles.container }}>
              <Grid item xs={4} textAlign={"right"}>
                <Typography sx={{ ...GoblinStyles.textMain }}>Balance:</Typography>
              </Grid>
              <Grid item xs={8}>
                <Stack direction="row" spacing={1}>
                  <img draggable="false"  src={gobiCoin} style={{width: "30px", height: "30px"}} />
                  <Typography sx={{ ...GoblinStyles.textMain }} >{param.finance?.gobioncloudwallet.toFixed(4)}</Typography>
                </Stack>
              </Grid>
              {param.finance?.lastwithdrawl ?
              <>
              <Grid item xs={4} textAlign={"right"}>
                <Typography sx={{ ...GoblinStyles.textMain }}>Last Withdrawal:</Typography>
              </Grid>
              <Grid item xs={8}>
                <Stack direction="row" spacing={1}>
                  <Typography sx={{ ...GoblinStyles.textMain }} >{Moment(param.finance?.lastwithdrawl).format("MM/DD/YYYY [at] HH:mm:ss [GMT]")}</Typography>
                </Stack>
              </Grid>
              </>
              : <></>
              }
              <Grid item xs={4} textAlign={"right"}>
                <Typography sx={{ ...GoblinStyles.textMain }}>Withdraw:</Typography>
              </Grid>
              <Grid item xs={8}>
                <Stack direction="row" spacing={1} >
                  <OulinedInput  id="price" type="number" label="Amount" value={valueGobi} 
                    onChange={ async (e: any) => { 
                      setValueGobi(e.target.value); 
                      setCanWithdrawl(false);
                      setCanCalculate((e.target.value > 0));
                    }}
                    InputLabelProps={{ sx: { ...textInputProps } }}
                    InputProps={{ sx: { ...textInputProps } }}
                    FormHelperTextProps={{ sx: { ...textInputProps } }}
                    sx={{ width: "100%"}}
                    //helperText="Value in GOBI you wanna deposit"
                  />
                </Stack>
              </Grid>
              <Grid item xs={4} textAlign={"right"}>
                <Typography sx={{ ...GoblinStyles.textMain }}>Fee:</Typography>
              </Grid>
              <Grid item xs={8}>
                <Stack direction="row" spacing={1}>
                  <img draggable="false"  src={gobiCoinOrange} style={{width: "30px", height: "30px"}} />
                  <Typography sx={{ ...GoblinStyles.textMain, color: "red" }} >{param.currentFee}</Typography>
                </Stack>
              </Grid>
              <Grid item xs={4} textAlign={"right"}>
                <Typography sx={{ ...GoblinStyles.textMain }}>Total:</Typography>
              </Grid>
              <Grid item xs={8}>
                <Stack direction="row" spacing={1}>
                  <img draggable="false"  src={gobiCoin} style={{width: "30px", height: "30px"}} />
                  <Typography sx={{ ...GoblinStyles.textMain }} >{valueGobi - param.currentFee}</Typography>
                </Stack>
              </Grid>
            </Grid>
            <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>
              NOTE: {param.finance?.withdrawalmin} GOBI minimum withdrawal. 
              To pay minimal fee you need wait for {param.finance?.daysfornofee} days
              {param.finance?.nextwithdrawlwithoutfee ? 
                ", you must wait until " + 
                Moment(param.finance?.nextwithdrawlwithoutfee).format("MM/DD/YYYY [at] HH:mm [GMT]")
                : ""
              }
              . To withdraw early you will need to pay a fee of up to {param.finance?.maxfeepercent}%.
              <br />
              Mininal fee is {param.finance?.minimalgobifee} GOBI.<br />
              Withdrawl pool have {param.finance?.hotwalletgobi} GOBI and {param.finance?.hotwalletbnb.toFixed(5)} BNB.<br />
            </Typography>
            {
              canWithdrawl ?
              <Button sx={{ ...MainStyles.mainButton, color: "white", width: 200 }} 
                onClick={() => {
                  if(param.loading)
                    return;
                  if (!(valueGobi > 0)) {
                    showError("Withdraw amount must be greater than 0.")
                    return;
                  }
                  param.withdrawl(valueGobi);
                }} >{param.loading ? "WITHDRAWING..." : "WITHDRAWL"}</Button>
              :
              <Button sx={{ ...MainStyles.mainButton, color: "white", width: 200 }} disabled={!canCalculate} 
                onClick={() => {
                  if (!(valueGobi > 0)) {
                    showError("Deposit amount must be greater than 0.")
                    return;
                  }
                  let _canWithdrawl = true;
                  if (!(valueGobi > 0)) {
                    _canWithdrawl = false;
                  }
                  if (valueGobi < param.finance.withdrawalmin) {
                    showError("Deposit amount must be greater than " + param.finance.withdrawalmin + ".")
                    _canWithdrawl = false;
                  }
                  if (valueGobi > param.finance.withdrawallimit) {
                    showError("Deposit amount must be lower than " + param.finance.withdrawallimit + ".")
                    _canWithdrawl = false;
                  }
                  setCanWithdrawl(_canWithdrawl);
                  param.calculateFee(valueGobi);
                }} >{param.loadingCalculate ? "CALCULATING..." : "CALCULATE FEE"}</Button> 
            }
          </Stack>
          
        </Stack>
      </Paper>
      <Snackbar open={open} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
        <Alert onClose={handleClose} severity="error" sx={{ width: '100%' }}>
          {errMessage}
        </Alert>
      </Snackbar>
      {
          param.loading &&
          <Backdrop
              sx={{ color: '#fff', zIndex: (theme) => 99 }}
              open={true}
          >
            <Stack sx={{ ...MainStyles.container }}>
              <CircularProgress color="inherit" />
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>Do not close this window</Typography>
            </Stack>
          </Backdrop>
      }
    </Box>
  )
}