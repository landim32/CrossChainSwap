@echo off
cd .\Backend\BTCSTXSwap\DB.Infra
dotnet ef dbcontext scaffold "Host=localhost;Port=15432;Database=crosschainswap;Username=postgres;Password=eaa69cpxy2" Npgsql.EntityFrameworkCore.PostgreSQL --context CrossChainSwapContext --output-dir Context -f
pause