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
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace oopsiewoopsie_stock_tool
{
    public partial class MainWindow : Window
    {
        public ObjectSerializer objectSerializer = new ObjectSerializer();

        public ObservableCollection<StockItem> StockItems { get; set; }

        public SubWindow subWindow = new SubWindow();
        public MainWindow()
        {
            InitializeComponent();

            objectSerializer.Load();

            StockItems = objectSerializer.stockItems;

            mainStockItems.ItemsSource = objectSerializer.stockItems;

        }


        public void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.subWindow = new SubWindow();

            subWindow.Closed += (s, EventArgs) =>
            {
                objectSerializer.Load();
                mainStockItems.ItemsSource = objectSerializer.stockItems;
            };

            this.subWindow.ShowDialog();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            objectSerializer.Load();
            mainStockItems.ItemsSource = objectSerializer.stockItems;
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Panel grid = button.Parent as Panel;
            TextBox textBox = grid.Children.OfType<TextBox>().FirstOrDefault(x => x.Name == "ItemAmountText");
            string text = textBox.Text;
            int amount = int.Parse(text);
            amount++;
            textBox.Text = amount.ToString();
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Panel grid = button.Parent as Panel;
            TextBox textBox = grid.Children.OfType<TextBox>().FirstOrDefault(x => x.Name == "ItemAmountText");
            string text = textBox.Text;
            int amount = int.Parse(text);
            amount--;
            textBox.Text = amount.ToString();
        }

        private void TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
