using Microsoft.Azure.Storage.Blob;
using session_02_api.Storage.Model;

namespace session_02_api.Storage
{
    public static class CloudStorageItemExtensions
    {
        public static StorageItem ToStorageItem(this IListBlobItem listBlobItem)
        {
            var castedItem = (CloudBlockBlob)listBlobItem;
            return new StorageItem
            {
                Name = castedItem.Name,
                Uri = castedItem.Uri.AbsoluteUri
            };
        }
    }
}
