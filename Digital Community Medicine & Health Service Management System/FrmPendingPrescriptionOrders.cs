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
    public partial class FrmPendingPrescriptionOrders : Form
    {
        private readonly string cs =
    @"data source=DESKTOP-AL7RNAT\SQLEXPRESS;
              database=DigitalHealthCareDB;
              integrated security=SSPI";
        public FrmPendingPrescriptionOrders()
        {
            InitializeComponent();
        }

        private void FrmPendingPrescriptionOrders_Load(object sender, EventArgs e)
        {
            if (Session.PharmacistId <= 0)
            {
                MessageBox.Show("Session expired. Please login again.");
                new FrmLogin().Show();
                this.Hide();
                return;
            }

            LoadPendingPrescriptions();
        }
        private void LoadPendingPrescriptions()
        {
            string query =
            @"SELECT 
                mo.OrderId,
                pr.PrescriptionId,
                u.Email AS PatientEmail,
                mo.OrderedAt
              FROM MedicineOrder mo
              INNER JOIN OrderPrescription op ON mo.OrderId = op.OrderId
              INNER JOIN Prescription pr ON op.PrescriptionId = pr.PrescriptionId
              INNER JOIN Patient p ON mo.PatientId = p.PatientId
              INNER JOIN Users u ON p.UserId = u.UserId
              WHERE op.VerificationStatus = 'Pending'
              ORDER BY mo.OrderedAt DESC";

            using (SqlConnection con = new SqlConnection(cs))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPendingOrders.DataSource = dt;
            }

            FormatGrid();
        }
        private void FormatGrid()
        {
            dgvPendingOrders.ClearSelection();
            dgvPendingOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendingOrders.MultiSelect = false;
            dgvPendingOrders.ReadOnly = true;
            dgvPendingOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPendingOrders.Columns["OrderId"].HeaderText = "Order ID";
            dgvPendingOrders.Columns["PrescriptionId"].HeaderText = "Prescription ID";
            dgvPendingOrders.Columns["PatientEmail"].HeaderText = "Patient Email";
            dgvPendingOrders.Columns["OrderedAt"].HeaderText = "Order Date";
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (dgvPendingOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a prescription to verify.");
                return;
            }

            int orderId = Convert.ToInt32(
                dgvPendingOrders.SelectedRows[0].Cells["OrderId"].Value);

            int prescriptionId = Convert.ToInt32(
                dgvPendingOrders.SelectedRows[0].Cells["PrescriptionId"].Value);

            new FrmPrescriptionVerification(prescriptionId, orderId).Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmPharmacyDashboard().Show();
            this.Hide();
        }
    }
}
