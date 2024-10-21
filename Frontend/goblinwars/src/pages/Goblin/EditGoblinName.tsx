import { Box, Button, IconButton, Paper, Stack, TextField, Theme, Typography } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { SxProps } from "@mui/system";
import { useState } from "react";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { OulinedInput } from "../../components/OutlinedInput";
import CloseIcon from '@mui/icons-material/Close';
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';

interface EditGoblinNameParam {
  editCb: (name: string) => void
  close: () => void
  name: string,
  loading: boolean
}

const textInput : SxProps<Theme> = {
  width: 1
}

const textInputProps : SxProps<Theme> = {
  color: "white"
}

export function EditGoblinName(param: EditGoblinNameParam) {

  const [name, setName] = useState(param.name);

  return (
    <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
      <Paper sx={{ ...MainStyles.popUp, bgcolor: "#2b211f" }}>
        <Stack sx={{...MainStyles.container}}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            
            <Stack direction={"row"} sx={{ display: "flex", justifyContent: "space-between" }}>
                <Typography sx={{ ...GoblinStyles.textMain }} >RENAME</Typography>
                <IconButton onClick={param.close}>
                  <CloseIcon sx={{ color: "white" }} fontSize={"large"} />
                </IconButton>
              </Stack>
          </Paper>
          <Stack sx={{ width: isMobile ? 300 : 500, p: 2 }} spacing={2}>
            <OulinedInput id="name" label="Name" variant="outlined" value={name} onChange={(event: any) => {
              setName(event.target.value);
            }} sx={{ ...textInput }} InputProps={{ sx: { ...textInputProps } }}  />
            <Box sx={{ width: 1, display: "flex", alignItems: "center", alignContent: "center", justifyContent: "flex-end" }}>
              <Box sx={{ width: "150px" }}>
                <Button sx={{ ...MainStyles.mainButton, color: "white" }} onClick={() => {
                  param.editCb(name);
                }} >{ param.loading ? "Changing..." : "Change"}</Button>  
              </Box>
            </Box>
          </Stack>
          
        </Stack>
      </Paper>
    </Box>
  )
}