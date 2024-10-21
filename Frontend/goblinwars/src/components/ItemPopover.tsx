import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Box, Paper, Popover, Stack } from "@mui/material";
import { AnchorElItem } from "../dto/business/AnchorElItem";
import { ItemInfo } from "../dto/domain/ItemInfo";
import { BodyPartEnum } from "../dto/enum/BodyPartEnum";
import { GetPartName } from "../utils/BodyPartUtils";
import { MainStyles, GoblinStyles } from "../utils/style";
import { useState } from "react";
import { isMobile } from "react-device-detect";
import EquipmentCard from "./EquipmentCard";

interface ItemPopoverParam {
  anchorEl: AnchorElItem,
  equipCb: (item: ItemInfo, part: BodyPartEnum) => void;
  moreDetail?: (item: ItemInfo) => void;
  loading: boolean;
  open: boolean;
  closeCb: () => void;
  id: string;
  canEquip: boolean;
  firstView?: number;
}

interface OpenDialogItemBinding {
  open: boolean;
  part: BodyPartEnum;
}

const getItemBasicInfo = (item: ItemInfo, canEquip: boolean, loading: boolean, cbEquip: (part: BodyPartEnum) => void, moreDetail?: (item: ItemInfo) => void) => {

  return (
    <>
      <EquipmentCard
        item={item}
        loading={loading}
        moreDetail={moreDetail}
      >
      {
        canEquip && !loading &&
        <Stack sx={{ ...MainStyles.container }}>
          {
            item.equipmentInfo.part.map(part => (
              <Button sx={{ ...MainStyles.mainButton, width: isMobile ? 150 : 250 }} onClick={() => { cbEquip(part) }} >Equip on {GetPartName(part)}</Button>
            ))
          }
        </Stack>
      }
      </EquipmentCard>
    </>
  )
}



export function ItemPopover(param: ItemPopoverParam) {

  let anchorEl = param.anchorEl;

  const [open, setOpen] = useState<OpenDialogItemBinding>(null);

  const handleClickOpen = (part: BodyPartEnum) => {
    setOpen({open: true, part});
  };

  const handleClose = () => {
    setOpen(null);
  };

  return (
    <>
     <Popover
        id={param.id}
        open={param.open}
        anchorEl={anchorEl?.anchorEl}
        onClose={param.closeCb}
        anchorOrigin={{
          vertical: 'bottom',
          horizontal: 'center',
        }}
      >
        {
          anchorEl &&
          <>
            {
              getItemBasicInfo(anchorEl.selectItem, param.canEquip,param.loading, (part) => {
                if(anchorEl.selectItem.equipmentInfo.binded == false){
                  handleClickOpen(part);
                }
                else {
                  param.equipCb(param.anchorEl.selectItem, part);
                  param.closeCb();
                }
              }, param.moreDetail)
            }
          </>
        }
      </Popover>
      <Dialog
        open={open?.open}
        onClose={handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          Binding Equipment
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Equipping this item will <b>bind</b> it to this goblin, not being able to equip it to another goblin.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose}>Close</Button>
          <Button onClick={() => {
              handleClose();
              param.equipCb(param.anchorEl.selectItem, open?.part);
              param.closeCb();
            }} autoFocus>
            Bind
          </Button>
        </DialogActions>
      </Dialog>
    </>
  )
}