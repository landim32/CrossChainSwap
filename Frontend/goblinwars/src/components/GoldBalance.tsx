import { SxProps } from '@mui/system';
import { CoinStyles } from '../utils/style';
import goldCoin from '../assets/images/coins/goldCoin.png';
import { useContext, useState } from 'react';
import { GuideCoin } from '../dto/business/GuideCoin';
import { Box, Paper, Tooltip, Typography, Theme } from '@mui/material';
import { NoticePopup } from './NoticePopup';
import { title } from 'process';
import GoblinUserContext from '../contexts/goblinUser/GoblinUserContext';
import { useHistory } from 'react-router-dom';

const goldBackground : SxProps<Theme> = {
  ...CoinStyles.coinBackground,
  background: "linear-gradient(90deg, #b8941c 0%, #e7e612 115%)",
}

export function GoldBalance() {
  const goblinUserContext = useContext(GoblinUserContext);
  const history = useHistory();
  const openGoldPopup = () => {
    history.push("/goldmarket");
  }


  return (
    <>
      <Tooltip title="Balance of Gold"> 
      <Box sx={{ width: "150px", height: "30px" }} >
        <Box sx={{ width: "146px", height: "30px", position: "relative", cursor: "pointer" }} onClick={openGoldPopup}>
          <Paper sx={{ ...goldBackground, position: "absolute", left: 6, top: 2.5 }}>
              <Typography sx={{ ...CoinStyles.coinText, mr: 1 }} >{ !goblinUserContext.balance ? "..." : goblinUserContext.balance.goldBalance.toFixed(4) }</Typography>
          </Paper>
          <Box sx={{ left: 0, top: 0, position: "absolute" }}>
              <img draggable="false"  src={goldCoin} alt={"Gold"} style={{ height: "35px"  }} />
          </Box>
        </Box>
      </Box>
      </Tooltip>
    </>
  )
}