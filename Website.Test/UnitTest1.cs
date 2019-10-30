using System;
using System.IO;
using BloobStorage.ServiceExternos;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Website.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Connect_To_CloudStorageAccount()
        {
            var pasta = Environment.SpecialFolder.MyDocuments;

            string localPath = Environment.GetFolderPath(pasta);

            string localFilename = "images.jpg";

            string sourceFile = Path.Combine(localPath, localFilename);

            var reader = File.OpenRead(sourceFile);

            ServidorDeArquivos servidorDeArquivos = new ServidorDeArquivos();

            servidorDeArquivos.uploadDeArquivo(reader, localFilename);

        }
    }
}
