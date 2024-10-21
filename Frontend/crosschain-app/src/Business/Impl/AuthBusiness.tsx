import BusinessResult from "../../DTO/Business/BusinessResult";
import { AuthSession } from "../../DTO/Domain/AuthSession";
import { IAuthService } from "../../Services/Interfaces/IAuthService";
import { IAuthBusiness } from "../Interfaces/IAuthBusiness";
import Web3 from 'web3';
import { AppConfig, getUserData, UserData, UserSession, showConnect, disconnect } from '@stacks/connect';

const LS_KEY = 'login-with-metamask:auth';

let _authService : IAuthService;

const AuthBusiness : IAuthBusiness = {
  init: function (authService: IAuthService): void {
    _authService = authService;
  },
  logIn: (callback?: any) => {
    var ret: BusinessResult<boolean>;
    const appConfig = new AppConfig(['store_write', 'publish_data']);
    const userSession = new UserSession({ appConfig });
    //console.log(userSession);
    //localStorage.setItem(LS_KEY, JSON.stringify(authSession));
    showConnect({
      userSession, // `userSession` from previous step, to access storage
      appDetails: {
        name: "Cross Chain Swap",
        icon: window.location.origin + '/public/logo192.png'
      },
      onFinish: () => {
        if (callback) {
          callback();
        }
        /*
        return {
          ...ret,
          sucesso: true,
          dataResult: true,
        };
        */
      },
      onCancel: () => {
        console.log('oops'); // WHEN user cancels/closes pop-up
      },
    });
  },
  logOut: () => {
    //localStorage.removeItem(LS_KEY);
    disconnect();
  },
  getSession: async () => {
    let ret: BusinessResult<boolean>;
    let lUserData = await getUserData();
    if (lUserData) {
      let userSession: AuthSession;
      let btcAddr = lUserData.profile?.btcAddress?.p2wpkh?.testnet;
      let stxAddr = lUserData.profile?.stxAddress?.testnet;
      let userAddr = btcAddr.substr(0, 6) + '...' + btcAddr.substr(-4);
      return {
        ...ret,
        sucesso: true,
        dataResult: {
          ...userSession,
          name: userAddr,
          publicAddress: lUserData.identityAddress,
          btcAddress: btcAddr,
          stxAddress: stxAddr
        },
      };
    }
    return {
      ...ret,
      sucesso: false,
      dataResult: null,
    };
  },
  checkUserRegister: async () => {
    var ret: BusinessResult<boolean>;

    let web3: Web3 | undefined = undefined;

    if (!(window as any).ethereum) {
      return {
        ...ret,
        sucesso: false,
        dataResult: false,
        mensagem: 'Please install MetaMask first.'
      };
    }

    if (!web3) {
      try {
        await (window as any).ethereum.enable();

        web3 = new Web3((window as any).ethereum);
      } catch (error) {
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: 'You need to allow MetaMask.'
        };
      }
    }
    let chainId = await web3.eth.net.getId();
    /*
    if(chainId != parseInt(process.env.REACT_APP_NETWORK)) {
      return {
        ...ret,
        sucesso: false,
        dataResult: false,
        mensagem: "You need to connect on Binance Mainnet"
      };
    }
    */
    const publicAddress = await web3.eth.getCoinbase();
    if (!publicAddress) {
      return {
        ...ret,
        sucesso: false,
        dataResult: false,
        mensagem: 'Please activate MetaMask first'
      };
    }

    let userAddressResult = await _authService.checkUserRegister(publicAddress);
    if (userAddressResult.sucesso) {
      if (!userAddressResult.user) {
        return {
          ...ret,
          sucesso: false,
          dataResult: false,
          mensagem: "register"
        };
      }
    } else {
      return {
        ...ret,
        sucesso: false,
        dataResult: false,
        mensagem: "Unknow error"
      };
    }

    return {
      ...ret,
      sucesso: true,
      dataResult: true
    };
  }
}

export {AuthBusiness};