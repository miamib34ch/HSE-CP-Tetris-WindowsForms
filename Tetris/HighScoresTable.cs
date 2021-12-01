using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class HighScoresTable : Form
    {
        public HighScoresTable()
        {
            InitializeComponent();
        }

        private void HighScoresTable_Load(object sender, EventArgs e)
        {
            
            this.BackColor = System.Drawing.Color.Black;
            label4.Text = "";
            label3.Text = "";
            label22.Text = "";

            for (int i = 0; i < Data.list.Count; i++)
            {
                label22.Text += $"{Data.list[i].Score}\n\n\n";
                label4.Text += $"{Data.list[i].Mode}\n\n\n";
                label3.Text += $"{Data.list[i].Name}\n\n\n";
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
