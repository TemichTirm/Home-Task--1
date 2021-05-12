using Newtonsoft.Json;
using NLog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Home_Task__1
{
    static class HttpHandler
    {
        private static readonly string _requestUri = "https://jsonplaceholder.typicode.com/posts";
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private static readonly HttpClient _httpClient = new HttpClient();
       
        /// <summary>
        /// Возвращает пост по Id, взятый с сайта https://jsonplaceholder 
        /// </summary>
        /// <param name="postId">Id поста</param>
        /// <returns>Jбъект класса Posts</returns>
        public static async Task<Post> GetPostAsync(int postId)
        {
            try
            {                
                var response = await _httpClient.GetAsync($"{_requestUri}/{postId}");
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Post>(content);
            }
            catch (HttpRequestException e)
            {
                _logger.Error($"Error while HttpRequest. {e.InnerException}");
                return null;
            }
            catch (Exception e)
            {
                _logger.Error($"Some problem occured. {e.InnerException}");
                return null;
            }
        }
    }
}
