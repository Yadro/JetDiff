using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace JetDiff
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var leftPath = LeftPath.Text;
            var rightPath = RightPath.Text;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "C:\\Program Files (x86)\\JetBrains\\PhpStorm 2016.3.3\\bin\\phpstorm64.exe",
                Arguments = $"diff {leftPath} {rightPath}"
            };
            Process.Start(startInfo);
        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.All;
            else
                e.Effects = DragDropEffects.None;
        }

        private void LeftPath_OnDrop(object sender, DragEventArgs e)
        {
            LeftPath.Text = GetFilePath(e);
        }

        private void RightPath_OnDrop(object sender, DragEventArgs e)
        {
            RightPath.Text = GetFilePath(e);
        }

        private string GetFilePath(DragEventArgs e)
        {
            var data = (string[]) e.Data.GetData("FileDrop", false);
            return data != null ? data.First() : "";
        }
    }
}
