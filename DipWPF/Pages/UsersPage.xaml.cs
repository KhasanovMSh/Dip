using DataLib;
using DipWPF.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DipWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();

            UpdateTable();
        }

        private void UpdateTable()
        {
            DataGridUsers.ItemsSource = CRUD.LoadUsers();
        }

      
        private void ChangeValueDataGrid(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                CRUD.UpdateUser(e.Row.Item as Users);

                UpdateTable();
            }
        }

        private void ButtonAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AddUser window = new AddUser("Admin");
            window.ShowDialog();
            UpdateTable();
        }

        private void ButtonAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            AddUser window = new AddUser("Teacher");
            window.ShowDialog();
            UpdateTable();
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddUser window = new AddUser("Student");
            window.ShowDialog();
            UpdateTable();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            CRUD.DeleteUser(DataGridUsers.SelectedItem as Users);
            UpdateTable();
        }
    }
}










/*private void ComboTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
      {
          //MessageBox.Show(ComboTables.SelectedIndex.ToString());
          switch (ComboTables.SelectedIndex)
          {
              case 0:
                  {
                      //MessageBox.Show(ComboTables.SelectedItem.ToString());
                      DataGridUsers.ItemsSource = CRUD.LoadAdministrators();
                      break;
                  }
              case 1:
                  {
                      //MessageBox.Show(ComboTables.SelectedItem.ToString());
                      DataGridUsers.ItemsSource = CRUD.LoadTeachers();
                      break;
                  }
              case 2:
                  {
                      //MessageBox.Show(ComboTables.SelectedItem.ToString());
                      DataGridUsers.ItemsSource = CRUD.LoadStudents();
                      break;
                  }
          }
      }*/