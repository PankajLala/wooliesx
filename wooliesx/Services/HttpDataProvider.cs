using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using wooliesx.Models;

namespace wooliesx.Services
{
    public class HttpDataProvider:IDataProvider
    {
        private readonly HttpClient _httpClient;

        public HttpDataProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<Product>> GetProducts()
        {
            var result =  await GetAsync<IEnumerable<Product>>(
                "api/resource/products?token=86856790-32bc-419f-a301-7956a7b5dc15");

            return result.Content;
        }

        public async Task<IEnumerable<Shopping>> GetShoppingHistory()
        {
            var result = await GetAsync<IEnumerable<Shopping>>(
                "api/resource/shopperHistory?token=86856790-32bc-419f-a301-7956a7b5dc15");

            return result.Content;
        }

        private async Task<HttpCallResult<TResponse>> GetAsync<TResponse>(string requestUri) where TResponse : class
        {
            var httpResponse = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
            return await GetResultFromHttpResponse<TResponse>(httpResponse);
        }

        private async Task<HttpCallResult<TResponse>> GetResultFromHttpResponse<TResponse>(
            HttpResponseMessage httpResponse)
            where TResponse : class
        {
            if (!httpResponse.IsSuccessStatusCode)
            {
                var httpResponseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                return HttpCallResultBuilder<TResponse>.New()
                    .WithHttpResponseStatusCode(httpResponse.StatusCode)
                    .WithSuccessIndicator(false)
                    .WithErrorResponseMessage(httpResponseContent)
                    .WithResponse(default)
                    .Build();
            }

            try
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var result =
                    await JsonSerializer.DeserializeAsync<TResponse>(await httpResponse.Content.ReadAsStreamAsync(),options);

                return HttpCallResultBuilder<TResponse>.New()
                    .WithHttpResponseStatusCode(httpResponse.StatusCode)
                    .WithSuccessIndicator(true)
                    .WithResponse(result)
                    .Build();
            }
            catch (Exception ex)
            {
                var httpResponseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                return HttpCallResultBuilder<TResponse>.New()
                    .WithHttpResponseStatusCode(httpResponse.StatusCode)
                    .WithSuccessIndicator(false)
                    .WithErrorResponseMessage(httpResponseContent)
                    .WithResponse(default)
                    .WithException(ex)
                    .Build();
            }
        }
    }
}
