import { Box, Paper, Stack, Theme, Typography } from '@mui/material';
import SizeGoblinCard from '../dto/enum/SizeGoblinCard';
import { LightenDarkenColor } from '../utils/utils';
import { GoblinCardStyles, GoblinStyles, MainStyles } from '../utils/style';
import { makeStyles } from '@mui/styles';
import { SxProps } from '@mui/system';
import { FontButton } from '../utils/fontStyle';
import { useTimer } from 'react-timer-hook';
import Moment from 'moment';
import CardGoblin from '../assets/images/goblin/card_goblin.png';
import MiningStatusIcon from '../assets/images/goblin/mining.png';
import TiredStatusIcon from '../assets/images/goblin/tired.png';
import ForSaleStatusIcon from '../assets/images/menu/marketplace.png';
import BusyStatusIcon from '../assets/images/goblin/busy.png';
import HashPowerIcon from '../assets/images/mining/hashPower.png';
import AttackIcon from "../assets/images/goblin/attack_power.png";
import BlacksmithIcon from "../assets/images/goblin/blacksmith_power.png";
import HuntingIcon from "../assets/images/goblin/hunting_power.png";
import MagicIcon from "../assets/images/goblin/magic_power.png";
import ResistenceIcon from "../assets/images/goblin/resistence_power.png";
import SocialIcon from "../assets/images/goblin/social_power.png";
import StealthIcon from "../assets/images/goblin/stealth_power.png";
import TailoringIcon from "../assets/images/goblin/tailoring_power.png";
import { RarityEnum } from '../dto/enum/RarityEnum';
import { RarityStyles } from '../utils/RarityStyles';
import { Layer, RegularPolygon, Stage } from 'react-konva';
import { StatusEnum } from '../dto/enum/StatusEnum';
import { LazyLoadImage } from 'react-lazy-load-image-component';
import { GoblinSkillInfo } from '../dto/domain/GoblinSkillInfo';
import { QuestRequirementInfo } from '../dto/domain/QuestRequirementInfo';

interface GoblinParam {
    id: number;
    idToken: number;
    image: string;
    name: string;
    size: SizeGoblinCard;
    mainColor: string;
    goblinSkillList: GoblinSkillInfo;
    rarity: RarityEnum;
    price?: number;
    //priceDollar?: number;
    showStatus?: boolean;
    status?: StatusEnum;
    inCooldown?: boolean;
    cooldownDate?: string;
    questRequeriment?: QuestRequirementInfo;
    onElemClick?: (idToken: number) => void
}

//const getCardSize = function(size: SizeGoblinCard) {
const getCardWidth = function(size: SizeGoblinCard) {
    switch(size){
        case SizeGoblinCard.Big:
            return 300;
        case SizeGoblinCard.Small:
            return 200;
        case SizeGoblinCard.VerySmall:
            return 150;
    }
}

const getCardHeight = function(size: SizeGoblinCard) {
    switch(size){
        case SizeGoblinCard.Big:
            return 400;
        case SizeGoblinCard.Small:
            return 250;
        case SizeGoblinCard.VerySmall:
            return 190;
    }
}

interface TimerParam {
    expiryTimestamp: Date;
    title: string;
}

const getBackgroundGradient = function(mainColor: string) {
    var color1 = LightenDarkenColor(mainColor, 40);
    var color2 = LightenDarkenColor(mainColor, 120);
    return `linear-gradient(202deg, ${color2} 0%, ${color1} 80%);`;
}

const useStyles = makeStyles(() => ({
    image: {
        objectFit: "cover",
        width: "100%",
        position: "absolute"
    }
}));

function bottomGoblin(size: SizeGoblinCard) {
    switch(size){
        case SizeGoblinCard.Big:
            return 70;
        case SizeGoblinCard.Small:
            return 40;
        case SizeGoblinCard.VerySmall:
            return 30;
    }
}

function bottomName(size: SizeGoblinCard) {
    switch(size){
        case SizeGoblinCard.Big:
            return 20;
        case SizeGoblinCard.Small:
            return 5;
        case SizeGoblinCard.VerySmall:
            return 0;
    }
}

function getCardGoblinStyle(size: SizeGoblinCard) : SxProps<Theme> {
    return {
        width: "100%", 
        height: "100%",
        cursor: "pointer",
        position: "relative",
        backgroundImage: 'url(' + CardGoblin + ')',
        backgroundSize: getCardWidth(size) + 'px ' + getCardHeight(size) + 'px;',
        backgroundRepeat: 'no-repeat',
        borderRadius: 2,
        ...MainStyles.container
    };
}

function getGradientRarity(rarity: RarityEnum) : (number | string)[] {
    return [1, LightenDarkenColor(RarityStyles.getRarityColor(rarity), 40), 0, RarityStyles.getRarityColor(rarity)];
}

function getCardMiningPower(rarity: RarityEnum, size: SizeGoblinCard, goblinSkillList: GoblinSkillInfo, questRequeriment?: QuestRequirementInfo) {
    var widthMaster = 0;
    var heightMaster = 0;
    var radiusMaster = 0;
    var gradientStop = 0;
    var iconSize = 0;
    var textPosition : SxProps<Theme> = null;
    switch(size) {
        case SizeGoblinCard.Big:
            widthMaster = 152;
            heightMaster = 105;
            radiusMaster = 120;
            gradientStop = 55;
            iconSize = 26;
            textPosition = { top: 7, left: 7 };
            break;
        case SizeGoblinCard.Small:
            widthMaster = 102;
            heightMaster = 68;
            radiusMaster = 80;
            gradientStop = 40;
            iconSize = 18;
            textPosition = { top: 3, left: 3 };
            break;
        case SizeGoblinCard.VerySmall:
            widthMaster = 90;
            heightMaster = 60;
            radiusMaster = 65;
            gradientStop = 30;
            iconSize = 16;
            textPosition = { top: 0.5, left: 0.5 };
            break;
    }
    return (
        <>
            <Stage width={widthMaster} height={heightMaster}>
                <Layer>
                    <RegularPolygon
                        x={0}
                        y={0}
                        scaleY={3}
                        scaleX={1.2}
                        rotation={70}
                        sides={3}
                        radius={radiusMaster}
                        fillLinearGradientStartPoint={{ x: 0, y: 0 }}
                        fillLinearGradientEndPoint={{ x: gradientStop, y: 0 }}
                        fillLinearGradientColorStops={getGradientRarity(rarity)}
                        shadowColor={"#000000"}
                        shadowOffsetX={1}
                        shadowOffsetY={1}
                        shadowOpacity={0.6}
                        shadowBlur={4}
                        name={"rarity"}
                    />
                </Layer>
            </Stage>
            <Box sx={{ position: "absolute", ...textPosition }}>
                {
                    getPowerBlock(goblinSkillList, size, iconSize, questRequeriment)
                }
            </Box>
        </>
    )
}

function getPowerBlock(goblinSkillList: GoblinSkillInfo, size: SizeGoblinCard, iconSize: number, questRequeriment?: QuestRequirementInfo) {
    let maximunPower = goblinSkillList.mining;
    let maximunPowerIcon = HashPowerIcon;

    if(!questRequeriment) {
        if(maximunPower.total < goblinSkillList.attack.total) {
            maximunPower = goblinSkillList.attack;
            maximunPowerIcon = AttackIcon;
        }
    
        if(maximunPower.total < goblinSkillList.blacksmith.total) {
            maximunPower = goblinSkillList.blacksmith;
            maximunPowerIcon = BlacksmithIcon;
        }
    
        if(maximunPower.total < goblinSkillList.hunting.total) {
            maximunPower = goblinSkillList.hunting;
            maximunPowerIcon = HuntingIcon;
        }
    
        if(maximunPower.total < goblinSkillList.magic.total) {
            maximunPower = goblinSkillList.magic;
            maximunPowerIcon = MagicIcon;
        }
    
        if(maximunPower.total < goblinSkillList.resistence.total) {
            maximunPower = goblinSkillList.resistence;
            maximunPowerIcon = ResistenceIcon;
        }
    
        if(maximunPower.total < goblinSkillList.social.total) {
            maximunPower = goblinSkillList.social;
            maximunPowerIcon = SocialIcon;
        }
    
        if(maximunPower.total < goblinSkillList.stealth.total) {
            maximunPower = goblinSkillList.stealth;
            maximunPowerIcon = StealthIcon;
        }
    
        if(maximunPower.total < goblinSkillList.tailoring.total) {
            maximunPower = goblinSkillList.tailoring;
            maximunPowerIcon = TailoringIcon;
        }
    } else {
        if(questRequeriment.useattack) {
            maximunPower = goblinSkillList.attack;
            maximunPowerIcon = AttackIcon;
        } else if(questRequeriment.useblacksmith) {
            maximunPower = goblinSkillList.blacksmith;
            maximunPowerIcon = BlacksmithIcon;
        } else if(questRequeriment.usehunting) {
            maximunPower = goblinSkillList.hunting;
            maximunPowerIcon = HuntingIcon;
        } else if(questRequeriment.usemagic) {
            maximunPower = goblinSkillList.magic;
            maximunPowerIcon = MagicIcon;
        } else if(questRequeriment.useresistence) {
            maximunPower = goblinSkillList.resistence;
            maximunPowerIcon = ResistenceIcon;
        } else if(questRequeriment.usesocial) {
            maximunPower = goblinSkillList.social;
            maximunPowerIcon = SocialIcon;
        } else if(questRequeriment.usestealth) {
            maximunPower = goblinSkillList.stealth;
            maximunPowerIcon = StealthIcon;
        } else if(questRequeriment.usetailoring) {
            maximunPower = goblinSkillList.tailoring;
            maximunPowerIcon = TailoringIcon;
        }
    }
    
    
    return (
        <Stack sx={{ ...MainStyles.container }} direction={"row"} spacing={size == SizeGoblinCard.Big ? 1 : 0.5 } >
            <img draggable="false"  src={maximunPowerIcon} style={{ height: iconSize }} />
            <Typography sx={{ ...getStyleMining(size) }}>{maximunPower.total}</Typography>
        </Stack>
    )
}

function getStatusIcon(status: StatusEnum) {
    switch(status) {
        case StatusEnum.Minning:
            return MiningStatusIcon;
        case StatusEnum.Busy:
            return BusyStatusIcon;
        case StatusEnum.Tired:
            return TiredStatusIcon;
        case StatusEnum.ForSale:
            return ForSaleStatusIcon;
    }
}

function getStyleName(size: SizeGoblinCard) : SxProps<Theme> {
    let fontSize = 18;
    if(size == SizeGoblinCard.VerySmall)
        fontSize = 16;
    return  { 
        fontSize: fontSize,
        p: 1,
        ...FontButton
    }
}

function getStyleHeaderRight(size: SizeGoblinCard) : SxProps<Theme> {
    switch(size){
        case SizeGoblinCard.Big:
            return  { 
                position: "absolute",
                top: 28,
                right: 30
            }
        case SizeGoblinCard.Small:
            return  { 
                position: "absolute",
                top: 10,
                right: 20
            }
        case SizeGoblinCard.VerySmall:
            return  { 
                position: "absolute",
                top: 8,
                right: 14   
            }
    }
}

function getStyleToken(size: SizeGoblinCard) : SxProps<Theme> {
    switch(size){
        case SizeGoblinCard.Big:
            return  { 
                fontSize: 22,
                ...FontButton
            }
        case SizeGoblinCard.Small:
            return  { 
                fontSize: 22,
                ...FontButton
            }
        case SizeGoblinCard.VerySmall:
            return  { 
                fontSize: 16,
                ...FontButton  
            }
    }
}

function getStyleMining(size: SizeGoblinCard) : SxProps<Theme> {
    let fontSize = 22;
    if(size == SizeGoblinCard.VerySmall)
        fontSize = 14;
    else if(size == SizeGoblinCard.Small)
        fontSize = 18;
    return  { 
        fontSize: fontSize,
        ...FontButton
    }
}

export function Goblin(param: GoblinParam) {
    const {  image } = useStyles();
    
    function MyTimer(props: TimerParam) {
        const {
          seconds,
          minutes,
          hours,
          days,
          isRunning,
          start,
          pause,
          resume,
          restart,
        } = useTimer({ expiryTimestamp: props.expiryTimestamp, onExpire:  () => console.warn('onExpire called') });

        return (
          <Stack sx={{ ...MainStyles.container }}>
            <Typography sx={{ ...GoblinStyles.sessionTitleText }} >{props.title}</Typography>
            <Typography sx={{ ...GoblinStyles.textMain }} >{days + " days " + hours + " hr " + minutes + " min " + seconds + " sec"}</Typography>
          </Stack>
        );
    }

    return (
        <Box sx={{ position: "relative", cursor: "pointer" }} onClick={() => param.onElemClick(param.idToken)} >
            <Box sx={{ position: "absolute", top: 2, left: 2, background: getBackgroundGradient(RarityStyles.getRarityColor(param.rarity)), width: getCardWidth(param.size) - 5, height: getCardHeight(param.size) - 5, opacity: param.inCooldown ? 0.3 : 1 }} />
            <Paper sx={{ ...GoblinCardStyles.outCardGoblin, width: getCardWidth(param.size), height: getCardHeight(param.size), opacity: param.inCooldown ? 0.3 : 1  }}  elevation={3}>
                <Box sx={{ ...getCardGoblinStyle(param.size) }} >
                    <img draggable="false"  
                        src={param.image}
                        alt={param.name}
                        className={image}
                        style={{ bottom: bottomGoblin(param.size), zIndex: 2 }}
                    />
                    <LazyLoadImage
                        alt={param.name}
                        src={param.image}
                        className={image}
                        style={{ bottom: bottomGoblin(param.size), zIndex: 2 }}
                    />
                    <Stack spacing={1} direction={"column"} sx={{ ...getStyleHeaderRight(param.size), display: "flex", alignContent: "flex-end", alignItems: "flex-end", zIndex: 3 }}>
                        <Typography sx={{ ...getStyleToken(param.size) }}>#{param.idToken}</Typography>
                        {
                            param.size == SizeGoblinCard.Big && param.showStatus && param.status != StatusEnum.Avaliable && 
                            <Paper sx={{ height: 40, width: 40, p: 0.3, bgcolor: "#e3dac9", borderRadius: 20 }} elevation={8}>
                                <img draggable="false"  src={getStatusIcon(param.status)} style={{ height: "100%", objectFit: "cover", }} alt={"Status"} />
                            </Paper>
                        }
                    </Stack>
                    <Box sx={{ ...MainStyles.container, width: 1, position: "absolute", bottom: bottomName(param.size), zIndex: 3 }}>
                        <Stack textAlign={"center"} spacing={0}> 
                            <Typography sx={{ ...getStyleName(param.size), pb: param.size == SizeGoblinCard.VerySmall ? "7px" : "0px" }} noWrap >{param.name}</Typography>
                            {param.price > 0 &&
                            <Typography sx={{ ...getStyleName(param.size), pt: "0px" }} noWrap >{param.price.toFixed(0)} GOBI</Typography>
                            }
                        </Stack>
                    </Box>
                </Box>
            </Paper>
            {
                param.inCooldown && param.size == SizeGoblinCard.Big && !param.price && 
                <Box sx={{ ...MainStyles.container, width: "100%", height: "100%", position: "absolute", bottom: 0 }}>
                    <MyTimer title={"In cooldown until"} expiryTimestamp={new Date(Moment(param.cooldownDate).add("minutes", (new Date()).getTimezoneOffset() * -1).valueOf())}  />
                </Box>
            }
            {
                <Box sx={{ ...MainStyles.container, width: "100%", height: "100%", position: "absolute", bottom: 0, top: 0, left: 0, right: 0 }} >
                    {
                        RarityStyles.getCardEffect(getCardHeight(param.size), getCardWidth(param.size), param.rarity, param.idToken + "card")
                    }
                </Box>
            }
            <Box sx={{ position: "absolute", top: 0, left: 0, overflow: "hidden", borderRadius: 2, zIndex: 4 }}>
                {
                    getCardMiningPower(param.rarity, param.size, param.goblinSkillList, param.questRequeriment)
                }
            </Box>
        </Box>
        
    )
}
