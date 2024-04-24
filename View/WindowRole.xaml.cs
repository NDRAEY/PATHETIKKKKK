using PATHETIKKKKK.Model;
using PATHETIKKKKK.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
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

            DataContext = new RoleViewModel();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView x = (ListView)sender;
            Role role = (Role)x.SelectedValue;

            ((RoleViewModel)DataContext).SelectedRole = role;
        }
    }
}
