@echo off
echo Testing /transfer
curl -X PUT http://localhost:3000/transfer -H "Content-Type: application/json" -d "{recipientAddress: 'ST3J2GVMMM2R07ZFBJDWTYAMW5Q91S66MGN2DYWQ6',amount: 1000000,fee: 500}"
