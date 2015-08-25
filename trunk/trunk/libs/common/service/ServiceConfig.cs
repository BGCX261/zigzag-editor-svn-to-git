using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Zigzag.Common
{
  public class ServiceBootInfo
  {
    public string Class;
    public string Assembly;
  }

  public class ServiceConfig : IServiceConfig
  {
    public ServiceInfo Info { get; set; }
    public List<ServiceBootInfo> ServiceBootInfoDict { get; private set; }

    public ServiceConfig()
    {
      ServiceBootInfoDict = new List<ServiceBootInfo>();
    }

    public void LoadConfig(string config)
    {
      XmlDocument document = new XmlDocument();
      document.Load(config);
      XmlNode root = document.SelectSingleNode("Include");
      XmlNode infoNode = root.SelectSingleNode("Info");
      Info.LoadConfig(infoNode);

      XmlNode configNode = root.SelectSingleNode("Config");
      foreach (XmlNode childNode in configNode)
      {
        ServiceBootInfo info = new ServiceBootInfo();
        info.Class = XmlUtil.ExtractString(childNode, "Class", "", true);
        info.Assembly = XmlUtil.ExtractString(childNode, "Assembly", "", true);
        ServiceBootInfoDict.Add(info);
      }
    }
  }
}
