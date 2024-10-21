import { Stack, Box, Typography, Paper, Button, Theme, Divider, Dialog, DialogTitle, DialogContent, DialogActions, DialogContentText, Snackbar, Alert, AlertColor } from "@mui/material";
import { GwViewPort } from "../../components/GwViewPort";
import { SxProps } from "@mui/system";
import React, {useContext, useEffect, useState} from 'react';
import { GoblinStyles, MainStyles } from "../../utils/style";
import Gobox1 from '../../assets/images/box/gobox1.png';
import Gobox2 from '../../assets/images/box/gobox2.png';
import Gobox3 from '../../assets/images/box/gobox3.png';
import TextField from '@mui/material/TextField';
import MenuItem from '@mui/material/MenuItem';
import GoboxContext from "../../contexts/payment/GoboxContext";
import { RarityStyles } from "../../utils/RarityStyles";
import { RarityEnum } from "../../dto/enum/RarityEnum";
import AuthContext from "../../contexts/auth/AuthContext";
import { useHistory } from "react-router-dom";
import GoblinUserFactory from "../../business/factory/GoblinUserFactory";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";
//import DollarContext from '../contexts/goblin/GoblinContext';

const rarityLeft : SxProps<Theme> = {
    ...GoblinStyles.sessionTitleText,
    textAlign: "left",
    width: 140
};
const rarityRight : SxProps<Theme> = {
    ...GoblinStyles.sessionTitleText,
    textAlign: "right"
};

const textInputProps : SxProps<Theme> = {
    color: "#fff"
}

export function BoxSeller() {
    const history = useHistory();

    //const dollarContext = useContext(DollarContext);
    const goboxContext = useContext(GoboxContext);
    const authContext = useContext(AuthContext);
    const goblinUserContext = useContext(GoblinUserContext);
    const [open, setOpen] = useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleSuccessClose = () => {
        setOpen(false);
        history.push("/login");
    };

    const [gobox1Loading, setGobox1Loading] = useState<boolean>(false);
    const [gobox2Loading, setGobox2Loading] = useState<boolean>(false);
    const [gobox3Loading, setGobox3Loading] = useState<boolean>(false);

    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");

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

    const loadGobox = () => {
        goboxContext.list().then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, "error")
            }
        });
    };

    const reloadBalance = async () => {
        let ret = await goblinUserContext.loadBalance();
        if (!ret.sucesso) {
            showDialog(ret.mensagemErro, 'error');
        }
    };

    const [currentGobox, setCurrentGobox] = useState<number>(0);
    const [openAlert, setOpenAlert] = useState<boolean>(false);

    const showAlert = (tokenGobox: number) => {
        setCurrentGobox(tokenGobox);
        setOpenAlert(true);
    };

    const closeAlert = () => {
        setOpenAlert(false);
    };

    const executeAlert = async () => {
        setOpenAlert(false);
        if (currentGobox == goboxContext.COMMON_ID) {
            setGobox1Loading(true);
            let ret = await goboxContext.buyToken(goboxContext.COMMON_ID, goboxContext.commonAmount);
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, "error");
            }
            loadGobox();
            reloadBalance();
            setGobox1Loading(false);
            showDialog(ret.mensagemSucesso, "success");
        }
        else if (currentGobox == goboxContext.UNCOMMON_ID) {
            setGobox2Loading(true);
            let ret = await goboxContext.buyToken(goboxContext.UNCOMMON_ID, goboxContext.uncommonAmount);
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, "error");
            }
            loadGobox();
            reloadBalance();
            setGobox2Loading(false);
            showDialog(ret.mensagemSucesso, "success");
        }
        else if (currentGobox == goboxContext.RARE_ID) {
            setGobox3Loading(true);
            let ret = await goboxContext.buyToken(goboxContext.RARE_ID, goboxContext.rareAmount);
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, "error");
            }
            loadGobox();
            reloadBalance();
            setGobox3Loading(false);
            showDialog(ret.mensagemSucesso, "success");
        }
    };

    useEffect(() => {
        loadGobox();
    }, []);

    return (
        <GwViewPort>
            <Stack direction={"row"} sx={{ ...MainStyles.container, flexWrap: "wrap", mb: 4 }} >
                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, height: "100%", padding: "20px", m: 1 }}>
                    <Box sx={{ cursor: "pointer", alignItems: "center", alignContent: "center" }}>
                        <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center"}}>GOBOX Common #1</Typography>
                        <img draggable="false"  src={Gobox1} style={{width: "300px"}} />
                        <Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>{goboxContext.goboxCommon?.price} GOBI</Typography>
                        {/*<Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>My Boxes: {goboxContext.goboxCommon?.qtdy}</Typography>*/}
                        <Divider sx={{ width: 1, m: 1 }} />
                        <Stack sx={{ ...MainStyles.container, alignContent: "flex-start", alignItems: "flex-start", justifyContent: "flex-start", justifyItems: "flex-start", height: 180 }}>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Common)}}>Common</Typography>
                                <Typography sx={{...rarityRight}}>50.22%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Uncommon)}}>Uncommon</Typography>
                                <Typography sx={{...rarityRight}}>32.15%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Rare)}}>Rare</Typography>
                                <Typography sx={{...rarityRight}}>12.54%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Epic)}}>Epic</Typography>
                                <Typography sx={{...rarityRight}}>4.31%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Legendary)}}>Legendary</Typography>
                                <Typography sx={{...rarityRight}}>0.78%</Typography>
                            </Stack>
                        </Stack>
                        <TextField id="gobox1_amount" select label="Amount" value={goboxContext.commonAmount} 
                            onChange={(e) => {goboxContext.setCommonAmount(parseInt(e.target.value));}}
                            InputLabelProps={{ sx: { ...textInputProps } }}
                            InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}
                            sx={{ width: "100%", mt: 2}}
                            helperText="Please select your box amount">
                            <MenuItem key={1} value={1}>01</MenuItem>
                            <MenuItem key={2} value={2}>02</MenuItem>
                            <MenuItem key={3} value={3}>03</MenuItem>
                            <MenuItem key={4} value={4}>04</MenuItem>
                            <MenuItem key={5} value={5}>05</MenuItem>
                            <MenuItem key={6} value={6}>06</MenuItem>
                            <MenuItem key={7} value={7}>07</MenuItem>
                            <MenuItem key={8} value={8}>08</MenuItem>
                            <MenuItem key={9} value={9}>09</MenuItem>
                            <MenuItem key={10} value={10}>10</MenuItem>
                        </TextField>
                        <Stack direction={"row"} spacing={1}>
                            <Button sx={{ ...MainStyles.mainButton }} 
                                onClick={ async () => {
                                    if(!authContext.sessionInfo) {
                                        handleClickOpen();
                                        return;
                                    }
                                    showAlert(goboxContext.COMMON_ID);
                            }}>{gobox1Loading ? "BUYING..." : "BUY"}</Button>
                        </Stack>
                    </Box>
                </Paper>
                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, height: "100%", padding: "20px", m: 1 }}>
                    <Box sx={{ cursor: "pointer", alignItems: "center", alignContent: "center" }}>
                        <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center"}}>GOBOX Uncommon #2</Typography>
                        <img draggable="false"  src={Gobox2} style={{width: "300px"}} />
                        <Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>{goboxContext.goboxUncommon?.price} GOBI</Typography>
                        {/*<Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>My Boxes: {goboxContext.goboxUncommon?.qtdy}</Typography>*/}
                        <Divider sx={{ width: 1, m: 1 }} />
                        <Stack sx={{ ...MainStyles.container, alignContent: "flex-start", alignItems: "flex-start", justifyContent: "flex-start", justifyItems: "flex-start", height: 180 }}>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Uncommon)}}>Uncommon</Typography>
                                <Typography sx={{...rarityRight}}>64,86%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Rare)}}>Rare</Typography>
                                <Typography sx={{...rarityRight}}>25,19%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Epic)}}>Epic</Typography>
                                <Typography sx={{...rarityRight}}>8,66%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Legendary)}}>Legendary</Typography>
                                <Typography sx={{...rarityRight}}>1,28%</Typography>
                            </Stack>
                        </Stack>
                        <TextField id="gobox2_amount" select label="Amount" value={goboxContext.uncommonAmount} 
                            onChange={(e) => {goboxContext.setUncommonAmount(parseInt(e.target.value));}}
                            InputLabelProps={{ sx: { ...textInputProps } }}
                            InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}
                            sx={{ width: "100%", mt: 2}}
                            helperText="Please select your box amount">
                            <MenuItem key={1} value={1}>01</MenuItem>
                            <MenuItem key={2} value={2}>02</MenuItem>
                            <MenuItem key={3} value={3}>03</MenuItem>
                            <MenuItem key={4} value={4}>04</MenuItem>
                            <MenuItem key={5} value={5}>05</MenuItem>
                            <MenuItem key={6} value={6}>06</MenuItem>
                            <MenuItem key={7} value={7}>07</MenuItem>
                            <MenuItem key={8} value={8}>08</MenuItem>
                            <MenuItem key={9} value={9}>09</MenuItem>
                            <MenuItem key={10} value={10}>10</MenuItem>
                        </TextField>
                        <Stack direction={"row"} spacing={1}>
                            <Button sx={{ ...MainStyles.mainButton }} 
                                onClick={ async () => {
                                    if(!authContext.sessionInfo) {
                                        handleClickOpen();
                                        return;
                                    }
                                    showAlert(goboxContext.UNCOMMON_ID);
                            }}>{gobox2Loading ? "BUYING..." : "BUY"}</Button>
                        </Stack>
                    </Box>
                </Paper>
                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, height: "100%", padding: "20px", m: 1 }}>
                    <Box sx={{ cursor: "pointer", alignItems: "center", alignContent: "center" }}>
                        <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center"}}>GOBOX Rare #3</Typography>
                        <img draggable="false"  src={Gobox3} style={{width: "300px"}} />
                        <Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>{goboxContext.goboxRare?.price} GOBI</Typography>
                        {/*<Typography sx={{ ...GoblinStyles.sessionTitleText, textAlign: "center"}}>My Boxes: {goboxContext.goboxRare?.qtdy}</Typography>*/}
                        <Divider sx={{ width: 1, m: 1 }} />
                        <Stack sx={{ ...MainStyles.container, alignContent: "flex-start", alignItems: "flex-start", justifyContent: "flex-start", justifyItems: "flex-start", height: 180 }}>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Rare)}}>Rare</Typography>
                                <Typography sx={{...rarityRight}}>71,13%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Epic)}}>Epic</Typography>
                                <Typography sx={{...rarityRight}}>24,45%</Typography>
                            </Stack>
                            <Stack direction={"row"} sx={{ width: 1, justifyContent: "space-between" }}>
                                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Legendary)}}>Legendary</Typography>
                                <Typography sx={{...rarityRight}}>4,42%</Typography>
                            </Stack>
                        </Stack>
                        <TextField id="gobox3_amount" select label="Amount" value={goboxContext.rareAmount} 
                            onChange={(e) => {goboxContext.setRareAmount(parseInt(e.target.value));}}
                            InputLabelProps={{ sx: { ...textInputProps } }}
                            InputProps={{ sx: { ...textInputProps } }}
                            FormHelperTextProps={{ sx: { ...textInputProps } }}
                            sx={{ width: "100%", mt: 2 }}
                            helperText="Please select your box amount">
                            <MenuItem key={1} value={1}>01</MenuItem>
                            <MenuItem key={2} value={2}>02</MenuItem>
                            <MenuItem key={3} value={3}>03</MenuItem>
                            <MenuItem key={4} value={4}>04</MenuItem>
                            <MenuItem key={5} value={5}>05</MenuItem>
                            <MenuItem key={6} value={6}>06</MenuItem>
                            <MenuItem key={7} value={7}>07</MenuItem>
                            <MenuItem key={8} value={8}>08</MenuItem>
                            <MenuItem key={9} value={9}>09</MenuItem>
                            <MenuItem key={10} value={10}>10</MenuItem>
                        </TextField>
                        <Stack direction={"row"} spacing={1}>
                            <Button sx={{ ...MainStyles.mainButton }} 
                                onClick={ async () => {
                                    if(!authContext.sessionInfo) {
                                        handleClickOpen();
                                        return;
                                    }
                                    showAlert(goboxContext.RARE_ID);
                            }}>{gobox3Loading ? "BUYING..." : "BUY"}</Button>
                        </Stack>
                    </Box>
                </Paper>
            </Stack>
            <Dialog
                open={open}
                onClose={handleSuccessClose}
            >
                <DialogTitle>
                    {"Authetication"}
                </DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        To buy a box you need to login.
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleSuccessClose}>Login</Button>
                </DialogActions>
            </Dialog>
            <Dialog open={openAlert} onClose={closeAlert}>
                <DialogTitle>{"Warning"}</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        Are you sure?
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <Button onClick={executeAlert}>Yes</Button>
                    <Button onClick={closeAlert}>No</Button>
                </DialogActions>
            </Dialog>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity={severity} sx={{ width: '100%' }}>
                    {message}
                </Alert>
            </Snackbar>
        </GwViewPort>
    )
}