import { Button, Modal, Snackbar, Theme, SxProps } from "@mui/material";
import { useContext, useState } from "react";
import { useLocation } from "react-router";
import { UserInfo } from "../../components/UserInfo";
import AuthContext from "../../contexts/auth/AuthContext";
import InicioContext from "../../contexts/inicio/InicioContext";
import SelectedRoute from "../../dto/enum/SelectedRoute";
import { FontButton } from "../../utils/fontStyle";
import { MainStyles } from "../../utils/style";
import { ValidateEmail } from "../../utils/utils";

interface LoginButtonParam {
  msgErrorCb : (msg: string) => void;
  successCb? : () => void;
  title? : string;
}

export function LoginButton(param : LoginButtonParam) {

  const [showUserInfo, setShowUserInfo] = useState(false);
  const authContext = useContext(AuthContext);
  const inicioContext = useContext(InicioContext);
  let location = useLocation();

  const openUserInfo = () => {
    setShowUserInfo(true);
  }
  const closeUserInfo = () => {
    setShowUserInfo(false);
  }

  const logInMetaMask = async (name: string, emai: string, fromReferralCode: string) => {
    let bindResult = await authContext.bindMetaMaskWallet(name, emai, fromReferralCode);
    if(bindResult.sucesso) {
      if(param.successCb)
        param.successCb();
      else
        inicioContext.setSelectedFlow(SelectedRoute.GameFlow);
    } else {
      param.msgErrorCb(bindResult.mensagemErro);
    }
  }

  return (
    <>
      <Button sx={{ ...MainStyles.bigButton, width: 200 }} onClick= { async () => {
          let checkRegister = await authContext.checkUserRegister();
          if(checkRegister.sucesso) {
            let referralCode = new URLSearchParams(location.search).get("ref");
            logInMetaMask("", "", referralCode);
          } else {
            if(checkRegister.mensagemErro == "register")
              openUserInfo();
            else{
              param.msgErrorCb(checkRegister.mensagemErro)
            }
          }
        }
      }>{authContext.loading ? "Logging in..." : (param.title ? param.title : "Play Now")}</Button>
      <Modal open={showUserInfo} onClose={closeUserInfo}>
            <UserInfo name={""} email={""} registerCb={(name: string, email: string) => {
              if (ValidateEmail(email)) {
                let referralCode = new URLSearchParams(location.search).get("ref");
                logInMetaMask(name, email, referralCode);
              } else {
                param.msgErrorCb("Invalid email address")
              }
            } } loading={authContext.loading} btnText={"Sign up"} btnLoadingText={"Signing up..."} />
      </Modal>
    </>
    
  );
}