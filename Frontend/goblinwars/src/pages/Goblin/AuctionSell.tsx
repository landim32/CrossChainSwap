import { Box, Button, IconButton, Paper, Stack, TextField, Theme, Typography } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { SxProps } from "@mui/system";
import { useContext, useEffect, useState } from "react";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { OulinedInput } from "../../components/OutlinedInput";
import CloseIcon from '@mui/icons-material/Close';
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';

interface AuctionSellParam {
  //editCb: (name: string) => void
  close: () => void,
  insert: (tokenId: number, price: number) => void,
  price?: number,
  //dollarPrice: number,
  tokenId: number,
  loading: boolean,
}

const textInput : SxProps<Theme> = {
  width: 1
}

const textInputProps = {
  color: "#fff",
  inputMode: 'numeric', 
  pattern: '[0-9]*'
}

/*
const textInfo : SxProps<Theme> = {
  ...GoblinStyles.sessionTitleText,
  fontSize: isMobile ? 14 : 16
}

const textDolar : SxProps<Theme> = {
  ...GoblinStyles.sessionTitleText,
  fontSize: isMobile ? 14 : 20
}
*/

export function AuctionSell(param: AuctionSellParam) {

  //const [dollarPrice, setDollarPrice] = useState<number>(0);
  const [price, setPrice] = useState<number>(param.price);
  //const [priceInDollar, setPriceInDollar] = useState<number>(0);

  const priceChange = (e: any) => {
    setPrice(e.target.value);
    //let priceUSD = e.target.value * param.dollarPrice;
    //setPriceInDollar(priceUSD);
  };

  return (
    <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
      <Paper sx={{ ...MainStyles.popUp, bgcolor: "#2b211f" }}>
        <Stack sx={{...MainStyles.container}}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            
            <Stack direction={"row"} sx={{ display: "flex", justifyContent: "space-between", pl: 1, pr: 1 }}>
                <Typography sx={{ ...GoblinStyles.textMain }} >SELL YOUR GOBLIN</Typography>
                <IconButton onClick={param.close}>
                  <CloseIcon sx={{ color: "white" }} fontSize={"large"} />
                </IconButton>
              </Stack>
          </Paper>
          <Stack sx={{ ...MainStyles.container, width: isMobile ? 350 : 500, p: 2 }} spacing={2}>
            <Stack direction="row" spacing={isMobile ? 0 : 3}>
              <TextField id="price" type="number" label="Price" value={price} 
                onChange={priceChange}
                InputLabelProps={{ sx: { ...textInputProps } }}
                InputProps={{ sx: { ...textInputProps } }}
                FormHelperTextProps={{ sx: { ...textInputProps } }}
                sx={{ width: "100%"}}
                helperText="Minimum price is 200 GOBI. 5% fee on sale.">
              </TextField>
            </Stack>
            <Stack direction="row" spacing={3}>
              <Button sx={{ ...MainStyles.mainButton, color: "white", width: 120 }} onClick={() => {
                  param.insert(param.tokenId, price);    
                }} >{param.loading ? "SELLING..." : "SELL"}</Button> 
            </Stack>
          </Stack>
          
        </Stack>
      </Paper>
    </Box>
  )
}