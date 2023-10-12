using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Digital_Vending_Machine
{
    public partial class Digital_Vending_Machine : Form
    {
        // Dynamic shop items
        private List<Product_Item> m_ProductItems;

        // Slide out panel items
        private Panel m_SlideOutPanel;
        private Timer m_SlideOutTimer;
        private bool m_IsPanelVisible = false;

        // Form title and date time items
        private string m_Title;
        private Timer m_TitleDateTimeTimer;

        // Other form items
        private double m_TotalPrice = 0.0;
        private List<int> m_PreviousProductQuantities;

        public Digital_Vending_Machine()
        {
            InitializeComponent();

            m_ProductItems = new List<Product_Item>();
            this.MinimumSize = new Size(900, 800);
            this.SizeChanged += (sender, e) => 
            { 
                CalculateAutoScrollMinSize();
            };

            AddProductItem("Rowntrees-Fruit-Pastilles.png", "Rowntree's Fruit Pastilles", 1.50, 10);
            AddProductItem("Rowntrees-Jelly-Tots.png", "Rowntree's Jelly Tots", 1.50, 10);
            AddProductItem("Rowntrees-Randoms-Sweets.png", "Rowntree's Randoms Sweets", 1.50, 10);
            AddProductItem("Fruittella-Duo-Stix.png", "Fruittella Duo Stix", 1.50, 10);
            AddProductItem("Haribo-Supermix.png", "Haribo Supermix", 1.50, 10);
            AddProductItem("Rowntrees-Fruit-Gums.png", "Rowntree's Fruit Gums", 1.50, 10);
            AddProductItem("Starburst-Original-Fruit.png", "Starburst Original Fruit", 1.50, 10);
            AddProductItem("Skittles-Fruits.png", "Skittles Fruits", 1.50, 10);
            AddProductItem("Skittles-Crazy-Sour-Fruit.png", "Skittles Crazy Sour Fruit", 1.50, 10);
            AddProductItem("Rowntrees-Fruit-Pastilles-Strawberry-&-Blackcurrant.png", "Rowntree's Fruit Pastilles Strawberry & Blackcurrant", 1.50, 10);
            AddProductItem("Haribo-Maoam-Pinballs.png", "Haribo Maoam Pinballs", 1.50, 10);
            AddProductItem("Swizzels-Luscious-Lollies.png", "Swizzels Luscious Lollies", 1.50, 10);
            AddProductItem("Haribo-Maoam-Joystixx.png", "Haribo Maoam Joystixx", 1.50, 10);
            AddProductItem("Swizzels-Drumstick-Squashies.png", "Swizzels Drumstick Squashies", 1.50, 10);
            AddProductItem("Haribo-Giant-Strawbs-Fruit-Gums.png", "Haribo Giant Strawbs Fruit Gums", 1.50, 10);
            AddProductItem("Haribo-Tangfastics-175G.png", "Haribo Tangfastics", 1.50, 10);
            AddProductItem("Haribo-Starmix-175G.png", "Haribo Starmix", 1.50, 10);
            AddProductItem("Maynards-Bassetts-Jelly-Babies.png", "Maynards Bassetts Jelly Babies", 1.50, 10);
            AddProductItem("Maynards-Bassetts-Sports-Mix.png", "Maynards Bassetts Sports Mix", 1.50, 10);
            AddProductItem("Maynards-Bassetts-Wine-Gums-Juicies.png", "Maynards Bassetts Wine Gums", 1.50, 10);

            SetUpShopItems();
            SetUpSlideOutPanel();
            SetUpTitleDateTime();

            CalculateAutoScrollMinSize();
        }

        private void PopulatePreviousProductQuantities()
        {
            m_PreviousProductQuantities = new List<int>();

            foreach (Product_Item productItem in m_ProductItems)
            {
                m_PreviousProductQuantities.Add(productItem.stockCount);
            }
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
            const string imageDirectory = "C:\\Users\\MrTst\\Documents\\C++ Dev\\Digital-Vending-Machine\\Digital-Vending-Machine\\App_Images\\";

            m_ProductItems.Add(new Product_Item($"{imageDirectory}{imageFile}", name, price, quantity));
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
                    if (Basket_Listbox.Items.Count == 0)
                    {
                        PopulatePreviousProductQuantities();
                    }

                    Product_Item productItem = (Product_Item)sender;

                    Basket_Listbox.Items.Add($"{(int)(Basket_Listbox.Items.Count / 2) + 1}• {productItem.name}:");
                    Basket_Listbox.Items.Add($"\t{productItem.price:C}");

                    m_TotalPrice += productItem.price;

                    Price_TextBox.Text = $"Total: {m_TotalPrice:C}";
                };
            }

            Shop_Items_Panel.Controls.Add(Shop_Items_Layout);
        }

        private void SetUpSlideOutPanel()
        {
            m_SlideOutPanel = new Panel();
            m_SlideOutPanel.Width = 0;
            m_SlideOutPanel.Dock = DockStyle.Left;
            m_SlideOutPanel.BackColor = SystemColors.Control;
            this.Controls.Add(m_SlideOutPanel);

            m_SlideOutTimer = new Timer();
            m_SlideOutTimer.Interval = 10;
            m_SlideOutTimer.Tick += SlideOutTimer_Tick;
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
                    m_SlideOutPanel.Width -= 50;
                }
                else
                {
                    m_SlideOutPanel.Width += 50;
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

            if (MessageBox.Show("Are you sure you want to cancel your order?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Basket_Listbox.Items.Clear();
                Price_TextBox.Text = "";

                foreach (Product_Item productItem in m_ProductItems)
                {
                    productItem.stockCount = m_PreviousProductQuantities[m_ProductItems.IndexOf(productItem)];
                }

                m_TotalPrice = 0.0;

                if (m_IsPanelVisible)
                {
                    m_SlideOutTimer.Start();
                    Shop_Items_Panel.Enabled = !Shop_Items_Panel.Enabled;
                    Checkout_Button.Enabled = !Checkout_Button.Enabled;
                }
            }
        }
    }
}
