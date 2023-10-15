using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Digital_Vending_Machine
{
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

            int index = m_Items.FindIndex(pair => pair.Key.name == item.name);

            if (index != -1)
            {
                m_Items[index] = new KeyValuePair<Product_Item, int>(item, m_Items[index].Value + 1);
            }
            else
            {
                m_Items.Add(new KeyValuePair<Product_Item, int>(item, 1));
            }
        }

        public void RemoveItem(Product_Item item, bool removeAll)
        {
            int index = m_Items.FindIndex(pair => pair.Key.name == item.name);

            if (removeAll)
            {
                if (index != -1)
                {
                    m_TotalPrice -= item.price * m_Items[index].Value;

                    m_Items.RemoveAt(index);
                }
            }
            else
            {
                m_TotalPrice -= item.price;

                if (index != -1)
                {
                    if (m_Items[index].Value == 1)
                    {
                        m_Items.RemoveAt(index);
                    }
                    else
                    {
                        m_Items[index] = new KeyValuePair<Product_Item, int>(item, m_Items[index].Value - 1);
                    }
                }
            }
        }

        public void RemoveItemByIndex(int index, bool removeAll)
        { 
            if (removeAll)
            {
                m_TotalPrice -= m_Items[index].Key.price * m_Items[index].Value;

                m_Items.RemoveAt(index);
            }
            else
            {
                m_TotalPrice -= m_Items[index].Key.price;

                if (m_Items[index].Value == 1)
                {
                    m_Items.RemoveAt(index);
                }
                else
                {
                    m_Items[index] = new KeyValuePair<Product_Item, int>(m_Items[index].Key, m_Items[index].Value - 1);
                }
            }
        }

        public void PrintBasketToListBox(ListBox listBox)
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

        public void Cancel(List<Product_Item> items)
        {
            foreach (KeyValuePair<Product_Item, int> pair in m_Items)
            {
                int index = items.FindIndex(item => item.name == pair.Key.name);

                if (index != -1)
                {
                    items[index].stockCount += pair.Value;
                }
            }

            Clear();
        }

        public void Clear()
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

    public partial class Digital_Vending_Machine : Form
    {
        const string m_ImageDirectory = "C:\\Users\\MrTst\\Documents\\C++ Dev\\Digital-Vending-Machine\\Digital-Vending-Machine\\App_Images\\";

        // Dynamic shop items
        private List<Product_Item> m_ProductItems;

        // Slide out panel items
        private Panel m_SlideOutPanel;
        private Timer m_SlideOutTimer;
        private bool m_IsPanelVisible = false;
        private TableLayoutPanel m_SlideOutLayout;
        private List<Coin_Item> m_CoinItems;
        private Coin_Slot m_PaymentBox;

        // Form title and date time items
        private string m_Title;
        private Timer m_TitleDateTimeTimer;

        // Other form items
        private Basket_Hander m_BasketHander;
        private ContextMenu m_ListBoxContextMenu;
        private MenuItem m_ListBoxRemoveOne;
        private MenuItem m_ListBoxRemoveAll;

        public Digital_Vending_Machine()
        {
            InitializeComponent();

            m_CoinItems = new List<Coin_Item>();
            m_BasketHander = new Basket_Hander();
            m_ProductItems = new List<Product_Item>();
            this.MinimumSize = new Size(900, 800);
            this.SizeChanged += (sender, e) =>
            {
                CalculateAutoScrollMinSize();
            };

            AddProductItem("Rowntrees-Fruit-Pastilles.png", "Rowntree's Fruit Pastilles", 1.25, 150);
            AddProductItem("Rowntrees-Jelly-Tots.png", "Rowntree's Jelly Tots", 1.10, 5);
            AddProductItem("Rowntrees-Randoms-Sweets.png", "Rowntree's Randoms Sweets", 1.70, 100);
            AddProductItem("Fruittella-Duo-Stix.png", "Fruittella Duo Stix", 1.29, 10);
            AddProductItem("Haribo-Supermix.png", "Haribo Supermix", 1.20, 200);
            AddProductItem("Rowntrees-Fruit-Gums.png", "Rowntree's Fruit Gums", 1.25, 140);
            AddProductItem("Starburst-Original-Fruit.png", "Starburst Original Fruit", 1.10, 10);
            AddProductItem("Skittles-Fruits.png", "Skittles Fruits", 1.50, 10);
            AddProductItem("Skittles-Crazy-Sour-Fruit.png", "Skittles Crazy Sour Fruit", 1.59, 15);
            AddProductItem("Rowntrees-Fruit-Pastilles-Strawberry-&-Blackcurrant.png", "Rowntree's Fruit Pastilles Strawberry & Blackcurrant", 1.60, 19);
            AddProductItem("Haribo-Maoam-Pinballs.png", "Haribo Maoam Pinballs", 1.90, 75);
            AddProductItem("Swizzels-Luscious-Lollies.png", "Swizzels Luscious Lollies", 2.00, 24);
            AddProductItem("Haribo-Maoam-Joystixx.png", "Haribo Maoam Joystixx", 1.55, 19);
            AddProductItem("Swizzels-Drumstick-Squashies.png", "Swizzels Drumstick Squashies", 0.90, 15);
            AddProductItem("Haribo-Giant-Strawbs-Fruit-Gums.png", "Haribo Giant Strawbs Fruit Gums", 1.90, 99);
            AddProductItem("Haribo-Tangfastics-175G.png", "Haribo Tangfastics", 1.53, 50);
            AddProductItem("Haribo-Starmix-175G.png", "Haribo Starmix", 0.99, 54);
            AddProductItem("Maynards-Bassetts-Jelly-Babies.png", "Maynards Bassetts Jelly Babies", 1.19, 119);
            AddProductItem("Maynards-Bassetts-Sports-Mix.png", "Maynards Bassetts Sports Mix", 1.43, 14);
            AddProductItem("Maynards-Bassetts-Wine-Gums-Juicies.png", "Maynards Bassetts Wine Gums", 1.05, 14);

            AddCoinItem("5pound.jpg", "Five Pound", 5.00);
            AddCoinItem("10pound.jpg", "Ten Pound", 10.00);
            AddCoinItem("20pound.jpg", "Twenty Pound", 20.00);
            AddCoinItem("1p.jpg", "One Pence", 0.01);
            AddCoinItem("2p.jpg", "Two Pence", 0.02);
            AddCoinItem("5p.jpg", "Five Pence", 0.05);
            AddCoinItem("10p.jpg", "Ten Pence", 0.10);
            AddCoinItem("20p.jpg", "Twenty Pence", 0.20);
            AddCoinItem("50p.jpg", "Fifty Pence", 0.50);
            AddCoinItem("1pound.jpg", "One Pound", 1.00);
            AddCoinItem("2pound.jpg", "Two Pound", 2.00);

            SetUpShopItems();
            SetUpSlideOutPanel();
            SetUpTitleDateTime();
            SetUpListBoxContextMenu();

            CalculateAutoScrollMinSize();
        }

        private void CalculateAutoScrollMinSize()
        {
            int height = 0;

            foreach (Control control in m_ProductItems)
            {
                height += control.MinimumSize.Height;
            }

            Shop_Items_Layout.AutoScrollMinSize = new Size(300, height / (Shop_Items_Layout.RowCount < 3 ? 3 : Shop_Items_Layout.RowCount / 3));
        }

        private void AddProductItem(string imageFile, string name, double price, int quantity)
        {
            m_ProductItems.Add(new Product_Item($"{m_ImageDirectory}{imageFile}", name, price, quantity));
        }

        private void AddCoinItem(string imageFile, string name, double value)
        {
            m_CoinItems.Add(new Coin_Item($"{m_ImageDirectory}{imageFile}", name, value));
        }

        private void SetUpShopItems()
        {
            Shop_Items_Layout.ColumnCount = 3;
            Shop_Items_Layout.Dock = DockStyle.Fill;

            int numRows = (int)Math.Ceiling((double)m_ProductItems.Count / Shop_Items_Layout.ColumnCount);

            Shop_Items_Layout.RowCount = numRows;

            for (int i = 0; i < 3; i++)
            {
                Shop_Items_Layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f / 3.0f));
            }

            for (int i = 0; i < numRows; i++)
            {
                Shop_Items_Layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f / (float)numRows));
            }

            foreach (Product_Item control in m_ProductItems)
            {
                Shop_Items_Layout.Controls.Add(control);

                control.click += (sender, e) =>
                {
                    Product_Item productItem = (Product_Item)sender;

                    m_BasketHander.AddItem(productItem);

                    Price_TextBox.Text = $"Total: {m_BasketHander.total:C}";

                    m_BasketHander.PrintBasketToListBox(Basket_Listbox);

                    Basket_Listbox.SelectedIndex = Basket_Listbox.Items.Count - 1;
                    Basket_Listbox.SelectedIndex = -1;
                };
            }

            Shop_Items_Panel.Controls.Add(Shop_Items_Layout);
        }

        private void SetUpSlideOutPanel()
        {
            // Set up the slide out panel
            m_SlideOutPanel = new Panel();
            m_SlideOutPanel.Width = 0;
            m_SlideOutPanel.Dock = DockStyle.Left;
            m_SlideOutPanel.BackColor = SystemColors.Control;
            this.Controls.Add(m_SlideOutPanel);

            // Set up the slide out timer
            m_SlideOutTimer = new Timer();
            m_SlideOutTimer.Interval = 1;
            m_SlideOutTimer.Tick += SlideOutTimer_Tick;

            // Set up the panel items
            m_SlideOutLayout = new TableLayoutPanel();
            m_SlideOutLayout.Dock = DockStyle.Fill;
            m_SlideOutLayout.ColumnCount = 3;

            int numRows = (int)Math.Ceiling((double)m_CoinItems.Count / m_SlideOutLayout.ColumnCount);

            m_SlideOutLayout.RowCount = numRows;

            for (int i = 0; i < 3; i++)
            {
                m_SlideOutLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f / 3.0f));
            }

            for (int i = 0; i < numRows; i++)
            {
                m_SlideOutLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f / (float)numRows));
            }

            foreach (Coin_Item coin in m_CoinItems)
            {
                m_SlideOutLayout.Controls.Add(coin);
            }

            m_PaymentBox = new Coin_Slot($"{m_ImageDirectory}Coin-Slot.jpg");
            m_PaymentBox.drop += OnClickOrDrop;

            m_SlideOutLayout.Controls.Add(m_PaymentBox);

            m_SlideOutPanel.Controls.Add(m_SlideOutLayout);
        }

        private void SetUpListBoxContextMenu()
        {
            m_ListBoxContextMenu = new ContextMenu();
            m_ListBoxRemoveAll = new MenuItem("Remove All");
            m_ListBoxRemoveOne = new MenuItem("Remove One");

            m_ListBoxRemoveAll.Click += (sender, e) =>
            {
                if (Basket_Listbox.SelectedIndex == -1)
                {
                    return;
                }
                else if (m_BasketHander.count > 0)
                {
                    int index = Basket_Listbox.SelectedIndex;

                    m_BasketHander.RemoveItemByIndex(index, true);

                    Price_TextBox.Text = $"Total: {m_BasketHander.total:C}";

                    m_BasketHander.PrintBasketToListBox(Basket_Listbox);
                }
            };

            m_ListBoxRemoveOne.Click += (sender, e) =>
            {
                if (Basket_Listbox.SelectedIndex == -1)
                {
                    return;
                }
                else if (m_BasketHander.count > 0)
                {
                    int index = Basket_Listbox.SelectedIndex;

                    m_BasketHander.RemoveItemByIndex(index, false);

                    Price_TextBox.Text = $"Total: {m_BasketHander.total:C}";

                    m_BasketHander.PrintBasketToListBox(Basket_Listbox);
                }
            };

            m_ListBoxContextMenu.MenuItems.Add(m_ListBoxRemoveAll);
            m_ListBoxContextMenu.MenuItems.Add(m_ListBoxRemoveOne);

            Basket_Listbox.ContextMenu = m_ListBoxContextMenu;
        }

        private void OnClickOrDrop(object sender, StringEventArgs e)
        {
            double coinValue = 0.0;

            if (double.TryParse(e.String.Remove(0, 1), out coinValue))
            {
                m_BasketHander.MinusAmount(coinValue);

                Price_TextBox.Text = $"Total: {m_BasketHander.total:C}";

                if (m_BasketHander.total > 0)
                {
                    return;
                }
                else if (m_BasketHander.total == 0)
                {
                    MessageBox.Show(this, "Thank you for your purchase!", "Purchase Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (m_BasketHander.total < 0)
                {
                    MessageBox.Show(this, $"Thank you for your purchase! Your change is {Math.Abs(m_BasketHander.total):C}", "Purchase Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Basket_Listbox.Items.Clear();
                Price_TextBox.Text = $"Total: {0.00:C}";
                m_BasketHander.Clear();
                m_SlideOutTimer.Start();
                Shop_Items_Panel.Enabled = !Shop_Items_Panel.Enabled;
                Checkout_Button.Enabled = !Checkout_Button.Enabled;
            }
        }

        private void SetUpTitleDateTime()
        {
            m_Title = this.Text;
            this.Text = $"{m_Title} • {DateTime.Now.ToString("dd/MM/yyyy")} • {DateTime.Now.ToString("HH:mm:ss")}";

            m_TitleDateTimeTimer = new Timer();
            m_TitleDateTimeTimer.Interval = 1000;
            m_TitleDateTimeTimer.Tick += TitleDateTimeTimer_Tick;
            m_TitleDateTimeTimer.Start();
        }

        private void Checkout_Button_Click(object sender, EventArgs e)
        {
            if (Basket_Listbox.Items.Count == 0)
            {
                return;
            }

            m_SlideOutTimer.Start();
            Shop_Items_Panel.Enabled = !Shop_Items_Panel.Enabled;
            Checkout_Button.Enabled = !Checkout_Button.Enabled;
        }

        private void SlideOutTimer_Tick(object sender, EventArgs e)
        {
            int targetWidth = m_IsPanelVisible ? 0 : (int)Math.Round((this.Width / 2) / 100.0) * 100; ;

            if (m_SlideOutPanel.Width != targetWidth)
            {
                if (m_IsPanelVisible)
                {
                    m_SlideOutPanel.Width -= 100;
                }
                else
                {
                    m_SlideOutPanel.Width += 100;
                }

                m_SlideOutPanel.BringToFront();
            }
            else
            {
                m_SlideOutTimer.Stop();
                m_IsPanelVisible = !m_IsPanelVisible;
            }
        }

        private void TitleDateTimeTimer_Tick(object sender, EventArgs e)
        {
            this.Text = $"{m_Title} • {DateTime.Now.ToString("dd/MM/yyyy")} • {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void Cancel_Order_Button_Click(object sender, EventArgs e)
        {
            if (Basket_Listbox.Items.Count == 0)
            {
                return;
            }

            if (MessageBox.Show(this, "Are you sure you want to cancel your order?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Basket_Listbox.Items.Clear();
                Price_TextBox.Text = $"Total: {0.00:C}";
                m_BasketHander.Cancel(m_ProductItems);

                if (m_IsPanelVisible)
                {
                    m_SlideOutTimer.Start();
                    Shop_Items_Panel.Enabled = !Shop_Items_Panel.Enabled;
                    Checkout_Button.Enabled = !Checkout_Button.Enabled;
                }
            }
        }

        private void OutputFile(string filePath)
        {

        }
    }
}