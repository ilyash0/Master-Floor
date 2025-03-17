using MasterFloor.Models;
using MasterFloor.ViewModels;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for PartnerProductListPage.xaml
    /// </summary>
    public partial class PartnerProductListPage : Page
    {
        public PartnerProductListPage(Partner partner)
        {
            InitializeComponent();
            productsList.ItemsSource = ViewModel.GetPartnersProductsForView(partner.Id);
            MainWindow.Instance.SetTitle($"Продукция {partner.PartnerTypeEntity.Name} «{partner.Name}»");
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Navigate(new ListPage());
        }
    }
}
