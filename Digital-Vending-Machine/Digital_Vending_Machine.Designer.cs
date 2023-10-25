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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Digital_Vending_Machine));
            this.m_ShopItemsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.m_CheckoutButton = new System.Windows.Forms.Button();
            this.m_CancelOrderButton = new System.Windows.Forms.Button();
            this.m_ShopItemsPanel = new System.Windows.Forms.Panel();
            this.m_BasketLabel = new System.Windows.Forms.Label();
            this.m_PriceTextBox = new System.Windows.Forms.TextBox();
            this.m_StatusTextBox = new System.Windows.Forms.TextBox();
            this.m_BasketDataGridVeiw = new System.Windows.Forms.DataGridView();
            this.m_ProductNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_ProductQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_InfoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_BasketDataGridVeiw)).BeginInit();
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
            this.m_CheckoutButton.Location = new System.Drawing.Point(868, 788);
            this.m_CheckoutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_CheckoutButton.Name = "m_CheckoutButton";
            this.m_CheckoutButton.Size = new System.Drawing.Size(301, 52);
            this.m_CheckoutButton.TabIndex = 1;
            this.m_CheckoutButton.Text = "Checkout";
            this.m_CheckoutButton.UseVisualStyleBackColor = true;
            this.m_CheckoutButton.Click += new System.EventHandler(this.Checkout_Button_Click);
            // 
            // m_CancelOrderButton
            // 
            this.m_CancelOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CancelOrderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.m_CancelOrderButton.Location = new System.Drawing.Point(868, 732);
            this.m_CancelOrderButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_CancelOrderButton.Name = "m_CancelOrderButton";
            this.m_CancelOrderButton.Size = new System.Drawing.Size(301, 52);
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
            this.m_ShopItemsPanel.Location = new System.Drawing.Point(16, 15);
            this.m_ShopItemsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_ShopItemsPanel.Name = "m_ShopItemsPanel";
            this.m_ShopItemsPanel.Size = new System.Drawing.Size(845, 825);
            this.m_ShopItemsPanel.TabIndex = 0;
            // 
            // m_BasketLabel
            // 
            this.m_BasketLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BasketLabel.AutoSize = true;
            this.m_BasketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_BasketLabel.Location = new System.Drawing.Point(869, 49);
            this.m_BasketLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_BasketLabel.Name = "m_BasketLabel";
            this.m_BasketLabel.Size = new System.Drawing.Size(73, 20);
            this.m_BasketLabel.TabIndex = 4;
            this.m_BasketLabel.Text = "Basket:";
            // 
            // m_PriceTextBox
            // 
            this.m_PriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PriceTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.m_PriceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_PriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_PriceTextBox.Location = new System.Drawing.Point(868, 706);
            this.m_PriceTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_PriceTextBox.Name = "m_PriceTextBox";
            this.m_PriceTextBox.ReadOnly = true;
            this.m_PriceTextBox.Size = new System.Drawing.Size(301, 19);
            this.m_PriceTextBox.TabIndex = 5;
            this.m_PriceTextBox.Text = "Total: £0.00";
            this.m_PriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_StatusTextBox
            // 
            this.m_StatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_StatusTextBox.BackColor = System.Drawing.Color.PaleGreen;
            this.m_StatusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_StatusTextBox.Location = new System.Drawing.Point(868, 15);
            this.m_StatusTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.m_StatusTextBox.Name = "m_StatusTextBox";
            this.m_StatusTextBox.ReadOnly = true;
            this.m_StatusTextBox.Size = new System.Drawing.Size(243, 26);
            this.m_StatusTextBox.TabIndex = 7;
            this.m_StatusTextBox.Text = "Please select your items";
            this.m_StatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // m_BasketDataGridVeiw
            // 
            this.m_BasketDataGridVeiw.AllowUserToAddRows = false;
            this.m_BasketDataGridVeiw.AllowUserToDeleteRows = false;
            this.m_BasketDataGridVeiw.AllowUserToResizeRows = false;
            this.m_BasketDataGridVeiw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BasketDataGridVeiw.BackgroundColor = System.Drawing.SystemColors.Control;
            this.m_BasketDataGridVeiw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_BasketDataGridVeiw.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.m_BasketDataGridVeiw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_BasketDataGridVeiw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_ProductNameColumn,
            this.m_ProductQuantityColumn});
            this.m_BasketDataGridVeiw.Location = new System.Drawing.Point(868, 71);
            this.m_BasketDataGridVeiw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_BasketDataGridVeiw.MultiSelect = false;
            this.m_BasketDataGridVeiw.Name = "m_BasketDataGridVeiw";
            this.m_BasketDataGridVeiw.ReadOnly = true;
            this.m_BasketDataGridVeiw.RowHeadersVisible = false;
            this.m_BasketDataGridVeiw.RowHeadersWidth = 51;
            this.m_BasketDataGridVeiw.RowTemplate.Height = 24;
            this.m_BasketDataGridVeiw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_BasketDataGridVeiw.Size = new System.Drawing.Size(301, 628);
            this.m_BasketDataGridVeiw.TabIndex = 8;
            this.m_BasketDataGridVeiw.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BasketDataGridVeiw_CellMouseDown);
            // 
            // m_ProductNameColumn
            // 
            this.m_ProductNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.m_ProductNameColumn.HeaderText = "Product Name";
            this.m_ProductNameColumn.MinimumWidth = 6;
            this.m_ProductNameColumn.Name = "m_ProductNameColumn";
            this.m_ProductNameColumn.ReadOnly = true;
            // 
            // m_ProductQuantityColumn
            // 
            this.m_ProductQuantityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.m_ProductQuantityColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.m_ProductQuantityColumn.HeaderText = "Quantity";
            this.m_ProductQuantityColumn.MinimumWidth = 6;
            this.m_ProductQuantityColumn.Name = "m_ProductQuantityColumn";
            this.m_ProductQuantityColumn.ReadOnly = true;
            this.m_ProductQuantityColumn.Width = 84;
            // 
            // m_InfoButton
            // 
            this.m_InfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_InfoButton.BackgroundImage = global::Digital_Vending_Machine.Properties.Resources.information;
            this.m_InfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_InfoButton.Location = new System.Drawing.Point(1118, 13);
            this.m_InfoButton.Name = "m_InfoButton";
            this.m_InfoButton.Size = new System.Drawing.Size(53, 53);
            this.m_InfoButton.TabIndex = 9;
            this.m_InfoButton.UseVisualStyleBackColor = true;
            this.m_InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // Digital_Vending_Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 862);
            this.Controls.Add(this.m_InfoButton);
            this.Controls.Add(this.m_BasketDataGridVeiw);
            this.Controls.Add(this.m_StatusTextBox);
            this.Controls.Add(this.m_PriceTextBox);
            this.Controls.Add(this.m_BasketLabel);
            this.Controls.Add(this.m_ShopItemsPanel);
            this.Controls.Add(this.m_CancelOrderButton);
            this.Controls.Add(this.m_CheckoutButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1199, 899);
            this.Name = "Digital_Vending_Machine";
            this.Text = "30048598 • Digital Vending Machine";
            ((System.ComponentModel.ISupportInitialize)(this.m_BasketDataGridVeiw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel m_ShopItemsLayout;
        private System.Windows.Forms.Button m_CheckoutButton;
        private System.Windows.Forms.Button m_CancelOrderButton;
        private System.Windows.Forms.Panel m_ShopItemsPanel;
        private System.Windows.Forms.Label m_BasketLabel;
        private System.Windows.Forms.TextBox m_PriceTextBox;
        private System.Windows.Forms.TextBox m_StatusTextBox;
        private System.Windows.Forms.DataGridView m_BasketDataGridVeiw;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_ProductNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_ProductQuantityColumn;
        private System.Windows.Forms.Button m_InfoButton;
    }
}

