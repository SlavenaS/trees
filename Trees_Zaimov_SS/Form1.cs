using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trees_Zaimov_SS
{
    public partial class Form1 : Form
    {
        string connstr = "server=10.6.0.127;" + "port=3306;"
              + "user=PC1;" + "password=1111;" + "database=trees_zaimov;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = new MySqlConnection(connstr);
            if (connect.State == 0)
            {
                connect.Open();
            }
            MessageBox.Show("Connection NOW opened");

            string str = "select * from type";
            MySqlCommand query = new MySqlCommand(str, connect);
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
            reader.Close();
            connect.Close();
            //type-vid
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insert1 = 
              "INSERT INTO trees_zaimov.type " +
              "(`name`, `name_bg`) " +
              "VALUES (@name, @name_bg)";

            MySqlConnection connect = new MySqlConnection(connstr);
            if (connect.State == 0)
            {
                connect.Open();
            }
          
            MySqlCommand query = new MySqlCommand(insert1, connect);
            query.Parameters.AddWithValue("@name", textBox1.Text);
            query.Parameters.AddWithValue("@name_bg", textBox2.Text);
            int result = query.ExecuteNonQuery();
            if(result != 0)
            {
                MessageBox.Show($"Dobaveni sa {result} br. records in type table!!! ");
            }
            else
            {

                MessageBox.Show("nesto ne e nared in type table!!! ");

            }
            connect.Close();
        }
    }
}
