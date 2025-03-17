using MasterFloor.Models;
using MasterFloor.ViewModels;
using Sprache;
using System;
using System.Collections.Generic;
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

namespace MasterFloor.Views
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public ListPage()
        {
            InitializeComponent();
            partnersList.ItemsSource = ViewModel.GetPartnersForView();
            MainWindow.Instance.SetTitle("Мастер Пол. Партнёры");
        }
        private void CreatePartner_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Navigate(new PartnerEditPage());
        }

        private void PartnersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (listBox.SelectedItem is Partner partner)
            {
                MainWindow.Instance.Navigate(new PartnerEditPage(partner));
            }
        }
        private void ViewPartnerProduct_Click(object sender, RoutedEventArgs e)
        {
            if (partnersList.SelectedItem is Partner partner)
            {
                MainWindow.Instance.Navigate(new PartnerProductListPage(partner));
            }
        }

        private void ViewMaterialCalculation_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Navigate(new MaterialCalculation());
        }
    }
}
