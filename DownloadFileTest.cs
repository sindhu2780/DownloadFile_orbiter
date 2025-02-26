using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;

//using Setup;

namespace DownloadFile_orbiter
{
    public class DownloadTest : DownloadFile
    {

        [Test]
        [Description("Verify the application have file for download and download the avaiable files from the UI") ]
        public void DownloadFileTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://orbiter-for-testing.azurewebsites.net/products/testApp?isInternal=true");
            driver.Manage().Window.Maximize();

            var pagemenu = driver.FindElement(By.XPath("//main//h1[@class='text-center']")).Text;
            Assert.AreEqual("Download TestApp", pagemenu, "Page is loaded properly");

            List<IWebElement> FileLst = driver.FindElements(By.XPath("//div//ul[@class='list-group list-group-flush']/li")).ToList();
            int FiledownloadCount = FileLst.Count;
            Assert.True(FiledownloadCount > 0, "File is avaiable for download", FiledownloadCount);
            Thread.Sleep(1000);
            TestContext.WriteLine($"Files are avaiable for download - {FiledownloadCount} ");


            List<IWebElement> fileList = driver.FindElements(By.XPath("//ul[@class='list-group list-group-flush']/li[@class='list-group-item']/a[contains(@href,'https:')]")).ToList();
            //Thread.Sleep(1000);
            foreach (IWebElement file in fileList)
            {
                string fileName = file.Text.Trim();
                Thread.Sleep(5000);
                ClickAndWaitForDownload(file, fileName);
                string downloadedFilePath = Path.Combine(downloadDirectory, fileName);
                Assert.IsTrue(File.Exists(downloadedFilePath), "File was downloaded successfully!");
                TestContext.WriteLine($"File was downloaded successfully - {downloadedFilePath} ");
            }

            driver.Quit();



        }
   
    }
}