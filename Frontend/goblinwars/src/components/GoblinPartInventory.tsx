import { Box, Fade, Paper, Popover, Stack, styled, SxProps, Tab, Tabs, Theme, Typography } from "@mui/material";
import { useState } from "react";
import { ItemInfo } from "../dto/domain/ItemInfo";
import { BodyPartEnum } from "../dto/enum/BodyPartEnum";
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import { MainStyles } from "../utils/style";
import { isMobile } from 'react-device-detect';
import { FontButton } from "../utils/fontStyle";
import { GenericSlot } from "./GenericSlot";
import { ItemPopover } from "./ItemPopover";
import { AnchorElItem } from "../dto/business/AnchorElItem";
import { GetItemAssets } from "../utils/ItemAssetsUtils";

const boxSize = isMobile ? 70 : 75;
const iconSize = isMobile ? 58 : 65;

interface GoblinPartPartInventory {
  bag: ItemInfo[];
  loading: boolean;
  equipCb: (item: ItemInfo, part: BodyPartEnum) => void;
  moreDetail?: (item: ItemInfo) => void;
}

const StyledTabs = styled((props: any) => (
  <Tabs
      {...props}
      TabIndicatorProps={{ children: <span className="MuiTabs-indicatorSpan" /> }}
  />
  ))({
  '& .MuiTabs-indicator': {
      display: 'flex',
      justifyContent: 'center',
      backgroundColor: 'transparent',
  },
  '& .MuiTabs-indicatorSpan': {
      maxWidth: 40,
      width: '100%',
      backgroundColor: GoblinWarsColors.lightBox,
  },
});

const StyledTab = styled((props: any) => 
  <Tab disableRipple {...props} />)(
  ({ theme }) => ({
      textTransform: 'none',
      fontSize: 18,
      fontFamily: "Yeon Sung",
      color: GoblinWarsColors.titleColor,
      fontWeight: "bold",
      textShadow: "0px 2px 1px #000000,1px 1px 0px #000000;",
      '&.Mui-selected': {
          fontSize: 22,
          fontFamily: "Yeon Sung",
          color: GoblinWarsColors.buttonFontColor,
          fontWeight: "bold",
          textShadow: "0px 5px 4px #191719,1px 1px 0px #181813, rgb(61, 59, 46) 3px 0px 0px, rgb(61, 59, 46) 2.83487px 0.981584px 0px, rgb(61, 59, 46) 2.35766px 1.85511px 0px, rgb(61, 59, 46) 1.62091px 2.52441px 0px, rgb(61, 59, 46) 0.705713px 2.91581px 0px, rgb(61, 59, 46) -0.287171px 2.98622px 0px, rgb(61, 59, 46) -1.24844px 2.72789px 0px, rgb(61, 59, 46) -2.07227px 2.16926px 0px, rgb(61, 59, 46) -2.66798px 1.37182px 0px, rgb(61, 59, 46) -2.96998px 0.42336px 0px, rgb(61, 59, 46) -2.94502px -0.571704px 0px, rgb(61, 59, 46) -2.59586px -1.50383px 0px, rgb(61, 59, 46) -1.96093px -2.27041px 0px, rgb(61, 59, 46) -1.11013px -2.78704px 0px, rgb(61, 59, 46) -0.137119px -2.99686px 0px, rgb(61, 59, 46) 0.850987px -2.87677px 0px, rgb(61, 59, 46) 1.74541px -2.43999px 0px, rgb(61, 59, 46) 2.44769px -1.73459px 0px, rgb(61, 59, 46) 2.88051px -0.838247px 0px;"
      }
  }),
);

const msgEmptyTitle : SxProps<Theme> = {
  ...FontButton,
  fontSize: 22
}

const EmptyMsg = (msg: string) => {
  return (
    <Box sx={{ ...MainStyles.container, width: isMobile ? 350 : 500, mb: 2 }}>
        <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
            <Stack sx={{ ...MainStyles.container }}>
                <Typography sx={{ ...msgEmptyTitle }} >
                            {msg}
                </Typography>
            </Stack>
        </Paper>
    </Box>
  );
}

export function GoblinPartInventory(param: GoblinPartPartInventory) {

  const [value, setValue] = useState(0);
  const handleChange = (event : any, newValue : number) => {
      setValue(newValue);
  };
  const [anchorEl, setAnchorEl] = useState<AnchorElItem>(null);

  const handleClick = (event: any, selectEquip: ItemInfo) => {
      setAnchorEl({anchorEl: event, selectItem: selectEquip});
  };

  const handleClosePopOver = () => {
      setAnchorEl(null);
  };

  const open = Boolean(anchorEl);
  const id = open ? 'inventory-popover' : undefined;

  let equipsUnbinded: ItemInfo[] = [];
  let equipsBinded: ItemInfo[] = [];
  if(param.bag) {
    equipsUnbinded = param.bag.filter(item => !item.equipmentInfo.binded);
    equipsBinded = param.bag.filter(item => item.equipmentInfo.binded);
  }

  return (<>
    <Stack sx={{ ...MainStyles.container, width: isMobile ? 300 : 550 }} spacing={2}>
      <Box >
        <StyledTabs value={value} onChange={handleChange} >
            <StyledTab label="Inventory" />
            <StyledTab label="Binded Equipment" />
        </StyledTabs>
      </Box>
      <Fade in={value == 0}>
          {
              value == 0 ?
              equipsUnbinded && equipsUnbinded.length > 0 ? 
                <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"} >
                  {
                    equipsUnbinded.map((item, i) => (
                      <Box sx={{ ...MainStyles.container, m: 1 }} key={i}>
                        <GenericSlot boxSize={boxSize} rarity={item.rarity} >
                          <Box sx={{ ...MainStyles.container, height: boxSize, width: boxSize }} onClick={(ev: any) => {
                            handleClick(ev.currentTarget, item);
                          }}>
                            <img draggable="false"  style={{ width: iconSize }} src={GetItemAssets(item.iconAsset)} />
                          </Box>
                        </GenericSlot>
                      </Box>
                    ))
                  }
                </Stack>
                : EmptyMsg("You don't any equipment for this Goblin.")
              : <Box></Box>
          }
      </Fade>
      <Fade in={value == 1}>
          {
              value == 1 ?
              equipsBinded && equipsBinded.length > 0 ? 
                <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"} >
                  {
                    equipsBinded.map((item, i) => (
                      <Box sx={{ ...MainStyles.container, m: 0 }} key={i}>
                        <GenericSlot boxSize={boxSize} rarity={item.rarity} >
                          <Box sx={{ ...MainStyles.container, height: boxSize, width: boxSize }} onClick={(ev: any) => {
                            handleClick(ev.currentTarget, item);
                          }}>
                            <img draggable="false"  style={{ width: iconSize }} src={GetItemAssets(item.iconAsset)} />
                          </Box>
                        </GenericSlot>
                      </Box>
                    ))
                  }
                </Stack>
                : EmptyMsg("You don't any binded equipment in this Goblin.")
              : <Box></Box>
          }
      </Fade>
    </Stack>
    <ItemPopover anchorEl={anchorEl} equipCb={param.equipCb} moreDetail={param.moreDetail} loading={param.loading} open={open} closeCb={handleClosePopOver} id={id} canEquip={true} />
  </>)
}