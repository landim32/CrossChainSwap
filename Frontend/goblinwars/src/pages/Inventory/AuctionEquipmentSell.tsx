import { Box, Button, IconButton, Paper, Stack, TextField, Theme, Typography } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { SxProps } from "@mui/system";
import { useContext, useEffect, useState } from "react";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { OulinedInput } from "../../components/OutlinedInput";
import CloseIcon from '@mui/icons-material/Close';
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';
import { FontButton } from "../../utils/fontStyle";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";

interface AuctionEquipmentSellParam {
  close: () => void,
  insert: (tokenId: number, price: number) => void,
  price?: number,
  itemKey: number,
  loading: boolean,
}

const textInputProps : SxProps<Theme> = {
  ...FontButton,
  color: GoblinWarsColors.titleColor,
  fontSize: 22,
  textAlign: "end",
  height: 48
}

const textInput : SxProps<Theme> = {
  ...MainStyles.container,
  width: isMobile ? 220 : 380, 
  textAlign: "end",
  color: "#fff"
}

export function AuctionEquipmentSell(param: AuctionEquipmentSellParam) {

  const [price, setPrice] = useState<string>(param.price?.toString() || "");

  const priceChange = (e: any) => {
    let value = e.target.value;
    value.replace(',', '.');
    if(value == ""){
      setPrice("");
      return;
    }
    if(/^(^\d+\.\d*$)|(^\d+$)|(^\d*\.\d+$)|(^\d+\.\d+$)$/.test(value)){
      var auxValue = value;
      if(auxValue.toString()[auxValue.toString().length-1] == '.')
        auxValue = auxValue + '0';
      if(auxValue.toString()[0] == '.')
        auxValue = '0' + auxValue;
      if(parseFloat(auxValue) >= 0){
        setPrice(value);
      }
    }
    
  };

  return (
    <Stack sx={{ ...MainStyles.container, p: 1 }}>
      <Stack sx={{ ...MainStyles.container, width: isMobile ? 350 : 500, p: 2 }}>
        <Stack sx={{ ...MainStyles.container, alignSelf: "flex-start", justifyContent: "space-between", width: isMobile ? 220 : 380, mb: -1.5 }} direction={"row"}>
            <Typography sx={{ ...textInputProps }} >Unit price of equipment</Typography>
        </Stack>
        <Stack sx={{ ...MainStyles.container, alignContent: "flex-start", alignItems: "flex-start" }} direction="row" spacing={1}>
          <OulinedInput id={"equipSellPrice"} variant="outlined" value={price}  placeholder="0"
              onChange={priceChange}
              sx={{ ...textInput }} 
              InputProps={{ 
                  sx: { ...textInputProps }
              }} 
              inputProps={{ style: { textAlign: "end" }, lang: "en" }} 
              helperText={<Typography sx={{ ...GoblinStyles.sessionSubTitleText, fontSize: 14 }} >Minimum price is 20 GOBI. 5% fee on sale.</Typography>}
          />
          <Button sx={{ ...MainStyles.mainButton, color: "white", width: 120 }} onClick={() => {
              if(!isNaN(parseFloat(price)))
                param.insert(param.itemKey, parseFloat(price));    
            }} >{param.loading ? "SELLING..." : "SELL"}</Button>
        </Stack>
      </Stack>
      
    </Stack>
  )
}