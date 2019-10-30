using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BloobStorage.ServiceExternos
{
    public class ServidorDeArquivos
    {
        public void uploadDeArquivo(Stream reader, string arquivo)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=marcioarmazenamento;AccountKey=NPsCesFBMnnoD4OTLOFoOG7y4QE8zCq4dvqVV4oD0XLz8K2cdK16Iu5pUN1fndnLAkECf/h/+Z/rVL9kSxF+CA==;EndpointSuffix=core.windows.net";

            CloudStorageAccount cloudStorageAccount = null;

            CloudStorageAccount.TryParse(connectionString, out cloudStorageAccount);

            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            var container = cloudBlobClient.GetContainerReference("api-amigo-fotos");

            container.CreateIfNotExists();

            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(arquivo);

            cloudBlockBlob.UploadFromStream(reader);
        }
    }
}