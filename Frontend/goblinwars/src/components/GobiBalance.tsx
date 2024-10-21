import { Box, Modal, Paper, Theme, Tooltip, Typography } from "@mui/material";
import { useContext, useState } from "react";
import GoblinUserContext from "../contexts/goblinUser/GoblinUserContext";
import { CoinStyles } from "../utils/style";
import { GobiPopup } from "./GobiPopup";
import { SxProps } from '@mui/system';
import gobiCoin from '../assets/images/coins/gobiCoin.png';
import { useHistory } from "react-router";

const gobiBackground : SxProps<Theme> = {
  ...CoinStyles.coinBackground,
  background: "linear-gradient(90deg, rgba(21,60,77,1) 0%, rgba(132,214,225,1) 115%)",
}

export function GobiBalance() {
  const goblinUserContext = useContext(GoblinUserContext);
  const history = useHistory();

  //const [showGobiPopup, setShowGobiPopup] = useState(false);
  const openGobiPopup = () => {
      //setShowGobiPopup(true);
      history.push("/finance");
  }
  /*
  const closeGobiPopup = () => {
      setShowGobiPopup(false);
  }
  */

  
  return ( 
    <>
      <Tooltip title="Balance of GOBI"> 
        <Box sx={{ width: "150px", height: "30px", position: "relative", cursor: "pointer" }} onClick={openGobiPopup}>
            <Paper sx={{ ...gobiBackground, position: "absolute", left: 2, top: 2.5 }}>
                <Typography sx={{ ...CoinStyles.coinText, mr: 1 }} >{ !goblinUserContext.balance ? "..." : goblinUserContext.balance.gobiBalance.toFixed(4) }</Typography>
            </Paper>
            <Box sx={{ left: 0, top: 0, position: "absolute" }}>
                <img draggable="false"  src={gobiCoin} alt={"GOBI"} style={{ height: "35px"  }} />
            </Box>
        </Box>
      </Tooltip>
      {/*<Modal open={showGobiPopup} onClose={closeGobiPopup}>
        <GobiPopup open={showGobiPopup} close={closeGobiPopup}></GobiPopup>
  </Modal>*/}
    </>
  )
}