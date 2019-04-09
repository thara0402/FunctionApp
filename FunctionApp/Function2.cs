using System;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public static class Function2
    {
        [FunctionName(nameof(Function2))]
        public static void Run([QueueTrigger("myqueue-items", Connection = "QueueConnection")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            log.LogInformation($"QueueConnection: {Environment.GetEnvironmentVariable("QueueConnection", EnvironmentVariableTarget.Process)}");

            using (var context = new ShopContext())
            {
                var item = context.Products.FirstOrDefault();
                log.LogInformation($"Product Name: {item.Name}");
            }

        }
    }
}
