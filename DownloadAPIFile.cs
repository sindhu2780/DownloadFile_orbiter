using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadFile_orbiter
{
    class DownloadAPIFile
    {


        public static bool DownloadFile(string fileurl, string endpoint, string savepath)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(fileurl, Method.Get);
                var response = client.Execute(request);

                if (response.IsSuccessful && response.RawBytes != null)
                {
                    File.WriteAllBytes(savepath, response.RawBytes);
                    return true;
                }
                else
                {
                    Console.WriteLine($"Failed to download status API {response.StatusCode}");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading file {ex.Message}");
                return false;
            }
        }
        public FileInfoResponse GetFileInfoFromAPI(string apiUrl)
        {
            try
            {
                var client = new RestClient();
                var request = new RestRequest(apiUrl, Method.Get);
                var response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    // Parse the JSON response into a list of FileInfo objects
                    // Use Newtonsoft.Json to deserialize the response
                    var fileInfo = JsonConvert.DeserializeObject<FileInfoResponse>(response.Content);
                    return fileInfo;
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve file info. Status code: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving file info: {ex.Message}");
                return null;
            }
        }
        public class FileInfoResponse
        {
            public ProductBuild productBuild { get; set; }
            public ReleaseNote releaseNote { get; set; }
            public Prerequisite[] prerequisiteList { get; set; }
        }
        public class ProductBuild
        {
            public string filename { get; set; }
            public string downloadLink { get; set; }
            public string description { get; set; }
        }

        public class ReleaseNote
        {
            public string filename { get; set; }
            public string downloadLink { get; set; }
            public string description { get; set; }
        }

        public class Prerequisite
        {
            public string filename { get; set; }
            public string downloadLink { get; set; }
            public string description { get; set; }
        }

    }
}

