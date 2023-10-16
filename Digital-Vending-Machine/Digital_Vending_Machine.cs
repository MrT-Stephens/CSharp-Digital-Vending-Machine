using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Digital_Vending_Machine
{
    public partial class Digital_Vending_Machine : Form
    {
        #region Class Attributes

        static readonly string s_LogOrdersFileName = "Digital-Vending-Machine-Log";

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
        private Timer m_TimeoutTimer;

        #endregion

        #region Constructor

        public Digital_Vending_Machine()
        {
            InitializeComponent();  // Auto-generated initialization of the form's controls.

            m_CoinItems = new List<Coin_Item>();
            m_BasketHander = new Basket_Hander();
            m_ProductItems = new List<Product_Item>();

            // Adding all product items. First: Image resource, Second: Name of item, Third: Cost of item, Fourth: Quantity of item.
            AddProductItem(Properties.Resources.Rowntrees_Fruit_Pastilles, "Rowntree's Fruit Pastilles", 1.25, 150);
            AddProductItem(Properties.Resources.Rowntrees_Jelly_Tots, "Rowntree's Jelly Tots", 1.10, 5);
            AddProductItem(Properties.Resources.Rowntrees_Randoms_Sweets, "Rowntree's Randoms Sweets", 1.70, 100);
            AddProductItem(Properties.Resources.Fruittella_Duo_Stix, "Fruittella Duo Stix", 1.29, 10);
            AddProductItem(Properties.Resources.Haribo_Supermix, "Haribo Supermix", 1.20, 200);
            AddProductItem(Properties.Resources.Rowntrees_Fruit_Gums, "Rowntree's Fruit Gums", 1.25, 140);
            AddProductItem(Properties.Resources.Starburst_Original_Fruit, "Starburst Original Fruit", 1.10, 10);
            AddProductItem(Properties.Resources.Skittles_Fruits, "Skittles Fruits", 1.50, 10);
            AddProductItem(Properties.Resources.Skittles_Crazy_Sour_Fruit, "Skittles Crazy Sour Fruit", 1.59, 15);
            AddProductItem(Properties.Resources.Rowntrees_Fruit_Pastilles_Strawberry___Blackcurrant, "Rowntree's Fruit Pastilles Strawberry & Blackcurrant", 1.60, 19);
            AddProductItem(Properties.Resources.Haribo_Maoam_Pinballs, "Haribo Maoam Pinballs", 1.90, 75);
            AddProductItem(Properties.Resources.Swizzels_Luscious_Lollies, "Swizzels Luscious Lollies", 2.00, 24);
            AddProductItem(Properties.Resources.Haribo_Maoam_Joystixx, "Haribo Maoam Joystixx", 1.55, 19);
            AddProductItem(Properties.Resources.Swizzels_Drumstick_Squashies, "Swizzels Drumstick Squashies", 0.90, 15);
            AddProductItem(Properties.Resources.Haribo_Giant_Strawbs_Fruit_Gums, "Haribo Giant Strawbs Fruit Gums", 1.90, 99);
            AddProductItem(Properties.Resources.Haribo_Tangfastics_175G, "Haribo Tangfastics", 1.53, 50);
            AddProductItem(Properties.Resources.Haribo_Starmix_175G, "Haribo Starmix", 0.99, 54);
            AddProductItem(Properties.Resources.Maynards_Bassetts_Jelly_Babies, "Maynards Bassetts Jelly Babies", 1.19, 119);
            AddProductItem(Properties.Resources.Maynards_Bassetts_Sports_Mix, "Maynards Bassetts Sports Mix", 1.43, 14);
            AddProductItem(Properties.Resources.Maynards_Bassetts_Wine_Gums_Juicies, "Maynards Bassetts Wine Gums", 1.05, 14);

            // Adding all coin items. First: Image resource, Second: Coin name, Third: Coin value.
            AddCoinItem(Properties.Resources._5pound, "Five Pound", 5.00);
            AddCoinItem(Properties.Resources._10pound, "Ten Pound", 10.00);
            AddCoinItem(Properties.Resources._20pound, "Twenty Pound", 20.00);
            AddCoinItem(Properties.Resources._1p, "One Pence", 0.01);
            AddCoinItem(Properties.Resources._2p, "Two Pence", 0.02);
            AddCoinItem(Properties.Resources._5p, "Five Pence", 0.05);
            AddCoinItem(Properties.Resources._10p, "Ten Pence", 0.10);
            AddCoinItem(Properties.Resources._20p, "Twenty Pence", 0.20);
            AddCoinItem(Properties.Resources._50p, "Fifty Pence", 0.50);
            AddCoinItem(Properties.Resources._1pound, "One Pound", 1.00);
            AddCoinItem(Properties.Resources._2pound, "Two Pound", 2.00);

            // Initializing other components like all shop items, slide out panel, all coins, etc.
            SetUpShopItems();
            SetUpTimeoutTimer();
            SetUpSlideOutPanel();
            SetUpTitleDateTime();
            SetUpListBoxContextMenu();

            // Setting up the initial minimum scroll size.
            CalculateAutoScrollMinSize();

            this.SizeChanged += (sender, e) =>   // Handling the window size change for the shop item panel and the slide out panel.
            {
                CalculateAutoScrollMinSize();

                if (m_IsPanelVisible)
                {
                    m_SlideOutPanel.Width = m_ShopItemsPanel.Width;
                }
            };

            this.FormClosing += (sender, e) =>   // Handling the form closing event for if there are items in the basket.
            {
                if (m_BasketHander.count > 0 && MessageBox.Show(this, "Are you sure you want to cancel your order?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            };
        }

        #endregion

        #region Adding Imaged Items

        private void AddProductItem(Image image, string name, double price, int quantity)
        {
            m_ProductItems.Add(new Product_Item(image, name, price, quantity));
        }

        private void AddCoinItem(Image image, string name, double value)
        {
            m_CoinItems.Add(new Coin_Item(image, name, value));
        }

        #endregion

        #region Initalization of Controls / Items

        private void SetUpShopItems()
        {
            m_ShopItemsLayout.ColumnCount = 3;
            m_ShopItemsLayout.Dock = DockStyle.Fill;

            int numRows = (int)Math.Ceiling((double)m_ProductItems.Count / m_ShopItemsLayout.ColumnCount);

            m_ShopItemsLayout.RowCount = numRows;

            for (int i = 0; i < 3; i++)
            {
                m_ShopItemsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0f / 3.0f));
            }

            for (int i = 0; i < numRows; i++)
            {
                m_ShopItemsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f / (float)numRows));
            }

            foreach (Product_Item control in m_ProductItems)
            {
                m_ShopItemsLayout.Controls.Add(control);

                control.click += (sender, e) =>
                {
                    Product_Item productItem = (Product_Item)sender;

                    m_BasketHander.AddItem(productItem);

                    m_PriceTextBox.Text = $"Total: {m_BasketHander.total:C}";

                    m_BasketHander.PrintBasketToListBox(m_BasketListBox);

                    m_BasketListBox.SelectedIndex = m_BasketListBox.Items.Count - 1;
                    m_BasketListBox.SelectedIndex = -1;

                    if (m_BasketHander.count > 0)
                    {
                        m_TimeoutTimer.Start();
                    }
                };
            }

            m_ShopItemsPanel.Controls.Add(m_ShopItemsLayout);
        }

        private void SetUpSlideOutPanel()
        {
            // Set up the slide out panel
            m_SlideOutPanel = new Panel();
            m_SlideOutPanel.Width = 0;
            m_SlideOutPanel.Dock = DockStyle.Left;
            m_SlideOutPanel.Padding = new Padding(20);
            m_SlideOutPanel.BackColor = SystemColors.ControlLight;
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
                m_SlideOutLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100.0f / numRows));
            }

            foreach (Coin_Item coin in m_CoinItems)
            {
                m_SlideOutLayout.Controls.Add(coin);
                coin.click += OnClickOrDrop;
            }

            m_PaymentBox = new Coin_Slot(Properties.Resources.Coin_Slot);
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
                if (m_BasketListBox.SelectedIndex == -1)
                {
                    return;
                }
                else if (m_BasketHander.count > 0)
                {
                    int index = m_BasketListBox.SelectedIndex;

                    {
                        KeyValuePair<string, int> pair = m_BasketHander.RemoveItemByIndex(index, true);

                        m_ProductItems.Find((item) => item.productName == pair.Key).stockCount += pair.Value;
                    }

                    m_PriceTextBox.Text = $"Total: {m_BasketHander.total:C}";

                    m_BasketHander.PrintBasketToListBox(m_BasketListBox);
                }
            };

            m_ListBoxRemoveOne.Click += (sender, e) =>
            {
                if (m_BasketListBox.SelectedIndex == -1)
                {
                    return;
                }
                else if (m_BasketHander.count > 0)
                {
                    int index = m_BasketListBox.SelectedIndex;

                    {
                        KeyValuePair<string, int> pair = m_BasketHander.RemoveItemByIndex(index, false);

                        m_ProductItems.Find((item) => item.productName == pair.Key).stockCount += pair.Value;
                    }

                    m_PriceTextBox.Text = $"Total: {m_BasketHander.total:C}";

                    m_BasketHander.PrintBasketToListBox(m_BasketListBox);
                }
            };

            m_ListBoxContextMenu.MenuItems.Add(m_ListBoxRemoveAll);
            m_ListBoxContextMenu.MenuItems.Add(m_ListBoxRemoveOne);

            m_BasketListBox.ContextMenu = m_ListBoxContextMenu;
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

        private void SetUpTimeoutTimer()
        {
            m_TimeoutTimer = new Timer();
            m_TimeoutTimer.Interval = 180000;
            m_TimeoutTimer.Tick += (sender, e) =>
            {
                m_TimeoutTimer.Stop();

                m_BasketListBox.Items.Clear();
                m_PriceTextBox.Text = $"Total: {0.00:C}";
                m_BasketHander.Cancel(m_ProductItems);

                if (m_IsPanelVisible)
                {
                    m_SlideOutTimer.Start();
                    m_ShopItemsPanel.Enabled = !m_ShopItemsPanel.Enabled;
                    m_CheckoutButton.Enabled = !m_CheckoutButton.Enabled;
                    m_BasketListBox.Enabled = !m_BasketListBox.Enabled;
                }
            };
        }

        #endregion

        #region Event Handler Functions

        private void CalculateAutoScrollMinSize()   // Calculates the minimum window scroll size for the shop items panel.
        {                                           // It makes sure that the shop items size correctly but also scrolls correctly.
            int height = 0;

            foreach (Control control in m_ProductItems)
            {
                height += control.MinimumSize.Height;
            }

            m_ShopItemsLayout.AutoScrollMinSize = new Size(300, height / (m_ShopItemsLayout.RowCount < 3 ? 3 : m_ShopItemsLayout.RowCount / 3));
        }

        private void OnClickOrDrop(object sender, TypeEventArgs<double> e)  // Event handler for either a coin click or a coin drag / drop.
        {
            m_BasketHander.MinusAmount(e.variable); // Minuses the coin value from the total basket cost.

            m_PriceTextBox.Text = $"Total: {m_BasketHander.total:C}";

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

            m_BasketHander.PrintBasketToFile(s_LogOrdersFileName);  // Logs the order to a log file.

            // Resets the application, but not the item quantities.
            m_BasketListBox.Items.Clear();
            m_PriceTextBox.Text = $"Total: {0.00:C}";
            m_BasketHander.Clear();
            m_SlideOutTimer.Start();    // Slides the slide out panel back in.
            m_ShopItemsPanel.Enabled = !m_ShopItemsPanel.Enabled;
            m_CheckoutButton.Enabled = !m_CheckoutButton.Enabled;
            m_BasketListBox.Enabled = !m_BasketListBox.Enabled;
        }

        private void Checkout_Button_Click(object sender, EventArgs e)  // Checkout button event handler.
        {
            if (m_BasketListBox.Items.Count == 0)
            {
                return;
            }

            m_SlideOutTimer.Start();    // Slides out the slide out panel, so user can pay for there items.
            m_ShopItemsPanel.Enabled = !m_ShopItemsPanel.Enabled;
            m_CheckoutButton.Enabled = !m_CheckoutButton.Enabled;
            m_BasketListBox.Enabled = !m_BasketListBox.Enabled;
        }

        private void SlideOutTimer_Tick(object sender, EventArgs e) // Slide out panel timer event handler, gets called every 1ms.
        {
            int targetWidth = m_IsPanelVisible ? 0 : (int)Math.Round(m_ShopItemsPanel.Width / 100.0) * 100;
                                                     // ↑↑↑↑ Rounds the shop items panel width to the nearest 100.
                                                     // ↑↑↑↑ So we can add a large amount of pixels onto the width to simulate the panel moving.

            if (m_SlideOutPanel.Width != targetWidth)   // If the slide out panel width is not equal to the target width.
            {
                if (m_IsPanelVisible)
                {
                    m_SlideOutPanel.Width -= ((int)Math.Round(m_ShopItemsPanel.Width / 100.0) * 100) / 4;
                                             // ↑↑↑↑ Minuses the shop items panel width divided by four from the slide out panel width.
                }
                else
                {
                    m_SlideOutPanel.Width += targetWidth / 4;   // Minuses the 'targetWidth' divided by four.
                }

                m_SlideOutPanel.BringToFront();
            }
            else
            {
                if (!m_IsPanelVisible)  // If the panel is not visible, it will equal the slide out panels width to the shop items panel width.
                {                       // This is due to us rounding the shop panels width to the nearest 100.
                    m_SlideOutPanel.Width = m_ShopItemsPanel.Width;
                }

                m_SlideOutTimer.Stop();
                m_IsPanelVisible = !m_IsPanelVisible;
            }
        }

        private void TitleDateTimeTimer_Tick(object sender, EventArgs e)    // Title time and date event handler function.
        {                                                                   // Updates the date and time in the title every 1000ms (1s).
            this.Text = $"{m_Title} • {DateTime.Now.ToString("dd/MM/yyyy")} • {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void CancelOrderButton_Click(object sender, EventArgs e)    // Cancel button event handler function.
        {                                                                   // Will display a dialog if there is items in the basket to ask if they are sure.
            if (m_BasketListBox.Items.Count == 0)                           // Clears the basket, updates total text box, and resets the slide out panel.
            {
                return;
            }

            if (MessageBox.Show(this, "Are you sure you want to cancel your order?", "Cancel Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_BasketListBox.Items.Clear();
                m_PriceTextBox.Text = $"Total: {0.00:C}";
                m_BasketHander.Cancel(m_ProductItems);

                if (m_IsPanelVisible)
                {
                    m_SlideOutTimer.Start();
                    m_ShopItemsPanel.Enabled = !m_ShopItemsPanel.Enabled;
                    m_CheckoutButton.Enabled = !m_CheckoutButton.Enabled;
                    m_BasketListBox.Enabled = !m_BasketListBox.Enabled;
                }
            }
        }

        #endregion
    }
}