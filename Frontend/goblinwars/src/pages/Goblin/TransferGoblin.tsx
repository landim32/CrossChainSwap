import { AlertColor, Box, Button, IconButton, Paper, Stack, Theme, Typography } from "@mui/material";
import { GoblinInfo } from "../../dto/domain/GoblinInfo";
import { GoblinStyles, MainStyles } from "../../utils/style";
import CloseIcon from '@mui/icons-material/Close';
import { OulinedInput } from "../../components/OutlinedInput";
import { useState } from "react";
import { SxProps } from "@mui/system";
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';

interface TransferGoblinParam {
  goblin: GoblinInfo;
  close: () => void;
  transferCb: (address: string) => void;
  loading: boolean;
}

const textInfo : SxProps<Theme> = {
  ...GoblinStyles.sessionTitleText,
  fontSize: isMobile ? 12 : 14
}

const textInput : SxProps<Theme> = {
  width: 1
}

const textInputProps : SxProps<Theme> = {
  color: "white"
}

export function TransferGoblin(param: TransferGoblinParam) {
  
  const [address, setAddress] = useState("");

  return (
    <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
      <Paper sx={{ ...MainStyles.popUp, bgcolor: "#2b211f" }}>
        <Stack sx={{...MainStyles.container}}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            
            <Stack direction={"row"} sx={{ display: "flex", justifyContent: "space-between" }}>
                <Typography sx={{ ...GoblinStyles.textMain }} >TRANSFER GOBLIN</Typography>
                <IconButton onClick={param.close}>
                  <CloseIcon sx={{ color: "white" }} fontSize={"large"} />
                </IconButton>
              </Stack>
          </Paper>
          <Stack sx={{ width: isMobile ? 300 : 500, p: 2 }} spacing={1}>
            <OulinedInput id="address" label="To Address" variant="outlined" value={address} onChange={(event: any) => {
              setAddress(event.target.value);
            }} sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}  />
            <Typography sx={{ ...textInfo, textAlign: "center", ml: 1, mr: 1 }} >Note: You will be charged a 10 GOBI transfer fee and a 3 hour cooldown.</Typography>
            <Box sx={{ width: 1, display: "flex", alignItems: "center", alignContent: "center", justifyContent: "flex-end" }}>
              <Box sx={{ width: "150px" }}>
                <Button sx={{ ...MainStyles.mainButton, color: "white" }} onClick={() => {
                  param.transferCb(address);
                }} >{ param.loading ? "Transferring..." : "Transfer"}</Button>  
              </Box>
            </Box>
          </Stack>
          
        </Stack>
      </Paper>
    </Box>
  )

}