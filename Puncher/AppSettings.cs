using System;
using System.Configuration;
using System.Globalization;

namespace Puncher
{
  public static class AppSettings
  {
    public static string AppName
    {
      get { return Setting<string>("AppName"); }
    }

    public static string AppVersion
    {
      get { return Setting<string>("AppVersion"); }
    }

    public static string Browser
    {
      get { return Setting<string>("Browser"); }
    }

    public static string Username
    {
      get { return Setting<string>("Username"); }
    }

    public static string Password
    {
      get { return Setting<string>("Password"); }
    }

    private static T Setting<T>(string name)
    {
      var value = ConfigurationManager.AppSettings[name];

      if (value == null)
      {
        throw new Exception(String.Format("Could not find setting '{0}',", name));
      }

      return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
    }
  }
}
