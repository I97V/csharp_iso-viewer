using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace csharp_iso_viewer
{
    public partial class MainWindow : Window
    {
        string path;
        string[] photos_path;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            tb_path.Text = folder.SelectedPath.ToString();
            path = folder.SelectedPath.ToString();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            photos_path = Directory.GetFiles(path);

            if (photos_path.Length > 0)
            {
                Redactor r = new Redactor(photos_path);
                r.Show();
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("No one picture in a directory\n\tTry again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
