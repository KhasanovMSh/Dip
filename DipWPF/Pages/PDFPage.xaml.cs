using DataLib;
using Microsoft.Win32;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
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


namespace DipWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PDFPage.xaml
    /// </summary>
    public partial class PDFPage : Page
    {
        #region Свойства
        private string _addingPath;
        public string AddingPath
        {
            get => _addingPath + $"\\Лекция {_lecturesList.Count + 1}.pdf";
            set => _addingPath = value;
        }
        private string lecturePath;

        private List<string> _lecturesList;

        public string _deletePath;
        public string DeletePath
        {
            get => _deletePath + $"\\{ListBoxLectures.SelectedItem.ToString()}.pdf";
            set => _deletePath = value;
        }

        public string _changePath;
        public string ChangePath
        {
            get => _changePath + $"\\{ListBoxLectures.SelectedItem.ToString()}.pdf";
            set => _changePath = value;
        }
        #endregion
        public PDFPage()
        {
            InitializeComponent();

            if (CurrentUser.currentUser.UserType == "Student")
            {
                BtnAddLecture.Visibility = Visibility.Collapsed;
                BtnDeleteLecture.Visibility = Visibility.Collapsed;
                BtnChangeLecture.Visibility = Visibility.Collapsed;
            }

            _addingPath= Path.GetFullPath($"Lectures");
            _deletePath = Path.GetFullPath($"Lectures");
            _changePath = Path.GetFullPath($"Lectures");

            UpdateLecture();

            ListBoxLectures.SelectedIndex = 0;


            lecturePath = Path.GetFullPath($"Lectures\\Лекция {ListBoxLectures.SelectedIndex + 1}.pdf");
            PdfViewer.Address = lecturePath;

        }

        private void ListBoxLectures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lecturePath = Path.GetFullPath($"Lectures\\Лекция {ListBoxLectures.SelectedIndex + 1}.pdf");
            PdfViewer.Address = lecturePath;
        }

        private void BtnAddLecture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pdf Files|*.pdf";
            openFileDialog.ShowDialog();
            string oldFilePath = openFileDialog.FileName;
            File.Copy(oldFilePath, AddingPath, true);
            UpdateLecture();
        }

    

        private void BtnDeleteLecture_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(DeletePath);
            UpdateLecture();
            ListBoxLectures.SelectedIndex = 0;
        }

        private void BtnChangeLecture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pdf Files|*.pdf";
            openFileDialog.ShowDialog();
            string oldFilePath = openFileDialog.FileName;
            File.Copy(oldFilePath, ChangePath, true);
            UpdateLecture();
        }
        private void UpdateLecture()
        {
            _lecturesList = (from a in Directory.GetFiles(Path.GetFullPath($"Lectures")) select Path.GetFileNameWithoutExtension(a)).ToList();
            ListBoxLectures.ItemsSource = _lecturesList;
        }
    }
}
