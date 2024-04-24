using PATHETIKKKKK.Helper;
using PATHETIKKKKK.Model;
using PATHETIKKKKK.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using static System.Net.Mime.MediaTypeNames;

namespace PATHETIKKKKK.View
{
    /// <summary>
    /// Interaction logic for WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        private PersonViewModel vmPerson;
        private RoleViewModel vmRole;
        //private ObservableCollection<PersonDpo> personsDpo;
        private List<Role> roles;

        public WindowEmployee()
        {
            InitializeComponent();

            vmPerson = new PersonViewModel();

            DataContext = vmPerson;
            //vmRole = new RoleViewModel();
            //roles = vmRole.ListRole.ToList();

            //personsDpo = new ObservableCollection<PersonDpo>();
            //foreach (var person in vmPerson.ListPerson)
            //{
            //    PersonDpo p = Person.CopyFromPerson(person);
            //    personsDpo.Add(p);
            //}

            //lvEmployee.ItemsSource = personsDpo;
        }

        private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView s = (ListView)sender;
            Person v = (Person)s.SelectedItem;

            vmPerson.SelectedPerson = v;
        }
    }
}
