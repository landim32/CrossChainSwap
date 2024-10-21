import { Divider, IconButton, List, ListItem, ListItemButton, ListItemIcon, ListItemText, Paper, Stack, Theme, Toolbar, Typography } from "@mui/material";
import MailIcon from '@mui/icons-material/Mail';
import InboxIcon from '@mui/icons-material/MoveToInbox';
import HideIcon from '../assets/images/menu/hide.png'
import ShowIcon from '../assets/images/menu/show.png'
import LinkIcon from '../assets/images/menu/link.png'
import { GoblinStyles, MainStyles } from "../utils/style";
import HordeIcon from '../assets/images/menu/horde.png';
import QuestsIcon from '../assets/images/menu/quests.png';
import JobsIcon from '../assets/images/menu/jobs.png';
import BoxIcon from '../assets/images/menu/box.png';
import InventoryIcon from '../assets/images/menu/inventory.png';
import GoldMarketIcon from '../assets/images/menu/goldMarket.png';
import LogsIcon from '../assets/images/menu/logs.png';
import MarketplaceIcon from '../assets/images/menu/marketplace.png';
import PickaxeIcon from '../assets/images/menu/pickaxe.png';
import gobiCoin from '../assets/images/coins/gobiCoinOrange.png';

import { CSSProperties, useState } from "react";
import { SxProps } from "@mui/system";
import { useHistory } from "react-router-dom";
import { GobiBalance } from "./GobiBalance";
import { GoldBalance } from "./GoldBalance";

interface GwDrawerParam {
  isMobile: boolean;
  hided: boolean;
  hideDrawer: () => void;
  showDrawer: () => void;
}

const iconMenu : CSSProperties = {
  height: "100%",
  objectFit: "cover",
}
const iconBox: SxProps<Theme> = {
  height: 54,
  width: 54,
  p: 0.8,
  bgcolor: "#e3dac9",
  borderRadius: 27
}

const itemMenuText : SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 16,
}

export function GwDrawer(props: GwDrawerParam) {
  const history = useHistory();

  const buildListItem = (icon: string, title: string) => {
    return (
      <Stack sx={{ ...MainStyles.container, justifyContent: "space-between", width: 1 }} direction={"row"}>
        <Paper sx={{ ...iconBox }} elevation={8}>
          <img draggable="false"  src={icon} alt={title} style={{ ...iconMenu }} />
        </Paper>
        {
          !props.hided &&
          <>
            <Typography sx={{ ...itemMenuText, textAlign: "center" }} >{title}</Typography>
            <IconButton sx={{ ml: 2 }}>
              <img draggable="false"  src={LinkIcon} style={{ height: 28 }} alt={"go"} />
            </IconButton>
          </>
        }
      </Stack>
    )
  }

  const toogleDrawer = () => {
    if(props.hided) {
      props.showDrawer();
    } else {
      props.hideDrawer();
    }
  }

  return (
    <Stack>
      <Toolbar sx={{ bgcolor: "#232a1b", display: "flex", alignContent: "center", justifyContent: "flex-end" }} >
        <Stack sx={{ ...MainStyles.container }} direction={"row"} >
          {
            !props.hided && 
            <Typography sx={{ ...GoblinStyles.sessionTitleText }} >hide</Typography>
          }
          <IconButton onClick={toogleDrawer}>
            <img draggable="false"  src={props.hided ? ShowIcon : HideIcon} style={{ height: 32 }} alt={"hide/show"} />
          </IconButton>
        </Stack>
      </Toolbar>
      <Divider />
      <List  >
        <ListItemButton onClick={() => {
          history.push("/horde")
        }}>
          {
            buildListItem(HordeIcon, "Horde")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/open-gobox")
        }}>
          {
            buildListItem(BoxIcon, "Open Box")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/mining")
        }}>
          {
            buildListItem(PickaxeIcon, "Mining")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/quests")
        }}>
          {
            buildListItem(QuestsIcon, "Quests")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/jobs")
        }}>
          {
            buildListItem(JobsIcon, "Jobs")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/inventory")
        }}>
          {
            buildListItem(InventoryIcon, "Inventory")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/goldmarket")
        }}>
          {
            buildListItem(GoldMarketIcon, "Gold Market")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/logs")
        }}>
          {
            buildListItem(LogsIcon, "Logs")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/marketplace")
        }}>
          {
            buildListItem(MarketplaceIcon, "Marketing place")
          }
        </ListItemButton>
        <ListItemButton onClick={() => {
          history.push("/finance")
        }}>
          {
            buildListItem(gobiCoin, "Finance")
          }
        </ListItemButton>
      </List>
      {
        props.isMobile && 
        <>
          <Divider />
          <Stack spacing={1} sx={{ ...MainStyles.container, width: 1, mt: 2 }} >
              <GobiBalance />
              <GoldBalance />
          </Stack>
        </>
      }
      
    </Stack>
  )
}