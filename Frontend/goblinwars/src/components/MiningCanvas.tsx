import { Box, Button, Paper, Stack, SxProps, Theme, Typography } from '@mui/material';
import React, { useEffect, useRef, useState } from 'react';
import { MiningInfo } from '../dto/domain/MiningInfo';
import Particles from 'react-tsparticles';
import MineImage from "../assets/images/mining/mine.jpg";
import { MinerPosInfo } from '../dto/domain/MinerPosInfo';
import { GoblinStyles, MainStyles } from '../utils/style';
import { GoblinHealthGood, GoblinHealthMedium, GoblinHealthLow } from './GoblinProgress';
import { RarityStyles } from '../utils/RarityStyles';
import MenuIcon from '@mui/icons-material/Menu';
import { GoblinWarsColors } from '../dto/styles/GoblinWarsColors';
// @ts-ignore
import { SpriteAnimator } from 'react-sprite-animator';

interface MiningParam {
    mining: MiningInfo;
    minerPos: MinerPosInfo[];
    isMobile: boolean;
    listGoblins: () => void;
    showCard: (goblinMining: MinerPosInfo, event: any) => void;
    loadingRecharge: boolean;
    rechargeAll: () => void;
}

interface SelectedImage {
    index: number;
    frames: HTMLImageElement[];
}


const MiningCanvas = (mining: MiningParam) => {
    const itemsRef = useRef([]);
    const [initAnimation, setInitAnimation] = useState<boolean[]>([]);
    useEffect(() => {
        itemsRef.current = itemsRef.current.slice(0, mining.minerPos.length);
        var auxAnimation = itemsRef.current.slice(0, mining.minerPos.length).map(item => (false));
        setInitAnimation([...auxAnimation])
        for(var i = 0; i < auxAnimation.length; i++) {
            setAnimationStart(i, mining.minerPos[i].start);
        }
     }, [mining.minerPos]);

     const setAnimationStart = (index: number, start: number) => {
        setTimeout(() => {
            initAnimation[index] = true;
            setInitAnimation([...initAnimation])
        }, start);
     }

    const sizeMining = { width: mining.isMobile ? 350 : 1000, height: mining.isMobile ? 151 : 430 };
    const goblinLeft : SxProps<Theme> = {
        width: "" + (mining.isMobile ? 49 : 140) + "px", 
        height: "" + (mining.isMobile ? 49 : 140) + "px", 
        top: "" + (mining.isMobile ? 27 : 78) + "px", 
        left: "" + (mining.isMobile ? 8 : 23) + "px", 
        position: "absolute", 
        zIndex: 1
    }
    
    const minerStyle = (topPos: number, leftPos: number) => {
        return {...goblinLeft, top: topPos, left: leftPos} as SxProps<Theme> ;
    };
    
    
    
    const healthPosition = (inverted: boolean) => {
        if(inverted)
            return {left: -15} as SxProps<Theme>
        else
            return {right: -15} as SxProps<Theme>
    }

    const rotateImage = (inverted: boolean) => {
        if(!inverted)
            return {
                transform: "rotateY(180deg) scale(" + (mining.isMobile ? 0.2734375 : 0.78125).toString() + ");"
            } as SxProps<Theme>
        else 
            return {
                transform: "scale(" + (mining.isMobile ? 0.2734375 : 0.78125).toString() + ");"
            } as SxProps<Theme>
    }

    return (
        <Box sx={{ width: sizeMining.width, height: sizeMining.height, position: "relative", borderRadius: 8 }}>
            {mining.minerPos?.map((goblin: MinerPosInfo, i) => {
            
            return (
                <Box key={goblin.idtoken} sx={{ ...MainStyles.container, ...minerStyle((mining.isMobile ? 0.2734375*parseFloat(goblin.top) : 0.78125*parseFloat(goblin.top)), (mining.isMobile ? 0.2734375*parseFloat(goblin.left) : 0.78125*parseFloat(goblin.left))) }}>
                    <Box sx={{ position: "absolute", bottom: 0 }}>
                        { RarityStyles.getMiningEffect((mining.isMobile ? 49 : 140), (mining.isMobile ? 49 : 140), goblin.rarityenum, goblin.idtoken + "mining") }
                    </Box>
                    <Box sx={{ position: "absolute", bottom: mining.isMobile ? (((180*0.2734375)/4)*-1)-56 : -28, ...rotateImage(goblin.inverted) }} ref={el => itemsRef.current[i] = el} onClick={(event: any) => {
                                    mining.showCard(goblin, itemsRef.current[i]);
                                }} >
                        {
                            goblin.exhausted ? 
                            <SpriteAnimator 
                                sprite={goblin.spriteTired} 
                                fps={1}
                                width={180}
                                height={180}
                                shouldAnimate={false}
                                direction={"horizontal"}
                            />
                            :
                            <SpriteAnimator 
                                sprite={goblin.sprite}
                                fps={9}
                                width={180}
                                height={180}
                                shouldAnimate={initAnimation[i] == true}
                                direction={"horizontal"}
                            />
                        }
                        
                    </Box>
                    <Box sx={{ width: 1 }}>
                        <Box sx={{width: 0.5, position: "absolute", ...healthPosition(goblin.inverted) }}>
                            {
                                goblin.goblinMining.energypercent >= 66 ?
                                <GoblinHealthGood sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f", height: 8, borderRadius: 4, transform: "rotate(270deg)" }} variant={"determinate"}
                                    value={goblin.goblinMining.energypercent} />
                                : goblin.goblinMining.energypercent >=33 ?
                                <GoblinHealthMedium sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f", height: 8, borderRadius: 4, transform: "rotate(270deg)" }} variant={"determinate"}
                                    value={goblin.goblinMining.energypercent} />
                                :
                                <GoblinHealthLow sx={{ width: 1, boxShadow: 6, border: 1, borderColor: "#2b211f", height: 8, borderRadius: 4, transform: "rotate(270deg)" }} variant={"determinate"}
                                    value={goblin.goblinMining.energypercent} /> 
                            }
                            
                        </Box>        
                    </Box>
                </Box>
                )
            })}
            <img draggable="false"  src={MineImage} style={{ width: sizeMining.width + "px", height: sizeMining.height + "px", borderRadius: 20, position: "absolute", top: 0, zIndex: 0 }} />
            {
                !mining.isMobile ?
                <Box sx={{ position: "absolute", top: 10, right: 10, zIndex: 4 }}>
                    <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1.5}>
                        <Button sx={{ ...MainStyles.mainButton, width: "auto" }} onClick={mining.rechargeAll} >
                            <Typography sx={{ ...GoblinStyles.textMain }} >{mining.loadingRecharge ? "Recharging..." : "Recharge All"}</Typography>
                        </Button>
                        <Button sx={{ ...MainStyles.mainButton, width: "auto" }} onClick={mining.listGoblins} >
                            <Stack direction={"row"} spacing={1}>
                                <MenuIcon sx={{ ...MainStyles.container, color: GoblinWarsColors.titleColor }} fontSize={"large"} />
                                <Typography sx={{ ...GoblinStyles.textMain }} >List</Typography>
                            </Stack>
                        </Button>
                    </Stack>
                </Box>
                :
                <Box sx={{ position: "absolute", top: 5, right: 5, zIndex: 4 }}>
                    <Stack direction={"row"} sx={{ ...MainStyles.container }} spacing={1.0}>
                        <Button sx={{ ...MainStyles.mainButton, width: "auto", height: 30 }} onClick={mining.rechargeAll} >
                            <Typography sx={{ ...GoblinStyles.textMain, fontSize: 13 }} >{mining.loadingRecharge ? "Recharging..." : "Recharge All"}</Typography>
                        </Button>
                        <Button sx={{ ...MainStyles.mainButton, width: "auto", height: 30 }} onClick={mining.listGoblins} >
                            <Stack direction={"row"} spacing={1}>
                                <MenuIcon sx={{ ...MainStyles.container, color: GoblinWarsColors.titleColor }} fontSize={"small"} />
                                <Typography sx={{ ...GoblinStyles.textMain, fontSize: 13 }} >List</Typography>
                            </Stack>
                        </Button>
                    </Stack>
                    
                </Box>
            }
            {
                <Box sx={{ width: sizeMining.width, height: sizeMining.height, position: "absolute", top: 0, left: 0 }}>
                    <Particles
                        id={"miningImage"}
                        width={sizeMining.width + "px"}
                        height={sizeMining.height + "px"}
                        options={{
                        fullScreen: {
                            enable: false
                        },
                        fpsLimit: 60,
                        particles: {
                            number: {
                            value: 16,
                            density: {
                                enable: false
                            }
                            },
                            color: {
                                value: ["#ffe84d", "#e58f18", "#fdc240", "#ffc34f", "#fff3c8", "#e0b544"]
                            },
                            opacity: {
                                value: 0.6,
                                random: true,
                                anim: { enable: true, speed: 1, opacity_min: 0.2, sync: false }
                            },
                            size: {
                                value: mining.isMobile ? 6 : 12,
                                animation: {
                                    enable: true,
                                    speed: 1,
                                    minimumValue: mining.isMobile ? 3 : 6,
                                    sync: false
                                }
                            },
                            move: {
                                enable: true,
                                direction: "top",
                                speed: 0.5,
                                outMode: "out"
                            },
                            shape: {
                                type: "circle"
                            },
                        },
                        detectRetina: true,
                        
                        }}
                    />
                </Box>
            }
        </Box>
    )
};
export default MiningCanvas;