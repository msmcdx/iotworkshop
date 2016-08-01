using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Iot.Interfaces
{
    /// <summary>
    /// Interface IFileWorker
    /// </summary>
    public interface IFileWorker
    {
        /// <summary>
        /// Uploads the file asynchronous.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns><see cref="Task"/>&lt;System.String&gt;.</returns>
        Task<string> UploadFileAsync(Stream stream, string uniqueName);
        /// <summary>
        /// Deletes the file asynchronous.
        /// </summary>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns><see cref="Task"/>&lt;System.Boolean&gt;.</returns>
        Task<bool> DeleteFileAsync(string uniqueName);

        /// <summary>
        /// Gets the files asynchronous.
        /// </summary>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="includeSubDir">if set to <c>true</c> [include sub dir].</param>
        /// <returns><see cref="Task"/>&lt;List&lt;System.String&gt;&gt;.</returns>
        Task<List<string>> GetFilesAsync(string containerName, bool includeSubDir);
        /// <summary>
        /// Downloads the file asynchronous.
        /// </summary>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns><see cref="Task"/>&lt;Stream&gt;.</returns>
        Task<Stream> DownloadFileAsync(string uniqueName);

        /// <summary>
        /// Gets the file URL.
        /// </summary>
        /// <param name="uniqueName">Name of the unique.</param>
        /// <returns>file url or empty string otherwise</returns>
        string GetFileUrl(string uniqueName);

        /// <summary>
        /// Gets or sets the account key.
        /// </summary>
        /// <value>The account key.</value>
        string AccountKey { get; set; }
        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        string AccountName { get; set; }
        /// <summary>
        /// Gets or sets the name of the container.
        /// </summary>
        /// <value>The name of the container.</value>
        string ContainerName { get; set; }
    }
}