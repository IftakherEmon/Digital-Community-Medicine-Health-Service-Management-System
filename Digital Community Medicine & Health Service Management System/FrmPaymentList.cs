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
    public partial class FrmPaymentList : Form
    {
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

        public FrmPaymentList()
        {
            InitializeComponent();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count > 0)
            {
                int paymentId = Convert.ToInt32(dgvPayments.SelectedRows[0].Cells["PaymentId"].Value);

                FrmPaymentDetails details = new FrmPaymentDetails(paymentId);
                details.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a payment first.");
            }


        }

        private void FrmPaymentList_Load(object sender, EventArgs e)
        {
            cmbFilter.Items.Add("All");
            cmbFilter.Items.Add("Appointment");
            cmbFilter.Items.Add("Order");
            cmbFilter.SelectedIndex = 0;

            LoadPayments();
        }
        private void LoadPayments()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PaymentId, AppointmentId, OrderId, Amount, Method, PaymentStatus " +
                               "FROM Payment WHERE PaymentStatus = 'Pending'";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPayments.DataSource = dt;
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "";

                if (cmbFilter.Text == "Appointment")
                {
                    query = "SELECT * FROM Payment WHERE AppointmentId IS NOT NULL AND PaymentStatus='Pending'";
                }
                else if (cmbFilter.Text == "Order")
                {
                    query = "SELECT * FROM Payment WHERE OrderId IS NOT NULL AND PaymentStatus='Pending'";
                }
                else
                {
                    query = "SELECT * FROM Payment WHERE PaymentStatus='Pending'";
                }

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPayments.DataSource = dt;
            }


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmAdminDashboard ad = new FrmAdminDashboard();
            ad.Show();
            this.Hide();
        }
    }
}
