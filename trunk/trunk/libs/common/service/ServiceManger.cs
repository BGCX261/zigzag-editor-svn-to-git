using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;

namespace Zigzag.Common
{
  public class ServiceManger : IService<ServiceConfig>
  {
    #region Singleton
    static ServiceManger s_instance = new ServiceManger();
    public static ServiceManger Instance { get { return s_instance; } }
    #endregion

    ServiceConfig config = null;

    public bool InitService(string configFile)
    {
      LogService.Info("ServiceManager.InitService");
      config = new ServiceConfig();
      config.LoadConfig(configFile);
      return true;
    }

    public bool ReleaseService()
    {
      LogService.Info("ServiceManager.ReleaseService");
      return true;
    }

    public ServiceConfig Config
    {
      get { return config; }
    }
  }
}
