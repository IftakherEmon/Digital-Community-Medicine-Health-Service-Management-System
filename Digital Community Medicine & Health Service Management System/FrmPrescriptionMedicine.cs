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
    public partial class FrmPrescriptionMedicine : Form
    {
        string connectionString =
           "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        private int prescriptionId;
        public FrmPrescriptionMedicine(int prescriptionId)
        {
            InitializeComponent();
            this.prescriptionId = prescriptionId;
        }

        private void FrmPrescriptionMedicine_Load(object sender, EventArgs e)
        {
            lblPrescriptionId.Text = "Prescription ID: " + prescriptionId;
            LoadMedicines();
            InitializeGrid();
        }
        private void LoadMedicines()
        {
            string q =
                "SELECT MedicineId, MedicineName FROM Medicine WHERE IsActive = 1 ORDER BY MedicineName";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMedicine.DisplayMember = "MedicineName";
                cmbMedicine.ValueMember = "MedicineId";
                cmbMedicine.DataSource = dt;
                cmbMedicine.SelectedIndex = -1;
            }
        }
        private void InitializeGrid()
        {
            dgvPrescriptionMedicine.Columns.Clear();

            dgvPrescriptionMedicine.Columns.Add("MedicineId", "MedicineId");
            dgvPrescriptionMedicine.Columns.Add("MedicineName", "Medicine Name");
            dgvPrescriptionMedicine.Columns.Add("Dosage", "Dosage");
            dgvPrescriptionMedicine.Columns.Add("Frequency", "Frequency");
            dgvPrescriptionMedicine.Columns.Add("DurationDays", "Duration (Days)");
            dgvPrescriptionMedicine.Columns.Add("Instructions", "Instructions");

            dgvPrescriptionMedicine.Columns["MedicineId"].Visible = false;
            dgvPrescriptionMedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            if (cmbMedicine.SelectedIndex == -1 ||
    string.IsNullOrWhiteSpace(txtDosage.Text) ||
    numDurationDays.Value <= 0)
            {
                MessageBox.Show("Please select medicine, dosage and duration.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            dgvPrescriptionMedicine.Rows.Add(
                cmbMedicine.SelectedValue,
                cmbMedicine.Text,
                txtDosage.Text.Trim(),
                txtFrequency.Text.Trim(),
                numDurationDays.Value,
                txtInstructions.Text.Trim()
            );

            ClearInputs();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionMedicine.SelectedRows.Count > 0)
            {
                dgvPrescriptionMedicine.Rows.RemoveAt(
                    dgvPrescriptionMedicine.SelectedRows[0].Index);
            }
        }

        private void btnSaveFinish_Click(object sender, EventArgs e)
        {
            if (dgvPrescriptionMedicine.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one medicine.",
                                "No Medicine Added",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string q =
                @"INSERT INTO PrescriptionMedicine
                  (PrescriptionId, MedicineId, Dosage, Frequency, DurationDays, Instructions)
                  VALUES
                  (@PrescriptionId, @MedicineId, @Dosage, @Frequency, @DurationDays, @Instructions)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (DataGridViewRow row in dgvPrescriptionMedicine.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        cmd.Parameters.AddWithValue("@PrescriptionId", prescriptionId);
                        cmd.Parameters.AddWithValue("@MedicineId", row.Cells["MedicineId"].Value);
                        cmd.Parameters.AddWithValue("@Dosage", row.Cells["Dosage"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Frequency", row.Cells["Frequency"].Value.ToString());
                        cmd.Parameters.AddWithValue("@DurationDays", row.Cells["DurationDays"].Value);
                        cmd.Parameters.AddWithValue("@Instructions", row.Cells["Instructions"].Value.ToString());

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Prescription medicines saved successfully.",
                            "Completed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            this.Hide();
            new FrmDoctorDashboard().Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmCreatePrescription(0).Show();
        }
        private void ClearInputs()
        {
            cmbMedicine.SelectedIndex = -1;
            txtDosage.Clear();
            txtFrequency.Clear();
            numDurationDays.Value = 1;
            txtInstructions.Clear();
        }
    }
}
