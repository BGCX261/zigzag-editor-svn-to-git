﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zigzag.SpriteEditor
{
	/// <summary>
	/// MainMenu.xaml 的交互逻辑
	/// </summary>
	public partial class MainMenu : UserControl
	{
		public MainMenu()
		{
			this.InitializeComponent();

      this.DataContext = MenuService.Instance;
		}
	}
}