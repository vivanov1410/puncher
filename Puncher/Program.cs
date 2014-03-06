using System;

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
  }
}
