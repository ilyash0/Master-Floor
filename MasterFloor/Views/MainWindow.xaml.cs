using MasterFloor.Models;
using MasterFloor.ViewModels;
using MasterFloor.Views;
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

namespace MasterFloor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public static readonly MainWindow Instance = (MainWindow)Application.Current.MainWindow;
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}