using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Home_Task__1
{
    static class FileHandler
    {
        private static readonly string _fileName = "result.txt";
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Записывает в текстовый файл result.txt посты из переданного списка
        /// </summary>
        /// <param name="posts">Список постов в виде объектов класса Posts</param>
        public static async Task WriteToFile(List<Post> posts)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_fileName, false))
                {
                    foreach (var post in posts)
                    {
                        await streamWriter.WriteLineAsync($"{post.UserId}\n{post.Id}\n{post.Title}\n{post.Body}\n");
                    }
                };
            }
            catch (NullReferenceException e)
            {
                _logger.Error($"Can't get any posts. There is no any posts in the list. {e.InnerException}");
            }
            catch (IOException e)
            {
                _logger.Error($"Can't write posts into file. {e.InnerException}");
            }
            catch (Exception e)
            {
                _logger.Error($"Some problem occured. {e.InnerException}");
            }

        }
    }
}
