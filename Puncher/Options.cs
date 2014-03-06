using System;
using CommandLine;
using CommandLine.Text;

namespace Puncher
{
  public class Options
  {
    [Option('i', "in", HelpText = "Punch In")]
    public bool In { get; set; }

    [Option('o', "out", HelpText = "Punch Out")]
    public bool Out { get; set; }

    [HelpOption]
    public string GetUsage()
    {
      var help = new HelpText
      {
        Heading = new HeadingInfo(AppSettings.AppName, AppSettings.AppVersion),
        Copyright = new CopyrightInfo("Viacheslav Ivanov", DateTime.Today.Year),
        AdditionalNewLineAfterOption = true,
        AddDashesToOption = true
      };
      help.AddPreOptionsLine("Usage: app <option>");
      help.AddOptions(this);

      return help;
    }
  }
}
