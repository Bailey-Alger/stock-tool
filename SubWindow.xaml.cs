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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace oopsiewoopsie_stock_tool
{
    public partial class SubWindow : Window
    {
        public ObjectSerializer objectSerializer = new ObjectSerializer();
        public ObservableCollection<StockItem> StockItems { get; set; }

        public SubWindow()
        {
            InitializeComponent();
            
            objectSerializer.Load();

            StockItems = objectSerializer.stockItems;

            subStockItems.ItemsSource = StockItems;
        }

        public void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            StockItems.Remove((sender as FrameworkElement).DataContext as StockItem);
        }

        public void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            StockItems.Add(new StockItem());
        }
        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            objectSerializer.Save();
            Close();
            
        }
        private void TextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
