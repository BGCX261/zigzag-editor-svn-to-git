/************************************************************************

   AvalonDock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the New BSD
   License (BSD) as published at http://avalondock.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up AvalonDock in Extended WPF Toolkit Plus at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like facebook.com/datagrids

  **********************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Zigzag.Common;

namespace Zigzag.SpriteEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
      DispatcherTimer m_MainTimer = null;
      StartupInfo m_StartupInfo = null;
      Window m_MainWindow = null;

      #region Singleton
      static App s_instance = new App();
      public static App Instance { get { return s_instance; } }
      private App() { }
      #endregion

      #region Event
      protected override void OnStartup(StartupEventArgs e)
      {
        base.OnStartup(e);

        //Window
        m_MainWindow = new Workbench();
        m_MainWindow.Show();

        //StartupInfo
        m_StartupInfo = new StartupInfo(e.Args);

        //MainTimer
        m_MainTimer = new DispatcherTimer();
        m_MainTimer.Tick += new EventHandler(_TickApp);
        m_MainTimer.Interval = TimeSpan.FromMilliseconds(20.0d);

        //Init
        _InitApp();
        m_MainTimer.Start();
      }

      protected override void OnExit(ExitEventArgs e)
      {
        m_MainTimer.Stop();
        _ExitApp();
        base.OnExit(e);
      }
      #endregion

      #region Logic
      private void _InitApp()
      {
        LogService.Instance.InitService(AppDefines.c_LogServicePath);
        MenuService.Instance.InitService(AppDefines.c_MenuServicePath);
      }

      private void _TickApp(object sender, EventArgs e)
      {

      }

      private void _ExitApp()
      {
        MenuService.Instance.ReleaseService();
        LogService.Instance.ReleaseService();
      }
      #endregion
    }
}
