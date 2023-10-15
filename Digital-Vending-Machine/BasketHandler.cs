using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Digital_Vending_Machine
{
    // ----- Basket_Handler Class -----
    //
    // This class handles:
    // • Adding of the shop items to the basket.
    // • Removing an item from the basket.
    // • Saving of old item quantities in-case of the user cancelling the order.
    // • Printing of the basket to a 'ListBox'.
    // • Keeping track of the total cost of the order.

    internal class Basket_Hander
    {
        private double m_TotalPrice;
        private List<KeyValuePair<Product_Item, int>> m_Items;   // Key = Product_Item, Value = Quantity

        public Basket_Hander()
        {
            m_TotalPrice = 0.0;
            m_Items = new List<KeyValuePair<Product_Item, int>>();
        }

        public void AddItem(Product_Item item)
        {
            m_TotalPrice += item.price;

            int index = m_Items.FindIndex(pair => pair.Key.productName == item.productName);

            if (index != -1)    // If the item already exists will increment the quantity variable.
            {
                m_Items[index] = new KeyValuePair<Product_Item, int>(item, m_Items[index].Value + 1);
            }
            else                // If the item doesnt exist will add the item to the basket.
            {
                m_Items.Add(new KeyValuePair<Product_Item, int>(item, 1));
            }
        }

        public void RemoveItem(Product_Item item, bool removeAll)   // Remove an item by the item's object.
        {
            int index = m_Items.FindIndex(pair => pair.Key.productName == item.productName);

            if (removeAll)  // If 'removeAll' is true it will completely remove the item without checking the quantity.
            {
                if (index != -1)
                {
                    m_TotalPrice -= item.price * m_Items[index].Value;

                    m_Items.RemoveAt(index);
                }
            }
            else            // If 'removeAll' is false.
            {
                m_TotalPrice -= item.price;

                if (index != -1)
                {
                    if (m_Items[index].Value == 1)  // Checks if the quantity is equal to one. If true it will remove the item.
                    {
                        m_Items.RemoveAt(index);
                    }
                    else                            // If the quantity is greater than one. It will minus one from the items quantity.
                    {
                        m_Items[index] = new KeyValuePair<Product_Item, int>(item, m_Items[index].Value - 1);
                    }
                }
            }
        }

        public void RemoveItemByIndex(int index, bool removeAll)    // Remove an item by the item's index within the basket.
        {
            if (removeAll)  // If 'removeAll' is true it will completely remove the item without checking the quantity.
            {
                m_TotalPrice -= m_Items[index].Key.price * m_Items[index].Value;

                m_Items.RemoveAt(index);
            }
            else            // If 'removeAll' is false.
            {
                m_TotalPrice -= m_Items[index].Key.price;

                if (m_Items[index].Value == 1)  // Checks if the quantity is equal to one. If true it will remove the item.
                {
                    m_Items.RemoveAt(index);
                }
                else                            // If the quantity is greater than one. It will minus one from the items quantity.
                {
                    m_Items[index] = new KeyValuePair<Product_Item, int>(m_Items[index].Key, m_Items[index].Value - 1);
                }
            }
        }

        public void PrintBasketToListBox(ListBox listBox)   // Prints all items in the basket to a 'ListBox' in the format: E.g. "• Item One x2".
        {
            listBox.Items.Clear();

            foreach (KeyValuePair<Product_Item, int> pair in m_Items)
            {
                listBox.Items.Add($"• {pair.Key.name} x{pair.Value}");
            }
        }

        public void MinusAmount(double value)
        {
            m_TotalPrice -= value;
        }

        public void PrintBasketToFile(string fileName)  // Prints all the items in the basket to a log file.
        {
            StreamWriter writer = new StreamWriter($"{Environment.CurrentDirectory}\\{fileName}.txt", true);

            writer.WriteLine($"Order Information - User: {Environment.UserName}, Date: {DateTime.Now.ToString("dd/MM/yyyy")}, Time: {DateTime.Now.ToString("HH:mm:ss")}");
            writer.WriteLine("{");
            writer.WriteLine("\tOrdered Items:");

            foreach (KeyValuePair<Product_Item, int> pair in m_Items)
            {
                writer.WriteLine($"\t  • {pair.Key.productName} x{pair.Value}. {pair.Key.price:C} per item.");
            }

            writer.WriteLine($"\tTotal Price: {CalculateTotalPrice():C}");
            writer.WriteLine($"\tChange Given: {Math.Abs(m_TotalPrice):C}");
            writer.WriteLine("}");
            writer.WriteLine();

            writer.Close();
        }

        public void Cancel(List<Product_Item> items)    // Clears the basket and re-populates the original items list with the original quantities.
        {
            foreach (KeyValuePair<Product_Item, int> pair in m_Items)
            {
                int index = items.FindIndex(item => item.productName == pair.Key.productName);

                if (index != -1)
                {
                    items[index].stockCount += pair.Value;
                }
            }

            Clear();
        }

        public double CalculateTotalPrice() // Calculates the total price of the basket.
        {
            double totalPrice = 0.0;

            foreach (KeyValuePair<Product_Item, int> pair in m_Items)
            {
                totalPrice += pair.Key.price * pair.Value;
            }

            return totalPrice;
        }

        public void Clear() // Clears the basket.
        {
            m_TotalPrice = 0;
            m_Items = new List<KeyValuePair<Product_Item, int>>();
        }

        public int count
        {
            get { return m_Items.Count; }
        }

        public double total
        {
            get { return m_TotalPrice; }
        }
    }
}
