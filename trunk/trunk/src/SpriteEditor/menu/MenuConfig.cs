﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Zigzag.Common
{
  public class MenuConfig : IServiceConfig
  {
    private ServiceInfo m_ServiceInfo;
    public ServiceInfo Info { get { return m_ServiceInfo; } }
    public int LogLevel;

    public MenuConfig()
    {
      m_ServiceInfo = new ServiceInfo();
    }

    public void LoadConfig(string config)
    {
      XmlDocument document = new XmlDocument();
      document.Load(config);
      XmlNode root = document.SelectSingleNode("Include");
      XmlNode infoNode = root.SelectSingleNode("Info");
      m_ServiceInfo.LoadConfig(infoNode);

      XmlNode configNode = root.SelectSingleNode("Config");
    }
  }
}
