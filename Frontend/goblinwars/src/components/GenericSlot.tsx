import { Box, Theme } from "@mui/material";
import { SxProps } from "@mui/system";
import { RarityEnum } from "../dto/enum/RarityEnum";
import { RarityStyles } from "../utils/RarityStyles";
import { MainStyles } from "../utils/style";


function outItemSlotStyle(size: number) : SxProps<Theme>  {
  return {
    borderRadius: 1,
    border: 1,
    width: size,
    height: size,
    ...MainStyles.container
  }
}

function itemSlotStyle(size: number) : SxProps<Theme>  {
  return {
    background: "radial-gradient(circle, rgba(115,96,79,1) 0%, rgba(38,28,18,1) 70%)",
    borderRadius: 1,
    border: 1,
    width: size,
    height: size,
    ...MainStyles.container
  };
}


const getBorderRarity = (rarity?: RarityEnum) => {
  if(rarity || rarity == 0) {
    return RarityStyles.getRarityColor(rarity);
  } else {
    return "#5f4a2d";
  }
}

interface GenericSlotParam {
  rarity?: RarityEnum;
  required?: boolean;
  children?: any;
  boxSize: number;
}

export function GenericSlot(param: GenericSlotParam) {

  return (
    <Box sx={{ ...outItemSlotStyle(param.boxSize || 60), bgcolor: getBorderRarity(param.rarity), m: 1 }}  >
      <Box sx={{ ...itemSlotStyle((param.boxSize || 60) - 6) }}>
        {param.children}
      </Box>
    </Box>
  )
}