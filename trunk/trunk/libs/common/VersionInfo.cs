using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zigzag.Common
{
  public class VersionInfo
  {
    public VersionInfo()
    {
      Major = "0";
      Minor = "0";
      Build = "1";
      Name = "Zigzag";
    }

    public string Major
    {
      set;
      get;
    }

    public string Minor
    {
      set;
      get;
    }

    public string Build
    {
      set;
      get;
    }

    public string Name
    {
      set;
      get;
    }

    public string VersionNum
    {
      get { return "V" + Major + "." + Minor + "." + Build; }
    }

    public string VersionName
    {
      get { return VersionNum + " " + VersionNum; }
    }
  }
}
