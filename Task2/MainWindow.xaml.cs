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
using System.Xml;
using System.Xml.Linq;
using Task2.BLL;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkDB db = new WorkDB();
        static List<Currency> currencies = new List<Currency>();
        public MainWindow()
        {
            InitializeComponent();
            currencies = db.ReadXml();
            ComboBoxInput.Items.Add("KZT");
            foreach (var item in currencies)
            {
                ComboBoxOutPut.Items.Add(item.title);
            }
        }
        bool check = true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (input_txt.Text != "")
            {
                if (ComboBoxInput.SelectedItem != null && ComboBoxOutPut.SelectedItem != null)
                {
                    OutPut_txt.Text = WorkDB.ConvertValue(currencies, input_txt.Text, ComboBoxInput.Text, ComboBoxOutPut.Text, check);
                }
                else MessageBox.Show("Выберите валюту для конвертации");

            }
            else MessageBox.Show("Введите сумму для конвертации");
        }

        private void ComboBoxInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ComboBoxOutPut_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (check)
            {
                ComboBoxInput.Items.Clear();
                ComboBoxOutPut.Items.Clear();
                ComboBoxOutPut.Items.Add("KZT");
                foreach (var item in currencies)
                {
                    ComboBoxInput.Items.Add(item.title);
                }
                check = false;
            }
            else
            {
                ComboBoxInput.Items.Clear();
                ComboBoxOutPut.Items.Clear();
                ComboBoxInput.Items.Add("KZT");
                foreach (var item in currencies)
                {
                    ComboBoxOutPut.Items.Add(item.title);
                }
                check = true;
            }
        }
    }
}
