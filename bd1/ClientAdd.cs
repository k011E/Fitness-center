using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bd1
{
    public partial class ClientAdd : Form
    {
        db db;
        public ClientAdd()
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
            db.query("INSERT INTO [Clients] (name, surname, city) VALUES(N'" + textBox1.Text + "', N'" + textBox2.Text + "', N'" + textBox3.Text + "')");
            using (SqlDataReader readr = db.querySelect("select id from [Clients] order by id desc"))
            {
                readr.Read();
                db.query("insert into [Group] (client, trainer) values (" + readr.GetInt32(0) + ", " + (comboBox1.SelectedItem as trainer).id + ")");
            }
            button2.PerformClick();
        }

        private void ClientAdd_Load(object sender, EventArgs e)
        {
            using (SqlDataReader reader = db.querySelect("SELECT * FROM [trainer]"))
            {
                while (reader.Read())
                {
                    comboBox1.Items.Add(new trainer() { id = reader.GetInt32(0), fio = reader.GetString(1) });
                }
                db.Close();
                if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            }
        }
    }
}
