using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Setup
{
 public class pageBys
    {
        //public By elementLocator(string filename) { return By.XPath($"//a[text()='{filename}']/ancestor::li"); }
    }


        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Close();
        //}

        /*
        //public class Config
        //{
        //}
        public void Config()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "appsettings.json");
            string path = files.First();
            //return Config;
        }

        private static string baseUrl;
        public static string BaseUrl
        { 
            get
            { 
                if(baseUrl == null)
                {
                    baseUrl = Config["url"];
                }
                
                return baseUrl;
            }
            
        }
        public void GoToHomePage(IWebDriver driver)
        {

            driver.Navigate().GoToUrl(baseUrl);
        }
        */

    }
