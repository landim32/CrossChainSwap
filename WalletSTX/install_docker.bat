docker build -t stacks-wallet .
docker run --name wallet-stx -p 3000:3000 stacks-wallet