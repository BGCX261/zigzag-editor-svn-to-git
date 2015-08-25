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
using System.Windows.Controls;
using System.Windows;

namespace Zigzag.SpriteEditor
{
  public class PanesStyleSelector : StyleSelector
  {
    public Style SolutionStyle
    {
      get;
      set;
    }

    public Style PropertyStyle
    {
      get;
      set;
    }

    public Style SpriteStyle
    {
      get;
      set;
    }

    public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
    {
      if (item is SolutionViewModel)
        return SolutionStyle;

      if (item is PropertyViewModel)
        return SolutionStyle;

      if (item is SpriteViewModel)
        return SpriteStyle;

      return base.SelectStyle(item, container);
    }
  }
}
