docker ps
docker network inspect docker-network
docker network create docker-network
docker network connect docker-network postgres1
docker build -t crosschainswap-api -f BTCSTXSwap.API\Dockerfile .
docker run --name crosschainswap-api1 -p 8080:8080 --network docker-network crosschainswap-api &
docker run --name crosschainswap-api1 -p 8080:80 --network docker-network crosschainswap-api