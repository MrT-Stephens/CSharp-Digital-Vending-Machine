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
            this.Shop_Items_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Checkout_Button = new System.Windows.Forms.Button();
            this.Basket_Listbox = new System.Windows.Forms.ListBox();
            this.Cancel_Order_Button = new System.Windows.Forms.Button();
            this.Shop_Items_Panel = new System.Windows.Forms.Panel();
            this.Basket_Label = new System.Windows.Forms.Label();
            this.Price_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Shop_Items_Layout
            // 
            this.Shop_Items_Layout.Location = new System.Drawing.Point(0, 0);
            this.Shop_Items_Layout.Name = "Shop_Items_Layout";
            this.Shop_Items_Layout.Size = new System.Drawing.Size(200, 100);
            this.Shop_Items_Layout.TabIndex = 0;
            // 
            // Checkout_Button
            // 
            this.Checkout_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Checkout_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Checkout_Button.Location = new System.Drawing.Point(423, 519);
            this.Checkout_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Checkout_Button.Name = "Checkout_Button";
            this.Checkout_Button.Size = new System.Drawing.Size(211, 42);
            this.Checkout_Button.TabIndex = 1;
            this.Checkout_Button.Text = "Checkout";
            this.Checkout_Button.UseVisualStyleBackColor = true;
            this.Checkout_Button.Click += new System.EventHandler(this.Checkout_Button_Click);
            // 
            // Basket_Listbox
            // 
            this.Basket_Listbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Basket_Listbox.BackColor = System.Drawing.SystemColors.Control;
            this.Basket_Listbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Basket_Listbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Basket_Listbox.FormattingEnabled = true;
            this.Basket_Listbox.ItemHeight = 16;
            this.Basket_Listbox.Location = new System.Drawing.Point(423, 30);
            this.Basket_Listbox.Margin = new System.Windows.Forms.Padding(2);
            this.Basket_Listbox.Name = "Basket_Listbox";
            this.Basket_Listbox.Size = new System.Drawing.Size(211, 400);
            this.Basket_Listbox.TabIndex = 2;
            // 
            // Cancel_Order_Button
            // 
            this.Cancel_Order_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Order_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Cancel_Order_Button.Location = new System.Drawing.Point(423, 470);
            this.Cancel_Order_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Cancel_Order_Button.Name = "Cancel_Order_Button";
            this.Cancel_Order_Button.Size = new System.Drawing.Size(211, 42);
            this.Cancel_Order_Button.TabIndex = 3;
            this.Cancel_Order_Button.Text = "Cancel Order";
            this.Cancel_Order_Button.UseVisualStyleBackColor = true;
            this.Cancel_Order_Button.Click += new System.EventHandler(this.Cancel_Order_Button_Click);
            // 
            // Shop_Items_Panel
            // 
            this.Shop_Items_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Shop_Items_Panel.AutoScroll = true;
            this.Shop_Items_Panel.Location = new System.Drawing.Point(12, 12);
            this.Shop_Items_Panel.Name = "Shop_Items_Panel";
            this.Shop_Items_Panel.Size = new System.Drawing.Size(406, 547);
            this.Shop_Items_Panel.TabIndex = 0;
            // 
            // Basket_Label
            // 
            this.Basket_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Basket_Label.AutoSize = true;
            this.Basket_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Basket_Label.Location = new System.Drawing.Point(424, 12);
            this.Basket_Label.Name = "Basket_Label";
            this.Basket_Label.Size = new System.Drawing.Size(59, 16);
            this.Basket_Label.TabIndex = 4;
            this.Basket_Label.Text = "Basket:";
            // 
            // Price_TextBox
            // 
            this.Price_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Price_TextBox.BackColor = System.Drawing.SystemColors.Control;
            this.Price_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Price_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price_TextBox.Location = new System.Drawing.Point(427, 445);
            this.Price_TextBox.Name = "Price_TextBox";
            this.Price_TextBox.ReadOnly = true;
            this.Price_TextBox.Size = new System.Drawing.Size(204, 15);
            this.Price_TextBox.TabIndex = 5;
            this.Price_TextBox.Text = "Total: £0.00";
            this.Price_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Digital_Vending_Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 571);
            this.Controls.Add(this.Price_TextBox);
            this.Controls.Add(this.Basket_Label);
            this.Controls.Add(this.Shop_Items_Panel);
            this.Controls.Add(this.Cancel_Order_Button);
            this.Controls.Add(this.Basket_Listbox);
            this.Controls.Add(this.Checkout_Button);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Digital_Vending_Machine";
            this.Text = "30048598 • Digital Vending Machine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Shop_Items_Layout;
        private System.Windows.Forms.Button Checkout_Button;
        private System.Windows.Forms.ListBox Basket_Listbox;
        private System.Windows.Forms.Button Cancel_Order_Button;
        private System.Windows.Forms.Panel Shop_Items_Panel;
        private System.Windows.Forms.Label Basket_Label;
        private System.Windows.Forms.TextBox Price_TextBox;
    }
}

