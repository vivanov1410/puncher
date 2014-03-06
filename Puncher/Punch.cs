using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Puncher
{
  public class Punch
  {
    private readonly string _username;
    private readonly string _password;
    private readonly string _browser;
    private readonly IWebDriver _driver;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <param name="browser">Browser</param>
    public Punch(string username, string password, string browser)
    {
      _username = username;
      _password = password;
      _browser = browser;

      switch (_browser)
      {
        case "iexplorer":
          _driver = new InternetExplorerDriver();
          break;

        case "firefox":
          _driver = new FirefoxDriver();
          break;

        default:
          _driver = new InternetExplorerDriver();
          break;
      }
    }

    /// <summary>
    /// Punch in
    /// </summary>
    public void In()
    {
      It();
    }

    /// <summary>
    /// Punch out
    /// </summary>
    public void Out()
    {
      It();
    }

    /// <summary>
    /// Generic punch
    /// </summary>
    private void It()
    {
      _driver.Navigate().GoToUrl("http://timeclock/Login.aspx");
      var user = _driver.FindElement(By.Id("txtUserName"));
      var pass = _driver.FindElement(By.Id("txtPassword"));
      var submit = _driver.FindElement(By.Id("btnLogin"));

      user.SendKeys(_username);
      Wait(10);
      pass.SendKeys(_password);
      Wait(10);
      submit.Click();

      Wait(30);

      var punch = _driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctl01_btnPunch"));
      punch.Click();

      _driver.Quit();
    }

    /// <summary>
    /// Wait for some time
    /// </summary>
    /// <param name="seconds">Time in seconds</param>
    private static void Wait(int seconds)
    {
      Thread.Sleep(TimeSpan.FromSeconds(seconds));
    }
  }
}
