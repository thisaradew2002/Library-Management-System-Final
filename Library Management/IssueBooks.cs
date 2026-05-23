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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = .\\SQLEXPRESS; database = myProject;integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from books", con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    comboBoxBooks.Items.Add(Sdr.GetSqlString(i));
                }
            }
            Sdr.Close();
            con.Close();
            {

            }
        }
        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEnrolment.Text != "")
            {
                String eid = txtEnrolment.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = .\\SQLEXPRESS; database = myProject;integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from students where enroll='" + eid + "' ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);



                //----------------------------------------------------------------------
                //Code to Count how many book has been issued on this enrollment number
                cmd.CommandText = "select count (std_enroll) from issues where std_enroll='" + eid + "' and book_return_date is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());

                //--------------------------------------------------------------------

                if (DS.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = DS.Tables[0].Rows[0][1].ToString();
                    txtNic.Text = DS.Tables[0].Rows[0][3].ToString();
                    txtContact.Text = DS.Tables[0].Rows[0][4].ToString();
                    txtemail.Text = DS.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    txtName.Clear();
                    txtNic.Clear();
                    txtContact.Clear();
                    txtemail.Clear();
                    MessageBox.Show("Invalid Enrollment NO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtName.Text !="")
            {
                if (comboBoxBooks.SelectedIndex != -1 && count<=2)
                {
                    String enroll = txtEnrolment.Text;
                    String sname = txtName.Text;
                    String nic = txtNic.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    String email = txtemail.Text;
                    String bookname = comboBoxBooks.Text;
                    String bookIssueDate = dateTimePicker.Text;

                    String eid = txtEnrolment.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = .\\SQLEXPRESS; database = myProject;integrated security = True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into issues (std_enroll, std_name, std_nic, std_contact, std_email, book_name, book_issue_date) values ('" + enroll + "', '" + sname + "', '" + nic + "', " + contact + ", '" + email + "', '" + bookname + "', '" + bookIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select Book. OR Maximum number of book has been ISSUED", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            else
            {
                MessageBox.Show("Enter Valid Enrollment NO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtEnrolment_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrolment.Text == "")
            {
                txtName.Clear();
                txtNic.Clear();
                txtContact.Clear();
                txtemail.Clear();
               
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrolment.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void comboBoxBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
