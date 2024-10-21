import BusinessResult from "../../dto/business/BusinessResult";
import { IDollarBusiness } from "../interfaces/IDollarBusiness";

const DollarBusiness: IDollarBusiness = {
    getDollar: async function getDollar() {
        let ret: BusinessResult<number>;
        let buildErro = (msg: string) => {
          return ret = {
            ...ret,
            sucesso: false,
            mensagem: msg
          };
        };
        try {
            let response = await fetch('https://api.binance.com/api/v3/ticker/price?symbol=BNBBUSD');
            let responseJson = await response.json();
            if (!responseJson.price) {
                buildErro("Error in transaction");
            }
            return ret = {
                ...ret,
                sucesso: true,
                dataResult: responseJson.price
            };
        } catch(err: any) {
            buildErro(err.message);
        }
    }
}

export default DollarBusiness;