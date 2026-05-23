using Microsoft.Reporting.WinForms;
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
    public partial class Marchreport : Form
    {
        public Marchreport()
        {
            InitializeComponent();
        }

        private void Marchreport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        SqlConnection connection = new SqlConnection("data source= .\\SQLEXPRESS; database=myProject; integrated security=True");

        private void button1_Click(object sender, EventArgs e)
        {
        
            string filterMonth = "March"; // You can get this from a dropdown or textbox

            SqlCommand command = new SqlCommand("SELECT * FROM issues", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Filter records that contain "June" in issue_date
            DataView view = new DataView(dt);
            view.RowFilter = $"book_issue_date LIKE '%{filterMonth}%'";

            
            // Load into ReportViewer
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", view.ToTable()); // Change "DataSet1" to your RDLC dataset name
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            reportViewer1.RefreshReport();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
