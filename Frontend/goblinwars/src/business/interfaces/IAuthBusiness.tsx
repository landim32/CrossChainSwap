import BusinessResult from "../../dto/business/BusinessResult";
import { AuthSession } from "../../dto/domain/AuthSession";
import { IAuthService } from "../../services/interfaces/IAuthService";

export interface IAuthBusiness {
  init: (authService: IAuthService) => void;
  bindMetaMaskWallet: (name: string, email: string, fromReferralCode: string) => Promise<BusinessResult<AuthSession>>;
  checkUserRegister: () => Promise<BusinessResult<boolean>>;
  logIn: (authSession: AuthSession) => void;
  logOut: () => void;
  getSession: () => AuthSession;
  getGokenSession: () => string;
  updateUser: (name: string, email: string) => Promise<BusinessResult<AuthSession>>;
  checkNetwork: () => Promise<BusinessResult<boolean>>;
}