import { Box, CircularProgress, Divider, IconButton, Stack, SwipeableDrawer, Toolbar, Typography } from "@mui/material";
import { GoblinInfo } from "../dto/domain/GoblinInfo";
import SizeGoblinCard from "../dto/enum/SizeGoblinCard";
import { GoblinStyles, MainStyles } from "../utils/style";
import { Goblin } from "./Goblin";
import HideIcon from "../assets/images/menu/hideBottonDrawer.png";
import { makeStyles } from "@mui/styles";

interface GoblinsCanFuseParam {
  loading: boolean;
  selectGoblin: (goblin: GoblinInfo) => void;
  goblinsCanFuse: GoblinInfo[];
  isMobile: boolean;
  open: boolean;
  handleCloseDrawer: () => void;
  handleOpenDrawer: () => void;
}

const useStyles = makeStyles({
  paper: {
      background: "linear-gradient(180deg, rgba(99,145,83,1) 0%, rgba(43,52,33,1) 100%)"
  }
})

export function GoblinsCanFuse(param: GoblinsCanFuseParam) {

  const classes = useStyles();

  return (
    <SwipeableDrawer
        anchor={"bottom"}
        open={param.open}
        onClose={param.handleCloseDrawer} 
        onOpen={param.handleOpenDrawer} 
        classes={{ paper: classes.paper }} 
    >
      <Box sx={{ width: 1, height: param.isMobile ? "80vh" : "65vh" }} >
        <Toolbar sx={{ bgcolor: "#232a1b", display: "flex", alignContent: "center", width: 1, p: 1, top: 0, position: "absolute" }} >
          <Stack sx={{ ...MainStyles.container, width: 1  }} direction={"row"} >
            <Typography sx={{ ...GoblinStyles.textMain, flexGrow: 1, textAlign: "center" }}>Select an Goblin for fuse</Typography>
            <Stack sx={{ ...MainStyles.container }} direction={"row"} >
              <IconButton onClick={param.handleCloseDrawer}>
                <img draggable="false"  src={HideIcon} style={{ height: 32 }} alt={"hide"} />
              </IconButton>
              <Typography sx={{ ...GoblinStyles.sessionTitleText }} >hide</Typography>
            </Stack>
          </Stack>
        </Toolbar>
        <Stack sx={{ ...MainStyles.container, position: "absolute", top: 64, width: 1 }}>
        <Divider />
        <Stack direction={"row"} sx={{ ...MainStyles.container, p: 0, flexWrap: "wrap" }}>
          {
            param.goblinsCanFuse && param.goblinsCanFuse.length > 0 &&
            param.goblinsCanFuse.map((goblin: GoblinInfo) => (
                <Box sx={{ ...MainStyles.container, m: param.isMobile ? 1 : 1 }} key={goblin.id}>
                  <Goblin
                    id={goblin.id}
                    idToken={goblin.idToken}
                    name={goblin.name}
                    size={param.isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Small}
                    mainColor={goblin.skincolor}
                    image={goblin.imageURL}
                    goblinSkillList={goblin.goblinSkillList}
                    rarity={goblin.rarityenum}
                    onElemClick={(tokenId:number) => {
                        param.selectGoblin(param.goblinsCanFuse.find(item => item.idToken == tokenId));
                    }}
                  />
                </Box>
            ))
          }
          </Stack>
          {
            param.loading &&
            <CircularProgress />
          }
          {
            !param.loading && param.goblinsCanFuse && param.goblinsCanFuse.length == 0 &&
            <Box sx={{ ...MainStyles.container, ...MainStyles.floatingBox, mt: 20 }}>
              <Typography sx={{ ...GoblinStyles.textMain }}>You didn't have any goblins to fuse</Typography>
            </Box>
          }
        </Stack>
      </Box>
    </SwipeableDrawer>
  );
}