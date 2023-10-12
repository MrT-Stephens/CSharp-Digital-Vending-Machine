using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Vending_Machine
{
    public partial class Digital_Vending_Machine : Form
    {
        private List<Product_Item> m_ProductItems = new List<Product_Item>();

        private void AddProductItem(string imagePath, string name, double price, int quantity)
        {
            m_ProductItems.Add(new Product_Item(imagePath, name, price, quantity));
        }

        private void SetUpShopItems()
        {
            int rowColCount = m_ProductItems.Count / 2;

            Shop_Items_Layout.ColumnCount = rowColCount;
            Shop_Items_Layout.RowCount = rowColCount;

            for (int  i = 0; i < m_ProductItems.Count; i++)
            {
                Shop_Items_Layout.Controls.Add(m_ProductItems[i], i % 2, i % 2);
            }
        }

        public Digital_Vending_Machine()
        {
            InitializeComponent();

            AddProductItem("C:\\Users\\MrTst\\Documents\\C++ Dev\\Digital-Vending-Machine\\Digital-Vending-Machine\\App_Images\\cola.png", "Coke", 1.50, 10);
            AddProductItem("C:\\Users\\MrTst\\Documents\\C++ Dev\\Digital-Vending-Machine\\Digital-Vending-Machine\\App_Images\\pepsi.png", "Pepsi", 1.50, 10);

            SetUpShopItems();
        }
    }
}
