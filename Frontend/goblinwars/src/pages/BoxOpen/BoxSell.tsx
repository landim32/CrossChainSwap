import { Box, Button, IconButton, Paper, Stack, TextField, Theme, Typography } from "@mui/material";
import { makeStyles } from "@mui/styles";
import { SxProps } from "@mui/system";
import { useContext, useEffect, useState } from "react";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { OulinedInput } from "../../components/OutlinedInput";
import CloseIcon from '@mui/icons-material/Close';
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';

interface AuctionSellParam {
  close: () => void,
  insert: (tokenId: number, price: number, qtdy: number) => void,
  error: (msg: string) => void,
  price?: number,
  qtdy: number,
  boxType: number,
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

export function BoxSell(param: AuctionSellParam) {

  const [price, setPrice] = useState<number>(param.price);
  const [qtdy, setQtdy] = useState<number>(param.qtdy);

  const priceChange = (e: any) => {
    setPrice(e.target.value);
  };

  const qtdyChange = (e: any) => {
    setQtdy(e.target.value);
  };

  return (
    <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
      <Paper sx={{ ...MainStyles.popUp, bgcolor: "#2b211f" }}>
        <Stack sx={{...MainStyles.container}}>
          <Paper sx={{ ...GoblinStyles.sessionTitle }}>
            
            <Stack direction={"row"} sx={{ display: "flex", justifyContent: "space-between", pl: 1, pr: 1 }}>
                <Typography sx={{ ...GoblinStyles.textMain }} >SELL YOUR BOXES</Typography>
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
                helperText="Price per Box. Minimum 50 GOBI.">
              </TextField>
            </Stack>
            <Stack direction="row" spacing={isMobile ? 0 : 3}>
              <TextField id="qtdy" type="number" label="Quantity" value={qtdy} 
                onChange={qtdyChange}
                InputLabelProps={{ sx: { ...textInputProps } }}
                InputProps={{ sx: { ...textInputProps } }}
                FormHelperTextProps={{ sx: { ...textInputProps } }}
                sx={{ width: "100%"}}
                helperText="Minimum 1.">
              </TextField>
            </Stack>
            <Stack direction="row" spacing={3}>
              <Button sx={{ ...MainStyles.mainButton, color: "white", width: 120 }} onClick={() => {
                  if(isNaN(price) || price < 50){
                    param.error("Invalid price.");
                    return;
                  }
                  if(isNaN(qtdy) || qtdy < 1) {
                    param.error("Invalid quantity.");
                    return;
                  }
                  param.insert(param.boxType, price, qtdy);    
                }} >{param.loading ? "SELLING..." : "SELL"}</Button> 
            </Stack>
          </Stack>
          
        </Stack>
      </Paper>
    </Box>
  )
}