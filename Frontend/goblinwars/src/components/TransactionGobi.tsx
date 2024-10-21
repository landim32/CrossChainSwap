import { Box, Button, IconButton, Paper, Stack, Theme, Typography } from "@mui/material";
import { SxProps } from "@mui/system";
import { GoblinStyles, MainStyles } from "../utils/style";
import CloseIcon from '@mui/icons-material/Close';
import { isMobile } from 'react-device-detect';
import ArrowRightAltIcon from '@mui/icons-material/ArrowRightAlt';
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import gobiCoin from '../assets/images/coins/gobiCoin.png';

interface TransactionGobiParam {
  //editCb: (name: string) => void
  close: () => void,
  approve: () => void,
  gobiCost: number,
  text: string
}

export function TransactionGobi(param: TransactionGobiParam) {

  return (
    <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
      <Paper sx={{ ...MainStyles.popUp, bgcolor: "#2b211f" }}>
        <Stack sx={{...MainStyles.container}}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            <Stack direction={"row"} sx={{ ...MainStyles.container, justifyContent: "space-between", pl: 1, pr: 1 }}>
                <Typography sx={{ ...GoblinStyles.textMain }} >GOBI Transaction</Typography>
                <IconButton onClick={param.close}>
                  <CloseIcon sx={{ color: "white" }} fontSize={"large"} />
                </IconButton>
              </Stack>
          </Paper>
          <Stack sx={{ ...MainStyles.container, width: isMobile ? 350 : 500, p: 2 }} spacing={2}>
            <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center", ml: 1, mr: 1 }} >{param.text}</Typography>
            <Stack direction="row" spacing={isMobile ? 1 : 3} sx={{ ...MainStyles.container }}>
              <img draggable="false"  src={gobiCoin} alt={"GOBI"} style={{ height: 32 }} />
              <Stack sx={{ ...MainStyles.container }}>
                <Typography sx={{ ...GoblinStyles.textMain }} >{param.gobiCost.toFixed(2)}</Typography>
                <Typography sx={{ ...GoblinStyles.sessionTitleText }} >GOBI</Typography>
              </Stack>
            </Stack>
            <Stack direction="row" spacing={3}>
              <Button sx={{ ...MainStyles.mainButton, color: "white", width: 95 }} onClick={() => {
                   param.close();
                }} >{"Cancel"}</Button>  
              <Button sx={{ ...MainStyles.mainButton, color: "white", width: 95 }} onClick={() => {
                  param.approve();
                  param.close();   
                }} >{"Confirm"}</Button> 
            </Stack>
          </Stack>
          
        </Stack>
      </Paper>
    </Box>
  )
}