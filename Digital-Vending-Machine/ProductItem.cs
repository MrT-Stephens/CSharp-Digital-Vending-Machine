using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Vending_Machine
{
    internal class Product_Item : GroupBox
    {
        private string m_Name;
        private int m_Quantity;
        private double m_Price;

        private Button m_Button;

        // Constructor
        public Product_Item(string imagePath, string name, double price, int quantity)
        {
            m_Name = name;
            m_Quantity = quantity;
            m_Price = price;

            // Set up properties for the button
            m_Button = new Button()
            {
                BackgroundImage = Image.FromFile(imagePath),
                BackgroundImageLayout = ImageLayout.Zoom,
                Dock = DockStyle.Fill,
                Enabled = true,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
            };

            // Set up properties for the inherated group box
            this.Dock = DockStyle.Fill;
            this.Text = $"{m_Name} • {m_Price:C} • Quantity: {m_Quantity}";
            this.Enabled = true;
            this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            // Add the button to the group box controls
            this.Controls.Add(m_Button);

            // Add the event handler for button click
            m_Button.Click += OnClick;
        }

        private void OnClick(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked ");
        }
    }
}
