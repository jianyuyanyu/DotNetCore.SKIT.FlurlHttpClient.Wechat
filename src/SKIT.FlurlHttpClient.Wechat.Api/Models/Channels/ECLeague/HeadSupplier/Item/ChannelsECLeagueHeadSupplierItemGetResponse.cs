using System;

namespace SKIT.FlurlHttpClient.Wechat.Api.Models
{
    /// <summary>
    /// <para>表示 [POST] /channels/ec/league/headsupplier/item/get 接口的响应。</para>
    /// </summary>
    public class ChannelsECLeagueHeadSupplierItemGetResponse : WechatApiResponse
    {
        public static class Types
        {
            public class Product
            {
                public static class Types
                {
                    public class ProductInfo : ChannelsECLeagueHeadSupplierWindowGetDetailResponse.Types.Product.Types.ProductInfo
                    {
                        public static new class Types
                        {
                            public class Detail : ChannelsECLeagueHeadSupplierWindowGetDetailResponse.Types.Product.Types.ProductInfo.Types.Detail
                            {
                            }

                            public class Category : ChannelsECLeagueHeadSupplierWindowGetDetailResponse.Types.Product.Types.ProductInfo.Types.Category
                            {
                            }
                        }

                        /// <summary>
                        /// 获取或设置商品详情信息。
                        /// </summary>
                        [Newtonsoft.Json.JsonProperty("desc_info")]
                        [System.Text.Json.Serialization.JsonPropertyName("desc_info")]
                        public new Types.Detail Detail { get; set; } = default!;

                        /// <summary>
                        /// 获取或设置商品类目列表。
                        /// </summary>
                        [Obsolete("相关接口或字段于 2024-10-28 下线。")]
                        [Newtonsoft.Json.JsonProperty("cats")]
                        [System.Text.Json.Serialization.JsonPropertyName("cats")]
                        public new Types.Category[]? CategoryList { get; set; }

                        /// <summary>
                        /// 获取或设置新版商品类目列表。
                        /// </summary>
                        [Newtonsoft.Json.JsonProperty("cats_v2")]
                        [System.Text.Json.Serialization.JsonPropertyName("cats_v2")]
                        public new Types.Category[]? CategoryV2List { get; set; }
                    }
                }

                /// <summary>
                /// 获取或设置小店 AppId。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("appid")]
                [System.Text.Json.Serialization.JsonPropertyName("appid")]
                public string AppId { get; set; } = default!;

                /// <summary>
                /// 获取或设置商品 ID。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("product_id")]
                [System.Text.Json.Serialization.JsonPropertyName("product_id")]
                [System.Text.Json.Serialization.JsonNumberHandling(System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString)]
                public long ProductId { get; set; }

                /// <summary>
                /// 获取或设置商品信息。
                /// </summary>
                [Newtonsoft.Json.JsonProperty("product_info")]
                [System.Text.Json.Serialization.JsonPropertyName("product_info")]
                public Types.ProductInfo ProductInfo { get; set; } = default!;
            }
        }

        /// <summary>
        /// 获取或设置商品信息。
        /// </summary>
        [Newtonsoft.Json.JsonProperty("item")]
        [System.Text.Json.Serialization.JsonPropertyName("item")]
        public Types.Product Product { get; set; } = default!;
    }
}
