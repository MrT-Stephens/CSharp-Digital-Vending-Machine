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
        // Private variables
        private string m_Name;
        private int m_Quantity;
        private double m_Price;

        private Button m_Button;
        private event EventHandler m_ButtonSecondEvent;

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
                BackColor = Color.White,
                Text = m_Quantity.ToString(),
                TextAlign = ContentAlignment.BottomRight
            };

            // Set up properties for the inherited group box
            this.Dock = DockStyle.Fill;
            this.Text = $"{m_Name} • {m_Price:C}";
            this.Enabled = true;
            this.BackColor = Color.White;
            this.MinimumSize = new Size(200, 200);
            this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            // Add the button to the group box controls
            this.Controls.Add(m_Button);

            // Add the event handler for the button
            m_Button.Click += new EventHandler(OnButtonClick);
        }

        void OnButtonClick(object sender, EventArgs e)
        {
            m_ButtonSecondEvent?.Invoke(this, e);

            if (m_Quantity > 0)
            {
                m_Quantity--;
            }
            
            if (m_Quantity == 0)
            {
                this.Visible = false;
            }

            m_Button.Text = m_Quantity.ToString();
        }

        // Getters and Setters
        public string name
        {
            get { return m_Name; }
        }

        public int stockCount
        {
            get { return m_Quantity; }

            set
            {
                m_Quantity = value;
                m_Button.Text = m_Quantity.ToString();

                if (m_Quantity > 0)
                {
                    this.Visible = true;
                }
                else if (m_Quantity == 0)
                {
                    this.Visible = false;
                }
            }
        }

        public double price
        {
            get { return m_Price; }
        }

        public EventHandler click
        {
            get { return m_ButtonSecondEvent; }
            set { m_ButtonSecondEvent += value; }
        }
    }
}
