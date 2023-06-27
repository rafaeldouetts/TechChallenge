using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
	[TestClass]
	public class UsuarioTestCase
	{
		private static IWebDriver driver;
		private StringBuilder verificationErrors;
		private static string baseURL;
		private bool acceptNextAlert = true;

		[ClassInitialize]
		public static void InitializeClass(TestContext testContext)
		{
			driver = new ChromeDriver();
			baseURL = "https://www.katalon.com/";
		}

		[ClassCleanup]
		public static void CleanupClass()
		{
			try
			{
				//driver.Quit();// quit does not close the window
				driver.Close();
				driver.Dispose();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
		}

		[TestInitialize]
		public void InitializeTest()
		{
			verificationErrors = new StringBuilder();
		}

		[TestCleanup]
		public void CleanupTest()
		{
			Assert.AreEqual("", verificationErrors.ToString());
		}

		[TestMethod]
		public void Usuario_0()
		{

			//Arrange
			driver.Navigate().GoToUrl("http://localhost:4200/create-account");
			driver.FindElement(By.XPath("//input[@type='email']")).Click();
			driver.FindElement(By.XPath("//input[@type='email']")).Clear();
			driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("teste");
			driver.FindElement(By.XPath("//input[2]")).Clear();
			driver.FindElement(By.XPath("//input[2]")).SendKeys("teste@teste.com.br");
			driver.FindElement(By.XPath("//input[@type='password']")).Clear();
			driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Teste@123");


			//Act
			driver.FindElement(By.XPath("//input[@value='Cadastrar']")).Click();

			Thread.Sleep(1000);

			var mensagem = driver.FindElement(By.XPath("//*[@id=\"cdk-overlay-0\"]/snack-bar-container/simple-snack-bar/span")).Text;



			//captura tela e salva 
			Capturar("loginSucesso");


			//Assert
			Assert.AreEqual(mensagem, "Usuario Cadastrado com sucesso!");
		}

		[TestMethod]
		public void Usuario_1()
		{
			//Assert
			driver.Navigate().GoToUrl("http://localhost:4200/create-account");
			driver.FindElement(By.XPath("//input[@type='email']")).Click();
			driver.FindElement(By.XPath("//input[@type='email']")).Clear();
			driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("teste");
			driver.FindElement(By.XPath("//input[2]")).Clear();
			driver.FindElement(By.XPath("//input[2]")).SendKeys("teste@teste.com.br");
			driver.FindElement(By.XPath("//input[@type='password']")).Clear();
			driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Teste@123");
			
			//Act
			driver.FindElement(By.XPath("//input[@value='Cadastrar']")).Click();

			Thread.Sleep(1000);

			var mensagem = driver.FindElement(By.XPath("//*[@id=\"cdk-overlay-0\"]/snack-bar-container/simple-snack-bar/span")).Text;



			//captura tela e salva 
			Capturar("UsuarioInvalido");

			//Assert
			Assert.AreEqual(mensagem, "Usuario ou senha invalida!");
		}

		//[TestMethod]
		//public void SenhaInvalida()
		//{
		//	//driver.Navigate().GoToUrl("http://localhost:4200/create-account");
		//	//driver.FindElement(By.XPath("//input[@type='email']")).Click();
		//	//driver.FindElement(By.XPath("//input[@type='email']")).Clear();
		//	//driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("teste");
		//	//driver.FindElement(By.XPath("//input[2]")).Clear();
		//	//driver.FindElement(By.XPath("//input[2]")).SendKeys("teste@teste.com.br");
		//	//driver.FindElement(By.XPath("//input[@type='password']")).Clear();
		//	//driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Teste@123");
		//	//driver.FindElement(By.XPath("//input[@value='Cadastrar']")).Click();

		//	//Assert.IsNotNull(By.XPath("//pre[contains(text(), 'sucesso')]"));


		//	////captura tela e salva 
		//	//var camera = driver as ITakesScreenshot;
		//	//var screenShot = camera.GetScreenshot();
		//	//screenShot.SaveAsFile("loginSucesso.png");
		//}

		//[TestMethod]
		//public void EmailInvalida()
		//{
		//	//driver.Navigate().GoToUrl("http://localhost:4200/create-account");
		//	//driver.FindElement(By.XPath("//input[@type='email']")).Click();
		//	//driver.FindElement(By.XPath("//input[@type='email']")).Clear();
		//	//driver.FindElement(By.XPath("//input[@type='email']")).SendKeys("teste");
		//	//driver.FindElement(By.XPath("//input[2]")).Clear();
		//	//driver.FindElement(By.XPath("//input[2]")).SendKeys("teste@teste.com.br");
		//	//driver.FindElement(By.XPath("//input[@type='password']")).Clear();
		//	//driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("Teste@123");
		//	//driver.FindElement(By.XPath("//input[@value='Cadastrar']")).Click();

		//	//Assert.IsNotNull(By.XPath("//pre[contains(text(), 'sucesso')]"));


		//	////captura tela e salva 
		//	//var camera = driver as ITakesScreenshot;
		//	//var screenShot = camera.GetScreenshot();
		//	//screenShot.SaveAsFile("loginSucesso.png");
		//}


		private static void Capturar(string nome)
		{
			var camera = driver as ITakesScreenshot;
			var screenShot = camera.GetScreenshot();
			screenShot.SaveAsFile(nome + ".png");
		}

		private bool IsElementPresent(By by)
		{
			try
			{
				driver.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}

		private bool IsAlertPresent()
		{
			try
			{
				driver.SwitchTo().Alert();
				return true;
			}
			catch (NoAlertPresentException)
			{
				return false;
			}
		}

		private string CloseAlertAndGetItsText()
		{
			try
			{
				IAlert alert = driver.SwitchTo().Alert();
				string alertText = alert.Text;
				if (acceptNextAlert)
				{
					alert.Accept();
				}
				else
				{
					alert.Dismiss();
				}
				return alertText;
			}
			finally
			{
				acceptNextAlert = true;
			}
		}
	}
}
