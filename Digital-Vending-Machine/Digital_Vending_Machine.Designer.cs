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
            this.Shop_Items_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Checkout_Button = new System.Windows.Forms.Button();
            this.Items_Listbox = new System.Windows.Forms.ListBox();
            this.Clear_Basket_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Shop_Items_Layout
            // 
            this.Shop_Items_Layout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Shop_Items_Layout.AutoSize = true;
            this.Shop_Items_Layout.ColumnCount = 2;
            this.Shop_Items_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Shop_Items_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Shop_Items_Layout.Location = new System.Drawing.Point(12, 12);
            this.Shop_Items_Layout.Name = "Shop_Items_Layout";
            this.Shop_Items_Layout.RowCount = 2;
            this.Shop_Items_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Shop_Items_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Shop_Items_Layout.Size = new System.Drawing.Size(617, 679);
            this.Shop_Items_Layout.TabIndex = 0;
            // 
            // Checkout_Button
            // 
            this.Checkout_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Checkout_Button.Location = new System.Drawing.Point(635, 639);
            this.Checkout_Button.Name = "Checkout_Button";
            this.Checkout_Button.Size = new System.Drawing.Size(210, 52);
            this.Checkout_Button.TabIndex = 1;
            this.Checkout_Button.Text = "Checkout";
            this.Checkout_Button.UseVisualStyleBackColor = true;
            // 
            // Items_Listbox
            // 
            this.Items_Listbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Items_Listbox.BackColor = System.Drawing.SystemColors.Control;
            this.Items_Listbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Items_Listbox.FormattingEnabled = true;
            this.Items_Listbox.ItemHeight = 16;
            this.Items_Listbox.Location = new System.Drawing.Point(635, 12);
            this.Items_Listbox.Name = "Items_Listbox";
            this.Items_Listbox.Size = new System.Drawing.Size(210, 496);
            this.Items_Listbox.TabIndex = 2;
            // 
            // Clear_Basket_Button
            // 
            this.Clear_Basket_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_Basket_Button.Location = new System.Drawing.Point(635, 578);
            this.Clear_Basket_Button.Name = "Clear_Basket_Button";
            this.Clear_Basket_Button.Size = new System.Drawing.Size(210, 52);
            this.Clear_Basket_Button.TabIndex = 3;
            this.Clear_Basket_Button.Text = "Clear Basket";
            this.Clear_Basket_Button.UseVisualStyleBackColor = true;
            // 
            // Digital_Vending_Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 703);
            this.Controls.Add(this.Clear_Basket_Button);
            this.Controls.Add(this.Items_Listbox);
            this.Controls.Add(this.Checkout_Button);
            this.Controls.Add(this.Shop_Items_Layout);
            this.Name = "Digital_Vending_Machine";
            this.Text = "Digital Vending Machine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Shop_Items_Layout;
        private System.Windows.Forms.Button Checkout_Button;
        private System.Windows.Forms.ListBox Items_Listbox;
        private System.Windows.Forms.Button Clear_Basket_Button;
    }
}

