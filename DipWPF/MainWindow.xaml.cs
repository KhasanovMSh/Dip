using DataLib;
using DipWPF.Pages;
using DipWPF.Windows;
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

namespace DipWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void typeDef();
        typeDef td;
        public MainWindow()
        {
            InitializeComponent();

            td = UserTypeDefenition;

            PageManager.FrameMain = FrameMain;
            PageManager.FrameMain.Navigate(new AuthRegPage(UserTypeDefenition));
        }

        private void FrameMain_ContentRendered(object sender, EventArgs e)
        {
            if (PageManager.FrameMain.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
         
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;

            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.GoBack();
        }
        private void BtnAccount_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.Navigate(new CurrentUserPage());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.Navigate(new UsersPage());
        }

        private void BtnLectures_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.Navigate(new PDFPage());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.currentUser = null;
            BtnAccount.Visibility = Visibility.Hidden;
            BtnUsers.Visibility = Visibility.Hidden;
            BtnLectures.Visibility = Visibility.Hidden;
            BtnLogout.Visibility = Visibility.Hidden;
            PageManager.FrameMain.Navigate(new AuthRegPage(UserTypeDefenition));
        }

        private void UserTypeDefenition()
        {
            switch (CurrentUser.currentUser.UserType)
            {
                case "Student":
                    {
                        BtnAccount.Visibility = Visibility.Visible;
                        BtnLectures.Visibility = Visibility.Visible;
                        BtnLogout.Visibility = Visibility.Visible;
                        break;
                    }
                case "Admin":
                    {
                        BtnAccount.Visibility = Visibility.Visible;
                        BtnUsers.Visibility = Visibility.Visible;
                        BtnLectures.Visibility = Visibility.Visible;
                        BtnLogout.Visibility = Visibility.Visible;
                        break;
                    }
                case "Teacher":
                    {
                        BtnAccount.Visibility = Visibility.Visible;
                        BtnLectures.Visibility = Visibility.Visible;
                        BtnLogout.Visibility = Visibility.Visible;
                        break;
                    }
            }
        }
    }
}
