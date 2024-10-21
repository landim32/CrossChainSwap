import { Alert, AlertColor, Backdrop, Box, Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Divider, Fade, IconButton, Paper, Snackbar, Stack, SxProps, Theme, Typography } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import { useHistory, useLocation } from "react-router";
import { GwViewPort } from "../../components/GwViewPort";
import ItemContext from "../../contexts/item/ItemContext";
import { GoblinStyles, MainStyles } from "../../utils/style";
import { isMobile } from "react-device-detect";
import EquipmentCard from "../../components/EquipmentCard";
import { GetItemAssets } from "../../utils/ItemAssetsUtils";
import { GenericSlot } from "../../components/GenericSlot";
import { CraftInfo } from "../../dto/domain/CraftInfo";
import { QuestType } from "../../dto/enum/QuestType";
import QuestIcon from '../../assets/images/menu/quests.png';
import JobIcon from '../../assets/images/menu/jobs.png';
import { QuestInfo } from "../../dto/domain/QuestInfo";
import { GoblinWarsColors } from "../../dto/styles/GoblinWarsColors";
import { AuctionEquipmentSell } from "./AuctionEquipmentSell";
import AuctionContext from "../../contexts/auction/AuctionContext";
import AuctionInsertInfo from "../../dto/domain/AuctionInsertInfo";
import AuctionInfo from "../../dto/domain/AuctionInfo";
import { DefaultTabs, DefaultTab } from "../../components/GwTabs";
import { BuySellMaterial } from "./BuySellMaterial";

export function Equipment() {
    const [openDialog, setOpenDialog] = useState<boolean>(false);
    const [message, setMessage] = useState("");
    const [severity, setSeverity] = useState<AlertColor>("success");
    const [openAlert, setOpenAlert] = useState<boolean>(false);
    const [currentAuction, setCurrentAuction] = useState<AuctionInfo>(null);
    const [value, setValue] = useState(0);

    const itemContext = useContext(ItemContext);
    const auctionContext = useContext(AuctionContext);

    let location = useLocation();
    const history = useHistory();

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

    const showAlert = (auction: AuctionInfo) => {
        setOpenAlert(true);
        setCurrentAuction(auction);
    };

    const closeAlert = () => {
        setOpenAlert(false);
    };

    const executeAlert = async () => {
        setOpenAlert(false);
        let ret = await auctionContext.buy(currentAuction.id);
        if (ret.sucesso) {
          auctionContext.listsameequipment(currentAuction.itemkey).then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
                return;
            }
          });
        }
        else {
            showDialog(ret.mensagemErro, "error");
        }
    };

    const handleChange = (event : any, newValue : number) => {
        setValue(newValue);
    };
    
    const getCraftInfo = (craftInfo: CraftInfo) => {
      return (
        <Stack sx={{ ...MainStyles.container, p: 1, width: isMobile ? 340 : 500 }} spacing={2}>
          {
            craftInfo.origins && craftInfo.origins.length > 0 &&
            <>
              {
                getQuestBlock(craftInfo.origins)
              }
              {
                getJobOriginBlock(craftInfo.origins)
              }
            </>
          }
          {
            craftInfo.destinations && craftInfo.destinations.length > 0 &&
            <>
              {
                getJobDestinationBlock(craftInfo.destinations)
              }
            </>
          }
          {
            craftInfo.chests && craftInfo.chests.length > 0 &&
            <Stack sx={{ ...MainStyles.container }} spacing={0.5}>
              <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center" }}>Reward from Chests</Typography>
              <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"} >
              {
                craftInfo.chests.map(chest => (
                  <GenericSlot boxSize={80} rarity={chest.rarity} >
                    <img src={GetItemAssets(chest.iconAsset)} style={{ width: 65 }} />
                  </GenericSlot>
                ))
              }
              </Stack>
            </Stack>
          }
        </Stack>
      )
    }
    
    const getQuestRows = (quests: QuestInfo[]) => {
      return quests.map(quest => (
        <Paper sx={{ ...MainStyles.container, width: 1 }} elevation={8} >
          <Stack sx={{ ...MainStyles.container, cursor: "pointer", justifyContent: "space-between", width: 1, bgcolor: GoblinWarsColors.lightBox, p: 1 }} direction={"row"} onClick={() => {
            if(quest.questtype == QuestType.Job)
              history.push("/jobdetails?questId=-1&questKey=" + quest.key);
            else
              history.push("/questdetail?questId=-1&questKey=" + quest.key);
          }} >
              <Stack sx={{ alignItems: "flex-start", alignContent: "flex-start", width: 1 }} spacing={-1}>
                  <Typography sx={{ ...GoblinStyles.sessionTitleText }} >{quest.name}</Typography>
              </Stack>
              <IconButton sx={{ ml: 2 }}>
                  <img src={quest.questtype == QuestType.Job ? JobIcon : QuestIcon} style={{ width: 28 }} alt={"go"} />
              </IconButton>
              <Divider />
          </Stack>
        </Paper>
      ))
    }
    
    const getQuestBlock = (quests: QuestInfo[]) => {
      if(quests.filter(x => x.questtype == QuestType.Quest).length > 0) {
        return (
          <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0.5}>
            <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center" }}>From Quests</Typography>
            {
              getQuestRows(quests)
            }
          </Stack>
        )
      } else {
        <></>
      }
    }
  
    const getJobOriginBlock = (quests: QuestInfo[]) => {
      if(quests.filter(x => x.questtype == QuestType.Job).length > 0) {
        return (
          <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0.5}>
            <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center" }}>Crafted from Jobs</Typography>
            {
              getQuestRows(quests)
            }
          </Stack>
        )
      } else {
        <></>
      }
    }
  
    const getJobDestinationBlock = (quests: QuestInfo[]) => {
      if(quests.filter(x => x.questtype == QuestType.Job).length > 0) {
        return (
          <Stack sx={{ ...MainStyles.container, width: 1 }} spacing={0.5}>
            <Typography sx={{ ...GoblinStyles.textMain, textAlign: "center" }}>Material for Jobs</Typography>
            {
              getQuestRows(quests)
            }
          </Stack>
        )
      } else {
        <></>
      }
    }

    const getSellEquipmentBlock = () => {
      return (
        <AuctionEquipmentSell insert={ async (itemKey: number, price: number) => {
          if(!auctionContext.loading ) {
            let param: AuctionInsertInfo = {
              auction: 3,
              itemKey: itemKey,
              price: price,
              qtdy: 1
            };
            let ret = await auctionContext.insert(param);
            if (ret.sucesso) {
              showDialog("Equipment published on the marketplace", 'success');
              itemContext.getbykey(itemKey).then((ret) => {
                  if (!ret.sucesso) {
                      showDialog(ret.mensagemErro, 'error');
                      return;
                  }
                  auctionContext.listsameequipment(itemKey).then((ret) => {
                    if (!ret.sucesso) {
                        showDialog(ret.mensagemErro, 'error');
                        return;
                    }
                  });
              });
            }
            else {
              showDialog(ret.mensagemErro, "error");
            }
          }
        }}
        close={() => {}} 
        itemKey={itemContext.itemDetail?.key}
        loading={auctionContext.loading}
        />
      )
    }
    
    const getMarketPlaceBlock = () => {
      return (
        !auctionContext.loading ?
        <Stack sx={{ ...MainStyles.container, width: 1 }}>
          <Typography sx={{ ...GoblinStyles.textMain }}>Marketplace</Typography>
          <Stack direction="row" sx={{ ...MainStyles.container, flexWrap: "wrap" }}>
            {
              auctionContext.sameEquipment && 
              auctionContext.sameEquipment.auctions.length > 0 &&
              auctionContext.sameEquipment?.auctions.map((value: AuctionInfo) => (
                <Box sx={{ m: 2 }}>
                  <EquipmentCard
                    auction={value}
                    item={value.item}
                    loading={auctionContext.loadingAction}
                    buy={(auction) => {
                      showAlert(auction);
                    }} 
                  />
                </Box>
              ))
            }
            {
              auctionContext.sameEquipment && 
              auctionContext.sameEquipment.auctions.length == 0 &&
              <Box sx={{ ...MainStyles.container, m: 1 }}>
                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, p: 1 }}>
                    <Typography sx={{ ...GoblinStyles.sessionSubTitleText }} >
                      No equipment similar to this has been published on the marketplace
                    </Typography>
                </Paper>
              </Box>
            }
          </Stack>
        </Stack> : <CircularProgress />
      )
    }

    useEffect(() => {
      let itemKey = parseInt(new URLSearchParams(location.search).get("key"));
      itemContext.getbykey(itemKey).then((ret) => {
          if (!ret.sucesso) {
              showDialog(ret.mensagemErro, 'error');
              return;
          }
          auctionContext.listsameequipment(itemKey).then((ret) => {
            if (!ret.sucesso) {
                showDialog(ret.mensagemErro, 'error');
                return;
            }
          });
      });
      itemContext.getcraftinfo(itemKey).then((ret) => {
          if (!ret.sucesso) {
              showDialog(ret.mensagemErro, 'error');
              return;
          }
      });
    }, [ location ]);

    const isMaterial = () => {
      return !itemContext.itemDetail?.item.isTrash && !itemContext.itemDetail?.item.isEquipment && !itemContext.itemDetail?.item.isBag;
    }

    return (
        <GwViewPort>
          {
            itemContext.itemDetail && 
            <Stack sx={{ ...MainStyles.container }} spacing={1}>
              <Stack sx={{ ...MainStyles.container, alignContent: isMobile ? "center" : "flex-start", alignItems: isMobile ? "center" : "flex-start" }} direction={isMobile ? "column" : "row"} spacing={1}>
                <EquipmentCard
                    item={itemContext.itemDetail?.item}
                    loading={itemContext.loading.detail}
                    qtdy={itemContext.itemDetail?.qtde}
                />
                <Paper sx={{ ...MainStyles.container, ...MainStyles.floatingBox, height: "inherit" }}>
                  <Stack sx={{ ...MainStyles.container  }} spacing={2}>
                    {
                      (itemContext.itemDetail?.item.isEquipment || isMaterial()) && 
                      <>
                        <Box >
                          <DefaultTabs value={value} onChange={handleChange} >
                              <DefaultTab label={itemContext.itemDetail?.item.isEquipment ? "Sell on marketplace" : "Sell"} />
                              {isMaterial() &&
                                <DefaultTab label="Buy" />
                              }
                              <DefaultTab label="Craft" />
                          </DefaultTabs>
                        </Box>
                        <Box sx={{ ...MainStyles.container, width: 1 }}>
                          <Fade in={value == 0}>
                              {
                                  value == 0 ?
                                  <Box>
                                    {
                                      itemContext.itemDetail?.item.isEquipment &&
                                      getSellEquipmentBlock()
                                    }
                                    {
                                      isMaterial() &&
                                      <BuySellMaterial useriteminfo={itemContext.itemDetail} isSell={true} />
                                    }
                                  </Box>
                                  : <Box></Box>
                              }
                          </Fade>
                          {
                            isMaterial() && 
                            <Fade in={value == 1}>
                                {
                                    value == 1 ?
                                    <Box>
                                    {
                                      <BuySellMaterial useriteminfo={itemContext.itemDetail} isSell={false} />
                                    }
                                    </Box>
                                    : <Box></Box>
                                }
                            </Fade>
                          }
                          <Fade in={value == (isMaterial() ? 2 : 1)}>
                              {
                                  value == (isMaterial() ? 2 : 1) ?
                                    itemContext.craftDetail ? 
                                      getCraftInfo(itemContext.craftDetail)
                                      : <CircularProgress />
                                  : <Box></Box>
                              }
                          </Fade>
                        </Box>
                      </>
                      
                    }
                    {
                      (itemContext.itemDetail?.item.isTrash || itemContext.itemDetail?.item.isBag) && 
                      <>
                        <Box >
                            <DefaultTabs value={value} onChange={handleChange} >
                                <DefaultTab label="Craft" />
                            </DefaultTabs>
                          </Box>
                          <Box sx={{ ...MainStyles.container, width: 1 }}>
                            <Fade in={value == 0}>
                              {
                                itemContext.craftDetail ? 
                                  getCraftInfo(itemContext.craftDetail)
                                  : <CircularProgress />
                              }
                            </Fade>
                          </Box>
                      </>
                    }
                  </Stack>
                </Paper>
              </Stack>
              <Divider />
              { 
                itemContext.itemDetail?.item.isEquipment &&
                getMarketPlaceBlock()
              }
            </Stack>
          }
          {
            (auctionContext.loading || auctionContext.loadingAction || itemContext.loading.craftDeatil || itemContext.loading.detail) &&
            <Backdrop
                sx={{ color: '#fff', zIndex: (theme) => 99 }}
                open={true}
            >
                <CircularProgress color="inherit" />
            </Backdrop>
          }
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