using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Home_Task__1
{
    class Posts
    {
        private static readonly string _requestUri = "https://jsonplaceholder.typicode.com/posts/";
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
       
        /// <summary>
        /// Возвращает список постов из заданного диапазона, взятых с сайта https://jsonplaceholder 
        /// </summary>
        /// <param name="startId">Начальный Id поста</param>
        /// <param name="endId">Конечный Id поста</param>
        /// <returns>Список постов в виде объектов класса Posts</returns>
        public static async Task<List<Posts>> GetPosts(int startId, int endId)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(_requestUri);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Posts>>(content)
                                  .Where(id => (id.Id >= startId && id.Id <= endId)).ToList();                
            }
            catch (HttpRequestException e)
            {
                _logger.Error($"Error while Httprequest. {e.InnerException}");
                return new List<Posts>();
            }
        }
    }
}
