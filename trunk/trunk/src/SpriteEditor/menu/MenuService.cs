// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Globalization;
using System.IO;
using Zigzag.Common;
using System.Windows.Input;
using System.Windows;
using Microsoft.Win32;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Zigzag.SpriteEditor
{
  public class MenuService : ViewModelBase, IService<MenuConfig>
  {
    #region Singleton
    static MenuService s_instance = new MenuService();
    public static MenuService Instance { get { return s_instance; } }
    #endregion

    static MenuConfig config = null;

    #region Service
    public bool InitService(string configFile)
    {
      LogService.Info("MenuService.InitService");

      config = new MenuConfig();
      config.LoadConfig(configFile);

      return true;
    }

    public bool ReleaseService()
    {
      LogService.Info("MenuService.ReleaseService");
      return true;
    }

    public MenuConfig Config
    {
      get { return config; }
    }
    #endregion

    #region NewCommand
    RelayCommand m_NewSpriteCommand = null;
    public ICommand NewSpriteCommand
    {
      get
      {
        if (m_NewSpriteCommand == null)
        {
          m_NewSpriteCommand = new RelayCommand(() => OnNewSprite(), () => CanNewSprite());
        }

        return m_NewSpriteCommand;
      }
    }
    public bool CanNewSprite()
    {
      return true;
    }

    public void OnNewSprite()
    {
      WorkbenchService.Instance.CreateSprite();
    }
    #endregion

    #region OpenCommand
    RelayCommand<object> m_OpenSpriteCommand = null;
    public ICommand OpenSpriteCommand
    {
      get
      {
        if (m_OpenSpriteCommand == null)
        {
          m_OpenSpriteCommand = new RelayCommand<object>((p) => OnOpenSprite(p), (p) => CanOpenSprite(p));
        }

        return m_OpenSpriteCommand;
      }
    }

    private bool CanOpenSprite(object param)
    {
      return true;
    }

    private void OnOpenSprite(object param)
    {
      var dlg = new OpenFileDialog();
      if (dlg.ShowDialog().GetValueOrDefault())
      {
        var fileViewModel = WorkbenchService.Instance.OpenSprite(dlg.FileName);
        WorkbenchService.Instance.ActiveDocument = fileViewModel;
      }
    }
    #endregion

  }
}
