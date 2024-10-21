import { makeStyles } from "@mui/styles";
import Bg from "../assets/images/bg.jpg";
import BgDungeon from "../assets/images/bg-dungeon.jpg";
import CardGray from '../assets/images/card-common.png';
import { Theme } from "@mui/material/styles";
import { SxProps } from "@mui/system";
import { FontButton, FontSocial, FontTitleSession } from "./fontStyle";
import { GoblinWarsColors, GoblinWarsBackground } from "../dto/styles/GoblinWarsColors";

//Main
const container : SxProps<Theme> = {
  display: "flex",
  alignItems: "center",
  alignContent: "center",
  justifyContent: "center"
};

const floatingBox : SxProps<Theme> = {
  background: GoblinWarsBackground.containerBackground,
  p: 1,
  border: 0,
  borderColor: GoblinWarsColors.borderContainer,
};

const mainClasses = makeStyles({
  BackgroundPage: {
    backgroundImage: 'url('+ Bg +')',
    width: "100%",
    height: "100vh"
  },
  BackgroundDungeon: {
    width: "100%",
    height: "100%",
    backgroundImage: 'url('+ BgDungeon +')'
  },
  center: {
    display: 'block',
    marginLeft: 'auto',
    marginRight: 'auto'
  }
});

const baseButton : SxProps<Theme> = { 
  width: 1,
  borderTop: 1,
  borderLeft: 1,
  borderRight: 1,
  borderColor: GoblinWarsColors.borderContainer,
  borderBottom: 5, 
  borderBottomColor: "#2f2e1c", 
  borderRadius: 3,
  background: GoblinWarsBackground.containerBackground,
  boxShadow: 6,
  ...FontButton
}

const mainButton : SxProps<Theme> = {
  ...baseButton,
  fontSize: 18
}
const bigButton : SxProps<Theme> = {
  ...baseButton,
  fontSize: 24
}

const textButton = {
  color: GoblinWarsColors.darkInfoText
}

const tabButton : SxProps<Theme>  = {
  fontFamily: "Yeon Sung",
  color: GoblinWarsColors.buttonFontColor,
  fontWeight: "bold",
  fontSize: 18
}

const tabButtonSelected : SxProps<Theme>  = {
  ...tabButton,
  fontSize: 22,
  borderBottom: 5, 
  paddingBottom: 0,
  borderBottomColor: GoblinWarsColors.lightBox, 
}

const popUp = {
  
}

//Goblin Detail
const outCardDetailGoblin : SxProps<Theme> = {
  //bgcolor: "#5f4a2d",
  borderRadius: 3,
  border: 1,
  p: 1,
  ...container
};

const cardDetailGoblin : SxProps<Theme> = {
  background: "radial-gradient(circle, rgba(115,96,79,1) 0%, rgba(38,28,18,1) 70%)",
  borderRadius: 3,
  border: 1,
  p: 1,
  ...container
};

const sessionTitle : SxProps<Theme> = {
  bgcolor: "#221a18",
  p: 2,
  width: 1,
}

const sessionTitleText : SxProps<Theme> = {
  ...FontTitleSession,
  fontSize: 22
}
const sessionSubTitleText : SxProps<Theme> = {
  ...FontTitleSession,
  fontSize: 18,
  fontWeight: "Normal"
}

const infoTextMain : SxProps<Theme> = {
  ...FontTitleSession,
  color: GoblinWarsColors.infoText
}

const textMain : SxProps<Theme> = {
  ...FontButton,
  fontSize: 22
}

const sessionDivider : SxProps<Theme> = {
  background: GoblinWarsBackground.containerBackground,
  p: 1,
  width: 1,
  border: 1,
  borderColor: GoblinWarsColors.borderContainer,
}

const subSessionTitle : SxProps<Theme> = {
  bgcolor: "#29201b",
  p: 1,
  width: 1,
}

const boxGoblinParent : SxProps<Theme> = {
  bgcolor: "#352a26",
  border: 1,
}

//Goblin Card
const outCardGoblin : SxProps<Theme> = {
  borderRadius: 4,
  borderWidth: 1,
  borderColor: "transparent",
  bgcolor: "transparent",
  ...container
};



const goblinNameContainer : SxProps<Theme> = {
  pl: 2,
  pr: 2,
  ...container
}

//Social
const baseSocialButton : SxProps<Theme> = {
  height: 42,
  width: 140,
  m: 1
}

const FacebookButton : SxProps<Theme> = {
  bgcolor: "#4267B2",
  ...baseSocialButton
}
const TwitterButton : SxProps<Theme> = {
  bgcolor: "#1DA1F2",
  ...baseSocialButton
}
const DiscordButton : SxProps<Theme> = {
  bgcolor: "#7289DA",
  ...baseSocialButton
}
const TelegranButton : SxProps<Theme> = {
  bgcolor: "#0088cc",
  ...baseSocialButton
}

const SocialText : SxProps<Theme> = {
  ...FontSocial,
  fontSize: 15
}
const SocialIcon : SxProps<Theme> = {
  color: "white"
}

//CoinStyles

const coinBackground : SxProps<Theme> = {
  width: 0.95,
  borderWidth: 1,
  borderColor: "black",
  borderRadius: 2,
  display: "flex",
  alignItems: "center",
  alignContent: "center",
  justifyItems: "flex-end",
  justifyContent: "flex-end",
  p: 0.1
}

const coinText : SxProps<Theme> = {
  ...FontButton,
  fontSize: 18
}


//Exports
const MainStyles = {
  container,
  mainButton,
  tabButton,
  tabButtonSelected,
  bigButton,
  popUp,
  floatingBox,
  textButton
}

const CoinStyles = {
  coinBackground,
  coinText
}

const GoblinStyles = {
  container,
  outCardDetailGoblin,
  cardDetailGoblin,
  sessionTitle,
  sessionTitleText,
  sessionSubTitleText,
  sessionDivider,
  infoTextMain,
  textMain,
  boxGoblinParent,
  subSessionTitle
};

const GoblinCardStyles = {
  outCardGoblin,
  goblinNameContainer
}

const SocialStyles = {
  FacebookButton,
  TwitterButton,
  DiscordButton,
  TelegranButton,
  SocialText,
  SocialIcon
}

export { mainClasses, MainStyles, GoblinStyles, GoblinCardStyles, SocialStyles, CoinStyles }