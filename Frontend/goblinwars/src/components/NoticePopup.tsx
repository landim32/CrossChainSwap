import { Box, Button, Dialog, IconButton, Paper, Slide, Stack, Theme, Typography } from "@mui/material";
import { SxProps } from "@mui/system";
import React from "react";
import { GoblinWarsBackground } from "../dto/styles/GoblinWarsColors";
import { GoblinStyles, MainStyles } from "../utils/style";
import CloseIcon from '@mui/icons-material/Close';

interface NoticePopupParam {
  title: string;
  text: any;
  open: boolean;
  animated: boolean;
  close: () => void;
  action?: () => void;
  banner?: boolean;
}

const noticeTitle : SxProps<Theme> = {
  ...GoblinStyles.sessionTitleText,
  fontSize: 26
}
const textStyle : SxProps<Theme> = {
  ...GoblinStyles.infoTextMain,
  fontSize: 22,
  pl: 1,
  pr: 1,
  textAlign: "justify"
}

export function NoticePopup(param: NoticePopupParam) {
  const Transition = param.animated ? React.forwardRef(function Transition(props : any, ref) {
    return <Slide direction="up" ref={ref} {...props} />;
  }) : undefined;
  return (
    <Dialog
      open={param.open}
      TransitionComponent={Transition}
      keepMounted
      onClose={param.close}
    >
      <Box sx={{ background: GoblinWarsBackground.containerBackground  }}>
        <Paper sx={{ ...GoblinStyles.sessionTitle }}>
          <Stack direction={"row"} sx={{ display: "flex", justifyContent: "space-between" }}>
            {
              !param.banner ?
              <Typography sx={{ ...noticeTitle }} >{param.title}</Typography>
              : <Box />
            }
            <IconButton onClick={param.close}>
              <CloseIcon sx={{ color: "white" }} fontSize={"medium"} />
            </IconButton>
          </Stack>
        </Paper>
        <Stack sx={{ ...MainStyles.container, p: 1 }}>
          <Typography sx={{ ...textStyle, pb: 2 }}>
            {param.text}
          </Typography>
          {
            param.action && 
            <Button sx={{ ...MainStyles.mainButton, width: 150 }} onClick={param.action} >Open</Button>
          }
        </Stack>
      </Box>
    </Dialog>
  );
}