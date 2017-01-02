using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuartoTGProject
{
    public partial class Pocetak : Form
    {
        public Pocetak()
        {
            InitializeComponent();
        }

        private void btn_prvi_Click(object sender, EventArgs e)
        {
            Form1 temp = new Form1();
            temp.poc = this;
            temp.Show();
            Hide();
        }

        private void btn_drugi_Click(object sender, EventArgs e)
        {
            Form1 temp = new Form1();
            temp.Show();
            temp.poc = this;
            Hide();
        }
    }
}
