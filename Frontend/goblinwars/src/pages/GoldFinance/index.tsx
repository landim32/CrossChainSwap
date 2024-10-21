import { Alert, Backdrop, Box, Button, CircularProgress, Divider, Grid, Snackbar, Stack, Theme, Typography, SxProps, Paper, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, AlertColor, InputAdornment, Pagination, PaginationItem, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { CSSProperties, useContext, useEffect, useState } from "react";
import { GwViewPort } from "../../components/GwViewPort";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";
import GoldFinanceContext from "../../contexts/goldFinance/GoldFinanceContext";
import { OulinedInput } from "../../components/OutlinedInput";
import GobiIcon from "../../assets/images/coins/gobiCoin.png";
import GoldIcon from "../../assets/images/coins/goldCoin.png";
import './styles.css';
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import ArrowDownwardIcon from '@mui/icons-material/ArrowDownward';
import SwapVertIcon from '@mui/icons-material/SwapVert';
import CachedIcon from '@mui/icons-material/Cached';
import { FontButton } from "../../utils/fontStyle";
import { FormatColorResetRounded } from "@mui/icons-material";
import ProviderResult from "../../dto/contexts/ProviderResult";
import MercadorIcon from "../../assets/images/marketplace/mercador.png";
import { BrowserView, isMobile, MobileView } from "react-device-detect";
import Moment from "moment";
import { GoldTransactionEnum } from "../../dto/enum/GoldTransactionEnum";
import AddIcon from '@mui/icons-material/Add';
import useInterval from '@use-it/interval';

const textInputProps : SxProps<Theme> = {
  ...FontButton,
  color: GoblinWarsColors.titleColor,
  fontSize: 22,
  textAlign: "end",
  height: 48
}

const textInput : SxProps<Theme> = {
  width: 1,
  textAlign: "end",
  height: 48
}

const coinIcon : CSSProperties = {
  height: 30
}

const textFinance = {
  ...GoblinStyles.textMain,
  fontSize: isMobile ? 16 : 22
}

export function GoldFinance() {
    const goldFinanceContext = useContext(GoldFinanceContext);
    const goblinUserContext = useContext(GoblinUserContext);
    const [openDialog, setOpenDialog] = useState(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");
    const [mouseSwap, setMouseSwap] = useState(false);
    const [confirm, setConfirm] = useState<boolean>(false);
    const [tax, setTax] = useState<number>(20);

    useEffect(() => {
      goldFinanceContext.list(1);
      goldFinanceContext.balance();
    }, []);

    useInterval(() => {
      goldFinanceContext.balance();
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

    const retSwap = (ret : ProviderResult) => {
      if(ret.sucesso) {
        goldFinanceContext.list(1);
        goldFinanceContext.balance();
        goblinUserContext.loadBalance();
        showDialog("Exchange Completed !", "success");
      } else {
        showDialog(ret.mensagemErro, "error");
      }
    }
    
    const executeConfirm = () => {
      handleCloseConfirmation();
      if(goldFinanceContext.isGobiToGold) {
        goldFinanceContext.swapGobi().then(retSwap);
      } else {
        goldFinanceContext.swapGold().then(retSwap);
      }
    }

    const getCoinValue = (value: string) => {
      return value;
    }

    const getTransactionStatus = (status: GoldTransactionEnum) => {
      let imgSize = 18;
      switch(status) {
        case GoldTransactionEnum.Transaction:
          return (
            <Stack sx={{ ...MainStyles.container }} spacing={0.5} direction={"row"}>
              <Stack sx={{ ...MainStyles.container }} spacing={0} direction={"row"}>
                <AddIcon sx={{ color: "green" }} fontSize={"small"} />
                <img draggable="false"  src={GoldIcon} style={{ height: imgSize }} />
              </Stack>
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >Game Reward</Typography>
            </Stack>
          )
        case GoldTransactionEnum.GoldForGobi:
          return (
            <Stack sx={{ ...MainStyles.container }} spacing={0.5} direction={"row"}>
              <Stack sx={{ ...MainStyles.container }} spacing={0} direction={"row"}>
                <SwapVertIcon sx={{ color: GoblinWarsColors.titleColor }} fontSize={"small"} />
                <img draggable="false"  src={GoldIcon} style={{ height: imgSize }} />
              </Stack>
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >Swap Gold</Typography>
            </Stack>
          )
        case GoldTransactionEnum.GobiForGold:
          return (
            <Stack sx={{ ...MainStyles.container }} spacing={0.5} direction={"row"}>
              <Stack sx={{ ...MainStyles.container }} spacing={0} direction={"row"}>
                <SwapVertIcon sx={{ color: GoblinWarsColors.titleColor }} fontSize={"small"} />
                <img draggable="false"  src={GobiIcon} style={{ height: imgSize }} />
              </Stack>
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >Swap GOBI</Typography>
            </Stack>
          )
      }
    }

    const getTransactionHistoric = () => {
      return !goldFinanceContext.loading.list ?
          <Stack spacing={1} sx={{ ...MainStyles.container, pb: 4, width: isMobile ? 340 : "auto"}}>
              <Typography sx={{ ...GoblinStyles.textMain }}>Transaction Hystoric</Typography>
              <BrowserView>
                  <TableContainer sx={{ ...MainStyles.floatingBox }}>
                      <Table aria-label="customized table">
                      <TableHead>
                          <TableRow>
                              <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Date (GMT)</Typography></TableCell>
                              <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Gold Credit</Typography></TableCell>
                              <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Gold Debit</Typography></TableCell>
                              <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Gold Swap Tax</Typography></TableCell>
                              <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>GOBI Credi</Typography></TableCell>
                              <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>GOBI Debit</Typography></TableCell>
                              <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>GOBI Swap Tax</Typography></TableCell>
                              <TableCell><Typography sx={{ ...textFinance, fontSize: 18, textAlign: "center" }}>Type</Typography></TableCell>
                          </TableRow>
                      </TableHead>
                      <TableBody>
                          {goldFinanceContext.transactions?.transactions.map((row) => (
                          <TableRow key={row.id}>
                              <TableCell component="td" scope="row">
                                  <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                      {Moment(row.insertdate).format("MM/DD/YYYY [at] HH:mm:ss")}
                                  </Typography>
                              </TableCell>
                              <TableCell component="td" scope="row">
                                  <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                      {row.credit.toFixed(4) || "-"}
                                  </Typography>
                              </TableCell>
                              <TableCell component="td" scope="row">
                                  <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                      {row.debit.toFixed(4) || "-"}
                                  </Typography>
                              </TableCell>
                              <TableCell component="td" scope="row">
                                  <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                      {row.transactiongoldtax?.toFixed(4) || "-"}
                                  </Typography>
                              </TableCell>
                              <TableCell component="td" scope="row">
                                  <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                      {row.gobicredit?.toFixed(4) || "-"}
                                  </Typography>
                              </TableCell>
                              <TableCell component="td" scope="row">
                                  <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                      {row.gobidebit?.toFixed(4) || "-"}
                                  </Typography>
                              </TableCell>
                              <TableCell component="td" scope="row">
                                  <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                      {row.transactiongobitax?.toFixed(4) || "-"}
                                  </Typography>
                              </TableCell>
                              <TableCell component="td" scope="row">
                                  <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "center"}}>
                                      {getTransactionStatus(row.status)}
                                  </Typography>
                              </TableCell>
                          </TableRow>
                          ))}
                      </TableBody>
                      </Table>
                  </TableContainer>
              </BrowserView>
              <MobileView>
                  <Stack sx={{ ...MainStyles.container }} spacing={1} >
                      {
                          goldFinanceContext.transactions?.transactions.map((row) => (
                              <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox }}>
                                  <Stack sx={{ ...MainStyles.container }}>
                                      <Grid sx={{ ...MainStyles.container }} container >
                                          <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                              <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Date (GMT):</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{Moment(row.insertdate).format("MM/DD/YYYY [at] HH:mm:ss")}</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                              <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Gold Credit:</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.credit.toFixed(4)}</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                              <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Gold Debit:</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.debit.toFixed(4)}</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                              <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Gold Swap Tax:</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.transactiongoldtax?.toFixed(4) || "-"}</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                              <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>GOBI Credit:</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.gobicredit?.toFixed(4) || "-"}</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                              <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>GOBI Debit:</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.gobidebit?.toFixed(4) || "-"}</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={4} >
                                              <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>GOBI Swap Tax:</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{row.transactiongobitax?.toFixed(4) || "-"}</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={4} > 
                                              <Typography sx={{ ...textFinance, textAlign: "right", width: 1}}>Type:</Typography>
                                          </Grid>
                                          <Grid sx={{ ...MainStyles.container }} item xs={8} >
                                              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, textAlign: "left"}}>{getTransactionStatus(row.status)}</Typography>
                                          </Grid>
                                      </Grid>
                                  </Stack>
                              </Paper>
                          ))
                      }
                  </Stack>
              </MobileView>
              <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
                  {goldFinanceContext.transactions && 
                  <Box sx={{ ...MainStyles.container, width: 1 }}>
                      <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                          <Pagination 
                              count={goldFinanceContext.transactions.totalpages} 
                              page={goldFinanceContext.transactions.page} 
                              onChange={(event: object, pg: number) => {
                                goldFinanceContext.list(pg).then((ret) => {
                                    if (!ret.sucesso) {
                                        showDialog(ret.mensagemErro, 'error');
                                    }
                                });
                              }} renderItem={(item)=> <PaginationItem {...item} sx={{ ...GoblinStyles.sessionSubTitleText }} /> }
                          />
                      </Paper>
                  </Box>
                  }
              </Stack>
          </Stack>
          : <CircularProgress />
    }

    const getGobiBlock = () => {
      return (
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0.5}>
          <Stack sx={{ ...MainStyles.container, justifyContent: "space-between", width: 1 }} direction={"row"}>
            <Stack sx={{ ...MainStyles.container, width: 1, justifyContent: "flex-start" }} spacing={1} direction={"row"}>
              <img draggable="false"  src={GobiIcon} style={{ ...coinIcon }} />
              <Typography sx={{ ...GoblinStyles.textMain }}>GOBI</Typography>
            </Stack>
            <Stack sx={{ ...MainStyles.container, alignContent: "flex-end", alignItems: "flex-end" }} spacing={0} >
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, fontSize: 12 }}>balance</Typography>
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, fontSize: 15 }}>{goblinUserContext.balance ? goblinUserContext.balance.gobiBalance.toFixed(4) : "..."}</Typography>
            </Stack>
          </Stack>
          <OulinedInput id="gobi" variant="outlined" value={getCoinValue(goldFinanceContext.gobi)} placeholder="0.0"
            onChange={(event: any) => {
              goldFinanceContext.setGobi(event.target.value);
            }} 
            sx={{ ...textInput }} 
            InputProps={{ 
              sx: { ...textInputProps },
              endAdornment: 
                parseFloat(getCoinValue(goldFinanceContext.gobi)) > 0 && !goldFinanceContext.isGobiToGold ? 
                <InputAdornment position="end">
                  <Box sx={{ ...MainStyles.container, height: 1 }}>
                    <Typography sx={{ ...textInputProps, color: "red", pt: "15px", fontSize: 15 }}>
                      -{(parseFloat(getCoinValue(goldFinanceContext.gobi))*(parseFloat(tax.toString())/100)).toFixed(4)}  (tax)
                    </Typography>
                  </Box>
                </InputAdornment> 
                : <></>
            }} 
            inputProps={{ style: { textAlign: "end" }, lang: "en" }}  
          />
        </Stack>
      )
    }

    const getGoldBlock = () => {
      return (
        <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0.5}>
          <Stack sx={{ ...MainStyles.container, justifyContent: "space-between", width: 1 }} direction={"row"}>
            <Stack sx={{ ...MainStyles.container, width: 1, justifyContent: "flex-start" }} spacing={1} direction={"row"}>
              <img draggable="false"  src={GoldIcon} style={{ ...coinIcon }} />
              <Typography sx={{ ...GoblinStyles.textMain }}>Gold Coin</Typography>
            </Stack>
            <Stack sx={{ ...MainStyles.container, alignContent: "flex-end", alignItems: "flex-end" }} spacing={0} >
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, fontSize: 12 }}>balance</Typography>
              <Typography sx={{ ...GoblinStyles.sessionSubTitleText, fontSize: 15 }}>{goblinUserContext.balance ? goblinUserContext.balance.goldBalance.toFixed(4) : "..."}</Typography>
            </Stack>
          </Stack>
          <OulinedInput id="gold" variant="outlined" value={getCoinValue(goldFinanceContext.gold)} placeholder="0.0"
            onChange={(event: any) => {
              goldFinanceContext.setGold(event.target.value);
            }} 
            sx={{ ...textInput }} 
            InputProps={{ 
              sx: { ...textInputProps }, 
              endAdornment: 
                parseFloat(getCoinValue(goldFinanceContext.gold)) > 0 && goldFinanceContext.isGobiToGold ? 
                <InputAdornment position="end">
                  <Box sx={{ ...MainStyles.container, height: 1 }}>
                    <Typography sx={{ ...textInputProps, color: "red", pt: "15px", fontSize: 15 }}>
                      -{(parseFloat(getCoinValue(goldFinanceContext.gold))*(parseFloat(tax.toString())/100)).toFixed(4)}  (tax)
                    </Typography>
                  </Box>
                </InputAdornment> 
                : <></>
            }} 
            inputProps={{ style: { textAlign: "end" }, lang: "en" }}  
          />
        </Stack>
      )
    }

    return (
        <GwViewPort>
            <Stack sx={{ ...MainStyles.container }} spacing={isMobile ? 2 : 0}> 
              <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={0.5}>
                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, width: 320, borderRadius: 3 }}>
                  <Stack sx={{ ...MainStyles.container, width: 1, p: 1.5 }} spacing={2}>
                    <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={0.5}>
                      <Stack sx={{ ...MainStyles.container }} spacing={0}>
                        <Typography sx={{ ...GoblinStyles.textMain }}>Gold Market</Typography>
                        <Typography sx={{ ...GoblinStyles.sessionSubTitleText }}>Swap Gold for Gobi</Typography>
                      </Stack>
                      {
                        isMobile &&
                        <img draggable="false"  src={MercadorIcon} style={{ height: 75 }} />
                      }
                    </Stack>
                    <Divider sx={{ width: 1 }} />
                    <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={1.5}>
                      {
                        goldFinanceContext.isGobiToGold ?
                        getGobiBlock()
                        : getGoldBlock()
                      }
                      <div />
                      <Paper sx={{ ...MainStyles.container, height: 36, width: 36, borderRadius: 18, 
                        bgcolor: mouseSwap ? GoblinWarsColors.darkBox : GoblinWarsColors.titleColor, cursor: "pointer" }}
                        onMouseLeave={() => {
                          setMouseSwap(false);
                        }}
                        onMouseEnter={() => {
                          setMouseSwap(true);
                        }}
                        onClick={goldFinanceContext.setIsGobiToGold}
                        >
                          {
                            mouseSwap ?
                            <SwapVertIcon fontSize="medium" sx={{ color: GoblinWarsColors.titleColor }} />
                            : <ArrowDownwardIcon fontSize="medium" sx={{ color: GoblinWarsColors.darkBox }} />
                          }
                      </Paper>
                      {
                        goldFinanceContext.isGobiToGold ?
                        getGoldBlock()
                        : getGobiBlock()
                      }
                    </Stack>
                    {
                      (parseFloat(goldFinanceContext.gold) > 0 && parseFloat(goldFinanceContext.gobi) > 0) &&
                      <Stack sx={{ ...MainStyles.container, justifyContent: "space-between", width: 1 }} direction={"row"}>
                        <Typography sx={{ ...GoblinStyles.textMain, fontSize: 18 }}>Price</Typography>
                        <Typography sx={{ ...GoblinStyles.sessionTitleText, fontSize: 15 }}>
                          {(goldFinanceContext.isGobiToGold ? goldFinanceContext.swapRateGobi.toFixed(4) + " Gold Coin per GOBI" : goldFinanceContext.swapRateGold.toFixed(4) + " GOBI per Gold Coin")} 
                        </Typography>
                      </Stack> 
                    }
                    <Stack sx={{ ...MainStyles.container }} spacing={1}>
                      <Button sx={{ ...MainStyles.mainButton, width: 1 }} onClick={() => {
                        if(goldFinanceContext.loading.swap)
                          return;
                        if(goldFinanceContext.isGobiToGold) {
                          if(goblinUserContext.balance.gobiBalance < parseFloat(goldFinanceContext.gobi)) {
                            showDialog("You don't have enough gobi.", "error");
                            return;
                          }
                          if(parseFloat(goldFinanceContext.gobi) > 0) {
                            handleOpenConfirmation();
                          } else {
                            showDialog("Invalid amont of gobi.", "error")
                          }
                        } else {
                          if(goblinUserContext.balance.goldBalance < parseFloat(goldFinanceContext.gold)) {
                            showDialog("You don't have enough gold.", "error");
                            return
                          }
                          if(parseFloat(goldFinanceContext.gold) > 0) {
                            handleOpenConfirmation();
                          } else {
                            showDialog("Invalid amont of gold coins.", "error")
                          }
                        }
                      }} >Swap</Button>
                      <Typography sx={{ ...GoblinStyles.sessionSubTitleText, fontSize: 15 }}>
                        * 20% tax for each transaction<br />
                        * Only one transaction per hour<br />
                        * Max of 5 GOBI per day<br />
                      </Typography>
                    </Stack>
                    
                  </Stack>
                </Paper>
                {
                  !isMobile &&
                  <img draggable="false"  src={MercadorIcon} style={{ height: 650 }} />
                }
              </Stack>
              {
                goldFinanceContext.transactions && goldFinanceContext.transactions?.transactions.length > 0 && 
                getTransactionHistoric()
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
                (goldFinanceContext.loading.list || goldFinanceContext.loading.balance || goldFinanceContext.loading.swap) &&
                <Backdrop
                    sx={{ color: '#fff', zIndex: (theme) => 99 }}
                    open={true}
                >
                    <CircularProgress color="inherit" />
                </Backdrop>
            }
        </GwViewPort>
    )
}