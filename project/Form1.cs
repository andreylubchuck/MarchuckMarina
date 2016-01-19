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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            ConnectToDB conn = new ConnectToDB();
            int type = conn.SignIn(login, password);
            if (type == 1)
            {
                BarForm barmenf = new BarForm();
                barmenf.Show();
            }
            else if (type == 2)
            {
                UserForm userf = new UserForm();
                userf.Show();
            }
            else if (type == 3)
            {
                WhmanForm whmanf = new WhmanForm();
                whmanf.Show();
            }
        }
    }
}
