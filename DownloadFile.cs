using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadFile_orbiter
{
   
    public class DownloadFile
    {
        private IWebDriver driver;
        
        public string downloadDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";

        public void WaitForFileDownload(string expectedFileName)
        {
           
            string filePath = Path.Combine(downloadDirectory, expectedFileName);
            int waitTimeInSeconds = 30;  // Wait time in seconds
            DateTime timeout = DateTime.Now.AddSeconds(waitTimeInSeconds);

            while (DateTime.Now < timeout)
            {
                if (File.Exists(filePath))
                {
                    Thread.Sleep(3000);
                    // Check if the file is still being written to (open for download)
                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 0)
                    {
                        Console.WriteLine($"File '{expectedFileName}' downloaded successfully.");
                        return;

                    }
                }
                Thread.Sleep(1000);
            }

            Assert.Fail($"Download of file '{expectedFileName}' did not complete {waitTimeInSeconds} in seconds.");

        }

        public void ClickAndWaitForDownload(IWebElement lists, string expectedFileName)
        {
            Thread.Sleep(5000);
            lists.Click();
            WaitForFileDownload(expectedFileName);
        }
       
    }
}
