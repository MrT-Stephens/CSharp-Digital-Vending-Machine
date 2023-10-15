namespace Digital_Vending_Machine
{
    partial class Digital_Vending_Machine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Digital_Vending_Machine));
            this.m_ShopItemsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.m_CheckoutButton = new System.Windows.Forms.Button();
            this.m_BasketListBox = new System.Windows.Forms.ListBox();
            this.m_CancelOrderButton = new System.Windows.Forms.Button();
            this.m_ShopItemsPanel = new System.Windows.Forms.Panel();
            this.m_BasketLabel = new System.Windows.Forms.Label();
            this.m_PriceTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_ShopItemsLayout
            // 
            this.m_ShopItemsLayout.Location = new System.Drawing.Point(0, 0);
            this.m_ShopItemsLayout.Name = "m_ShopItemsLayout";
            this.m_ShopItemsLayout.Size = new System.Drawing.Size(200, 100);
            this.m_ShopItemsLayout.TabIndex = 0;
            // 
            // m_CheckoutButton
            // 
            this.m_CheckoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CheckoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.m_CheckoutButton.Location = new System.Drawing.Point(664, 709);
            this.m_CheckoutButton.Margin = new System.Windows.Forms.Padding(2);
            this.m_CheckoutButton.Name = "m_CheckoutButton";
            this.m_CheckoutButton.Size = new System.Drawing.Size(211, 42);
            this.m_CheckoutButton.TabIndex = 1;
            this.m_CheckoutButton.Text = "Checkout";
            this.m_CheckoutButton.UseVisualStyleBackColor = true;
            this.m_CheckoutButton.Click += new System.EventHandler(this.Checkout_Button_Click);
            // 
            // m_BasketListBox
            // 
            this.m_BasketListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BasketListBox.BackColor = System.Drawing.SystemColors.Control;
            this.m_BasketListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_BasketListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.m_BasketListBox.FormattingEnabled = true;
            this.m_BasketListBox.ItemHeight = 16;
            this.m_BasketListBox.Location = new System.Drawing.Point(664, 30);
            this.m_BasketListBox.Margin = new System.Windows.Forms.Padding(2);
            this.m_BasketListBox.Name = "m_BasketListBox";
            this.m_BasketListBox.Size = new System.Drawing.Size(211, 576);
            this.m_BasketListBox.TabIndex = 2;
            // 
            // m_CancelOrderButton
            // 
            this.m_CancelOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CancelOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.m_CancelOrderButton.Location = new System.Drawing.Point(664, 660);
            this.m_CancelOrderButton.Margin = new System.Windows.Forms.Padding(2);
            this.m_CancelOrderButton.Name = "m_CancelOrderButton";
            this.m_CancelOrderButton.Size = new System.Drawing.Size(211, 42);
            this.m_CancelOrderButton.TabIndex = 3;
            this.m_CancelOrderButton.Text = "Cancel Order";
            this.m_CancelOrderButton.UseVisualStyleBackColor = true;
            this.m_CancelOrderButton.Click += new System.EventHandler(this.CancelOrderButton_Click);
            // 
            // m_ShopItemsPanel
            // 
            this.m_ShopItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ShopItemsPanel.AutoScroll = true;
            this.m_ShopItemsPanel.Location = new System.Drawing.Point(12, 12);
            this.m_ShopItemsPanel.Name = "m_ShopItemsPanel";
            this.m_ShopItemsPanel.Size = new System.Drawing.Size(647, 737);
            this.m_ShopItemsPanel.TabIndex = 0;
            // 
            // m_BasketLabel
            // 
            this.m_BasketLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BasketLabel.AutoSize = true;
            this.m_BasketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_BasketLabel.Location = new System.Drawing.Point(665, 12);
            this.m_BasketLabel.Name = "m_BasketLabel";
            this.m_BasketLabel.Size = new System.Drawing.Size(59, 16);
            this.m_BasketLabel.TabIndex = 4;
            this.m_BasketLabel.Text = "Basket:";
            // 
            // m_PriceTextBox
            // 
            this.m_PriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PriceTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.m_PriceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_PriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PriceTextBox.Location = new System.Drawing.Point(668, 635);
            this.m_PriceTextBox.Name = "m_PriceTextBox";
            this.m_PriceTextBox.ReadOnly = true;
            this.m_PriceTextBox.Size = new System.Drawing.Size(204, 15);
            this.m_PriceTextBox.TabIndex = 5;
            this.m_PriceTextBox.Text = "Total: £0.00";
            this.m_PriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Digital_Vending_Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.m_PriceTextBox);
            this.Controls.Add(this.m_BasketLabel);
            this.Controls.Add(this.m_ShopItemsPanel);
            this.Controls.Add(this.m_CancelOrderButton);
            this.Controls.Add(this.m_BasketListBox);
            this.Controls.Add(this.m_CheckoutButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(900, 800);
            this.Name = "Digital_Vending_Machine";
            this.Text = "30048598 • Digital Vending Machine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel m_ShopItemsLayout;
        private System.Windows.Forms.Button m_CheckoutButton;
        private System.Windows.Forms.ListBox m_BasketListBox;
        private System.Windows.Forms.Button m_CancelOrderButton;
        private System.Windows.Forms.Panel m_ShopItemsPanel;
        private System.Windows.Forms.Label m_BasketLabel;
        private System.Windows.Forms.TextBox m_PriceTextBox;
    }
}

