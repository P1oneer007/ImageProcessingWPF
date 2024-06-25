using System.IO;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using Window = System.Windows.Window;
using System.Runtime.InteropServices;

namespace ImageProcessingWPF;

public partial class MainWindow : Window
{
    private ushort[,,] _currentImage;
    public MainWindow()
    {
        InitializeComponent();
    }
    private void LoadRawImage_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        openFileDialog.Filter = "Raw Image Files (*.raw)|*.raw";
        if (openFileDialog.ShowDialog() == true)
        {
            _currentImage = Tools.ReadRaw(openFileDialog.FileName);
            DisplayImage(ImageView, _currentImage);
        }

    }

    private void LoadImageByOpenCV_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
        if (openFileDialog.ShowDialog() == true)
        {
            _currentImage = Tools.ReadImageByOpenCV(openFileDialog.FileName);
            DisplayImage(ImageView, _currentImage);
        }
    }

    private void SaveImageByOpenCV_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
        saveFileDialog.Filter = "PNG Image (*.png)|*.png";
        if (saveFileDialog.ShowDialog() == true)
        {
            Tools.WriteImageByOpenCV(System.IO.Path.GetDirectoryName(saveFileDialog.FileName), System.IO.Path.GetFileNameWithoutExtension(saveFileDialog.FileName), _currentImage);
        }
    }

    private void NormalizeImage_Click(object sender, RoutedEventArgs e)
    {
        _currentImage = Tools.Normalize(_currentImage);
        DisplayImage(ImageView, _currentImage);
    }

    private void GammaCorrection_Click(object sender, RoutedEventArgs e)
    {
        Tools.GammaCorrection(_currentImage, 1.2);
        DisplayImage(ImageView, _currentImage);
    }

    private void InvertImage_Click(object sender, RoutedEventArgs e)
    {
        Tools.Invert(_currentImage);
        DisplayImage(ImageView, _currentImage);
    }

    private void HistogramEqualization_Click(object sender, RoutedEventArgs e)
    {
        _currentImage = Tools.HistEqualization(_currentImage);
        DisplayImage(ImageView, _currentImage);
    }

    private void MedianFilter_Click(object sender, RoutedEventArgs e)
    {
        _currentImage = Tools.MedianFilter(_currentImage, 5);
        DisplayImage(ImageView, _currentImage);
    }

    private void BoxFilter_Click(object sender, RoutedEventArgs e)
    {
        _currentImage = Tools.BoxFilter(_currentImage, 5);
        DisplayImage(ImageView, _currentImage);
    }

    private void BilateralFilter_Click(object sender, RoutedEventArgs e)
    {
        _currentImage = Tools.BilateralFilter(_currentImage, 3, 10);
        DisplayImage(ImageView, _currentImage);
    }

    private void GaussianFilter_Click(object sender, RoutedEventArgs e)
    {
        _currentImage = Tools.Gaussian(_currentImage, 5, 0.8);
        DisplayImage(ImageView, _currentImage);
    }

    private void SharpenFilter_Click(object sender, RoutedEventArgs e)
    {
        _currentImage = Tools.Sharpen(_currentImage, 1.0, false);
        DisplayImage(ImageView, _currentImage);
    }

    private void DisplayImage(Image imageControl, ushort[,,] image)
    {
        Tools.DisplayTensor(image);

        int height = image.GetLength(0);
        int width = image.GetLength(1);
        int channels = image.GetLength(2);
        byte[] pixels = new byte[height * width * channels];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int c = 0; c < channels; c++)
                {
                    pixels[y * width * channels + x * channels + c] = (byte)(image[y, x, c] >> 8);
                }
            }
        }
        BitmapSource bitmapSource = BitmapSource.Create(
            width, height, 96, 96, System.Windows.Media.PixelFormats.Bgr24,
            null, pixels, width * channels);

        imageControl.Source = bitmapSource;
    }
}
