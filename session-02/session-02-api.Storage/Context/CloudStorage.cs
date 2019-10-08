using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Storage.Blob;
using session_02_api.Storage.Model;

namespace session_02_api.Storage.Context
{
    public class CloudStorage
    {
        public string StorageConnectionString { get; }
        private CloudStorageConnection CloudStorageConnection { get; }
        public CloudStorage(string connectionString)
        {
            StorageConnectionString = connectionString;
            CloudStorageConnection = new CloudStorageConnection(StorageConnectionString);
        }

        public IEnumerable<StorageItem> GetContainerItems(string containerName)
        {
            var result = new List<StorageItem>();
            var cloudBlobContainer = CloudStorageConnection.GetContainer(containerName);
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                BlobResultSegment results = cloudBlobContainer.ListBlobsSegmented(null, blobContinuationToken);
                blobContinuationToken = results.ContinuationToken;

                result = results.Results.Select(x => x.ToStorageItem()).ToList();

            } while (blobContinuationToken != null);
            return result;
        }
    }
}
