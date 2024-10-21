import { Box, Button, Paper, Stack, TextField, Theme, Typography } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { SxProps } from "@mui/system";
import { useState } from "react";
import { GoblinStyles, MainStyles } from "../utils/style";
import { OulinedInput } from "./OutlinedInput";
import gobiCoin from '../assets/images/coins/gobiCoin.png';
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';

interface BuyGoblinParam {
  onBuy: () => void
  btnText: string;
  btnLoadingText: string;
  loading: boolean
}

export function BuyGoblin(param: BuyGoblinParam) {

  return (
    <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
      <Paper sx={{ ...MainStyles.popUp, bgcolor: "#2b211f" }}>
        <Stack sx={{...MainStyles.container}}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }} >BUY A RANDOM GOBLIN</Typography>
          </Paper>
          <Stack sx={{ width: isMobile ? 300 : 500, p: 2, alignItems: "center" }} spacing={2}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }}>Mint one random Goblin NFT</Typography>
            <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1}>
              <Typography sx={{ ...GoblinStyles.textMain }} >Price 50 GOBI</Typography>
              <img draggable="false"  src={gobiCoin} style={{ height: "25px" }} alt="GOBI" />
            </Stack>
            <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >WARNING! For a limited time only! Just as long as we don't have a marketing place.</Typography>
            <Box sx={{ width: 1, display: "flex", alignItems: "center", alignContent: "center", justifyContent: "flex-end" }}>
              <Box sx={{ width: "150px", alignItems: "center" }}>
                <Button sx={{ ...MainStyles.mainButton, alignItems: "center", color: "white" }} onClick={() => {
                  param.onBuy();
                }} >{ param.loading ? param.btnLoadingText : param.btnText}</Button>  
              </Box>
            </Box>
          </Stack>
          
        </Stack>
      </Paper>
    </Box>
  )
}