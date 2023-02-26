using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TESTE.StepDefinitions
{
    [Binding]
    public class CorreiosStepDefinitions
    {

        public String url = "https://www.correios.com.br/";
        IWebDriver driver;

        [Given(@"that I'm on the website of the correios")]
        public void GivenThatImOnTheWebsiteOfTheCorreios()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
            driver.FindElement(By.XPath("//*[@id=\"btnCookie\"]")).Click();
        }

        [When(@"have an not valid  CEP")]
        public void WhenHaveAnNotValidCEP()
        {

           
            driver.FindElement(By.Id("relaxation")).SendKeys("80700000");
            driver.FindElement(By.Id("relaxation")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.Id("relaxation")).SendKeys(Keys.Enter);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Assert.That(driver.FindElement(By.Id("mensagem-resultado")).Text, Is.EqualTo("Não há dados a serem exibidos"));
        }

        [Then(@"the site returns invalid cep")]
        public void ThenTheSiteReturnsInvalidCep()
        {
            driver.Url = url;
        }

        [Then(@"that I'([^']*)'ll do new search")]
        public void ThenThatIllDoNewSearch(string p0)
        {
            driver.FindElement(By.Id("relaxation")).Click();
            driver.FindElement(By.Id("relaxation")).SendKeys("01013001");
        }

        [Then(@"have an valid  CEP")]
        public void ThenHaveAnValidCEP()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("relaxation")).SendKeys(Keys.Enter);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        [Then(@"the site returns valid cep")]
        public void ThenTheSiteReturnsValidCep()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.That(driver.FindElement(By.CssSelector("td:nth-child(1)")).Text, Is.EqualTo("Rua Quinze de Novembro - lado ímpar"));
        }


        [Then(@"I return on the website of the Correios")]
        public void ThenTheIreturnonthewebsiteoftheCorreios()
        {
            driver.Url = url;
        }

        [Then(@"I Consult a tracking code")]
        public void ThenTheIConsultatrackingcode()
        {
            driver.FindElement(By.Id("objetos")).SendKeys("SS987654321BR");
            driver.FindElement(By.CssSelector(".card:nth-child(1) .ic-busca-out")).Click();
        }


    }




    }

