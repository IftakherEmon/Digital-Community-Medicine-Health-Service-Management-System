using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmRevenueReport : Form
    {
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";


        public FrmRevenueReport()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmSystemReport().Show();
            this.Hide();
        }

        private void FrmRevenueReport_Load(object sender, EventArgs e)
        {
            LoadRevenue();
        }
        private void LoadRevenue()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query =
                    "SELECT " +
                    "PaymentId, " +
                    "Amount, " +
                    "Method, " +
                    "PaidAt " +
                    "FROM Payment " +
                    "WHERE PaymentStatus = 'Completed' " +
                    "ORDER BY PaidAt DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRevenue.DataSource = dt;
            }
        }

    }
}
