using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IceCreamShopWebView
{
    public static class APIClient
    {
        private static HttpClient client = new HttpClient();

        public static void Connect()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T GetRequest<T>(string requestUrl)
        {
            var response = client.GetAsync("http://localhost:49927/" + requestUrl);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadAsAsync<T>().Result;
            }
            throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
        }

        public static U PostRequest<T, U>(string requestUrl, T model)
        {
            var response = client.PostAsJsonAsync("http://localhost:49927/" + requestUrl, model);
            if (response.Result.IsSuccessStatusCode)
            {
                if (typeof(U) == typeof(bool))
                {
                    return default(U);
                }
                return response.Result.Content.ReadAsAsync<U>().Result;
            }
            throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
        }
    }
}