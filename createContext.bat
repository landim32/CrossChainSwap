@echo off
cd .\Backend\NoChainSwap\DB.Infra
dotnet ef dbcontext scaffold "Host=167.172.240.71;Port=5432;Database=crosschainswap;Username=postgres;Password=eaa69cpxy2" Npgsql.EntityFrameworkCore.PostgreSQL --context NoChainSwapContext --output-dir Context -f
pause