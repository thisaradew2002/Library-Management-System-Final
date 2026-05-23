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
using System.Configuration;

namespace Library_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnx_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtusername.Text == "Username")
            {
                txtusername.Clear();
            }
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtpassword.Text == "Password")
            {
                txtpassword.Clear();
                txtpassword.PasswordChar = '*';
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = .\\SQLEXPRESS; database = myProject; integrated security = True";

            // Check for admin
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from users where username = '" + txtusername.Text + "' and pass = '" + txtpassword.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                // Admin login
                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();
            }
            else
            {
                // Check for user in "registers" table (note: you wrote 'registres', fix spelling)
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = con;
                cmd1.CommandText = "select * from registers where username = '" + txtusername.Text + "' and pass = '" + txtpassword.Text + "'";

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1); // FIXED: now using cmd1
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                if (ds1.Tables[0].Rows.Count != 0)
                {
                    // User login
                    this.Hide();
                    userissue ui = new userissue();
                    ui.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username OR Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            RegisterForm rf = new RegisterForm();
            rf.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtpassword.PasswordChar = '\0'; //show password
            }
            else
            {
                txtpassword.PasswordChar = '*'; //hide password
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
