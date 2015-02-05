using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS.PListVisualizerNS
{
    public partial class PListForm : Form
    {
        public PListForm()
        {
            InitializeComponent();
        }

        public void ShowPList(string str)
        {
            this.textBox1.Text = str;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
