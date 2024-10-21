import Web3 from "web3";
import BusinessResult from "../../dto/business/BusinessResult";
import GoblinContractFactory from "../factory/GoblinContractFactory";
import IGoblinContractBusiness from "../interfaces/IGoblinContractBusiness";

const GoblinContractBusiness : IGoblinContractBusiness = {
    transferFrom: async (to: string, tokenId: number) => {
        let ret: BusinessResult<string>;
        let buildErro = (msg: string) => {
            return ret = {
                ...ret,
                sucesso: false,
                mensagem: msg
            };
        };
    
        try {
            let web3: Web3 | undefined = undefined;
    
            web3 = new Web3((window as any).ethereum);
            const publicAddress = await web3.eth.getCoinbase();
            if (!publicAddress) {
                return buildErro('Please activate MetaMask first.');
            }
            const goblinContract = GoblinContractFactory.getGoblinContract(web3);
            let receipt = await goblinContract.methods.transferFrom(publicAddress, to, tokenId).send({ 
              from: publicAddress
            });
            if (receipt.transactionHash) {
                return ret = {
                    ...ret,
                    sucesso: true,
                    dataResult: receipt.transactionHash
                };
            }
            else {
                buildErro("Error in transaction");
            }
        } catch (err: any) {
            return buildErro('Error: ' + err.message);
        }
    }
}

export default GoblinContractBusiness;