using System.Threading.Tasks;
using NLog;

namespace Home_Task__1
{
    class Program
    {
        public readonly static ILogger logger = LogManager.GetCurrentClassLogger();
        static async Task Main()
        {
            int startId = 4;
            int endId = 13;

            var postsList = await Posts.GetPosts(startId, endId);
            FileHandler.WriteToFile(postsList);
        }              
    }
}
