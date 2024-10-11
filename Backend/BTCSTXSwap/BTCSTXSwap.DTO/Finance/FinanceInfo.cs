using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTCSTXSwap.DTO.Finance
{
    public class FinanceInfo
    {
        [JsonPropertyName("publicaddress")]
        public string PublicAddress { get; set; }
        [JsonPropertyName("hotwalletgobi")]
        public decimal HotWalletGobi { get; set; }
        [JsonPropertyName("hotwalletbnb")]
        public decimal HotWalletBNB { get; set; }
        [JsonPropertyName("lastwithdrawl")]
        public DateTime? LastWithdrawl { get; set; }
        [JsonPropertyName("nextwithdrawlwithoutfee")]
        public DateTime? NextWithdrawlWithoutFee { get; set; }
        [JsonPropertyName("daysfornofee")]
        public int DaysForNoFee { get; set; }
        [JsonPropertyName("minimalgobifee")]
        public decimal MinimalGobiFee { get; set; }
        [JsonPropertyName("minimalgobi")]
        public decimal MinimalGobi { get; set; }
        [JsonPropertyName("gobioncloudwallet")]
        public decimal GobiOnCloudWallet { get; set; }
        [JsonPropertyName("gobionmetamask")]
        public decimal GobiOnMetamask { get; set; }
        [JsonPropertyName("withdrawalmin")]
        public decimal WithdrawalMin { get; set; }
        [JsonPropertyName("maxfeepercent")]
        public int MaxFeePercent { get; set; }
        [JsonPropertyName("withdrawallimit")]
        public decimal WithdrawalLimit { get; set; }
        [JsonPropertyName("canwithdrawal")]
        public bool CanWithdrawal { get; set; }

    }
}
