import { Box, Button, Dialog, Input, Slider, Stack, Theme, Typography, DialogTitle, DialogContent, DialogContentText, DialogActions } from "@mui/material";
import React, {useContext, useState} from 'react';
import { SxProps } from "@mui/system";
import { UserItemInfo } from "../dto/domain/UserItemInfo";
import { RarityEnum } from "../dto/enum/RarityEnum";
import { RarityStyles } from "../utils/RarityStyles";
import { GoblinStyles, MainStyles } from "../utils/style";
import { withStyles } from "@mui/styles";
import goldCoin from '../assets/images/coins/goldCoin.png';
import { ResultDialog } from "./ResultDialog";
import { GenericSlot } from "./GenericSlot";
import ItemContext from "../contexts/item/ItemContext";
import { AnchorElItem } from "../dto/business/AnchorElItem";
import { ItemInfo } from "../dto/domain/ItemInfo";
import { ItemPopover } from "./ItemPopover";
import { useHistory } from "react-router";

interface ItemDetailParam {
  userItemInfo: UserItemInfo;
  sellCb: (item: UserItemInfo, qtde: number) => void;
  openCb: (item: UserItemInfo, qtde: number) => void;
}

const invStyle : SxProps<Theme> = {
  p: 2,
  borderRadius: 2,
  bgcolor: "#2b211f"
}

const boxSize = 90;
const boxSizeInternal = 84;

const outItemSlot : SxProps<Theme> = {
  borderRadius: 1,
  border: 1,
  width: boxSize,
  height: boxSize,
  ...MainStyles.container
};

const itemSlot : SxProps<Theme> = {
  background: "radial-gradient(circle, rgba(115,96,79,1) 0%, rgba(38,28,18,1) 70%)",
  borderRadius: 1,
  border: 1,
  width: boxSizeInternal,
  height: boxSizeInternal,
  ...MainStyles.container
};

const getBorderRarity = (rarity?: RarityEnum) => {
  if(rarity || rarity == 0) {
    return RarityStyles.getRarityColor(rarity);
  } else {
    return "#5f4a2d";
  }
}

const styleQtde: SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 18,
  bottom: 1,
  right: 4,
  position: "absolute"
}

const SlideStyled = withStyles({
  root: {
    '& .MuiSlider-markLabel': {
      color: "white"
    }
  },
})(Slider);

interface ConfirmPopUpItemDetail {
  open: boolean;
  sell: boolean;
  openChest: boolean;
}

export function ItemDetail(param: ItemDetailParam) {
  const [value, setValue] = useState(1);
  const [confirm, setConfirm] = useState<ConfirmPopUpItemDetail>(null);

  const history = useHistory();

  const handleChange = (event: any, newValue: any) => {
    setValue(newValue);
  };
  const handleOpenConfirmation = (sell: boolean, open: boolean) => {
    setConfirm({ open: true, sell: sell, openChest: open })
  }

  const handleCloseConfirmation = () => {
    setConfirm(null)
  }
  
  const executeConfirm = () => {
    if(confirm.openChest) {
      param.openCb(param.userItemInfo, value);
    } else {
      param.sellCb(param.userItemInfo, value);
    }
    handleCloseConfirmation();
  }

  const [anchorEl, setAnchorEl] = useState<AnchorElItem>(null);

  const handleClick = (event: any, selectItem: ItemInfo) => {
      setAnchorEl({anchorEl: event, selectItem: selectItem});
  };

  const handleClosePopOver = () => {
      setAnchorEl(null);
  };

  const open = Boolean(anchorEl);
  const id = open ? 'iventorydetail-popover' : undefined;

  return (
    <>
      <Box sx={{ ...MainStyles.container, ...invStyle }}>
        <Stack sx={{ ...MainStyles.container, width: 1  }} spacing={2}>
          <Stack sx={{ ...MainStyles.container, justifyContent: "space-around", width: 1 }} direction={"row"}>
            <Typography sx={{ ...GoblinStyles.textMain }} >{param.userItemInfo.item.name}</Typography>
            {
              param.userItemInfo.item.isTrash && 
              <Stack sx={{ ...MainStyles.container }}>
                <Typography sx={{ ...GoblinStyles.sessionTitleText }}>Price For Sell</Typography>
                <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1}>
                  <Typography sx={{ ...GoblinStyles.textMain }} >{param.userItemInfo.item.price * value} Coins</Typography>
                  <img draggable="false"  src={goldCoin} style={{ height: "25px" }} alt="Gold Coin" />
                </Stack>
              </Stack>
            }
          </Stack>
          
          <Stack sx={{ ...MainStyles.container, justifyContent: "space-around", width: 1 }} spacing={4} direction={"row"}>
            <Box sx={{ ...outItemSlot, bgcolor: getBorderRarity(param.userItemInfo.item.rarity)}}  >
              <Box sx={{ ...itemSlot, position: "relative" }}>
                <img draggable="false"  src={param.userItemInfo.item.iconAsset} alt={param.userItemInfo.item.name} style={{ width: 84, objectFit: "cover" }} />
                {
                  param.userItemInfo.qtde > 1 &&
                  <Typography sx={{...styleQtde}}>{param.userItemInfo.qtde}</Typography>
                }
              </Box>
            </Box>
            {
              (param.userItemInfo.item.isTrash || param.userItemInfo.item.isBag) &&
              <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={3}>
                <SlideStyled aria-label="Amount" value={value} onChange={handleChange} defaultValue={param.userItemInfo.qtde} min={1} max={param.userItemInfo.qtde}
                  marks={[
                    {
                      value: 1,
                      label: '1',

                    },
                    {
                      value: param.userItemInfo.qtde,
                      label: param.userItemInfo.qtde,
                    },
                  ]} valueLabelDisplay="on" sx={{ ...GoblinStyles.textMain, width: 85 }}  />

                {
                  param.userItemInfo.item.isBag ?
                  <Button sx={{ ...MainStyles.mainButton, width: 70 }} onClick={() => {
                    handleOpenConfirmation(false, true);
                  }}>OPEN</Button>
                  : <Button sx={{ ...MainStyles.mainButton, width: 70 }} onClick={() => {
                    handleOpenConfirmation(true, false);
                  }}>SELL</Button>
                }
              </Stack>
            }
          </Stack>
          <Button sx={{ ...MainStyles.mainButton }} onClick={(ev: any) => {
            //handleClick(ev.currentTarget, param.userItemInfo.item);
            history.push("/equipment?key=" + param.userItemInfo.item.key);
          }}>Open Item Details</Button>
        </Stack>
      </Box>
      <Dialog open={confirm?.open} onClose={handleCloseConfirmation}>
          <DialogTitle>{"Warning"}</DialogTitle>
          <DialogContent>
              <DialogContentText>
                  Are you sure?
              </DialogContentText>
          </DialogContent>
          <DialogActions>
              <Button onClick={executeConfirm}>Yes</Button>
              <Button onClick={handleCloseConfirmation}>No</Button>
          </DialogActions>
      </Dialog>
      <ItemPopover anchorEl={anchorEl} equipCb={() => {}} moreDetail={(item: ItemInfo) => {
        history.push("/equipment?key=" + item.key);
      }} loading={false} open={open} closeCb={handleClosePopOver} id={id} canEquip={false} firstView={1} />
    </>
  )
}