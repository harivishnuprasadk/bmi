using System;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace BmiApp.Utilities
{
    public class BmiBlobUtility
    {
        public readonly IConfiguration _configuration;
        public BmiBlobUtility(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetBlobUrl(IFormFile file)
        {
            string storageConnStr = _configuration.GetConnectionString("Storage");
            BlobContainerClient blobContainerClient = new BlobContainerClient(storageConnStr, "bmidocs");
            string url = "file/test.com";
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                blobContainerClient.UploadBlob($"folder1/{file.FileName}", stream);
                BlobClient blobClient = new BlobClient(storageConnStr, "bmidocs", $"documents/{file.FileName}");
                url = blobClient.Uri.AbsoluteUri;
                Console.WriteLine("URL------is" + url);
            }
            return url;
        }
    }
}

