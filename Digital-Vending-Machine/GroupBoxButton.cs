using System;
using System.Drawing;
using System.Windows.Forms;

namespace Digital_Vending_Machine
{
    // Custom event arguments class for the coin drag / drop and click events
    public class TypeEventArgs<Type> : EventArgs    // Templated to accept any type.
    {
        private Type m_Type;

        public TypeEventArgs(Type customString)
        {
            m_Type = customString;
        }

        public Type variable
        {
            get { return m_Type; }
        }
    } 

    internal class GroupBox_Button : GroupBox
    {
        protected string m_Name;
        protected Button m_Button;

        public GroupBox_Button(System.Drawing.Image image, string name) : base()
        {
            m_Name = name;

            // Set up properties for the button
            m_Button = new Button()
            {
                BackgroundImage = image,
                BackgroundImageLayout = ImageLayout.Zoom,
                Dock = DockStyle.Fill,
                Enabled = true,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.White,
                TextAlign = ContentAlignment.BottomRight
            };

            // Set up properties for the inherited group box
            this.Dock = DockStyle.Fill;
            this.Text = m_Name;
            this.Enabled = true;
            this.BackColor = Color.White;
            this.MinimumSize = new Size(200, 200);
            this.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            // Add the button to the group box controls
            this.Controls.Add(m_Button);
        }


        // Getters and Setters
        public string name
        {
            get { return m_Name; }
        }
    }

    internal class Product_Item : GroupBox_Button
    {
        // Private variables
        private int m_Quantity;
        private double m_Price;
        private event EventHandler m_ButtonClickEvent;

        // Constructor
        public Product_Item(System.Drawing.Image image, string name, double price, int quantity) : base(image, name)
        {
            productName = name;
            m_Quantity = quantity;
            m_Price = price;

            m_Button.Text = m_Quantity.ToString();
            this.Text = $"{m_Price:C} • {m_Name}";

            m_Button.Click += new EventHandler(OnButtonClick);
        }

        // Event handler for the button click
        private void OnButtonClick(object sender, EventArgs e)
        {
            m_ButtonClickEvent?.Invoke(this, e);

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

        // Getters and setters
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

        public string productName { get; }

        public double price
        {
            get { return m_Price; }
        }

        public EventHandler click
        {
            get { return m_ButtonClickEvent; }
            set { m_ButtonClickEvent += value; }
        }
    }

    internal class Coin_Item : GroupBox_Button
    {
        // Private variables
        private double m_Value;
        private event EventHandler<TypeEventArgs<double>> m_ButtonClickEvent;

        // Constructor
        public Coin_Item(System.Drawing.Image image, string name, double value) : base(image, name)
        {
            m_Value = value;

            this.MinimumSize = new Size(100, 100);
            m_Button.Text = m_Value.ToString("C");
            m_Button.MouseDown += new MouseEventHandler(OnButtonMouseDown);
        }

        // Event handler for the button mouse down
        private void OnButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_Button.DoDragDrop(this.value, DragDropEffects.Copy);
            }
        }

        // Getters and setters
        public double value
        {
            get { return m_Value; }
        }

        public EventHandler<TypeEventArgs<double>> click
        {
            get { return m_ButtonClickEvent; }
            set { m_ButtonClickEvent += value; }
        }
    }

    internal class Coin_Slot : GroupBox_Button
    {
        private event EventHandler<TypeEventArgs<double>> m_DropEvent;

        // Constructor
        public Coin_Slot(System.Drawing.Image image) : base(image, "Payment")
        {
            this.MinimumSize = new Size(100, 100);
            m_Button.AllowDrop = true;
            m_Button.DragEnter += new DragEventHandler(OnButtonDragEnter);
            m_Button.DragDrop += new DragEventHandler(OnButtonDragDrop);
        }

        // Event handler for the button dragging
        private void OnButtonDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(double)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        // Event handler for the button dropping
        private void OnButtonDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(double)) is double value)
            {
                m_DropEvent?.Invoke(null, new TypeEventArgs<double>(value));
            }
        }

        // Getters and setters
        public EventHandler<TypeEventArgs<double>> drop
        {
            get { return m_DropEvent; }
            set { m_DropEvent += value; }
        }
    }
}
