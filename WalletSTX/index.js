const { generateWallet, getStxAddress } = require('@stacks/wallet-sdk');
const { makeSTXTokenTransfer, broadcastTransaction, TransactionVersion, AnchorMode } = require('@stacks/transactions');
const { StacksMainnet, StacksDevnet } = require('@stacks/network');
const fs = require('fs');
const path = require('path');

const mnemonicFilePath = path.join(__dirname, 'mnemonic.txt');

async function loadMnemonic() {
    if (!fs.existsSync(mnemonicFilePath)) {
        throw new Error('mnemonic file not exist.');
    }
    const mnemonic = fs.readFileSync(mnemonicFilePath, 'utf8');
    //const mnemonic = fs.readFileSync(mnemonicFilePath);
    console.log('MNemonic:', mnemonic.trim());
    return mnemonic.trim();
}

async function getPrivateKeyFromMnemonic(mnemonic) {
    const wallet = await generateWallet({ secretKey: mnemonic });
    const account = wallet.accounts[0]; // Primeira conta derivada do mnemonic
    return account.stxPrivateKey;
}

async function getAddress() {
    const mnemonic = await loadMnemonic();
    const wallet = await generateWallet({ secretKey: mnemonic });
    const account = wallet.accounts[0];
    const address = await getStxAddress({ account, transactionVersion: TransactionVersion.Testnet });
    console.log('Address:', address);
    return address;
}

async function transferSTX(recipientAddress, amount) {
    const mnemonic = await loadMnemonic();
    const senderPrivateKey = await getPrivateKeyFromMnemonic(mnemonic);

    //const network = new StacksMainnet();
    const network = new StacksDevnet({ url: "https://api.testnet.hiro.so" });

    const txOptions = {
        recipient: recipientAddress,
        //amount: new BigNum(amount),
        amount: amount,
        senderKey: senderPrivateKey,
        network: network,
        //fee: new BigNum(fee),
        //fee: fee,
        //nonce: await getNonce(address), // Obter o nonce do endereço usando a API Stacks
        anchorMode: AnchorMode.Any,
        //version: TransactionVersion.Mainnet,
        version: TransactionVersion.Testnet,
    };

    const transaction = await makeSTXTokenTransfer(txOptions);
    const broadcastResponse = await broadcastTransaction(transaction, network);

    console.log('Hash da Transação:', broadcastResponse);
    return broadcastResponse;
}

const express = require('express');
const app = express();
app.use(express.json());

app.get('/get-address', async (req, res) => {
    try {
        const address = await getAddress();
        res.json(address);
    }
    catch (error) {
        console.error('Error:', error);
        res.json({ error: error});
    }
});

app.put('/transfer', async (req, res) => {
    try {
        console.log('Request:', req.body);
        const { recipientAddress, amount } = req.body;
        const result = await transferSTX(recipientAddress, amount);
        res.json({ transactionHash: result });
    }
    catch (error) {
        console.error('Error:', error);
        res.json({ error: error});
    }
});

app.listen(3000, () => {
    console.log('API running on port 3000');
});

