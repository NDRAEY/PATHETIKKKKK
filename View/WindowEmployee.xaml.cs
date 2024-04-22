﻿using PATHETIKKKKK.Helper;
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
        private ObservableCollection<PersonDPO> personsDPO;
        private List<Role> roles;

        public WindowEmployee()
        {
            InitializeComponent();
            vmPerson = new PersonViewModel();
            vmRole = new RoleViewModel();
            roles = vmRole.ListRole.ToList();

            personsDPO = new ObservableCollection<PersonDPO>();
            foreach (var person in vmPerson.ListPerson)
            {
                PersonDPO p = Person.CopyFromPerson(person);
                personsDPO.Add(p);
            }
            lvEmployee.ItemsSource = personsDPO;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewEmployee wnEmployee = new WindowNewEmployee
            {
                Title = "Новый сотрудник",
                Owner = this
            };
            // формирование кода нового собрудника
            int maxIdPerson = vmPerson.MaxId() + 1;
            PersonDPO per = new PersonDPO
            {
                Id = maxIdPerson,
                Birthday = DateTime.Now
            };
            wnEmployee.DataContext = per;
            wnEmployee.CbRole.ItemsSource = roles;
            if (wnEmployee.ShowDialog() == true)
            {
                Role r = (Role)wnEmployee.CbRole.SelectedValue;
                per.RoleName = r.NameRole;
                personsDPO.Add(per);
                // добавление нового сотрудника в коллекцию ListPerson<Person> 
                Person p = new Person();
                p = p.CopyFromPersonDPO(per);
                vmPerson.ListPerson.Add(p);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewEmployee wnEmployee = new WindowNewEmployee
            {
                Title = "Редактирование данных",
                Owner = this
            };
            PersonDPO perDPO = (PersonDPO)lvEmployee.SelectedValue;
            PersonDPO tempPerDPO; // временный класс для редактирования
            if (perDPO != null)
            {
                tempPerDPO = perDPO.ShallowCopy();
                wnEmployee.DataContext = tempPerDPO;
                wnEmployee.CbRole.ItemsSource = roles;
                wnEmployee.CbRole.Text = tempPerDPO.RoleName;
                if (wnEmployee.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                     Role r = (Role)wnEmployee.CbRole.SelectedValue;
                    perDPO.RoleName = r.NameRole;
                    perDPO.FirstName = tempPerDPO.FirstName;
                    perDPO.LastName = tempPerDPO.LastName;
                    perDPO.Birthday = tempPerDPO.Birthday;
                    lvEmployee.ItemsSource = null;
                    lvEmployee.ItemsSource = personsDPO;
                // перенос данных из класса отображения данных в класс Person
                    FindPerson finder = new FindPerson(perDPO.Id);
                    List<Person> listPerson = vmPerson.ListPerson.ToList();
                    Person p = listPerson.Find(new Predicate<Person>(finder.PersonPredicate));
                    p = p.CopyFromPersonDPO(perDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать сотрудника для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonDPO person = (PersonDPO)lvEmployee.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по сотруднику: \n" + person.LastName +" "+person.FirstName, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    // удаление данных в списке отображения данных
                    personsDPO.Remove(person);
                    // удаление данных в списке классов ListPerson<Person>
                    Person per = new Person();
                    per = per.CopyFromPersonDPO(person);
                    vmPerson.ListPerson.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные по сотруднику для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
