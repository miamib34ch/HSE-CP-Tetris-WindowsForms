using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Name : Form
    {
        public Name()
        {
            InitializeComponent();
            if (Tetris.Lang == "R")
            {
                label1.Text = "Вы поставили новый рекорд! Введите свое имя";
                button1.Text = "Сохранить";
            }
            else
            {
                label1.Text = "You have set a new record! Please enter your name";
                button1.Text = "Save";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Name = textBox1.Text;
            Close();
        }
    }
}
