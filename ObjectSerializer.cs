using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Linq.Expressions;

namespace oopsiewoopsie_stock_tool
{
    public class ObjectSerializer
    {
        public ObservableCollection<StockItem> stockItems = new ObservableCollection<StockItem>();

        XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<StockItem>));
        
        public void Save()
        {
            using (StreamWriter wr = new StreamWriter("StockItems.xml"))
            {
                xs.Serialize(wr, stockItems);
            }
        }

        public void Load()
        {
            if(!File.Exists("StockItems.xml"))
            {
                //FileStream fs = File.Create("StockItems.xml");
                
                using (StreamWriter sw = File.AppendText("StockItems.xml"))
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                    sw.WriteLine("<ArrayOfStockItem xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ");
                    sw.WriteLine("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
                    sw.WriteLine("  <StockItem>");
                    sw.WriteLine("    <ItemName>Item Name</ItemName>");
                    sw.WriteLine("    <ItemAmount>0</ItemAmount>");
                    sw.WriteLine("  </StockItem>");
                    sw.WriteLine("</ArrayOfStockItem>");
                }
            }

            using (StreamReader rd = new StreamReader("StockItems.xml"))
            {
                stockItems = xs.Deserialize(rd) as ObservableCollection<StockItem>;
            }
        }
        
    }
}
