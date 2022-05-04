using DataLib;
using DipWPF;
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
    /// Логика взаимодействия для AuthRegPage.xaml
    /// </summary>
    public partial class AuthRegPage : Page
    {
        bool _auth = true;
        public delegate void typeDef();
        typeDef td;
        public AuthRegPage(typeDef typeDelegate)
        {
            InitializeComponent();
            td = typeDelegate;
        }

        private void BtnAuthReg_Click(object sender, RoutedEventArgs e)
        {
            if (_auth == true)
            {
                Authorization();
            }
            else
            {
                Registration();
            }
        }
        private void Registration()
        {
            bool IsReg = CRUD.Regin("Student", TbLogin.Text, TbPassword.Text, TbFirstName.Text, TbSurname.Text);

            if (IsReg)
            {
                ClearTextBoxes();
                td();
                PageManager.FrameMain.Navigate(new PDFPage());
            }
        }

        private void Authorization()
        {
            bool IsAuth = CRUD.Login(TbLogin.Text, TbPassword.Text);

            if (IsAuth)
            {
                ClearTextBoxes();
                td();
                PageManager.FrameMain.Navigate(new PDFPage());

            }

        }

        private void BtnChangeAuth_Click(object sender, RoutedEventArgs e)
        {
            if (_auth == true)
            {
                _auth = false;
                TbAuth.Text = "Регистрация";
                BtnChangeAuth.Content = "Авторизация";
                GridFirstName.Visibility = Visibility.Visible;
                GridSurname.Visibility = Visibility.Visible;
                BtnAuthReg.Content = "Зарегистрироваться";
            }
            else
            {
                _auth = true;
                TbAuth.Text = "Авторизация";
                BtnChangeAuth.Content = "Регистрация";
                GridFirstName.Visibility = Visibility.Hidden;
                GridSurname.Visibility = Visibility.Hidden;
                BtnAuthReg.Content = "Авторизоваться";
            }
        }

        private void ClearTextBoxes()
        {
            TbLogin.Text = "";
            TbPassword.Text = "";
            TbFirstName.Text = "";
            TbSurname.Text = "";
        }
    }
}
