using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zigzag.Common
{
  public interface IService<T> where T : IServiceConfig
  {
    bool InitService(string configFile);
    bool ReleaseService();
    T Config { get; }
  }
}