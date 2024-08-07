using System;

namespace SKIT.FlurlHttpClient.Wechat.Api.Models
{
    /// <summary>
    /// <para>表示 [POST] /channels/ec/vip/user/info/get 接口的响应。</para>
    /// </summary>
    [Obsolete("相关接口或字段于 2024-07-22 下线。")]
    public class ChannelsECVipUserInfoGetResponse : WechatApiResponse
    {
        public static class Types
        {
            public class VipInfo : ChannelsECVipUserListGetResponse.Types.VipInfo
            {
            }
        }

        /// <summary>
        /// 获取或设置会员信息。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("info")]
        [System.Text.Json.Serialization.JsonPropertyName("info")]
        public Types.VipInfo VipInfo { get; set; } = default!;
    }
}
