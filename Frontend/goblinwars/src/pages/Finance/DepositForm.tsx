import { Alert, Backdrop, Box, Button, CircularProgress, IconButton, Paper, Snackbar, Stack, Typography } from "@mui/material";
import { useState } from "react";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { OulinedInput } from "../../components/OutlinedInput";
import CloseIcon from '@mui/icons-material/Close';
import { isMobile } from 'react-device-detect';
import gobiCoinOrange from '../../assets/images/coins/gobiCoinOrange.png';

interface DepositFormParam {
  close: () => void,
  deposit: (tokenId: number) => void,
  valueGobi: number,
  loading: boolean,
}

const textInputProps = {
  color: "white",
  inputMode: 'numeric', 
  pattern: '[0-9]*'
}

export function DepositForm(param: DepositFormParam) {

  //const [dollarPrice, setDollarPrice] = useState<number>(0);
  const [valueGobi, setValueGobi] = useState<number>(0);
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
                <Typography sx={{ ...GoblinStyles.textMain }} >DEPOSIT GOBI</Typography>
                <IconButton onClick={param.close}>
                  <CloseIcon sx={{ color: "white" }} fontSize={"large"} />
                </IconButton>
              </Stack>
          </Paper>
          <Stack sx={{ ...MainStyles.container, width: isMobile ? 350 : 500, p: 2 }} spacing={2}>
            <Stack direction="row" spacing={isMobile ? 0 : 3}>
              <img draggable="false"  src={gobiCoinOrange} style={{width: "35px", height: "35px"}} />
              <Typography sx={{ ...GoblinStyles.textMain }} >{param.valueGobi}</Typography>
            </Stack>
            <Stack direction="row" spacing={isMobile ? 0 : 3}>
              <OulinedInput id="price" type="number" label="Value In GOBI" value={valueGobi} 
                onChange={(e: any) => { setValueGobi(e.target.value); }}
                InputLabelProps={{ sx: { ...textInputProps } }}
                InputProps={{ sx: { ...textInputProps } }}
                FormHelperTextProps={{ sx: { ...textInputProps } }}
                sx={{ width: "100%"}}
                helperText="Value in GOBI you wanna deposit">
              </OulinedInput>
            </Stack>
            <Stack direction="row" spacing={3}>
              <Button sx={{ ...MainStyles.mainButton, color: "white" }} onClick={() => {
                  if(param.loading)
                    return;
                  if (!(valueGobi > 0)) {
                    showError("Deposit amount must be greater than 0.");
                    return;
                  }
                  if (valueGobi > param.valueGobi) {
                    showError("Out of balance.");
                    return;
                  }
                  param.deposit(valueGobi);
                }} >{param.loading ? "DEPOSITING..." : "DEPOSIT"}</Button> 
            </Stack>
          </Stack>
          
        </Stack>
      </Paper>
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
      <Snackbar open={open} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
        <Alert onClose={handleClose} severity="error" sx={{ width: '100%' }}>
          {errMessage}
        </Alert>
      </Snackbar>
    </Box>
  )
}