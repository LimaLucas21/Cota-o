using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace Cotacao.Interacoes
{
    public class InteracaoBCB 
    {
        public string CaminhoDolar = "//*[@id=\"home\"]/div/div[1]/div[1]/div/cotacao/table[1]/tbody/tr[1]/td[2]/span";
        public string Dolar = "";
        public string CaminhoEuro = "//*[@id=\"home\"]/div/div[1]/div[1]/div/cotacao/table[2]/tbody/tr[1]/td[2]/span";
        public string Euro = "";

        string chromePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "chrome.exe");
        string driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Driver");
        public InteracaoBCB()
        {
            string BCB = "https://www.bcb.gov.br/";
            new DriverManager().SetUpDriver(new ChromeConfig());
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            service.SuppressInitialDiagnosticInformation = true;

            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--log-level=3");
            options.AddArgument("--silent");
            options.AddArgument("--disable-logging");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-features=TranslateUI,VoiceInput");

            Console.Clear();
            IWebDriver driver = new ChromeDriver(service, options);

            driver.Navigate().GoToUrl(BCB);
            
                Console.Clear();

            IWebElement elemento = driver.FindElement(By.XPath(CaminhoDolar));
            Dolar = elemento.Text;

            elemento = driver.FindElement(By.XPath(CaminhoEuro));
            Euro = elemento.Text;
        }

    }
}
