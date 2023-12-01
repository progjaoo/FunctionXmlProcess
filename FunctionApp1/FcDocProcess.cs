using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class FcDocProcess
    {
        [FunctionName("FcDocProcess")]
        [return: Table("docsinfo", Connection = "AzureWebJobsStorage")]

        public async Task<DocEntity> Run([QueueTrigger("queueprocess", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue Trigger function processed: {myQueueItem}");

            var queueItem = JsonSerializer.Deserialize<DocFile>(myQueueItem);

            var blobClient = new BlobClient(
                System.Environment.GetEnvironmentVariable("AzureWebJobsStorage"),
                "tobeprocess",
                queueItem.FileName
            );

            var currentBlob = await blobClient.DownloadStreamingAsync();

            var blobContainerClient = new BlobContainerClient(
                System.Environment.GetEnvironmentVariable("AzureWebJobsStorage"),
                "processdone"
            );

            await blobContainerClient.UploadBlobAsync(queueItem.FileName, currentBlob.Value.Content);

            await blobClient.DeleteIfExistsAsync();

            return new DocEntity
            {
                PartitionKey = "nota_fiscal",
                RowKey = Guid.NewGuid().ToString(),
                PersonName = queueItem.PersonName,
                PersonCpf = queueItem.PersonCpf
            };
        }
    }
}
