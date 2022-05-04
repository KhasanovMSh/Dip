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
    /// Логика взаимодействия для AuthRegWindow.xaml
    /// </summary>
    public partial class AuthRegWindow : Window
    {
        bool _auth = true;
        public AuthRegWindow()
        {
            InitializeComponent();
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
            bool IsReg = true; 
            //DataController.Regin("client", TbLogin.Text, TbPassword.Text, TbFirstName.Text, TbSurname.Text);
            if (IsReg)
            {
                PageManager.FrameMain.GoBack();
            }
        }

        private void Authorization()
        {
            bool IsAuth = true; 
            //DataController.Login(TbLogin.Text, TbPassword.Text);
            if (IsAuth)
            {

                PageManager.FrameMain.GoBack();
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
