using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace SKIT.FlurlHttpClient.Wechat.Api
{
    public static class WechatApiClientExecuteWxaGameExtensions
    {
        #region ContentSpam
        /// <summary>
        /// <para>异步调用 [POST] /wxa/game/content_spam/msg_sec_check 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/wxa-sec-check/gamesecurity.msgSecCheck.html ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.WxaGameContentSpamMessageSecurityCheckResponse> ExecuteWxaGameContentSpamMessageSecurityCheckAsync(this WechatApiClient client, Models.WxaGameContentSpamMessageSecurityCheckRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "wxa", "game", "content_spam", "msg_sec_check")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.WxaGameContentSpamMessageSecurityCheckResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /wxa/game/content_spam/media_check_sync 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developers.weixin.qq.com/minigame/dev/api-backend/open-api/wxa-sec-check/gamesecurity.mediaCheck.html ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.WxaGameContentSpamMediaCheckSyncResponse> ExecuteWxaGameContentSpamMediaCheckSyncAsync(this WechatApiClient client, Models.WxaGameContentSpamMediaCheckSyncRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "wxa", "game", "content_spam", "media_check_sync")
                .SetQueryParam("access_token", request.AccessToken);

            return await client.SendFlurlRequestAsJsonAsync<Models.WxaGameContentSpamMediaCheckSyncResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion

        #region Payment
        private static T PreprocessRequest<T>(WechatApiClient client, ref T request)
            where T : Models.WxaGamePaymentRequestBase, new()
        {
            if (client is null) throw new ArgumentNullException(nameof(request));
            if (request is null) throw new ArgumentNullException(nameof(request));

            string? tmpRawData = null; // 用于缓存待签名数据中的请求正文部分，避免序列化多次浪费性能

            if (request.OfferId is null)
            {
                request.OfferId = client.Credentials.MidasOfferIdV2;
            }

            if (request.Timestamp is null)
            {
                request.Timestamp = DateTimeOffset.Now.ToLocalTime().ToUnixTimeSeconds();
            }

            if (request.SignMethod is null)
            {
                request.SignMethod = Constants.MidasSignMethods.HMAC_SHA256;
            }

            if (request.Signature is null && request.SessionKey is not null)
            {
                tmpRawData = tmpRawData ?? client.JsonSerializer.Serialize(request);

                switch (request.SignMethod)
                {
                    case Constants.MidasSignMethods.HMAC_SHA256:
                        {
                            string msgText = tmpRawData;
                            request.Signature = Utilities.HMACUtility.HashWithSHA256(request.SessionKey, msgText).Value!.ToLower();
                        }
                        break;

                    default:
                        {
                            request.Signature = string.Empty;
                        }
                        break;
                }
            }

            if (request.PaySign is null)
            {
                tmpRawData = tmpRawData ?? client.JsonSerializer.Serialize(request);

                string msgText = $"{request.GetRequestPath()}&{tmpRawData}";
                request.PaySign = Utilities.HMACUtility.HashWithSHA256(client.Credentials.MidasAppKeyV2 ?? string.Empty, msgText).Value!.ToLower();
            }

            return request;
        }

        /// <summary>
        /// <para>异步调用 [POST] /wxa/game/getbalance 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://docs.qq.com/doc/DVUN0QWJja0J5c2x4 ]]> <br/>
        /// <![CDATA[ https://developers.weixin.qq.com/minigame/dev/api-backend/midas-payment-v2/pay_v2.getBalance.html ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.WxaGameGetBalanceResponse> ExecuteWxaGameGetBalanceAsync(this WechatApiClient client, Models.WxaGameGetBalanceRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            PreprocessRequest(client, ref request);

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "wxa", "game", "getbalance")
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("sig_method", request.SignMethod)
                .SetQueryParam("signature", request.Signature)
                .SetQueryParam("pay_sig", request.PaySign);

            return await client.SendFlurlRequestAsJsonAsync<Models.WxaGameGetBalanceResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /wxa/game/pay 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://docs.qq.com/doc/DVUN0QWJja0J5c2x4 ]]> <br/>
        /// <![CDATA[ https://developers.weixin.qq.com/minigame/dev/api-backend/midas-payment-v2/pay_v2.pay.html ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.WxaGamePayResponse> ExecuteWxaGamePayAsync(this WechatApiClient client, Models.WxaGamePayRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            PreprocessRequest(client, ref request);

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "wxa", "game", "pay")
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("sig_method", request.SignMethod)
                .SetQueryParam("signature", request.Signature)
                .SetQueryParam("pay_sig", request.PaySign);

            return await client.SendFlurlRequestAsJsonAsync<Models.WxaGamePayResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /wxa/game/cancelpay 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://docs.qq.com/doc/DVUN0QWJja0J5c2x4 ]]> <br/>
        /// <![CDATA[ https://developers.weixin.qq.com/minigame/dev/api-backend/midas-payment-v2/pay_v2.cancelPay.html ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.WxaGameCancelPayResponse> ExecuteWxaGameCancelPayAsync(this WechatApiClient client, Models.WxaGameCancelPayRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            PreprocessRequest(client, ref request);

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "wxa", "game", "cancelpay")
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("sig_method", request.SignMethod)
                .SetQueryParam("signature", request.Signature)
                .SetQueryParam("pay_sig", request.PaySign);

            return await client.SendFlurlRequestAsJsonAsync<Models.WxaGameCancelPayResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /wxa/game/present 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://docs.qq.com/doc/DVUN0QWJja0J5c2x4 ]]> <br/>
        /// <![CDATA[ https://developers.weixin.qq.com/minigame/dev/api-backend/midas-payment-v2/pay_v2.present.html ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.WxaGamePresentResponse> ExecuteWxaGamePresentAsync(this WechatApiClient client, Models.WxaGamePresentRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            PreprocessRequest(client, ref request);

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "wxa", "game", "present")
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("sig_method", request.SignMethod)
                .SetQueryParam("signature", request.Signature)
                .SetQueryParam("pay_sig", request.PaySign);

            return await client.SendFlurlRequestAsJsonAsync<Models.WxaGamePresentResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /wxa/game/queryorderinfo 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://developers.weixin.qq.com/minigame/dev/api-backend/midas-payment-v2/pay_v2.queryOrder.html ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.WxaGameQueryOrderInfoResponse> ExecuteWxaGameQueryOrderInfoAsync(this WechatApiClient client, Models.WxaGameQueryOrderInfoRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            PreprocessRequest(client, ref request);

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "wxa", "game", "queryorderinfo")
                .SetQueryParam("access_token", request.AccessToken)
                .SetQueryParam("sig_method", request.SignMethod)
                .SetQueryParam("signature", request.Signature)
                .SetQueryParam("pay_sig", request.PaySign);

            return await client.SendFlurlRequestAsJsonAsync<Models.WxaGameQueryOrderInfoResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        #endregion
    }
}
