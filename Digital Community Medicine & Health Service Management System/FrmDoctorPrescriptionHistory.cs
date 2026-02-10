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
    public partial class FrmDoctorPrescriptionHistory : Form
    {
        string connectionString =
    "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        private int selectedPrescriptionId = 0;
        public FrmDoctorPrescriptionHistory()
        {
            InitializeComponent();
        }

        private void FrmDoctorPrescriptionHistory_Load(object sender, EventArgs e)
        {
            LoadPrescriptionHistory();
            dgvPrescriptionHistory.AllowUserToAddRows = false;
            dgvPrescriptionHistory.ReadOnly = true;
        }
        private void LoadPrescriptionHistory()
        {
            string query =
                @"SELECT 
                    pr.PrescriptionId,
                    p.FullName AS PatientName,
                    aps.SlotDateTime AS AppointmentDate,
                    pr.Diagnosis,
                    pr.Symptoms,
                    pr.CreatedAt
                  FROM Prescription pr
                  JOIN Appointment a ON pr.AppointmentId = a.AppointmentId
                  JOIN Patient p ON a.PatientId = p.PatientId
                  JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId
                  JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId
                  WHERE dc.DoctorId = @DoctorId
                  ORDER BY pr.CreatedAt DESC";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPrescriptionHistory.DataSource = dt;

                dgvPrescriptionHistory.Columns["PrescriptionId"].Visible = false;
                dgvPrescriptionHistory.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvPrescriptionHistory.ClearSelection();
            }
        }

        private void dgvPrescriptionHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            object value =
                dgvPrescriptionHistory.Rows[e.RowIndex]
                .Cells["PrescriptionId"].Value;

            if (value == null || value == DBNull.Value)
            {
                selectedPrescriptionId = 0;
                return;
            }

            selectedPrescriptionId = Convert.ToInt32(value);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (selectedPrescriptionId == 0)
            {
                MessageBox.Show("Please select a prescription first.",
                                "Selection Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string q =
                @"SELECT 
                    m.MedicineName,
                    pm.Dosage,
                    pm.Frequency,
                    pm.DurationDays,
                    pm.Instructions
                  FROM PrescriptionMedicine pm
                  JOIN Medicine m ON pm.MedicineId = m.MedicineId
                  WHERE pm.PrescriptionId = @PrescriptionId";

            StringBuilder details = new StringBuilder();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, con))
            {
                cmd.Parameters.AddWithValue("@PrescriptionId", selectedPrescriptionId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    details.AppendLine(
                        $"• {dr["MedicineName"]}\n" +
                        $"  Dosage: {dr["Dosage"]}\n" +
                        $"  Frequency: {dr["Frequency"]}\n" +
                        $"  Duration: {dr["DurationDays"]} days\n" +
                        $"  Instruction: {dr["Instructions"]}\n");
                }
            }

            MessageBox.Show(details.ToString(),
                            "Prescription Medicine Details",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPrescriptionHistory();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorDashboard().Show();
        }
    }
}
