using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Puncher
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        var options = new Options();
        if (!CommandLine.Parser.Default.ParseArguments(args, options))
        {
          options.GetUsage();
          Environment.Exit(1);
        }

        var punch = new Punch(AppSettings.Username, AppSettings.Password, AppSettings.Browser);

        if (options.In)
        {
          punch.In();
        }
        else if (options.Out)
        {
          punch.Out();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("[error] {0}", ex.Message);
        Environment.Exit(1);
      }

      Environment.Exit(0);
    }

    static void SendEmail(string body)
    {
      const string from = "slava.ivanov@fyidoctors.com";
      const string to = "slava.ivanov@fyidoctors.com";
      const string subject = "Kesha status";

      var message = new MailMessage(from, to, subject, body);
      var client = new SmtpClient("mail.fyidoctors.local") { Credentials = new NetworkCredential("vivanov", "Popka123", "fyidoctors") };

      client.Send(message);
    }
  }
}
