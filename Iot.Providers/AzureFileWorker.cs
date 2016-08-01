using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Iot.Interfaces;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Iot.Providers
{
    /// <summary>
    /// Class AzureFileWorker for working with files
    /// </summary>
    public class AzureFileWorker : IFileWorker
    {
        /// <summary>
        /// Gets or sets the account key.
        /// </summary>
        /// <value>The account key.</value>
        public string AccountKey { get; set; }
        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        public string AccountName { get; set; }
        /// <summary>
        /// Gets or sets the name of the container.
        /// </summary>
        /// <value>The name of the container.</value>
        public string ContainerName { get; set; }
        
        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <value>The account.</value>
        private CloudStorageAccount Account
        {
            get
            {
                string connString = $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={AccountKey}";
                return CloudStorageAccount.Parse(connString);
            }
        }

        /// <summary>
        /// Gets the BLOB container.
        /// </summary>
        /// <param name="containerName">Name of the container.</param>
        /// <returns>CloudBlobContainer.</returns>
        private CloudBlobContainer GetBlobContainer(string containerName)
        {
            var account = Account;

            var cloudBlobClient = account.CreateCloudBlobClient();

            var cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
            return cloudBlobContainer;
        }

        /// <summary>
        /// upload file as an asynchronous operation.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> UploadFileAsync(Stream stream, string uniqueName)
        {
            try
            {
                var cloudBlobContainer = GetBlobContainer(ContainerName);

                await cloudBlobContainer.CreateIfNotExistsAsync();

                var blockBlob = cloudBlobContainer.GetBlockBlobReference(uniqueName);

                await blockBlob.UploadFromStreamAsync(stream);

                return blockBlob.Uri.AbsoluteUri;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// delete file as an asynchronous operation.
        /// </summary>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> DeleteFileAsync(string uniqueName)
        {
            try
            {
                var cloudBlobContainer = GetBlobContainer(ContainerName);
                var blockBlob = cloudBlobContainer.GetBlockBlobReference(uniqueName);
                await blockBlob.DeleteAsync();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message + "\r\n" + err.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Gets the files asynchronous.
        /// </summary>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="includeSubDir">if set to <c>true</c> [include sub dir].</param>
        /// <returns>Task&lt;List&lt;System.String&gt;&gt;.</returns>
        public Task<List<string>> GetFilesAsync(string containerName, bool includeSubDir = false)
        {
            try
            {
                var cloudBlobContainer = GetBlobContainer(containerName);
                var blobs = cloudBlobContainer.ListBlobs(useFlatBlobListing: includeSubDir);
                var list = blobs.Select(currentBlob => currentBlob.Uri.ToString()).ToList();
                return Task.FromResult(list);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message + "\r\n" + err.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Downloads the file asynchronous.
        /// </summary>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns>Task&lt;Stream&gt;.</returns>
        public async Task<Stream> DownloadFileAsync(string uniqueName)
        {
            try
            {
                var cloudBlobContainer = GetBlobContainer(ContainerName);
                var blockBlob = cloudBlobContainer.GetBlockBlobReference(uniqueName);
                var memoryStream = new MemoryStream();
                await blockBlob.DownloadToStreamAsync(memoryStream);
                return memoryStream;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message + "\r\n" + err.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Gets the file URL.
        /// </summary>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns>System.String.</returns>
        public string GetFileUrl(string uniqueName)
        {
            var container = GetBlobContainer(ContainerName);
            var blockBlob = container.GetBlockBlobReference(uniqueName);
            return blockBlob.Uri.AbsoluteUri;
        }
    }
}