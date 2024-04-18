﻿using PATHETIKKKKK.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PATHETIKKKKK.View
{
    /// <summary>
    /// Interaction logic for WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {
        public WindowRole()
        {
            InitializeComponent();

            RoleViewModel vmRole = new RoleViewModel();
            lvRole.ItemsSource = vmRole.ListRole;
        }
    }
}
