import { Theme } from "@mui/material";
import { SxProps } from "@mui/system";
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";

const FontButton : SxProps<Theme> = {
  fontFamily: "Yeon Sung",
  color: GoblinWarsColors.buttonFontColor,
  fontWeight: "bold",
  textShadow: "0px 5px 4px #191719,1px 1px 0px #181813, rgb(61, 59, 46) 3px 0px 0px, rgb(61, 59, 46) 2.83487px 0.981584px 0px, rgb(61, 59, 46) 2.35766px 1.85511px 0px, rgb(61, 59, 46) 1.62091px 2.52441px 0px, rgb(61, 59, 46) 0.705713px 2.91581px 0px, rgb(61, 59, 46) -0.287171px 2.98622px 0px, rgb(61, 59, 46) -1.24844px 2.72789px 0px, rgb(61, 59, 46) -2.07227px 2.16926px 0px, rgb(61, 59, 46) -2.66798px 1.37182px 0px, rgb(61, 59, 46) -2.96998px 0.42336px 0px, rgb(61, 59, 46) -2.94502px -0.571704px 0px, rgb(61, 59, 46) -2.59586px -1.50383px 0px, rgb(61, 59, 46) -1.96093px -2.27041px 0px, rgb(61, 59, 46) -1.11013px -2.78704px 0px, rgb(61, 59, 46) -0.137119px -2.99686px 0px, rgb(61, 59, 46) 0.850987px -2.87677px 0px, rgb(61, 59, 46) 1.74541px -2.43999px 0px, rgb(61, 59, 46) 2.44769px -1.73459px 0px, rgb(61, 59, 46) 2.88051px -0.838247px 0px;"
};
const FontTitleSession : SxProps<Theme> = {
  fontFamily: "Yeon Sung",
  color: GoblinWarsColors.titleColor,
  fontWeight: "bold",
  textShadow: "0px 2px 1px #000000,1px 1px 0px #000000;"
};

const FontInfo : SxProps<Theme> = {
  fontFamily: "Open Sans",
  color: GoblinWarsColors.titleColor,
  fontWeight: "normal",
  textShadow: "0px 2px 1px #000000,1px 1px 0px #000000;"
};

const FontSocial : SxProps<Theme> = {
  fontFamily: "Open Sans",
  color: "white",
  fontWeight: "normal",
};

export { FontButton, FontTitleSession, FontInfo, FontSocial }