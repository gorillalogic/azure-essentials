using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace session_02_api.Storage.Context
{
    internal class CloudStorageConnection
    {
        public string StorageConnectionString { get; }
        internal CloudStorageConnection(string connectionString)
        {
            StorageConnectionString = connectionString;
        }

        internal CloudStorageAccount GetStorageAccount()
        {
            // Retrieve the connection string for use with the application. The storage 
            // connection string is stored in an environment variable on the machine 
            // running the application called CONNECT_STR. If the 
            // environment variable is created after the application is launched in a 
            // console or with Visual Studio, the shell or application needs to be closed
            // and reloaded to take the environment variable into account.

            // Check whether the connection string can be parsed.
            if (CloudStorageAccount.TryParse(StorageConnectionString, out CloudStorageAccount storageAccount))
            {
                // If the connection string is valid, proceed with operations against Blob
                // storage here.
                // ADD OTHER OPERATIONS HERE
            }
            else
            {
                // Otherwise, let the user know that they need to define the environment variable.
                Console.WriteLine(
                    "A connection string has not been defined in the system environment variables. " +
                    "Add an environment variable named 'CONNECT_STR' with your storage " +
                    "connection string as a value.");
                Console.WriteLine("Press any key to exit the application.");
                Console.ReadLine();
            }
            return storageAccount;
        }

        internal CloudBlobContainer GetContainer(string containerName)
        {
            // Create the CloudBlobClient that represents the 
            // Blob storage endpoint for the storage account.
            var storageAccount = GetStorageAccount();
            var cloudBlobClient = storageAccount.CreateCloudBlobClient();

            // Create a container called 'quickstartblobs' and 
            // append a GUID value to it to make the name unique.
            CloudBlobContainer cloudBlobContainer =
                cloudBlobClient.GetContainerReference(containerName);
            return cloudBlobContainer;
        }
    }
}
