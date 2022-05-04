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
using System.Windows.Shapes;

namespace DipWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserxaml.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        string _userType;
        public AddUser(string userType)
        {
            InitializeComponent();
            _userType = userType;
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            CRUD.AddUser(new Users { UserType=_userType, Login=TbLogin.Text, Password=TbPassword.Text, Name=TbFirstName.Text, Surname=TbSurname.Text, Patronomic=TbPatronomic.Text});
            this.Close();
        }
    }
}
