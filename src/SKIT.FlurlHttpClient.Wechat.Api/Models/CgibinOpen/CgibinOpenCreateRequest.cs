namespace SKIT.FlurlHttpClient.Wechat.Api.Models
{
    /// <summary>
    /// <para>表示 [POST] /cgi-bin/open/create 接口的请求。</para>
    /// </summary>
    public class CgibinOpenCreateRequest : WechatApiRequest, IInferable<CgibinOpenCreateRequest, CgibinOpenCreateResponse>
    {
        /// <summary>
        /// 获取或设置授权方 AppId。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("appid")]
        [System.Text.Json.Serialization.JsonPropertyName("appid")]
        public string AuthorizerAppId { get; set; } = string.Empty;
    }
}
