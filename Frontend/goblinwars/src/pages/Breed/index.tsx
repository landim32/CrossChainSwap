import { Alert, AlertColor, Box, Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Grid, Paper, Snackbar, Stack, Theme, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { Goblin } from "../../components/Goblin";
import SizeGoblinCard from "../../dto/enum/SizeGoblinCard";
import { GoblinStyles, MainStyles } from "../../utils/style";
import FavoriteIcon from '@mui/icons-material/Favorite';
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";
import GoblinBreedContext from "../../contexts/goblinBreed/GoblinBreedContext";
import { useHistory, useLocation } from "react-router-dom";
import { FontButton, FontTitleSession } from "../../utils/fontStyle";
import { SxProps } from "@mui/system";
import gobiCoin from '../../assets/images/coins/gobiCoin.png'
import { GwViewPort } from "../../components/GwViewPort";
import { BrowserView, MobileView, isBrowser, isMobile } from 'react-device-detect';
import { RarityStyles } from "../../utils/RarityStyles";
import { RarityEnum } from "../../dto/enum/RarityEnum";
import { GobiMetamask } from "../../components/GobiMetamask";
import GoboxContext from "../../contexts/payment/GoboxContext";

export function Breed() {
  let tokenId1 : number;
  let tokenId2 : number;

  const goblinBreedContext = useContext(GoblinBreedContext);
  const goblinUserContext = useContext(GoblinUserContext);
  const goboxContext = useContext(GoboxContext);

  let location = useLocation();
  const history = useHistory();

  const [open, setOpen] = useState(false);
  const [tokenRet, setTokenRet] = useState(-1);
  const [openDialog, setOpenDialog] = useState(false);
  const [message, setMessage] = useState("");
  const [severity, setSeverity] = useState<AlertColor>("success");

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleSuccessClose = () => {
    setOpen(false);
    if(tokenRet > -1) {
      history.push("/goblin?tokenId=" + tokenRet);
    } else {
      history.push("/horde");
    }
  };

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

  useEffect(() => {
    tokenId1 = parseInt(new URLSearchParams(location.search).get("idToken1"));
    tokenId2 = parseInt(new URLSearchParams(location.search).get("idToken2"));
    goblinBreedContext.getGoblin1(tokenId1);
    goblinBreedContext.getGoblin2(tokenId2);
    goblinBreedContext.getBreedCost(tokenId1, tokenId2);
    //goblinBreedContext.getBreedRarity(tokenId1, tokenId2);
    //goboxContext.gobiBalanceOf();
    setTokenRet(-1);
  }, []);

  const rarityLeft : SxProps<Theme> = {
    ...GoblinStyles.sessionTitleText,
    textAlign: "left",
    width: 140
  };
  const rarityRight : SxProps<Theme> = {
    ...GoblinStyles.sessionTitleText,
    textAlign: "right"
  };

  const styleWallet : SxProps<Theme> = { 
    fontSize: 26,
    ...FontTitleSession
  }

  const styleBalance : SxProps<Theme> = { 
    fontSize: 24,
    ...FontTitleSession
  }

  const msgAlertText: SxProps<Theme> = {
    ...FontButton,
    fontSize: 22
}

  const msgAlert = () => {
    return (
      <Box sx={{ ...MainStyles.container, m: 1 }}>
        <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
            <Typography sx={{ ...msgAlertText }} >
              Note: parents and child generated in the breed had a cooldown 
              of 5 days.<br />During this period, they will not be able to breed or transfer.
            </Typography>
        </Paper>
      </Box>
    );
  }

  {/*
  const msgFreeBreed = () => {
    return (
        <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1, mb: 2 }}>
          <Stack sx={{ ...MainStyles.container }}>
            <Typography sx={{ ...msgAlertText }} >
                <div>
                  <p>Insufficient GOBI for breed ? You can do free breed right now.</p>
                </div>
              </Typography>
              <Button sx={{ ...MainStyles.mainButton, width: 180 }} onClick={() => {
                  history.push("/campaign?form=freeborn&g1=" + new URLSearchParams(location.search).get("idToken1") + "&g2=" + new URLSearchParams(location.search).get("idToken2"));
              }} >
                  Free Breed
              </Button>
          </Stack>
        </Paper>
    );
  }
  */}

  const getBoxRarity = () => {
    return (
      <Paper sx={{ ...MainStyles.container, p: 1, ...MainStyles.floatingBox }}>
        <Grid container spacing={0} sx={{width: "210px"}}>
          {goblinBreedContext.rarity?.commonVisible &&
            <>
            <Grid item md={6}>
                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Common)}}>Common</Typography>
            </Grid>
            <Grid item md={6}>
                <Typography sx={{...rarityRight}}>{goblinBreedContext.rarity?.commonValue}</Typography>
            </Grid>
            </>
          }
          {goblinBreedContext.rarity?.uncommonVisible &&
            <>
            <Grid item md={6}>
                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Uncommon)}}>Uncommon</Typography>
            </Grid>
            <Grid item md={6}>
                <Typography sx={{...rarityRight}}>{goblinBreedContext.rarity?.uncommonValue}</Typography>
            </Grid>
            </>
          }
          {goblinBreedContext.rarity?.rareVisible &&
            <>
            <Grid item md={6}>
                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Rare)}}>Rare</Typography>
            </Grid>
            <Grid item md={6}>
                <Typography sx={{...rarityRight}}>{goblinBreedContext.rarity?.rareValue}</Typography>
            </Grid>
            </>
          }
          {goblinBreedContext.rarity?.epicVisible &&
            <>
            <Grid item md={6}>
                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Epic)}}>Epic</Typography>
            </Grid>
            <Grid item md={6}>
                <Typography sx={{...rarityRight}}>{goblinBreedContext.rarity?.epicValue}</Typography>
            </Grid>
            </>
          } 
            <Grid item md={6}>
                <Typography sx={{...rarityLeft, color: RarityStyles.getRarityColor(RarityEnum.Legendary)}}>Legendary</Typography>
            </Grid>
            <Grid item md={6}>
                <Typography sx={{...rarityRight}}>{goblinBreedContext.rarity?.legendaryValue}</Typography>
            </Grid>
        </Grid>
      </Paper>
    );
  }

  const buildBreedingBlock = () => {
    return (
      <>
        {
          goblinUserContext.balance && !goblinBreedContext.loading.breedCost ?
            goblinBreedContext.loading.breeding ?
                  <Paper sx={{ ...MainStyles.container, p: 1, ...MainStyles.floatingBox }}>
                    <Stack spacing={0} sx={{ ...MainStyles.container }}>
                      <CircularProgress />
                      <Stack direction={"row"} spacing={1} sx={{ ...MainStyles.container }}>
                        <FavoriteIcon fontSize={"medium"} sx={{ color: "white" }} />
                        <Typography sx={{ ...styleWallet }} >Breeding...</Typography>
                      </Stack>
                    </Stack>
                  </Paper>
                : <Stack spacing={4}> 
                  <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox }} elevation={6}>
                    {
                      (goblinBreedContext.breedCost && goblinUserContext.balance) ? 
                      <GobiMetamask 
                        loadingCost={false} 
                        cost={goblinBreedContext.breedCost}
                        //balance={goboxContext.gobiBalance}
                        balance={goblinUserContext.balance?.cloudWalletGobiBalance}
                        text="GOBI"
                        subtext="Breed Cost"
                      />
                      : <CircularProgress />
                    }
                    
                  </Paper>
                  {
                    !isMobile &&
                    getBoxRarity()
                  }
                  <Button variant="contained" sx={{ ...MainStyles.mainButton }} onClick={async () => {
                    if(goblinBreedContext.breedCost > goblinUserContext.balance?.cloudWalletGobiBalance) {
                      showDialog("Insufficient balance of GOBI", "error");
                      return;
                    }
                    let ret = await goblinBreedContext.breed(goblinBreedContext.goblin1, goblinBreedContext.goblin2);
                    if(ret.sucesso) {
                      setTokenRet(ret.dataResult);
                      handleClickOpen();
                    } else {
                      showDialog(ret.mensagemErro, "error");
                    }
                  }} >
                    <Stack direction={"row"} spacing={2} sx={{ ...MainStyles.container }}>
                      <FavoriteIcon fontSize={"medium"} sx={{ color: "white", mr: 1 }} />
                      Start Breed
                    </Stack>
                  </Button>
                </Stack>
            : <CircularProgress />
        }
      </>
    )
  }

  const buildGoblin1 = () => {
    return (
      <>
        {
          goblinBreedContext.goblin1 ?
          <Goblin
              id={goblinBreedContext.goblin1.id}
              idToken={goblinBreedContext.goblin1.idToken}
              name={goblinBreedContext.goblin1.name}
              image={goblinBreedContext.goblin1.imageURL}
              size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Big}
              mainColor={goblinBreedContext.goblin1.skincolor}
              goblinSkillList={goblinBreedContext.goblin1.goblinSkillList}
              rarity={goblinBreedContext.goblin1.rarityenum}
              onElemClick={(tokenId:number) => {}}
          />
          : <CircularProgress />
        }
      </>
    )
  }

  const buildGoblin2 = () => {
    return (
      <>
        {
          goblinBreedContext.goblin2 ?
          <Goblin
              id={goblinBreedContext.goblin2.id}
              idToken={goblinBreedContext.goblin2.idToken}
              name={goblinBreedContext.goblin2.name}
              image={goblinBreedContext.goblin2.imageURL}
              size={isMobile ? SizeGoblinCard.VerySmall : SizeGoblinCard.Big}
              mainColor={goblinBreedContext.goblin2.skincolor}
              goblinSkillList={goblinBreedContext.goblin2.goblinSkillList}
              rarity={goblinBreedContext.goblin2.rarityenum}
              onElemClick={(tokenId:number) => {}}
          />
          : <CircularProgress />
        }
      </>
    )
  }
  
  return (
    <GwViewPort>
      <Box sx={{ ...MainStyles.container, alignContent: "center" }}>
        <Stack sx={{...MainStyles.container}}>
        <Paper sx={{ ...GoblinStyles.sessionDivider }} elevation={6}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }} >BREED</Typography>
        </Paper>
          <Grid container spacing={isMobile ? 2 : 6} sx={{ ...MainStyles.container, p: 4 }}>
            {
              !isMobile && 
              <>
                <Grid item sx={{ ...MainStyles.container }}>
                  { buildGoblin1() }
                </Grid>
                <Grid item sx={{ ...MainStyles.container }} >
                  { buildBreedingBlock() }
                </Grid>
                <Grid item sx={{ ...MainStyles.container }}>
                  { buildGoblin2() }
                </Grid>
              </>
            }
            {
              isMobile && 
              <>
                <Grid item sx={{ ...MainStyles.container }} xs={12} >
                  { buildBreedingBlock() }
                </Grid>
                <Grid item sx={{ ...MainStyles.container }} xs={6} >
                  { buildGoblin1() }
                </Grid>
                <Grid item sx={{ ...MainStyles.container }} xs={6}>
                  { buildGoblin2() }
                </Grid>
                <Grid item sx={{ ...MainStyles.container }} xs={12} >
                  { 
                    goblinUserContext.balance && !goblinBreedContext.loading.breedCost ?
                      getBoxRarity() 
                    : <CircularProgress />
                  }
                </Grid>
              </>
            }
          </Grid>
          {/* msgFreeBreed() */}
          { msgAlert() }
        </Stack>
      </Box>
      <Dialog
        open={open}
        onClose={handleClose}
      >
        <DialogTitle>
          {"Breed complete !"}
        </DialogTitle>
        <DialogContent>
          <DialogContentText>
            Congratulations, breeding successfully completed
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleSuccessClose}>Yay !</Button>
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