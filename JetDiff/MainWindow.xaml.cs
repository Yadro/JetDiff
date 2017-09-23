using System.Diagnostics;
using System.Linq;
using System.Windows;

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
            string fileName = JetDiff.Properties.Settings.Default.DiffPath;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = fileName,
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
