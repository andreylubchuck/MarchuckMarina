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
    public partial class WhmanForm : Form
    {
        public WhmanForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item = textBox1.Text;
            int quantity = (int)numericUpDown1.Value;

            ConnectToDB conn = new ConnectToDB();
            conn.AddItemToWarehouse(item, quantity);
        }

        private void WhmanForm_Load(object sender, EventArgs e)
        {
            ConnectToDB conn = new ConnectToDB();
            List<string> warehouseStr = conn.GetWarehouseStrings();

            for (int i = 0; i < warehouseStr.Count; i++)
                comboBox1.Items.Add(warehouseStr[i]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string item = comboBox1.SelectedItem.ToString();
            int quantity = (int)numericUpDown2.Value;

            ConnectToDB conn = new ConnectToDB();
            conn.RemoveItemFromWarehouse(item, quantity);
        }
    }
}
