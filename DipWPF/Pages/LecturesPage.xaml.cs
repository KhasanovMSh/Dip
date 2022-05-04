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
    /// Логика взаимодействия для LecturesPage.xaml
    /// </summary>
    public partial class LecturesPage : Page
    {

        public LecturesPage()
        {
            InitializeComponent();
            List<string> _lecturesList = (from a in Directory.GetFiles(System.IO.Path.GetFullPath($"Lectures")) select System.IO.Path.GetFileNameWithoutExtension(a)).ToList();

            ListBoxLectures.ItemsSource = _lecturesList;
            ListBoxLectures.SelectedIndex = 0;


            string path = System.IO.Path.GetFullPath($"Lectures\\Лекция {ListBoxLectures.SelectedIndex + 1}.txt");

            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                string text = reader.ReadToEnd();
                TextBoxLectures.Text = text;
                Console.WriteLine(text);
            }
        }

        private void ListBoxLectures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string path = System.IO.Path.GetFullPath($"Lectures\\Лекция {ListBoxLectures.SelectedIndex + 1}.txt");

            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                string text = reader.ReadToEnd();
                TextBoxLectures.Text = text;
                Console.WriteLine(text);
            }
        }
    }
}
