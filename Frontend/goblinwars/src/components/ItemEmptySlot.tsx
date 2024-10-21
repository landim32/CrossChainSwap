import { Box, Theme } from "@mui/material";
import { SxProps } from "@mui/system";
import { ItemSlotParam } from "../dto/business/ItemSlotParam";
import { RarityEnum } from "../dto/enum/RarityEnum";
import { RarityStyles } from "../utils/RarityStyles";
import { MainStyles } from "../utils/style";
import { useDrop } from 'react-dnd';
import { DragTypes } from "../dto/business/DragTypes";
import { UserItemInfo } from "../dto/domain/UserItemInfo";

const boxSize = 60;
const boxSizeInternal = 54;

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

export function ItemEmptySlot(param: ItemSlotParam) {

  const [{ isOver, canDrop, rarity }, drop] = useDrop(
    () => ({
      accept: DragTypes.ITEM,
      drop: (item: UserItemInfo, monitor) => { param.moveCb(item.id, param.x, param.y) },
      canDrop: () => param.canDropCb(0, param.x, param.y),
      collect: (monitor) => ({
        isOver: monitor.isOver(),
        canDrop: monitor.canDrop(),
        rarity: monitor.getItem() && (monitor.getItem() as UserItemInfo)?.item?.rarity
      })
    }),
    [param.x, param.y, param.context]
  )

  return (
    <Box sx={{ ...outItemSlot, bgcolor: getBorderRarity(param.userItemInfo?.item?.rarity || ((isOver && canDrop) ? rarity : param.userItemInfo?.item?.rarity)), transform: "scale(" + (isOver && canDrop ? 1.1 : 1) + ")" }}  ref={drop}>
      <Box sx={{ ...itemSlot }}>
        {param.children}
      </Box>
    </Box>
  )
}