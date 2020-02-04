using Microsoft.Win32;
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

namespace WpfREctangleTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private Point anchorPoint = new Point();
        string actualFileName;

        private bool CanDrag = false;

        public List<System.Drawing.Rectangle> areas = new List<System.Drawing.Rectangle>();

        public MainWindow()
        {
            InitializeComponent();
            SaveButton.Visibility = Visibility.Hidden;
        }

        private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(CanDrag)
            {
                anchorPoint.X = e.GetPosition(BackPlane).X;
                anchorPoint.Y = e.GetPosition(BackPlane).Y;
                isDragging = true;
            }
        }

        private void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDragging)
            {
                double x = e.GetPosition(BackPlane).X;
                double y = e.GetPosition(BackPlane).Y;

                Rect.SetValue(Canvas.LeftProperty, Math.Min(x, anchorPoint.X));
                Rect.SetValue(Canvas.TopProperty, Math.Min(y, anchorPoint.Y));

                Rect.Width = Math.Abs(x - anchorPoint.X);
                Rect.Height = Math.Abs(y - anchorPoint.Y);

                if (Rect.Visibility != Visibility.Visible)
                    Rect.Visibility = Visibility.Visible;
            }
        }

        private void ResetRect()
        {
            Rect.Visibility = Visibility.Collapsed;
            isDragging = false;
        }

        private void LayoutRoot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var imageStream = File.OpenRead(actualFileName);

            var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile,
                    BitmapCacheOption.Default);

            var height = decoder.Frames[0].PixelHeight;
            var width = decoder.Frames[0].PixelWidth;

            var hmul = height / ImageToCrop.ActualHeight;
            var wmul = width / ImageToCrop.ActualWidth;


            //area sizes
            int rectx = (int)Math.Round(anchorPoint.X * wmul);
            int recty = (int)Math.Round(anchorPoint.Y * hmul);
            int rectwidth = (int)Math.Round(Rect.Width * wmul);
            int rectheight = (int)Math.Round(Rect.Height * hmul);

            if (MessageBox.Show($"Save this values: {rectx} {recty} {rectwidth} {rectheight} ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                areas.Add(new System.Drawing.Rectangle { X = rectx, Y = recty, Width = rectwidth, Height = rectheight });
                MessageBox.Show($"VALUES SAVED! TOTAL RECTANGLES: {areas.Count}");
            }

            ResetRect();
        }

        private void LayoutRoot_MouseLeave(object sender, MouseEventArgs e)
        {
            //ResetRect();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                actualFileName = openFileDialog.FileName;
                ImageToCrop.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(openFileDialog.FileName);
                OpenButton.Visibility = Visibility.Hidden;
                SaveButton.Visibility = Visibility.Visible;
                CanDrag = true;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string rects = string.Empty;
            rects += actualFileName + ":" + Environment.NewLine;
            foreach(var rect in areas)
            {
                rects += $"{rect.X}:{rect.Y}:{rect.Width}:{rect.Height}{Environment.NewLine}";
            }

            if (MessageBox.Show(rects, "Save This Rectangles?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "Crop_Areas.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, rects);
                }
            }
        }
    }
}
