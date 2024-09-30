using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppOpenGl
{
    /// <summary>
    /// Логика взаимодействия для WindowFileTxt.xaml
    /// </summary>
    public partial class WindowFileTxt : Window
    {
        private MainViewModel _viewModel;
        public static string filePath = @"C:\Users\Admin\source\repos\WpfAppOpenGl\data.txt"; // Необходимо изменить
        private bool isLoaded = false;
        private MainWindow _mainWindow;
        public event EventHandler DataUpdated;
        public WindowFileTxt(MainWindow mainWindow)
        {
            InitializeComponent();
            _viewModel = new MainViewModel(); 
            DataContext = _viewModel; 
            _mainWindow = mainWindow; // Сохраняем ссылку на главное окно
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataFromFile();
        }

        private void LoadDataFromFile()
        {
            if (File.Exists(filePath))
            {
                UpdateTextBoxes();
                isLoaded = true;
            }
            else
            {
                MessageBox.Show("Файл не найден: " + filePath);
                this.Close();
            }
        }

        private void UpdateTextBoxes()
        {
            CoordinatesTextBox.Text = string.Join(Environment.NewLine, _viewModel.Points.Select(p => $"{p.X} {p.Y} {p.Z} {p.H}"));
            ConnectionSequenceTextBox.Text = string.Join(Environment.NewLine, _viewModel.Lines.Select(l => $"{l.StartIndex} {l.EndIndex}"));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isLoaded)
            {
                SaveButton.Visibility = Visibility.Visible;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveDataToFile(); 
            SaveButton.Visibility = Visibility.Collapsed;
            MessageBox.Show("Изменения сохранены!");
        }

        private void SaveDataToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                var coordinatesLines = CoordinatesTextBox.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                writer.WriteLine(coordinatesLines.Length);

                foreach (var line in coordinatesLines)
                {
                    writer.WriteLine(line);
                }

                var sequenceLines = ConnectionSequenceTextBox.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                writer.WriteLine(sequenceLines.Length);

                foreach (var line in sequenceLines)
                {
                    writer.WriteLine(line);
                }                
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            DataUpdated?.Invoke(this, EventArgs.Empty);
            _mainWindow.Show();
        }        
    }
}
