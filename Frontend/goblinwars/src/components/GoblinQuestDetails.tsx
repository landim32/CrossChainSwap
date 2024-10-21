import { Box, Button, Paper, Popover, Stack, SxProps, Theme, Typography, Divider } from "@mui/material";
import { AnchorElGoblinQuest } from "../dto/business/AnchorElGoblinQuest";
import { GoblinInfo } from "../dto/domain/GoblinInfo";
import { GoblinWarsBackground } from "../dto/styles/GoblinWarsColors";
import { FontButton } from "../utils/fontStyle";
import { GoblinStyles, MainStyles } from "../utils/style";

const geneIconSize = 44;
const subInfoStyle : SxProps<Theme> = {
  ...GoblinStyles.sessionSubTitleText,
  fontSize: 14,
}

const statsText : SxProps<Theme> = {
  ...FontButton,
  fontSize: 23
}

const statsIconBoxStyle : SxProps<Theme> = {
  ...MainStyles.container, 
  background: GoblinWarsBackground.containerBackground, 
  height: geneIconSize, 
  width: geneIconSize, 
  borderRadius: geneIconSize/2
}

interface GoblinQuestDetailParam {
  removeCb: (goblin: GoblinInfo) => void;
  closeCb: () => void;
  anchorEl: AnchorElGoblinQuest;
  id: string;
  canRemove: boolean;
}

export function GoblinQuestDetail(param: GoblinQuestDetailParam) {
  
  var anchor = param.anchorEl;
  var goblin = anchor?.goblin;
  var quest = anchor?.quest;

  return (
    <>
     <Popover
        id={param.id}
        open={anchor?.open}
        anchorEl={anchor?.anchorEl}
        onClose={param.closeCb}
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'center',
        }}
      >
        {
          anchor && 
          <Box sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: 300 }}>
            <Stack sx={{ ...MainStyles.container }} spacing={2}>
              <Typography sx={{ ...GoblinStyles.textMain }}>{goblin.name}</Typography>
              <img draggable="false"  src={goblin.imageURL} style={{ height: 200 }} />
              <Stack sx={{ ...MainStyles.container }}>
                <Typography sx={{ ...GoblinStyles.sessionTitleText }} >Quest Power</Typography>
                <Typography sx={{ ...GoblinStyles.textMain }} >{goblin.questaffinity}</Typography>
              </Stack>
              <Divider sx={{ width: 1, m: 1 }} />
              <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"} spacing={1.5}>
                
              </Stack>
              {
                param.canRemove && 
                <Button sx={{ ...MainStyles.mainButton }} onClick={() => { param.removeCb(goblin) }} >Remove</Button>
              }
            </Stack>
          </Box>
        }
      </Popover>
    </>
  )
}