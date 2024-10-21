import BusinessResult from "../../dto/business/BusinessResult";
import Web3 from "web3";
import IGobiBusiness from "../interfaces/IGobiBusiness";
import GobiContractFactory from "../factory/GobiContractFactory";

const GobiBusiness : IGobiBusiness = {
    allowance:  async (spender: string) => {
        let ret: BusinessResult<number>;
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
          const gobiContract = GobiContractFactory.getGobiContract(web3);
          let receipt = await gobiContract.methods.allowance(publicAddress, spender).call();
          if (receipt) {
            let balanceInWei = web3.utils.fromWei(receipt.toString(), "ether");
            return ret = {
              ...ret,
              sucesso: true,
              dataResult: parseFloat(balanceInWei)
            };
          }
          else {
            buildErro("Error in transaction");
          }
        } catch (err: any) {
          return buildErro('Error: ' + err.message);
        }
    },
    balanceOf: async () => {
        let ret: BusinessResult<number>;
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
          const gobiContract = GobiContractFactory.getGobiContract(web3);
          let receipt = await gobiContract.methods.balanceOf(publicAddress).call();
          if (receipt) {
            let balanceInWei = web3.utils.fromWei(receipt.toString(), "ether");
            return ret = {
              ...ret,
              sucesso: true,
              dataResult: parseFloat(balanceInWei)
            };
          }
          else {
            buildErro("Error in transaction");
          }
        } catch (err: any) {
          return buildErro('Error: ' + err.message);
        }
    },
    approve: async (spender: string, amount: number) => {
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
            const gobiContract = GobiContractFactory.getGobiContract(web3);
            let amountInWei = web3.utils.toWei(amount.toString(), "ether");
            let receipt = await gobiContract.methods.approve(spender, amountInWei).send({ 
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
    },
    transfer: async (recipient: string, amount: number) => {
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
            const gobiContract = GobiContractFactory.getGobiContract(web3);
            let priceInWei = web3.utils.toWei(amount.toString(), "ether");
            let receipt = await gobiContract.methods.transfer(recipient, priceInWei).send({ 
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

export default GobiBusiness;