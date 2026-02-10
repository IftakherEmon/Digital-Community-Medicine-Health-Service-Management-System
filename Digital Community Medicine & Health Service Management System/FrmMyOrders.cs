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
    public partial class FrmMyOrders : Form
    {
        public FrmMyOrders()
        {
            InitializeComponent();
        }

        private void FrmMyOrders_Load(object sender, EventArgs e)
        {
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

            dataGridViewOrders.AllowUserToAddRows = false;
            LoadMyOrders();
        }
        private void LoadMyOrders()
        {
            string connectionString =
                "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";

            string query =
                "SELECT " +
                "mo.OrderId, " +
                "ph.PharmacyName, " +
                "mo.TotalAmount, " +
                "mo.Status, " +
                "mo.OrderedAt AS OrderDate, " +
                "mo.DeliveredAt " +
                "FROM MedicineOrder mo " +
                "JOIN Pharmacy ph ON mo.PharmacyId = ph.PharmacyId " +
                "WHERE mo.PatientId = @PatientId " +
                "ORDER BY mo.OrderedAt DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", Session.PatientId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewOrders.DataSource = dt;
            }

            // UI polish
            dataGridViewOrders.Columns["OrderId"].Visible = false;
            dataGridViewOrders.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmPatientDashboard().Show();
        }
    }
}
