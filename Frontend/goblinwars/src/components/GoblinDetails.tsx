import { GoblinInfo } from "../dto/domain/GoblinInfo";
import Moment from "moment";
import { GoblinStyles, MainStyles } from "../utils/style";
import { Stack, Typography, Paper, Box, CircularProgress, SxProps, Theme, AlertColor, Snackbar, Alert, Backdrop } from "@mui/material";
import MaleIcon from '@mui/icons-material/Male';
import FemaleIcon from '@mui/icons-material/Female';
import { RarityStyles } from "../utils/RarityStyles";
import { FontInfo } from "../utils/fontStyle";
import { LightenDarkenColor } from "../utils/utils";
import { GenericSlot } from "./GenericSlot";
import FavoriteIcon from '@mui/icons-material/Favorite';
import { GoblinPartInventory } from "./GoblinPartInventory";
import { useContext, useState } from "react";
import { ItemInfo } from "../dto/domain/ItemInfo";
import { RarityEnum } from "../dto/enum/RarityEnum";
import { FamilyRestroomRounded } from "@mui/icons-material";
import { AnchorElItem } from "../dto/business/AnchorElItem";
import { ItemPopover } from "./ItemPopover";
import { BodyPartEnum } from "../dto/enum/BodyPartEnum";
import { GetPartName } from "../utils/BodyPartUtils";
import GoblinContext from "../contexts/goblin/GoblinContext";
import { GetItemAssets } from "../utils/ItemAssetsUtils";
import { useHistory } from "react-router";

interface GoblinDetailsParam {
  isMobile: boolean;
  goblin: GoblinInfo;
  goblinSize: number;
  //breedCout: number;
  //breedLoading: boolean;
  isOwner: boolean;
}

const bodyPartStyle : SxProps<Theme> = {
  ...GoblinStyles.sessionSubTitleText,
  fontSize: 14,
}

export function GoblinDetails(param: GoblinDetailsParam) {
  const goblinContext = useContext(GoblinContext);
  const [anchorEl, setAnchorEl] = useState<AnchorElItem>(null);
  const [openDialog, setOpenDialog] = useState(false);
  const [message, setMessage] = useState("");
  const [severity, setSeverity] = useState<AlertColor>("success");

  const history = useHistory();
  
  const handleClick = (event: any, selectEquip: ItemInfo) => {
      setAnchorEl({anchorEl: event, selectItem: selectEquip});
  };

  const handleClosePopOver = () => {
      setAnchorEl(null);
  };

  const open = Boolean(anchorEl);
  const id = open ? 'goblin-inventory-popover' : undefined;

  const handleClose = (ev: any) => {
    if (ev?.reason === 'clickaway') {
        return;
    }
    setOpenDialog(false);
  };

  const showDialog = (message: string, severity: AlertColor) => {
      setSeverity(severity);
      setMessage(message);
      setOpenDialog(true);
  }

  const slotItem = (item: ItemInfo, part: BodyPartEnum, disabled: boolean = false) => {
    return (
      <Stack sx={{ ...MainStyles.container }} spacing={-1}>
        <GenericSlot boxSize={slotSize} rarity={item?.rarity} >
          <Box sx={{ ...MainStyles.container, width: slotSize, height: slotSize, opacity: disabled ? 0.2 : 1 }} onClick={(ev: any) => {
            if(item && !disabled)
              handleClick(ev.currentTarget, item);
          }}>
            <img draggable="false"  src={GetItemAssets(item?.iconAsset)} style={{ width: itemSlotSize }} />
          </Box>
        </GenericSlot>
        <Typography sx={{ ...bodyPartStyle }}>{GetPartName(part)}</Typography>
      </Stack>
    )
  }

  const getBirthday = () => {
    var dateObj = Moment(param.goblin.birthday).locale('en');
    return (
      <Stack direction={"row"} spacing={1}>
        <Typography sx={{ ...GoblinStyles.textMain }} >{dateObj.format("MMM.")}</Typography>
        <Typography sx={{ ...GoblinStyles.textMain }} >{dateObj.format("D,")}</Typography>
        <Typography sx={{ ...GoblinStyles.textMain }} >{dateObj.format("YYYY")}</Typography>
        <Typography sx={{ ...GoblinStyles.textMain }} >at</Typography>
        <Typography sx={{ ...GoblinStyles.textMain }} >{dateObj.format("h:mm")}</Typography>
        <Typography sx={{ ...GoblinStyles.textMain }} >{dateObj.format("A z")}</Typography>
      </Stack>
    );
  }

  const slotSize = param.goblinSize * 0.2;
  const itemSlotSize = slotSize - 20;

  return (
    <Stack sx={{ ...MainStyles.container }} spacing={2}>
      <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1}>
        <Stack sx={{ ...MainStyles.container, alignContent: "space-between" }}>
          {
            slotItem(param.goblin.goblinEquipment?.head, BodyPartEnum.Head)
          }
          {
            slotItem(param.goblin.goblinEquipment?.chest, BodyPartEnum.Chest)
          }
          {
            slotItem(param.goblin.goblinEquipment?.foot, BodyPartEnum.Foot)
          }
        </Stack>
        <Paper sx={{...GoblinStyles.outCardDetailGoblin, position: "relative", width: param.goblinSize, bgcolor: RarityStyles.getRarityColor(param.goblin.rarityenum)}}>
          <Paper sx={{...GoblinStyles.cardDetailGoblin, position:"relative", width: param.goblinSize }}>
            <Box sx={{ position: "absolute", top: 0 }}>
              { RarityStyles.getCardEffect(param.goblinSize - 15, param.goblinSize - 15, param.goblin.rarityenum, param.goblin.idToken + "detail") }
            </Box>
            {
              <img draggable="false"  
                src={param.goblin.imageURL}
                alt="my goblin"
                style={{ objectFit: "cover", width: "100%", zIndex: 2 }}
              />
            }
          </Paper>
            {param.goblin.genre === "M" ?
              <MaleIcon sx={{ ...FontInfo, top: 15, right: 15, position: "absolute", fontSize: param.isMobile ? 30 : 45, color: "#6ca0dc" }}  />
              : <FemaleIcon sx={{ ...FontInfo, top: 15, right: 15, position: "absolute", fontSize: param.isMobile ? 30 : 45, color: "#f8b9d4" }} />
          }
        </Paper>
        <Stack sx={{ ...MainStyles.container, alignContent: "space-between" }}>
          {
            slotItem(param.goblin.goblinEquipment?.hand, BodyPartEnum.Gloves)
          }
          {
            slotItem(param.goblin.goblinEquipment?.rightHand, BodyPartEnum.RHand)
          }
          {
            param.goblin.goblinEquipment?.rightHand?.equipmentInfo.isTwoHanded ?
            slotItem(param.goblin.goblinEquipment?.rightHand, BodyPartEnum.LHand, true)
            : slotItem(param.goblin.goblinEquipment?.leftHand, BodyPartEnum.LHand)
          }
        </Stack>
      </Stack>
      <Stack sx={{ ...MainStyles.container }}>
        <Typography sx={{ ...GoblinStyles.sessionTitleText }} >Birthday</Typography>
        {getBirthday()}
        <Stack direction={"row"} spacing={1} sx={{ ...MainStyles.container }}>
            <FavoriteIcon fontSize={"medium"} sx={{ color: "white" }} />
            <Typography sx={{ ...GoblinStyles.textMain }} >{param.goblin.sonscount} {param.goblin.sonscount == 1 ? "child" : "children"}</Typography>
        </Stack>
        {
          param.isOwner &&
          <GoblinPartInventory bag={param.goblin.goblinEquipment?.goblinBag} loading={goblinContext.loading.equipGoblin} equipCb={(item, part) => {
            goblinContext.equipGoblin(param.goblin, item, part).then(ret => {
              if(ret.sucesso){
                showDialog("Item has been equipped", "success");
              } else {
                showDialog(ret.mensagemErro, "error");
              }
            });
          } }  />
        }
      </Stack>
      <ItemPopover anchorEl={anchorEl} equipCb={(item, part) => {} } moreDetail={(item: ItemInfo) => {
        history.push("/equipment?key=" + item.key);
      }} loading={false} open={open} closeCb={handleClosePopOver} id={id} canEquip={false}  />
      <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
        <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
          {message}
        </Alert>
      </Snackbar>
      {
        goblinContext.loading.equipGoblin &&
        <Backdrop
            sx={{ color: '#fff', zIndex: (theme) => 99 }}
            open={true}
        >
          <Stack sx={{ ...MainStyles.container }}>
            <CircularProgress color="inherit" />
            <Typography>Equipping...</Typography>
          </Stack>
        </Backdrop>
      }
    </Stack>
  )
}