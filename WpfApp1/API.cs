using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    internal static class API
    {
        static HttpClient HttpClient = new HttpClient();
        static string baseUrl = "http://localhost:5240/api/";
        private static JsonSerializerOptions? options = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve };

        public static async Task<T> Get<T>(string controller, int arg = 0) where T : class
        {
            if (arg != 0)
                controller += "/" + arg;
            var answer = await HttpClient.GetAsync(baseUrl + controller);
            string result = await answer.Content.ReadAsStringAsync();
            if (answer.StatusCode == System.Net.HttpStatusCode.OK)
            {
                try
                {
                    return JsonSerializer.Deserialize<T>(result, options);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                MessageBox.Show(result);
                return null;
            }
        }

    }
}
