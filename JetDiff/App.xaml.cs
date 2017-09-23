using System.Windows;

namespace JetDiff
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnExit(object sender, ExitEventArgs e)
        {
            JetDiff.Properties.Settings.Default.Save();
        }
    }
}
