import BusinessResult from "../../dto/business/BusinessResult";
import { AuthSession } from "../../dto/domain/AuthSession";
import { IAuthService } from "../../services/interfaces/IAuthService";
import { IAuthBusiness } from "../interfaces/IAuthBusiness";
import Web3 from 'web3';

const LS_KEY = 'login-with-metamask:auth';

let _authService : IAuthService;

const AuthBusiness : IAuthBusiness = {
  init: function (authService: IAuthService): void {
    _authService = authService;
  },
  checkNetwork: async () => {
    let ret: BusinessResult<boolean>;

    let web3: Web3 | undefined = undefined;
    let ethereum: any = null;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    if (!(window as any).ethereum) {
      return buildErro('Please install MetaMask first.');
    }

    if (!web3) {
      try {
        await (window as any).ethereum.enable();
        ethereum = (window as any).ethereum;
        web3 = new Web3((window as any).ethereum);
      } catch (error) {
        return buildErro('You need to allow MetaMask.');
      }
    }

    try {
      await ethereum.request({
        method: 'wallet_switchEthereumChain',
        params: [{ chainId: '0x' + parseInt(process.env.REACT_APP_NETWORK).toString(16) }],
      });
    } catch (switchError: any) {
      // This error code indicates that the chain has not been added to MetaMask.
      if (switchError.code === 4902) {
        try {
          await ethereum.request({
            method: 'wallet_addEthereumChain',
            params: [
              { 
                chainId: '0x'+parseInt(process.env.REACT_APP_NETWORK).toString(16), 
                chainName: process.env.REACT_APP_CHAIN_NAME,
                rpcUrls: [process.env.REACT_APP_CHAIN_URL],
                blockExplorerUrls: [process.env.REACT_APP_CHAIN_EXPLORER],
                nativeCurrency: {
                  name: "BNB",
                  symbol: "BNB",
                  decimals: 18
                }
              }
            ],
          });
        } catch (addError) {
          // handle "add" error
        }
      }
      // handle other "switch" errors
    }

    return {
      ...ret,
      dataResult: true,
      sucesso: true,
    };
  },
  bindMetaMaskWallet: async (name: string, email: string, fromReferralCode: string) => {
    let ret: BusinessResult<AuthSession>;
    let web3: Web3 | undefined = undefined;
    let buildErro = (msg: string) => {
      return ret = {
        ...ret,
        sucesso: false,
        mensagem: msg
      };
    };

    if (!(window as any).ethereum) {
      return buildErro('Please install MetaMask first.');
    }

    if (!web3) {
      try {
        await (window as any).ethereum.enable();

        web3 = new Web3((window as any).ethereum);
      } catch (error) {
        return buildErro('You need to allow MetaMask.');
      }
    }

    const publicAddress = await web3.eth.getCoinbase();
    if (!publicAddress) {
      return buildErro('Please activate MetaMask first.');
    }

    let userAddressResult = await _authService.getAuthHash(publicAddress, fromReferralCode);
    if (userAddressResult.sucesso) {
      // Parece q não está entrando aqui
      if (!userAddressResult.user) {
        userAddressResult = await _authService.register(publicAddress, name, email, fromReferralCode);
      }
      // Fim do código inutil
      if (userAddressResult.sucesso) {
        try {
          const signature = await web3.eth.personal.sign(
            userAddressResult.user.hash,
            publicAddress,
            ''
          );
          userAddressResult.user.publicKey = signature;
          AuthBusiness.logIn(userAddressResult.user);
        } catch (err) {
          return buildErro('You need to sign the message to be able to log in.');
        }

      } else {
        return buildErro(userAddressResult.mensagem);
      }
    } else {
      return buildErro(userAddressResult.mensagem);
    }

    ret = {
      ...ret,
      sucesso: true,
      dataResult: userAddressResult.user
    };
    return ret;
  },
  logIn: (authSession: AuthSession) => {
    localStorage.setItem(LS_KEY, JSON.stringify(authSession));
  },
  logOut: () => {
    localStorage.removeItem(LS_KEY);
  },
  getSession: () => {
    const ls = window.localStorage.getItem(LS_KEY);
    return ls && JSON.parse(ls);
  },
  getGokenSession: () => {
    let session = AuthBusiness.getSession();
    if (session) {
      return Buffer.from(session.publicKey + "|separator|" + session.publicAddress).toString('base64');
    } else {
      return "";
    }
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
    if(chainId != parseInt(process.env.REACT_APP_NETWORK)) {
      return {
        ...ret,
        sucesso: false,
        dataResult: false,
        mensagem: "You need to connect on Binance Mainnet"
      };
    }
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
  },
  updateUser: async (name: string, email: string) => {
    let ret: BusinessResult<AuthSession>;
    let userSession = AuthBusiness.getSession();
    let userAddressResult = await _authService.updateUser(userSession.publicAddress, name, email, AuthBusiness.getGokenSession());
    if(!userAddressResult.sucesso)
      return {
        ...ret,
        sucesso: false,
        dataResult: null,
        mensagem: userAddressResult.mensagem
      }
    
    userAddressResult.user.hash = userSession.hash;
    userAddressResult.user.publicKey = userSession.publicKey;
    userAddressResult.user.publicAddress = userSession.publicAddress;
    AuthBusiness.logIn(userAddressResult.user);
    return {
      ...ret,
      sucesso: true,
      dataResult: userAddressResult.user
    };
  }
}

export {AuthBusiness};