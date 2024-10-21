import { Box, Button, Paper, Stack, TextField, Theme, Typography } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { SxProps } from "@mui/system";
import { useState } from "react";
import { GoblinStyles, MainStyles } from "../utils/style";
import { OulinedInput } from "./OutlinedInput";
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';

interface UserInfoParam {
  registerCb: (name: string, email: string) => void
  name: string,
  email: string,
  btnText: string;
  btnLoadingText: string;
  loading: boolean
}

const textInput : SxProps<Theme> = {
  width: 1
}

const textInputProps : SxProps<Theme> = {
  color: "white"
}

export function UserInfo(param: UserInfoParam) {

  const [name, setName] = useState(param.name);
  const [email, setEmail] = useState(param.email);

  return (
    <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
      <Paper sx={{ ...MainStyles.popUp, bgcolor: "#2b211f" }}>
        <Stack sx={{...MainStyles.container}}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            <Typography variant={"h6"} color="white" >REGISTER</Typography>
          </Paper>
          <Stack sx={{ width: isMobile ? 300 : 500, p: 2 }} spacing={2}>
            <OulinedInput id="name" label="Name" variant="outlined" value={name} onChange={(event: any) => {
              setName(event.target.value);
            }} sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}  />
            <OulinedInput id="email" label="Email" variant="outlined" value={email} onChange={(event: any) => {
              setEmail(event.target.value);
            }} sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}  />
            <Box sx={{ width: 1, display: "flex", alignItems: "center", alignContent: "center", justifyContent: "flex-end" }}>
              <Box sx={{ width: "150px" }}>
                <Button sx={{ ...MainStyles.mainButton, color: "white" }} onClick={() => {
                  param.registerCb(name, email);
                }} >{ param.loading ? param.btnLoadingText : param.btnText}</Button>  
              </Box>
            </Box>
          </Stack>
          
        </Stack>
      </Paper>
    </Box>
  )
}