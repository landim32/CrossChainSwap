import { Alert, Snackbar, Grid, Box, Stack, Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions, Button } from '@mui/material';
import React, { useContext, useState, useEffect } from 'react';
import { Redirect } from 'react-router-dom';
import logo from '../../assets/logo.png';
import { mainClasses, MainStyles } from '../../utils/style';
import goblinRight from '../../assets/images/goblins-dir.png';
import goblinLeft from '../../assets/images/goblins-esq.png';
import InicioContext from '../../contexts/inicio/InicioContext';
import './styles.css';
import BgDungeonMobile from "../../assets/images/bg-dungeon-mobile.jpg";
import BgMobile from "../../assets/images/bg.jpg";
import { LoginButton } from './LoginButton';
import { BrowserView, MobileView, isMobile } from 'react-device-detect';
import ReactGA from "react-ga";

export function Start() {
  const inicioContext = useContext(InicioContext);
  const sessionResult = inicioContext.checkSession();

  const [openDialog, setOpenDialog] = useState(false);
  const [errMessage, setErrMessage] = useState("");
  const [open, setOpen] = useState(false);

  const imgSize = 150;
  const backSize = 294;

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleSuccessClose = () => {
    setOpen(false);
    window.open("https://metamask.app.link/dapp/app.goblinwars.io/");
  };

  const handleClose = (ev: any) => {
    if (ev?.reason === 'clickaway') {
      return;
    }

    setOpenDialog(false);
  };

  useEffect(() => {
    ReactGA.pageview(window.location.pathname);
  }, []);

  
  const classes = mainClasses();

  return (
    <>
      {
        sessionResult.sucesso ?
            <Redirect to={"/home"} />
          :
          <> 
            <MobileView>
              <Box sx={{ ...MainStyles.container, height: "100vh", width: "100%", position: "relative", overflowX: "hidden", overflowY: "hidden" }} >
                <img draggable="false"  src={BgMobile} style={{ position: "absolute", top: 0, height: "100vh" }} />
                <img draggable="false"  src={BgDungeonMobile} style={{ height: 155, position: "absolute", top: 140 }} />
                <img draggable="false"  src={logo} alt="Goblin Wars" style={{ position: "absolute", height: 160, top: 20 }} />
                <Grid item xs={12} sx={{position: "absolute", top: 16}} >
                    <Grid container justifyContent="center" >
                      <Grid key="limg" item sx={{ zIndex: 2 }} xs={5} >
                        <Box sx={{ display: "flex", justifyContent: "flex-end", alignItems: "flex-end", pb: 2, pr: 5, width: 1, height: backSize }}>
                            <img draggable="false"  src={goblinLeft} alt="Goblin Wars" style={{ height: imgSize }} />
                        </Box>
                      </Grid>
                      <Grid key="logo" item sx={{ ...MainStyles.container, zIndex: 1 }} xs={2}>
                      </Grid>
                      <Grid key="rimg" item sx={{ zIndex: 2 }} xs={5}>
                        <Box sx={{ display: "flex", justifyContent: "flex-start", alignItems: "flex-end", pb: 2, pl: 3, width: 1, height: backSize }}>
                            <img draggable="false"  src={goblinRight} alt="Goblin Wars" style={{ height: imgSize }} />
                        </Box>
                      </Grid>
                    </Grid>
                </Grid>
                <Box sx={{position: "absolute", top: backSize + 20}} >
                  <LoginButton msgErrorCb={(msg: string) => {
                    if(msg == "Please install MetaMask first." && isMobile) {
                      handleClickOpen();
                    } else {
                      setErrMessage(msg);
                      setOpenDialog(true);
                    }
                  } }  />
                </Box>
              </Box>
            </MobileView>
            <BrowserView>
              <Box sx={{ ...MainStyles.container, height: "100vh", width: "100%" }}>
                <Box className={classes.BackgroundPage}>
                  <Box className={classes.BackgroundDungeon} sx={{ height: 700 }}>
                    <Grid item xs={12} >
                        <Grid container justifyContent="center" >
                          <Grid key="limg" item sx={{ zIndex: 2 }} xs={5} >
                            <Box sx={{ display: "flex", justifyContent: "flex-end", alignItems: "flex-end", pb: 2, pr: 4, width: 1, height: 700 }}>
                                <img draggable="false"  src={goblinLeft} alt="Goblin Wars" style={{ height: 500 }} />
                            </Box>
                          </Grid>
                          <Grid key="logo" item sx={{ ...MainStyles.container, zIndex: 1 }} xs={2}>
                            <Stack spacing={5} sx={{ ...MainStyles.container }} >
                              <img draggable="false"  src={logo} alt="Goblin Wars" />
                              <LoginButton msgErrorCb={(msg: string) => {
                                setErrMessage(msg);
                                setOpenDialog(true);
                              } }  />
                            </Stack>
                          </Grid>
                          <Grid key="rimg" item sx={{ zIndex: 2 }} xs={5}>
                            <Box sx={{ display: "flex", justifyContent: "flex-start", alignItems: "flex-end", pb: 2, width: 1, height: 700 }}>
                                <img draggable="false"  src={goblinRight} alt="Goblin Wars" style={{ height: 500 }} />
                            </Box>
                          </Grid>
                        </Grid>
                    </Grid>
                  </Box>
                </Box>
              </Box>
            </BrowserView>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
              <Alert onClose={handleClose} severity="error" sx={{ width: '100%' }}>
                {errMessage}
              </Alert>
            </Snackbar>
            <Dialog
              open={open}
              onClose={handleClose}
            >
              <DialogTitle>
                Attention !
              </DialogTitle>
              <DialogContent>
                <DialogContentText>
                  You need to install metamask on your phone to login. Click the button below to install or open the app if you have installed it before.
                  <br />Warning: You need to connect on Binance Mainnet. For more details <a href='https://academy.binance.com/pt/articles/connecting-metamask-to-binance-smart-chain' >click here</a>
                </DialogContentText>
              </DialogContent>
              <DialogActions>
                <Button onClick={handleSuccessClose}>Install/Open Metamask</Button>
              </DialogActions>
            </Dialog>
          </>
      }
    </>
  );
}