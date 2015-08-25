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
  public class PropertyViewModel : PadViewModel
    {
        public PropertyViewModel()
            :base("Property")
        {
            WorkbenchService.Instance.ActiveDocumentChanged += new EventHandler(OnActiveDocumentChanged);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri("pack://application:,,/resources/images/property-blue.png");
            bi.EndInit();
            IconSource = bi;
        }

        void OnActiveDocumentChanged(object sender, EventArgs e)
        {
            if (WorkbenchService.Instance.ActiveDocument != null &&
                WorkbenchService.Instance.ActiveDocument.FilePath != null &&
                File.Exists(WorkbenchService.Instance.ActiveDocument.FilePath))
            {
                var fi = new FileInfo(WorkbenchService.Instance.ActiveDocument.FilePath);
                FileSize = fi.Length;
                LastModified = fi.LastWriteTime;
            }
            else
            {
                FileSize = 0;
                LastModified = DateTime.MinValue;
            }
        }

        #region FileSize

        private long _fileSize;
        public long FileSize
        {
            get { return _fileSize; }
            set
            {
                if (_fileSize != value)
                {
                    _fileSize = value;
                    RaisePropertyChanged("FileSize");
                }
            }
        }

        #endregion

        #region LastModified

        private DateTime _lastModified;
        public DateTime LastModified
        {
            get { return _lastModified; }
            set
            {
                if (_lastModified != value)
                {
                    _lastModified = value;
                    RaisePropertyChanged("LastModified");
                }
            }
        }

        #endregion




    }
}
