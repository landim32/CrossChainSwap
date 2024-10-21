import React from "react";
import { Routes } from "./routes";
import Dotenv from "dotenv";
import { createTheme } from "@mui/material/styles";
import { ThemeProvider } from "@mui/material/styles";
import { GoblinWarsColors } from "./dto/styles/GoblinWarsColors";
import ReactGA from "react-ga";


const theme = createTheme({
  typography: {
    fontFamily: 'Open Sans, Yeon Sung',
  },
  palette: {
    primary: {
      main: GoblinWarsColors.darkInfoText
    }
  },
  components: {
    MuiButton: {
      styleOverrides: {
        root: {
          "&:disabled":{
            color: "gray",
            opacity: 0.2
          }
        }
      }
    },
    MuiTextField: {
      defaultProps: {
        SelectProps: {
          MenuProps: {
              PaperProps: {
                  sx: {
                    background: "linear-gradient(180deg, rgba(99,145,83,1) 0%, rgba(43,52,33,1) 100%)"
                  }
              },
              MenuListProps: {
                  sx: {
                      color: "white"
                  }
              }
          }
        }
      }
    },
    MuiPopover: {
      styleOverrides: {
        paper: {
          backgroundColor: "transparent"
        },
        root: {
          backgroundColor: "rgb(0, 0, 0, 0.5)"
        }
      }
    }
  }
});

const App: React.FC = () => {
  Dotenv.config();
  ReactGA.initialize("UA-60360955-3");
  return (
    
      <ThemeProvider theme={theme}>
        <Routes />
      </ThemeProvider>
  );
};

export default App;