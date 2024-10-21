import { TextField } from "@mui/material";
import { withStyles } from "@mui/styles";
import { GoblinWarsColors } from "../dto/styles/GoblinWarsColors";
import { FontInfo } from "../utils/fontStyle";

const OulinedInput = withStyles({
  root: {
    '& label.Mui-focused': {
      fontWeight: "normal",
      fontFamily: "Open Sans",
      color: GoblinWarsColors.titleColor,
      textShadow: "0px 2px 1px #000000,1px 1px 0px #000000;"
    },
    '& label.Mui-disabled': {
      fontWeight: "normal",
      fontFamily: "Open Sans",
      color: GoblinWarsColors.titleColor,
      textShadow: "0px 2px 1px #000000,1px 1px 0px #000000;"
    },
    '& label': {
      fontWeight: "normal",
      fontFamily: "Open Sans",
      color: GoblinWarsColors.titleColor,
      textShadow: "0px 2px 1px #000000,1px 1px 0px #000000;"
    },
    '& .MuiInput-underline:after': {
      borderBottomColor: 'white',
    },
    '& .MuiOutlinedInput-root': {
      '& fieldset': {
        borderColor: 'white',
      },
      '&:hover fieldset': {
        borderColor: 'white',
      },
      '&.Mui-focused fieldset': {
        borderColor: 'white',
      },
    },
  },
})(TextField);

export { OulinedInput }