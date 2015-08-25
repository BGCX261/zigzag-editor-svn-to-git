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
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Zigzag.SpriteEditor
{
  public class SolutionViewModel : PadViewModel
  {
    public SolutionViewModel()
      : base("Solution")
    {
      BitmapImage bi = new BitmapImage();
      bi.BeginInit();
      bi.UriSource = new Uri("pack://application:,,/resources/images/property-blue.png");
      bi.EndInit();
      IconSource = bi;

      TreeRoot = new FolderNode("f:\\");
    }

    #region TreeRoot
    private FolderNode _TreeRoot;
    public FolderNode TreeRoot
    {
      get { return _TreeRoot; }
      set
      {
        if (_TreeRoot != value)
        {
          _TreeRoot = value;
          RaisePropertyChanged("TreeRoot");
        }
      }
    }
    #endregion
  }
}
