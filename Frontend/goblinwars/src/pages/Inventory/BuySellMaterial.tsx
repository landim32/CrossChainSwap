import { Alert, AlertColor, Backdrop, Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Snackbar, Stack, Typography, SxProps, Theme, Box, InputAdornment, Paper } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { isMobile } from "react-device-detect";
import useInterval from "use-interval";
import { OulinedInput } from "../../components/OutlinedInput";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";
import MaterialMarketContext from "../../contexts/materialMarket/MaterialMarketContext";
import ProviderResult from "../../dto/contexts/ProviderResult";
import { UserItemInfo } from "../../dto/domain/UserItemInfo";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { FontButton } from "../../utils/fontStyle";
import { MainStyles, GoblinStyles } from "../../utils/style";
import GoldIcon from "../../assets/images/coins/goldCoin.png";
import ItemContext from "../../contexts/item/ItemContext";

interface BuySellMaterialParam {
    useriteminfo: UserItemInfo;
    isSell: boolean;
    successCb?: () => void;
}

const textInputProps : SxProps<Theme> = {
    ...FontButton,
    color: GoblinWarsColors.titleColor,
    fontSize: 22,
    textAlign: "end",
    height: 48,
    width: 1
}
  
const textInput : SxProps<Theme> = {
    ...MainStyles.container,
    width: 1,
    textAlign: "end",
    height: 48
}

const textFinance = {
    ...GoblinStyles.textMain,
    fontSize: isMobile ? 12 : 16
}

const textTax = {
    ...GoblinStyles.textMain,
    fontSize: isMobile ? 10 : 12
}

export function BuySellMaterial(param: BuySellMaterialParam) {
    const materialMarketContext = useContext(MaterialMarketContext);
    const goblinUserContext = useContext(GoblinUserContext);
    const itemContext = useContext(ItemContext);
    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");
    const [confirm, setConfirm] = useState<boolean>(false);
    
    const iteminfo = param.useriteminfo.item;
    const qtdeUser = param.useriteminfo.qtde;
    const isSell = param.isSell;

    useEffect(() => {
        materialMarketContext.refresh();
        materialMarketContext.balance(iteminfo.key);
    }, []);

    useInterval(() => {
        materialMarketContext.balance(iteminfo.key);
    }, 60000)

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

    const handleOpenConfirmation = () => {
        setConfirm(true)
    }

    const handleCloseConfirmation = () => {
        setConfirm(false)
    }

    const executeConfirm = () => {
        handleCloseConfirmation();
        if(isSell) {
            materialMarketContext.swapMaterialPerGold().then(retSwap);
        } else {
            materialMarketContext.swapGoldPerMaterial().then(retSwap);
        }
    }

    const retSwap = (ret : ProviderResult) => {
        if(ret.sucesso) {
            materialMarketContext.balance(iteminfo.key);
            goblinUserContext.loadBalance();
            itemContext.getbykey(iteminfo.key);
            param.successCb && param.successCb();
            showDialog("Exchange Completed !", "success");
        } else {
            showDialog(ret.mensagemErro, "error");
        }
    }

    const getTaxText = () => {
        if(isSell) {
            return parseFloat(materialMarketContext.priceForSellBase.toString()).toFixed(2) + "-" + parseFloat(materialMarketContext.sellTax.toString()).toFixed(2) + "(tax)";
        } else {
            return parseFloat(materialMarketContext.priceForBuyBase.toString()).toFixed(2) + "+" + parseFloat(materialMarketContext.buyTax.toString()).toFixed(2) + "(tax)";
        }
    }

    return (
        <>
            <Stack sx={{ ...MainStyles.container, width: isMobile ? 340 : 500 }} >
                <Stack sx={{ ...MainStyles.container, alignSelf: "flex-start", justifyContent: "space-between", width: 1, mb: -2 }} direction={"row"}>
                    <Typography sx={{ ...textInputProps, width: undefined }} >Units of {iteminfo.name}</Typography>
                </Stack>
                <Stack sx={{ ...MainStyles.container, width: 1 }} direction={"row"} spacing={1}>
                    <OulinedInput id={isSell ? "qtdeMaterialSell" : "qtdeMaterialBuy"} variant="outlined" value={materialMarketContext.qtdeMaterial} placeholder="0"
                        onChange={(event: any) => { 
                            materialMarketContext.setQtdeMaterial(event.target.value, isSell);
                        }} 
                        sx={{ ...textInput }} 
                        InputProps={{ 
                            sx: { ...textInputProps },
                            endAdornment: 
                                isSell ? 
                                <InputAdornment position="end">
                                    <Paper sx={{ ...MainStyles.container, p: 1, bgcolor: GoblinWarsColors.titleColor, height: 25, cursor: "pointer" }} onClick={() => {
                                        materialMarketContext.setQtdeMaterial(qtdeUser.toString(), isSell);
                                    }}>
                                        <Typography sx={{ ...GoblinStyles.textMain, fontSize: 12 }}>max</Typography>
                                    </Paper>
                                </InputAdornment> 
                                : <></>
                        }} 
                        inputProps={{ style: { textAlign: "end" }, lang: "en" }}  
                    />
                    <Button sx={{ ...MainStyles.mainButton, width: 100 }} onClick={() => { 
                        if(!goblinUserContext.balance) {
                            return;
                        }
                        if(materialMarketContext.loading.swap) {
                            return;
                        }
                        if(parseInt(materialMarketContext.qtdeMaterial) < 0) {
                            showDialog("Invalid value", "error");
                            return;
                        }
                        if(!isSell && parseInt(materialMarketContext.qtdeMaterial) > materialMarketContext.materialBalance.totalmaterial) {
                            showDialog("Invalid amount of itens to sell", "error");
                            return;
                        }
                        if(!isSell && materialMarketContext.priceForBuy > goblinUserContext.balance.goldBalance) {
                            showDialog("Insufficient amount of gold", "error");
                            return;
                        }
                        handleOpenConfirmation()
                    }} >
                        <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={0.5}>
                            <img src={GoldIcon} style={{ height: 24 }} />
                            <Typography sx={{ ...GoblinStyles.textMain }}>{isSell ? "Sell" : "Buy"}</Typography> 
                        </Stack>
                    </Button>
                </Stack>
                {
                    parseInt(materialMarketContext.qtdeMaterial) > 0 ?
                    <Stack sx={{ ...MainStyles.container, alignSelf: "flex-start", justifyContent: "space-between", width: 1 }} direction={"row"}>
                        <Typography sx={{ ...textFinance }} >Price per unit: {parseFloat((isSell ? materialMarketContext.swapRateSell : materialMarketContext.swapRateBuy).toString()).toFixed(4)}</Typography>
                        <Stack sx={{ ...MainStyles.container, pr: "94px" }} spacing={0}>
                            <Typography sx={{ ...textFinance }} >Total: {parseFloat(((isSell ? materialMarketContext.priceForSell : materialMarketContext.priceForBuy)).toString()).toFixed(4)}</Typography>
                            <Typography sx={{ ...textTax }}>{getTaxText()}</Typography>
                        </Stack>
                    </Stack>
                    : <Box sx={{ height: 28 }}>
                        <Typography />
                    </Box>
                }
            </Stack>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
              <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                {message}
              </Alert>
            </Snackbar>
            <Dialog open={confirm} onClose={handleCloseConfirmation}>
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
            {
                (materialMarketContext.loading.materialbalance || materialMarketContext.loading.swap) &&
                <Backdrop
                    sx={{ color: '#fff', zIndex: (theme) => 99 }}
                    open={true}
                >
                    <CircularProgress color="inherit" />
                </Backdrop>
            }
        </>
    );
}