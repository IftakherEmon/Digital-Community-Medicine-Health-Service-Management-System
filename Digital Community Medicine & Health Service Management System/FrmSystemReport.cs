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
    public partial class FrmSystemReport : Form
    {
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmSystemReport()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmAdminDashboard().Show();
            this.Hide();
        }

        private void FrmSystemReport_Load(object sender, EventArgs e)
        {
            LoadSystemReport();
        }
        private void LoadSystemReport()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Total Users
                SqlCommand cmdUsers = new SqlCommand("SELECT COUNT(*) FROM Users", con);
                int totalUsers = Convert.ToInt32(cmdUsers.ExecuteScalar());
                lblTotalUsers.Text = "Total Users: " + totalUsers;

                // Total Orders
                SqlCommand cmdOrders = new SqlCommand("SELECT COUNT(*) FROM MedicineOrder", con);
                int totalOrders = Convert.ToInt32(cmdOrders.ExecuteScalar());
                lblTotalOrders.Text = "Total Orders: " + totalOrders;

                // Total Revenue (only completed payments)
                SqlCommand cmdRevenue = new SqlCommand("SELECT ISNULL(SUM(Amount),0) FROM Payment WHERE PaymentStatus='Completed'", con);
                decimal totalRevenue = Convert.ToDecimal(cmdRevenue.ExecuteScalar());
                lblTotalRevenue.Text = "Total Revenue: " + totalRevenue + " BDT";
            }
        }


    }
}
