using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace csharp_iso_viewer
{
    public partial class Redactor : Window
    {
        string[] photos_path;
        int iter = 0;
        List<BitmapImage> bitmaps = new List<BitmapImage>();

        public Redactor(string[] _photos_path)
        {
            InitializeComponent();

            photos_path = _photos_path;

            Update();
            MakeNewImage();
        }

        void MakeNewImage()
        {
            image.Source = bitmaps[iter];
            lable_filename.Content = Path.GetFileNameWithoutExtension(photos_path[iter]);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            iter--;

            if (iter >= 0)
            {
                MakeNewImage();
            }
            else
            {
                iter = photos_path.Length - 1;
                MakeNewImage();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            iter++;

            if (iter <= photos_path.Length - 1)
            {
                MakeNewImage();
            }
            else
            {
                iter = 0;
                MakeNewImage();
            }
        }

        private void Update()
        {
            foreach (string path in photos_path)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(path, UriKind.Absolute);
                bi.EndInit();
                bitmaps.Add(bi);
            }
        }
    }
}
