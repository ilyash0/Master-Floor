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
    public partial class MainWindow : Window
    {
        public static readonly MainWindow Instance = (MainWindow)Application.Current.MainWindow;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Views.ListPage());
        }

        public void Navigate(Page page)
        {
            MainFrame.Navigate(page);
        }

        public void SetTitle(string title)
        {
            Title = title;
            headerTitle.Text = title;
        }
    }
}