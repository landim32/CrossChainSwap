import { Alert, Backdrop, Box, Button, CircularProgress, Grid, Snackbar, Stack, Theme, Typography } from "@mui/material";
import { DevPages } from "../../components/DevPage";
import { Header } from "../../components/Header";
import { GoblinStyles, MainStyles } from "../../utils/style";
import NoticeInfo from '../../assets/images/notice.png';
import { SxProps } from "@mui/system";
import { ItemSlot } from "../../components/ItemSlot";
import { useContext, useEffect, useState } from "react";
import ItemContext from "../../contexts/item/ItemContext";
import { UserItemInfo } from "../../dto/domain/UserItemInfo";
import { ItemEmptySlot } from "../../components/ItemEmptySlot";
import { ItemDetail } from "../../components/ItemDetail";
import goldCoin from '../../assets/images/coins/goldCoin.png';
import { GwViewPort } from "../../components/GwViewPort";
import GoblinUserContext from "../../contexts/goblinUser/GoblinUserContext";
import { ResultDialog } from "../../components/ResultDialog";
import { GenericSlot } from "../../components/GenericSlot";

const matrizXSize = 6;
const matrizYSize = 7;

const invStyle : SxProps<Theme> = {
    m: 1,
    p: "5px",
    borderRadius: 2,
    bgcolor: "#2b211f"
}


const styleQtde: SxProps<Theme> = {
    ...GoblinStyles.textMain,
    fontSize: 18,
    bottom: 1,
    right: 4,
    position: "absolute"
}

interface ResultPopUpChest {
    open: boolean;
    items: UserItemInfo[];
    gobi: number;
    gold: number;
}

export function Inventory() {
    const goblinUserContext = useContext(GoblinUserContext);
    const itemContext = useContext(ItemContext);
    const [openResult, setOpenResult] = useState<ResultPopUpChest>(null);
    const [openDialog, setOpenDialog] = useState(false);
    const [errMessage, setErrMessage] = useState("");

    useEffect(() => {
        itemContext.list();
    }, []);


    const handleCloseResult = () => {
        setOpenResult(null);
        itemContext.list();
    };
    const handleOpenResult = (items: UserItemInfo[], gobi: number, gold: number) => {
        setOpenResult({ open: true, items: items, gobi: gobi, gold: gold });
    };

    const handleClose = (ev: any) => {
        if (ev?.reason === 'clickaway') {
          return;
        }
    
        setOpenDialog(false);
    };

    const getResultPopup = () => {
        return (
          <ResultDialog onClose={handleCloseResult} open={openResult?.open} title={"Reward"}>
            <Stack sx={{ ...MainStyles.container, ...MainStyles.floatingBox}}>
              <Typography sx={{ ...GoblinStyles.textMain }}>You open an Chest, this is your reward !</Typography>
              {
                getRewardBlock()
              }
              <Button sx={{ ...MainStyles.mainButton, width: 150 }} onClick={handleCloseResult} >Yay !</Button>
            </Stack>
          </ResultDialog>
        )
      }
    
      const getRewardBlock = () => {
        return (
          <Stack sx={{ ...MainStyles.container }} >
            <Typography sx={{ ...GoblinStyles.textMain }}>Reward</Typography>
            <Stack sx={{ ...MainStyles.container, flexWrap: "wrap" }} direction={"row"}>
              {
                openResult && itemContext.destroyItems.map((item) => {
                  return (
                    <GenericSlot boxSize={76} key={item.item.key} rarity={item.item.rarity} >
                      {
                        <Box sx={{ height: 56, width: 56, position: "relative" }} > 
                          <img draggable="false"  src={item.item.iconAsset} style={{ width: "100%" }} alt={item.item.name} />
                          <Typography sx={{...styleQtde}}>{item.qtde}</Typography>
                        </Box>
                      }
                    </GenericSlot>
                  )
                })
              }
            </Stack>
          </Stack>
        )
      }

    let buildMatriz = () => {
        let lstLine : JSX.Element[] = [];
        for(var i = 0; i < matrizYSize; i++){
            let lstRow : JSX.Element[] = [];
            for(var j = 0; j < matrizXSize; j++){
                var userItem : UserItemInfo = null; 
                userItem = itemContext.itens.find((item) => {
                    if(item.posX == j && item.posY == i){
                        return true;
                    }
                 })
                 lstRow.push(<ItemEmptySlot key={j+i} userItemInfo={userItem || null} x={j} y={i} context={itemContext} moveCb={itemContext.move} canDropCb={itemContext.canDrop} >
                     {userItem && <ItemSlot userItemInfo={userItem} selectItemCb={itemContext.setItemDetail}  />}
                 </ItemEmptySlot>);
                
            }
            lstLine.push(<Stack key={i} direction={"row"} spacing={"5px"}>
                {lstRow}
            </Stack>)
        }
        return (
            <Stack spacing={"5px"}>
                {lstLine}
            </Stack>
        );
    }

    return (
        <GwViewPort>
            <Stack sx={{ ...MainStyles.container }} spacing={2}>
                {
                    itemContext.itemDetail &&
                    <ItemDetail userItemInfo={itemContext.itemDetail} sellCb={async (item, qtde) => {
                        var ret = await itemContext.sell(item.key, qtde);
                        if(!ret.sucesso) {
                            setErrMessage(ret.mensagemErro);
                            setOpenDialog(true);
                        } else {
                            goblinUserContext.loadBalance();
                            itemContext.list();
                        }
                    }} openCb={async (item, qtde) => {
                        var ret = await itemContext.destroyitem(item.id, qtde);
                        if(ret.sucesso) {
                            //handleOpenResult(ret.dataResult);
                            handleOpenResult(itemContext.destroyItems, itemContext.destroyGobi, itemContext.destroyGold);
                        } else {
                            setErrMessage(ret.mensagemErro);
                            setOpenDialog(true);
                        }
                    }} />
                }
                <Stack sx={{ ...MainStyles.container, ...invStyle }} >
                    {buildMatriz()}
                    <Stack sx={{ ...MainStyles.container, width: 1, justifyContent: "space-between", p: 1 }} direction={"row"}>
                        <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={1}>
                            <Typography sx={{ ...GoblinStyles.textMain }} >{ !goblinUserContext.balance ? "..." : goblinUserContext.balance.goldBalance.toFixed(4) }</Typography>
                            <img draggable="false"  src={goldCoin} style={{ height: 20 }} alt={"gold coin"} />
                        </Stack>
                        <Typography sx={{ ...GoblinStyles.textMain }} >{(itemContext.itens ? itemContext.itens.length : 0) + "/" + (matrizXSize * matrizYSize).toString()}</Typography>
                    </Stack>
                </Stack>
                <Button sx={{ ...MainStyles.mainButton, width: 200 }} onClick={() => {
                    itemContext.sellalltrash().then(ret => {
                        itemContext.list();
                    });
                }} >Sell All Trash</Button>
            </Stack>
            <Snackbar open={openDialog} autoHideDuration={6000} onClose={handleClose} anchorOrigin={{ vertical: "top", horizontal: "right"}}>
                <Alert onClose={handleClose} severity="error" sx={{ width: '100%' }}>
                    {errMessage}
                </Alert>
            </Snackbar>
            { getResultPopup() }
            {
                (itemContext.loading.list || itemContext.loading.sell || itemContext.loading.openItem || itemContext.loading.sellAllTrash) &&
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