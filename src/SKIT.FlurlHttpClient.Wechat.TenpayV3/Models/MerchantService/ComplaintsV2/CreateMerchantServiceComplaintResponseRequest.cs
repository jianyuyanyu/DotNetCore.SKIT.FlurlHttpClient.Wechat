using System.Collections.Generic;

namespace SKIT.FlurlHttpClient.Wechat.TenpayV3.Models
{
    /// <summary>
    /// <para>表示 [POST] /merchant-service/complaints-v2/{complaint_id}/response 接口的请求。</para>
    /// </summary>
    public class CreateMerchantServiceComplaintResponseRequest : WechatTenpayRequest
    {
        public static class Types
        {
            public class MiniProgramJumpInfo
            {
                /// <summary>
                /// 获取或设置小程序 AppId。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("appid")]
                [System.Text.Json.Serialization.JsonPropertyName("appid")]
                public string AppId { get; set; } = string.Empty;

                /// <summary>
                /// 获取或设置小程序页面路径。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("path")]
                [System.Text.Json.Serialization.JsonPropertyName("path")]
                public string PagePath { get; set; } = string.Empty;

                /// <summary>
                /// 获取或设置小程序页面名称。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("text")]
                [System.Text.Json.Serialization.JsonPropertyName("text")]
                public string Text { get; set; } = string.Empty;
            }
        }

        /// <summary>
        /// 获取或设置投诉单号。
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string ComplaintId { get; set; } = string.Empty;

        /// <summary>
        /// 获取或设置被诉商户号。如果不指定将使用构造 <see cref="WechatTenpayClient"/> 时的 <see cref="WechatTenpayClientOptions.MerchantId"/> 参数。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("complainted_mchid")]
        [System.Text.Json.Serialization.JsonPropertyName("complainted_mchid")]
        public string? ComplaintedMerchantId { get; set; }

        /// <summary>
        /// 获取或设置回复内容。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("response_content")]
        [System.Text.Json.Serialization.JsonPropertyName("response_content")]
        public string ResponseContent { get; set; } = string.Empty;

        /// <summary>
        /// 获取或设置回复图片 MediaId 列表。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("response_images")]
        [System.Text.Json.Serialization.JsonPropertyName("response_images")]
        public IList<string>? ResponseMediaIdList { get; set; }

        /// <summary>
        /// 获取或设置跳转链接。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("jump_url")]
        [System.Text.Json.Serialization.JsonPropertyName("jump_url")]
        public string? JumpUrl { get; set; }

        /// <summary>
        /// 获取或设置跳转链接文案。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("jump_url_text")]
        [System.Text.Json.Serialization.JsonPropertyName("jump_url_text")]
        public string? JumpUrlText { get; set; }

        /// <summary>
        /// 获取或设置小程序跳转信息。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("mini_program_jump_info")]
        [System.Text.Json.Serialization.JsonPropertyName("mini_program_jump_info")]
        public Types.MiniProgramJumpInfo? MiniProgramJumpInfo { get; set; }
    }
}
