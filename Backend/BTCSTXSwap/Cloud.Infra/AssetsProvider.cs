using Core.Domain.Cloud;
using BTCSTXSwap.Domain.Interfaces.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Infra
{
    public class AssetsProvider : IAssetsProviders
    {
        private readonly IConfiguration _configuration;
        private List<KeyValuePair<string, Bitmap>> _cache;

        public AssetsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _cache = new List<KeyValuePair<string, Bitmap>>();
        }
        public Bitmap GetBaseAssets(string baseFolder, string imgPath)
        {
            try
            {
                var path = _configuration["Assets:ContainerBaseURL"] + baseFolder + "/" + imgPath;
                if(_cache.Where(x => x.Key == path).Count() > 0)
                    return _cache.Where(x => x.Key == path).First().Value;

                var webClient = new WebClient();
                byte[] imageBytes = webClient.DownloadData(path);
                using (var ms = new MemoryStream(imageBytes))
                {
                    var bm = new Bitmap(ms);
                    _cache.Add(new KeyValuePair<string, Bitmap>(path, bm));
                    return bm;
                }
            }
            catch(Exception err)
            {
                string msg = string.Format("Error Assets: \n\t{0}\n\t{1}", baseFolder, imgPath);
                Console.WriteLine(msg);
                throw new Exception(msg, err);
            }
        }

        public async Task<string> UploadFileToBlobAsync(string strFileName, byte[] fileData, string fileMimeType)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("Azure"));
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                string strContainerName = _configuration["Assets:ContainerName"];
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
                string fileName = strFileName;

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                if (fileName != null && fileData != null)
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                    cloudBlockBlob.Properties.ContentType = fileMimeType;
                    await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);
                    return cloudBlockBlob.Uri.AbsoluteUri;
                }
                return _configuration["Assets:ContainerBaseURL"] + strFileName;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteFile(string strFileName)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("Azure"));
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                string strContainerName = _configuration["Assets:ContainerName"];
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
                string fileName = strFileName;

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                if (fileName != null)
                {
                    var blob = cloudBlobContainer.GetBlockBlobReference(fileName);
                    await blob.DeleteIfExistsAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
