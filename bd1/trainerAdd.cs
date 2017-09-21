using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bd1
{
    public partial class trainerAdd : Form
    {

        db db;

        public trainerAdd()
        {
            InitializeComponent();
            db = new db();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Close();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.query("INSERT INTO [trainer] (name, surname) values (N'" + textBox1.Text + "', N'" + textBox2.Text + "')");
            button2.PerformClick();
        }
    }
}
