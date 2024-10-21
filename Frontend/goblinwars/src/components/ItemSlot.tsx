import { Box, Theme, Tooltip, Typography } from "@mui/material";
import { SxProps } from "@mui/system";
import { UserItemInfo } from "../dto/domain/UserItemInfo";
import { RarityEnum } from "../dto/enum/RarityEnum";
import { RarityStyles } from "../utils/RarityStyles";
import { GoblinStyles, MainStyles } from "../utils/style";
import { useDrag } from 'react-dnd';
import { DragTypes } from "../dto/business/DragTypes";
import { ItemSlotParam } from "../dto/business/ItemSlotParam";


const boxSizeInternal = 51;

const styleQtde: SxProps<Theme> = {
  ...GoblinStyles.textMain,
  fontSize: 12,
  bottom: 0,
  right: 2,
  position: "absolute"
}

export function ItemSlot(param: ItemSlotParam) {

  const [{isDragging}, drag] = useDrag(() => ({
    type: DragTypes.ITEM,
    item: param.userItemInfo,
    collect: monitor => ({
      isDragging: !!monitor.isDragging(),
    }),
  }))

  return (
    <Tooltip title={param.userItemInfo.item.name}>
      <Box sx={{ ...MainStyles.container, height: boxSizeInternal, width: boxSizeInternal, opacity: isDragging ? 0.5 : 1, position: "relative" }} ref={drag} onClick={() => { param.selectItemCb(param.userItemInfo) }}>
        <img draggable="false"  src={param.userItemInfo.item.iconAsset} alt={param.userItemInfo.item.name} style={{ width: "85%", objectFit: "cover" }} />
        {
          param.userItemInfo.qtde > 1 &&
          <Typography sx={{...styleQtde}}>{param.userItemInfo.qtde}</Typography>
        }
      </Box>
    </Tooltip>
  )
}