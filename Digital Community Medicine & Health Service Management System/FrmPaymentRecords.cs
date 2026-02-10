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
    public partial class FrmPaymentRecords : Form
    {
        public FrmPaymentRecords()
        {
            InitializeComponent();
        }

        private void FrmPaymentRecords_Load(object sender, EventArgs e)
        {
            // 🔐 Session check
            if (Session.PatientId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                this.Hide();
                new FrmLogin().Show();
                return;
            }

            LoadPaymentRecords();
        }
        private void LoadPaymentRecords()
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT " +
                "ISNULL(p.PaidAt, p.CreatedAt) AS PaymentDate, " +
                "p.Amount, " +
                "p.Method AS PaymentMethod, " +
                "p.PaymentStatus, " +
                "CASE " +
                "   WHEN p.AppointmentId IS NOT NULL THEN 'Appointment' " +
                "   ELSE 'Medicine Order' " +
                "END AS PaymentType, " +
                "ISNULL(p.AppointmentId, p.OrderId) AS ReferenceId " +
                "FROM Payment p " +
                "LEFT JOIN Appointment a ON p.AppointmentId = a.AppointmentId " +
                "LEFT JOIN MedicineOrder mo ON p.OrderId = mo.OrderId " +
                "WHERE (a.PatientId = @PatientId OR mo.PatientId = @PatientId) " +
                "ORDER BY ISNULL(p.PaidAt, p.CreatedAt) DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", Session.PatientId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewPayments.Columns.Clear();
                dataGridViewPayments.DataSource = dt;
            }

            dataGridViewPayments.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
