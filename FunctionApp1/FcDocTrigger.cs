using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    [StorageAccount("AzureWebJobsStorage")]
    public class FcDocTrigger
    {
        [FunctionName("Function1")]
        [return: Queue("queueprocess")]

        public string Run([BlobTrigger("tobeprocess/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob,
        string name,
        ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            var currentDoc = ProcessDocument(myBlob, name);

            //testar sem o proxy em casa o recebimento na queueprocess
            return JsonSerializer.Serialize(currentDoc);
        }

        private static DocFile ProcessDocument(Stream blob, string name)
        {
            XmlDocument document = new XmlDocument();

            using (Stream stream = blob)
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    if(stream.Position > 0)
                    {
                        stream.Position = 0;
                    }
                    document.Load(stream);
                }
            }

            var cpfFromXml = document.SelectSingleNode("xml/nota_fiscal/cpf").InnerText;

            var nomeFromXml = document.SelectSingleNode("xml/nota_fiscal/nome").InnerText;


            var doc = new DocFile()
            {
                FileName = name,
                FileSize = blob.Length,
                PersonCpf = cpfFromXml,
                PersonName = nomeFromXml,
                DataProcess = DateTime.UtcNow
            };

            return doc;
        }
    }
}
