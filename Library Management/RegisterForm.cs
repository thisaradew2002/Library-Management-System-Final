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
using System.Xml.Linq;
using System.Configuration;

namespace Library_Management
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (txtusename.Text != "" && txtpassword.Text != "")
            {
                String name = txtusename.Text;
                String password = txtpassword.Text;
               

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = .\\SQLEXPRESS; database = myProject;integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into registers(username,pass) values ('" + name + "','" + password + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Register is Succesd!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
