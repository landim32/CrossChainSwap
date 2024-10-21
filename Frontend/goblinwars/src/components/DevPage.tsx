import { Box, Paper, Stack, Theme, Typography } from "@mui/material";
import { SxProps } from "@mui/system";
import { GoblinWarsBackground } from "../dto/styles/GoblinWarsColors";
import { FontButton } from "../utils/fontStyle";
import { GoblinStyles, MainStyles } from "../utils/style";

interface DevPageParam {
  text: any;
  title: string;
}

const noticeTitle : SxProps<Theme> = {
  ...FontButton,
  fontSize: 26
}
const textStyle : SxProps<Theme> = {
  ...GoblinStyles.infoTextMain,
  fontSize: 22,
  pl: 1,
  pr: 1,
  textAlign: "justify"
}

export function DevPages(param: DevPageParam) {
  return (
    <Paper sx={{ background: GoblinWarsBackground.containerBackground, m: 1, ml: 3, mr: 3  }}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
              <Stack direction={"row"} sx={{ display: "flex", justifyContent: "space-between" }}>
                  <Typography sx={{ ...noticeTitle }} >{param.title}</Typography>
              </Stack>
              </Paper>
              <Stack sx={{ ...MainStyles.container, p: 1 }}>
              <Typography sx={{ ...textStyle, pb: 2 }}>
                  {param.text}
              </Typography>
          </Stack>
      </Paper>
  )
}