using DataLib;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DipWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для CurrentUserPage.xaml
    /// </summary>
    public partial class CurrentUserPage : Page
    {
        public CurrentUserPage()
        {
            InitializeComponent();
            DataContext = CurrentUser.currentUser;
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            CRUD.UpdateUser(CurrentUser.currentUser);
        }
    }
}
