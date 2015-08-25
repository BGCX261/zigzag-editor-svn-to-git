using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Zigzag.Common
{
  public class ServiceInfo
  {
    public string Name { get; set; }
    public string Author { get; set; }
    public string Date { get; set; }
    public string Description { get; set; }

    public void LoadConfig(XmlNode node)
    {
      Name = XmlUtil.ExtractString(node, "Name", "", true);
      Author = XmlUtil.ExtractString(node, "Author", "", false);
      Date = XmlUtil.ExtractString(node, "Date", "", false);
      Description = XmlUtil.ExtractString(node, "Description", "", false);
    }
  }

  public interface IServiceConfig
  {
    ServiceInfo Info { get;}
    void LoadConfig(string config);
  }
}
