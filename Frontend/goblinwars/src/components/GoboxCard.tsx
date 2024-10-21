import { Button, Paper, Stack, Typography } from "@mui/material";
import { GoblinStyles, MainStyles } from "../utils/style";
import AuctionInfo from "../dto/domain/AuctionInfo";
import GoboxCommon from "../assets/images/box/gobox1.png";
import GoboxUncommon from "../assets/images/box/gobox2.png";
import GoboxRare from "../assets/images/box/gobox3.png";
import ItemBoxCommon from '../assets/images/box/item-common.png';
import ItemBoxUncommon from '../assets/images/box/item-uncommon.png';
import ItemBoxRare from '../assets/images/box/item-rare.png';
import ItemBoxEpic from '../assets/images/box/item-epic.png';
import ItemBoxLegendary from '../assets/images/box/item-legendary.png';
import gobiCoin from '../assets/images/coins/gobiCoin.png';

interface GoboxParam {
  boxType: number;
  auction: AuctionInfo;
  loading: boolean;
  buy?: (auction: AuctionInfo) => void;
  cancel?: (auction: AuctionInfo) => void;
}

const iconSize = 24;

export default function GoboxCard(param: GoboxParam) {

  const GOBOX_COMMON: number = 1;
  const GOBOX_UNCOMMON: number = 2;
  const GOBOX_RARE: number = 3;
  const ITEM_BOX_COMMON: number = 4;
  const ITEM_BOX_UNCOMMON: number = 5;
  const ITEM_BOX_RARE: number = 6;
  const ITEM_BOX_EPIC: number = 7;
  const ITEM_BOX_LEGENDARY: number = 8;

  const showImage = (boxType: number) => {
    if (boxType == GOBOX_COMMON) {
      return (
        <img draggable="false"  src={GoboxCommon} alt={"Gobox Common"} style={{ width: "200px" }} />
      );
    }
    else if (boxType == GOBOX_UNCOMMON) {
      return (
        <img draggable="false"  src={GoboxUncommon} alt={"Gobox Uncommon"} style={{ width: "200px" }} />
      );
    }
    else if (boxType == GOBOX_RARE) {
      return (
        <img draggable="false"  src={GoboxRare} alt={"Gobox Rare"} style={{ width: "200px" }} />
      );
    }
    else if (boxType == ITEM_BOX_COMMON) {
      return (
        <img draggable="false"  src={ItemBoxCommon} alt={"Item Box Common"} style={{ width: "200px" }} />
      );
    }
    else if (boxType == ITEM_BOX_UNCOMMON) {
      return (
        <img draggable="false"  src={ItemBoxUncommon} alt={"Item Box Uncommon"} style={{ width: "200px" }} />
      );
    }
    else if (boxType == ITEM_BOX_RARE) {
      return (
        <img draggable="false"  src={ItemBoxRare} alt={"Item Box Rare"} style={{ width: "200px" }} />
      );
    }
    else if (boxType == ITEM_BOX_EPIC) {
      return (
        <img draggable="false"  src={ItemBoxEpic} alt={"Item Box Epic"} style={{ width: "200px" }} />
      );
    }
    else if (boxType == ITEM_BOX_LEGENDARY) {
      return (
        <img draggable="false"  src={ItemBoxLegendary} alt={"Item Box Legendary"} style={{ width: "200px" }} />
      );
    }
  };

  const showName = (boxType: number) => {
    if (boxType == GOBOX_COMMON) {
      return "Gobox Common";
    }
    else if (boxType == GOBOX_UNCOMMON) {
      return "Gobox Uncommon";
    }
    else if (boxType == GOBOX_RARE) {
      return "Gobox Rare";
    }
  };

  return (
    <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1, borderRadius: 3, width: 260 }} elevation={6}>
      <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={1}>
        <Typography sx={{ ...GoblinStyles.textMain }}>{showName(param.boxType)}</Typography>
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={2}>
          <Stack direction={"row"} sx={{ ...MainStyles.container, justifyContent: "space-evenly", width: 1 }}>
            {showImage(param.boxType)}
          </Stack>
          <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"} spacing={1} >
            <img draggable="false"  src={gobiCoin} alt={"Gobi token"} style={{width: "20px", height: "20px"}} />
            <Typography sx={{ ...GoblinStyles.sessionTitleText }}>{param.auction.price}</Typography>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }}> / Qtdy: {param.auction.qtdy}</Typography>
          </Stack>
        </Stack>
        {param.buy ?
          <Button sx={{ ...MainStyles.mainButton }} onClick={() => {
            param.buy(param.auction); 
          }}>{param.loading ? "BUYING..." : "BUY"}</Button>
          :
          <></>
        }
        {param.cancel ?
          <Button sx={{ ...MainStyles.mainButton }} onClick={() => {
            param.cancel(param.auction); 
          }}>{param.loading ? "CANCELLING..." : "CANCEL"}</Button>
          :
          <></>
        }
      </Stack>
    </Paper>
  )
}