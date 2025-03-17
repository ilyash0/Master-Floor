using MasterFloor.Models;
using MasterFloor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MaterialCalculation.xaml
    /// </summary>
    public partial class MaterialCalculation : Page
    {
        public MaterialCalculation()
        {
            InitializeComponent();
            MainWindow.Instance.SetTitle("Расчёт количества материала");
            comboBoxProductType.ItemsSource = ViewModel.GetProductTypesForView();
            comboBoxMaterialType.ItemsSource = ViewModel.GetMaterialTypesForView();
            var a = (ComboBox)comboBoxProductType.SelectedItem;
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int productTypeId = ((ProductType)comboBoxProductType.SelectedItem).Id;
            int materialTypeId = ((MaterialType)comboBoxMaterialType.SelectedItem).Id;

            if (!int.TryParse(txtQuantity.Text, out int quantity) ||
                !double.TryParse(txtWidth.Text, out double width) ||
                !double.TryParse(txtLength.Text, out double length))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректными значениями.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (width <= 0 || length <= 0 || quantity <= 0)
            {
                MessageBox.Show("Ширина, длина и количество продукции должны быть положительными числами.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int requiredMaterial = Utils.CalculateRequiredMaterial(productTypeId, materialTypeId, quantity, width, length);

            if (requiredMaterial == -1)
            {
                txtResult.Text = "Ошибка: неверные типы продукции или материала.";
            }
            else
            {
                txtResult.Text = $"Необходимое количество материала: {requiredMaterial}";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Navigate(new ListPage());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+"); // Все, кроме цифр
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^.0-9]+"); // Все, кроме цифр и .
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
