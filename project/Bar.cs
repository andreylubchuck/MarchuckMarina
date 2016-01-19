using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CocktailMix
{
    public partial class BarForm : Form
    {
        public BarForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  // making next cocktail
        {
            Cocktail c = OrderSystem.ReleaseOrder();
            try
            {
                MessageBox.Show("Cocktail made:\n" + c.Print());
            }
            catch (NullReferenceException)
            {
                if (OrderSystem.warehouseError)
                    MessageBox.Show("There are not enough ingredients for this order!");
                else
                    MessageBox.Show("No orders left!");
            }
        }

        private void button2_Click(object sender, EventArgs e)  // adding new recipe
        {
            string name = textBox1.Text;
            string liq = textBox2.Text;
            string ice = textBox3.Text;
            string dec = textBox4.Text;
            int price = (int)numericUpDown1.Value;

            ConnectToDB conn = new ConnectToDB();
            conn.AddRecipe(name, liq, ice, dec, price);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            numericUpDown1.Value = 0;
        }
    }
}
