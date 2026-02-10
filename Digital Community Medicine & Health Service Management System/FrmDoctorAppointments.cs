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
    public partial class FrmDoctorAppointments : Form
    {
        string connectionString =
    "data source=DESKTOP-AL7RNAT\\SQLEXPRESS; database=DigitalHealthCareDB; integrated security=SSPI";
        private int selectedAppointmentId = 0;
        private string selectedPrescriptionStatus = string.Empty;
        private string selectedAppointmentStatus = string.Empty;
        public FrmDoctorAppointments()
        {
            InitializeComponent();
        }

        private void FrmDoctorAppointments_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }
        private void LoadAppointments()
        {
            string query =
                @"SELECT 
                    a.AppointmentId,
                    p.FullName AS PatientName,
                    aps.SlotDateTime,
                    a.Status AS AppointmentStatus,
                    CASE 
                        WHEN pr.PrescriptionId IS NULL THEN 'No'
                        ELSE 'Yes'
                    END AS PrescriptionGiven
                  FROM Appointment a
                  JOIN AppointmentSlot aps ON a.SlotId = aps.SlotId
                  JOIN DoctorClinic dc ON aps.DoctorClinicId = dc.DoctorClinicId
                  JOIN Patient p ON a.PatientId = p.PatientId
                  LEFT JOIN Prescription pr ON a.AppointmentId = pr.AppointmentId
                  WHERE dc.DoctorId = @DoctorId
                  ORDER BY aps.SlotDateTime DESC";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@DoctorId", Session.DoctorId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAppointments.DataSource = dt;

                // UI Tweaks
                dgvAppointments.Columns["AppointmentId"].Visible = false;
                dgvAppointments.Columns["PatientName"].HeaderText = "Patient Name";
                dgvAppointments.Columns["SlotDateTime"].HeaderText = "Date & Time";
                dgvAppointments.Columns["AppointmentStatus"].HeaderText = "Status";
                dgvAppointments.Columns["PrescriptionGiven"].HeaderText = "Prescription Given";

                dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAppointments.ClearSelection();
            }
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAppointments.Rows[e.RowIndex];

                selectedAppointmentId = Convert.ToInt32(row.Cells["AppointmentId"].Value);
                selectedPrescriptionStatus = row.Cells["PrescriptionGiven"].Value.ToString();
                selectedAppointmentStatus = row.Cells["AppointmentStatus"].Value.ToString();
            }
        }

        private void btnCreatePrescription_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentId == 0)
            {
                MessageBox.Show("Please select an appointment first.",
                                "Selection Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (selectedAppointmentStatus != "Completed")
            {
                MessageBox.Show("Prescription can only be created for completed appointments.",
                                "Invalid Action",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (selectedPrescriptionStatus == "Yes")
            {
                MessageBox.Show("Prescription already exists for this appointment.",
                                "Duplicate Prescription",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // 🔥 PASS APPOINTMENT ID
            FrmCreatePrescription frm = new FrmCreatePrescription(selectedAppointmentId);
            frm.Show();
            this.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmDoctorDashboard().Show();
        }

        private void btnCompleteAppointment_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentId == 0)
            {
                MessageBox.Show("Please select an appointment first.",
                                "Selection Required",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (selectedAppointmentStatus == "Completed")
            {
                MessageBox.Show("This appointment is already completed.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query =
                    "UPDATE Appointment SET Status = 'Completed' WHERE AppointmentId = @AppointmentId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentId", selectedAppointmentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Appointment marked as completed successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            LoadAppointments();
        }
    }
}
