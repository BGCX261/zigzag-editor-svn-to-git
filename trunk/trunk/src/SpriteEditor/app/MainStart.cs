using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zigzag.SpriteEditor
{
  class MainStart
  {
    [STAThread]
    public static void Main(string[] args)
    {
      System.Console.WriteLine("Start...");
      App.Instance.Run();
    }
  }
}
