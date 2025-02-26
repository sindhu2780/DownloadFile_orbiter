using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using OpenQA.Selenium;

namespace DownloadFile_orbiter
{
    class DownloadFileAPITest : DownloadAPIFile
    {
        [Test]
        [Description("Verify the Json have file for download from API and download the files")]
        public void DownloadAPIFileTest()

        {
            string fileurl = "https://orbiter-for-testing.azurewebsites.net/api/products/testApp?isInternal=true";
            string endpoint = "/products/testApp?isInternal=true";
           
            FileInfoResponse fileInfo = GetFileInfoFromAPI(fileurl);

            var downloadLinks = new[]
            {
            fileInfo.productBuild.downloadLink,
            fileInfo.releaseNote.downloadLink
            };
           
            foreach (var file in downloadLinks)
            {
                // Construct the save path for each file
                string filename = Path.GetFileName(file);
                string savepath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\" + filename;

                try
                {
                    bool downloadsucess = DownloadFile(fileurl, endpoint, savepath);
                    if (downloadsucess)
                    {
                        Console.WriteLine($"File download sucessfully {savepath}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error download file {ex.Message}");
                }
            }
        }
    }
}



