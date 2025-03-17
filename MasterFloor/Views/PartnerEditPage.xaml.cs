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
    /// Interaction logic for PartnerEditPage.xaml
    /// </summary>
    public partial class PartnerEditPage : Page
    {
        private readonly Partner _currentPartner;
        public PartnerEditPage()
        {
            InitializeComponent();
            _currentPartner = new();
            Init("Новый партнёр");
        }

        public PartnerEditPage(Partner partner)
        {
            InitializeComponent();
            _currentPartner = partner;
            Init($"{_currentPartner.PartnerTypeEntity.Name} «{_currentPartner.Name}»");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Navigate(new ListPage());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAllFieldsValid())
            {
                return;
            }

            try
            {
                // Если партнёр новый (Id равен 0), добавляем его, иначе обновляем существующего
                if (_currentPartner.Id == 0)
                {
                    ViewModel.CreateNewPartner(_currentPartner);
                }
                else
                {
                    ViewModel.UpdatePartner(_currentPartner);
                }
                MessageBox.Show("Партнёр успешно сохранён.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow.Instance.Navigate(new ListPage());
            }
            catch
            {
                MessageBox.Show($"Ошибка при сохранении. Обратитесь к администратору", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+"); // Все, кроме цифр
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Init(string title)
        {
            comboBoxPartnerType.ItemsSource = ViewModel.GetPartnerTypesForView();
            DataContext = _currentPartner;
            MainWindow.Instance.SetTitle(title);
        }

        private bool IsAllFieldsValid()
        {
            if (string.IsNullOrWhiteSpace(txtPartnerName.Text))
            {
                MessageBox.Show("Поле 'Наименование' обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (comboBoxPartnerType.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать тип партнёра.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!int.TryParse(txtRating.Text, out int rating) || rating < 0)
            {
                MessageBox.Show("Поле 'Рейтинг' должно быть неотрицательным целым числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Поле 'Адрес' обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDirector.Text))
            {
                MessageBox.Show("Поле 'ФИО директора' обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Поле 'Телефон' обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Поле 'Email' обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtInn.Text))
            {
                MessageBox.Show("Поле 'ИНН' обязательно для заполнения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
