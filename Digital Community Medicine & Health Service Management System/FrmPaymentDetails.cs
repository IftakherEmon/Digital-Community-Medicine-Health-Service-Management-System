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

namespace Digital_Community_Medicine___Health_Service_Management_System
{
    public partial class FrmPaymentDetails : Form
    {
        int paymentId;
        string connectionString = "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        public FrmPaymentDetails(int pid)
        {
            InitializeComponent();
            paymentId = pid;
        }

        private void FrmPaymentDetails_Leave(object sender, EventArgs e)
        {

        }

        private void FrmPaymentDetails_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Amount, Method, TransactionId FROM Payment WHERE PaymentId = @PaymentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PaymentId", paymentId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblAmount.Text = "Amount: " + reader["Amount"].ToString();
                    lblMethod.Text = "Method: " + reader["Method"].ToString();
                    lblTransaction.Text = "Transaction ID: " + reader["TransactionId"].ToString();
                }
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (Session.AdminId <= 0)
            {
                MessageBox.Show("Admin session invalid. Please login again.",
                                "Session Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query =
                    "UPDATE Payment SET " +
                    "PaymentStatus = 'Completed', " +
                    "VerifiedByAdminId = @AdminId, " +
                    "PaidAt = GETDATE() " +
                    "WHERE PaymentId = @PaymentId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AdminId", Session.AdminId);
                cmd.Parameters.AddWithValue("@PaymentId", paymentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Payment verified successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            new FrmPaymentList().Show();
            this.Hide();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Payment SET PaymentStatus='Failed' WHERE PaymentId=@PaymentId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PaymentId", paymentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Payment rejected!");
            new FrmPaymentList().Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmPaymentList().Show();
            this.Hide();
        }
    }
}
