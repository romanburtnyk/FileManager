using System.Windows;
using System.Windows.Input;
using WpfUtils;

namespace FileManager.ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = CompositionService.GetExportedValue<MainViewModel>();
            mainViewModel.Initialize();
            DataContext = mainViewModel;
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
