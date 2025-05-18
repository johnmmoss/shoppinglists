using System.Text.Json;
using Azure.Storage.Blobs;

namespace ShoppingLists.Data;

public class AzureBlobFileRepository<T>(BlobServiceClient blobServiceClient, string containerName, string fileName)
{
    private List<T> GetCurrentItems()
    {
        try
        {
            var blobClient = GetBlobClient(containerName, fileName);
            if (!blobClient.Exists())
            {
                blobClient.Upload(BinaryData.FromString("[]"));
                return new List<T>(); 
            }
            var data = blobClient.DownloadContent().Value.Content;
            return data != null ? JsonSerializer.Deserialize<List<T>>(data) : new List<T>();
        }
        catch (Exception e)
        {
            //_logger.LogError(e, "There was a problem getting the current items.");
            throw;
        }
    }

    private BlobClient GetBlobClient(string containerName, string fileName)
    {
        return blobServiceClient.GetBlobContainerClient(containerName).GetBlobClient(fileName);
    }
}