using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace SKIT.FlurlHttpClient.Wechat.TenpayV3
{
    public static class WechatTenpayClientExecuteFundsToOverseaExtensions
    {
        /// <summary>
        /// <para>异步调用 [GET] /funds-to-oversea/transactions/{transaction_id}/available_abroad_amounts 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://pay.weixin.qq.com/doc/v3/partner/4012476109 ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.GetFundsToOverseaTransactionAvailableAbroadAmountByTransactionIdResponse> ExecuteGetFundsToOverseaTransactionAvailableAbroadAmountByTransactionIdAsync(this WechatTenpayClient client, Models.GetFundsToOverseaTransactionAvailableAbroadAmountByTransactionIdRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "funds-to-oversea", "transactions", request.TransactionId, "available_abroad_amounts")
                .SetQueryParam("sub_mchid", request.SubMerchantId);

            return await client.SendFlurlRequestAsJsonAsync<Models.GetFundsToOverseaTransactionAvailableAbroadAmountByTransactionIdResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /funds-to-oversea/orders 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://pay.weixin.qq.com/doc/v3/partner/4012476113 ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.CreateFundsToOverseaOrderResponse> ExecuteCreateFundsToOverseaOrderAsync(this WechatTenpayClient client, Models.CreateFundsToOverseaOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "funds-to-oversea", "orders");

            return await client.SendFlurlRequestAsJsonAsync<Models.CreateFundsToOverseaOrderResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /funds-to-oversea/orders/{out_order_id} 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://pay.weixin.qq.com/doc/v3/partner/4012476127 ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.GetFundsToOverseaOrderByOutOrderIdResponse> ExecuteGetFundsToOverseaOrderByOutOrderIdAsync(this WechatTenpayClient client, Models.GetFundsToOverseaOrderByOutOrderIdRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "funds-to-oversea", "orders", request.OutOrderId)
                .SetQueryParam("sub_mchid", request.SubMerchantId)
                .SetQueryParam("transaction_id", request.TransactionId);

            return await client.SendFlurlRequestAsJsonAsync<Models.GetFundsToOverseaOrderByOutOrderIdResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /funds-to-oversea/bill-download-url 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://pay.weixin.qq.com/doc/v3/partner/4012476132 ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.GetFundsToOverseaBillDownloadUrlResponse> ExecuteGetFundsToOverseaBillDownloadUrlAsync(this WechatTenpayClient client, Models.GetFundsToOverseaBillDownloadUrlRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "funds-to-oversea", "bill-download-url")
                .SetQueryParam("sub_mchid", request.SubMerchantId)
                .SetQueryParam("bill_date", request.BillDateString);

            return await client.SendFlurlRequestAsJsonAsync<Models.GetFundsToOverseaBillDownloadUrlResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [POST] /funds-to-oversea/return/return-orders 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://pay.weixin.qq.com/doc/v3/partner/4013735039 ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.CreateFundsToOverseaReturnOrderResponse> ExecuteCreateFundsToOverseaReturnOrderAsync(this WechatTenpayClient client, Models.CreateFundsToOverseaReturnOrderRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Post, "funds-to-oversea", "return", "return-orders");

            return await client.SendFlurlRequestAsJsonAsync<Models.CreateFundsToOverseaReturnOrderResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// <para>异步调用 [GET] /funds-to-oversea/return/return-orders/out-return-no/{out_return_no} 接口。</para>
        /// <para>
        /// REF: <br/>
        /// <![CDATA[ https://pay.weixin.qq.com/doc/v3/partner/4013735052 ]]>
        /// </para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Models.GetFundsToOverseaReturnOrderByOutReturnNumberResponse> ExecuteGetFundsToOverseaReturnOrderByOutReturnNumberAsync(this WechatTenpayClient client, Models.GetFundsToOverseaReturnOrderByOutReturnNumberRequest request, CancellationToken cancellationToken = default)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            if (request is null) throw new ArgumentNullException(nameof(request));

            IFlurlRequest flurlReq = client
                .CreateFlurlRequest(request, HttpMethod.Get, "funds-to-oversea", "return", "return-orders", "out-return-no", request.OutReturnNumber)
                .SetQueryParam("sub_mchid", request.SubMerchantId);

            return await client.SendFlurlRequestAsJsonAsync<Models.GetFundsToOverseaReturnOrderByOutReturnNumberResponse>(flurlReq, data: request, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

    }
}
