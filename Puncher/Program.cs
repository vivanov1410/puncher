using System;
using System.Threading;

namespace Puncher
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        var options = new Options();
        if (!CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
        {
          Environment.Exit(1);
        }

        var punch = new Punch(AppSettings.Username, AppSettings.Password, AppSettings.Browser);

        if (options.In)
        {
          if (options.Delay > 0)
          {
            WaitRandomly(options.Delay);
          }

          punch.In();
        }
        else if (options.Out)
        {
          if (options.Delay > 0)
          {
            WaitRandomly(options.Delay);
          }

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

    /// <summary>
    /// Wait randomly for some time in minutes
    /// </summary>
    /// <param name="seconds">Time in seconds</param>
    private static void WaitRandomly(int minutes)
    {
      var random = new Random();
      var delay = random.Next(minutes);

      Thread.Sleep(TimeSpan.FromMinutes(delay));
    }
  }
}
