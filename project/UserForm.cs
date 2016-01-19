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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            ConnectToDB conn = new ConnectToDB();
            List<string> menuStr = conn.GetMenuStrings();
            List<int> menuPrices = conn.GetMenuPrices();

            for (int i = 0; i < menuStr.Count; i++)
                comboBox1.Items.Add("$" + menuPrices[i].ToString() + " " + menuStr[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sel = comboBox1.SelectedItem.ToString();
            int i = sel.IndexOf(" ");
            string name = sel.Substring(i + 1);
            OrderSystem.AddOrder(name);
        }
    }
}
