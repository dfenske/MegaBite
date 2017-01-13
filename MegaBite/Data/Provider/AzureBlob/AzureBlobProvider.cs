using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;
using System.IO;
using System.Web;

namespace MegaBite.Data.Provider.AzureBlob
{
    public class AzureBlobProvider
    {
        public AzureBlobProvider()
        {

        }

        public Uri UploadFile(CloudStorageAccount storageAccount, string containerName, HttpPostedFileBase file, string imageName)
        {
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            // Retrieve reference to a blob with imageName as 'name'.
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);

            // Create or overwrite the blob with contents from a local file.
            using (var fileStream = file.InputStream)
            {
                blockBlob.UploadFromStream(fileStream);
            }

            // Return URL that accesses this blob.
            return blockBlob.StorageUri.PrimaryUri;
        }
    }
}
