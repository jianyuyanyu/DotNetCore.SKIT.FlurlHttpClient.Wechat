namespace SKIT.FlurlHttpClient.Wechat.TenpayV3.Models
{
    /// <summary>
    /// <para>表示 [GET] /fund-app/mch-transfer/transfer-bills/out-bill-no/{out_bill_no} 接口的请求。</para>
    /// </summary>
    public class GetFundAppMerchantTransferBillByOutBillNumberRequest : WechatTenpayRequest
    {
        /// <summary>
        /// 获取或设置商户单号。
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string OutBillNumber { get; set; } = string.Empty;
    }
}
